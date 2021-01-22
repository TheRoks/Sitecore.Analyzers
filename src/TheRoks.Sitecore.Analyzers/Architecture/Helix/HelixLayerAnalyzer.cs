using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Architecture.Helix
{
	public abstract class HelixLayerAnalyzer : DiagnosticAnalyzer
	{
		internal DiagnosticIds DiagnosticId { get; }

		protected DiagnosticDescriptor Rule;

		private static readonly LocalizableString Title =
			new LocalizableResourceString(nameof(Resources.Title), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString MessageFormat =
			new LocalizableResourceString(nameof(Resources.MessageFormat), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString Description =
			new LocalizableResourceString(nameof(Resources.Description), Resources.ResourceManager, typeof(Resources));

		internal HelixLayerAnalyzer(DiagnosticIds diagnosticId, string baseNamespace, string parentNamespace)
		{
			DiagnosticId = diagnosticId;
			Rule = new DiagnosticDescriptor(Helper.ToDiagnosticId(diagnosticId),
																Title,
																MessageFormat,
																nameof(Categories.Design),
																DiagnosticSeverity.Warning,
																isEnabledByDefault: true,
																description: Description);

			BaseNamespace = baseNamespace;
			ParentNamespace = parentNamespace;
		}

		public override void Initialize(AnalysisContext context)
		{
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
			context.EnableConcurrentExecution();
			context.RegisterSyntaxNodeAction(UsingDirectiveAction, SyntaxKind.UsingDirective);
			context.RegisterSyntaxNodeAction(ClassDeclarationExpressionAction, SyntaxKind.ClassDeclaration);
		}

		public static IEnumerable<(SyntaxNode, T)> GetAllSymbols<T>(CSharpCompilation compilation, SyntaxNode root) where T : ISymbol
		{
			if (compilation != null && root != null && root.SyntaxTree != null)
			{
				var noDuplicates = new HashSet<Location>();
				var model = compilation.GetSemanticModel(root.SyntaxTree);

				if (model != null)
				{
					foreach (var node in root.DescendantNodesAndSelf())
					{
						if (node == null)
						{
							continue;
						}

						switch (node.Kind())
						{
							case SyntaxKind.ObjectCreationExpression:
								var objectCreationDeclartionSyntax = node as ObjectCreationExpressionSyntax;
								if (noDuplicates.Add(objectCreationDeclartionSyntax.GetLocation()))
								{
									var objectSymbol = model.GetSymbolInfo(node).Symbol;
									if (objectSymbol != null && objectSymbol is T)
									{
										if (noDuplicates.Add(node.GetLocation()))
										{
											yield return (objectCreationDeclartionSyntax, (T)objectSymbol);
										}
									}
								}
								break;
							case SyntaxKind.MethodDeclaration:
								var methodDeclarationSyntax = node as MethodDeclarationSyntax;
								if (methodDeclarationSyntax.ReturnType != null && model.GetTypeInfo(methodDeclarationSyntax.ReturnType) is TypeInfo returntypeInfo)
								{
									if (noDuplicates.Add(methodDeclarationSyntax.ReturnType.GetLocation()))
									{
										yield return (methodDeclarationSyntax.ReturnType, (T)returntypeInfo.Type);
									}
								}
								break;
							case SyntaxKind.Parameter:
								var parameterSyntax = node as ParameterSyntax;
								if (parameterSyntax.Type != null && model.GetTypeInfo(parameterSyntax.Type) is TypeInfo parametertypeInfo)
								{
									if (noDuplicates.Add(parameterSyntax.Type.GetLocation()))
									{
										yield return (parameterSyntax.Type, (T)parametertypeInfo.Type);
									}
								}
								break;
							default:
								var symbol = model.GetSymbolInfo(node).Symbol;
								if (symbol != null && symbol is T t)
								{
									if (noDuplicates.Add(node.GetLocation()))
									{
										yield return (node, t);
									}
								}
								break;
						}
					}
				}
			}
		}

		private void ClassDeclarationExpressionAction(SyntaxNodeAnalysisContext context)
		{
			if (!(context.Node is ClassDeclarationSyntax classDeclarationStatement))
			{
				return;
			}

			var allSymbols = GetAllSymbols<ISymbol>(context.Compilation as CSharpCompilation, classDeclarationStatement);

			foreach (var symbol in allSymbols)
			{
				ValidateLayerUsage(context, symbol.Item1 as CSharpSyntaxNode, symbol.Item2.ToString());
			}
		}

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
		{
			get { return ImmutableArray.Create(Rule); }
		}

		private readonly string BaseNamespace;
		private readonly string ParentNamespace;

		protected void UsingDirectiveAction(SyntaxNodeAnalysisContext context)
		{
			var usingDirectiveSyntax = (UsingDirectiveSyntax)context.Node;
			if (usingDirectiveSyntax?.Name == null)
			{
				return;
			}

			ValidateLayerUsage(context, usingDirectiveSyntax, usingDirectiveSyntax.Name.ToString());
		}

		private static string CurrentNamespace(SyntaxNodeAnalysisContext context)
		{
			var root = context.SemanticModel.SyntaxTree.GetRoot();
			if (root == null)
			{
				return string.Empty;
			}
			var childNode = root.ChildNodes().FirstOrDefault(x => x is NamespaceDeclarationSyntax) as NamespaceDeclarationSyntax;
			if (childNode == null)
			{
				return string.Empty;
			}

			var currentClassNamespace = childNode.Name.ToString();
			var currentHelixLayer = GetHelixLayer(currentClassNamespace);
			return currentHelixLayer;
		}

		protected void ValidateLayerUsage(SyntaxNodeAnalysisContext context, CSharpSyntaxNode expressionSyntax, string referenceNamespace)
		{
			var currentHelixLayer = CurrentNamespace(context);
			if (string.Equals(currentHelixLayer, BaseNamespace, System.StringComparison.OrdinalIgnoreCase))
			{
				var referencedHelixLayer = GetHelixLayer(referenceNamespace);
				if (string.Equals(referencedHelixLayer, ParentNamespace, System.StringComparison.OrdinalIgnoreCase))
				{
					ReportDiagnostic(context, expressionSyntax, ParentNamespace);
				}
			}
		}

		private void ReportDiagnostic(SyntaxNodeAnalysisContext context,
			CSharpSyntaxNode syntaxNode, string targetLayer)
		{
			var diagnostic = Diagnostic.Create(Rule, syntaxNode.GetLocation(), targetLayer);
			context.ReportDiagnostic(diagnostic);
		}

		public static string GetHelixLayer(string name)
		{
			var layer = string.Empty;
			if (!string.IsNullOrEmpty(name))
			{
				var namespaceParts = name.Split('.');
				if (namespaceParts != null && namespaceParts.Length >= 2)
				{
					layer = LayerCheck(namespaceParts[1]);
					if (string.IsNullOrEmpty(layer))
					{
						layer = LayerCheck(namespaceParts[0]);
					}
				}
				
				if (string.IsNullOrEmpty(layer))
				{
					layer = LayerCheck(name);
				}
			}

			return layer;

			string LayerCheck(string layername)
			{
				if (string.IsNullOrEmpty(layername))
				{
					return string.Empty;
				}
				else if (layername.Contains("Foundation"))
				{
					return "Foundation";
				}
				else if (layername.Contains("Feature"))
				{
					return "Feature";
				}
				else if (layername.Contains("Project"))
				{
					return "Project";
				}
				else
				{
					return string.Empty;
				}
			}
		}

		public string GetHelixModule(string name)
		{
			var matches = Compile().Matches(name);
			if (matches != null && matches.Count > 0)
			{
				return matches[0].Groups[2].Value;
			}
			return string.Empty;
		}

		private Regex Compile()
		{
			var pattern = @".(Foundation|Feature|Project).(\w*)";
			return new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}
	}
}
