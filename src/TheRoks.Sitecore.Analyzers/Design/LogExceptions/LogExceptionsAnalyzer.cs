using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.LogExceptions
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class LogExceptionsAnalyzer : DiagnosticAnalyzer
	{
		private static readonly LocalizableString NoCatchBlockTitle =
			new LocalizableResourceString(nameof(Resources.NoCatchBlockTitle), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString NoCatchBlockMessageFormat =
			new LocalizableResourceString(nameof(Resources.NoCatchBlockMessageFormat), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString NoCatchBlockDescription =
			new LocalizableResourceString(nameof(Resources.NoCatchBlockDescription), Resources.ResourceManager, typeof(Resources));

		private static readonly DiagnosticDescriptor NoCatchBlockRule = new DiagnosticDescriptor(Helper.ToDiagnosticId(DiagnosticIds.NoCatchBlock),
																			 NoCatchBlockTitle,
																			 NoCatchBlockMessageFormat,
																			 nameof(Categories.Performance),
																			 DiagnosticSeverity.Warning,
																			 isEnabledByDefault: true,
																			 description: NoCatchBlockDescription);

		private static readonly LocalizableString NoErrorLogTitle =
			new LocalizableResourceString(nameof(Resources.NoErrorLogTitle), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString NoErrorLogMessageFormat =
			new LocalizableResourceString(nameof(Resources.NoErrorLogMessageFormat), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString NoErrorLogDescription =
			new LocalizableResourceString(nameof(Resources.NoErrorLogDescription), Resources.ResourceManager, typeof(Resources));
		private static readonly DiagnosticDescriptor NoRuleError = new DiagnosticDescriptor(Helper.ToDiagnosticId(DiagnosticIds.NoLogError),
																					 NoErrorLogTitle,
																					 NoErrorLogMessageFormat,
																					 nameof(Categories.Performance),
																					 DiagnosticSeverity.Warning,
																					 isEnabledByDefault: true,
																					 description: NoErrorLogDescription);

		private static readonly LocalizableString NoExceptionOnErrorLogTitle =
			new LocalizableResourceString(nameof(Resources.NoExceptionOnErrorLogTitle), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString NoExceptionOnErrorLogMessageFormat =
			new LocalizableResourceString(nameof(Resources.NoExceptionOnErrorLogMessageFormat), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString NoExceptionOnErrorLogDescription =
			new LocalizableResourceString(nameof(Resources.NoExceptionOnErrorLogDescription), Resources.ResourceManager, typeof(Resources));
		private static readonly DiagnosticDescriptor NoRuleExceptionOnError = new DiagnosticDescriptor(Helper.ToDiagnosticId(DiagnosticIds.NoLogExceptionsOnError),
																					 NoExceptionOnErrorLogTitle,
																					 NoExceptionOnErrorLogMessageFormat,
																					 nameof(Categories.Performance),
																					 DiagnosticSeverity.Warning,
																					 isEnabledByDefault: true,
																					 description: NoExceptionOnErrorLogDescription);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics 
		{ 
			get 
			{ 
				return ImmutableArray.Create(NoCatchBlockRule, NoRuleExceptionOnError, NoRuleError); 
			} 
		}

		public override void Initialize(AnalysisContext context)
		{
			context.EnableConcurrentExecution();
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
			context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.CatchClause);
		}

		private void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
		{
			var catchClause = context.Node as CatchClauseSyntax;
			if (catchClause == null)
			{
				return;
			}

			if (catchClause.Declaration == null)
			{
				context.ReportDiagnostic(Diagnostic.Create(NoCatchBlockRule, catchClause.CatchKeyword.GetLocation()));
				return;
			}

			var allSymbols = GetAllSymbols<IMethodSymbol>(context.Compilation as CSharpCompilation, catchClause);
			var logMethods = allSymbols.Where(x => x.Item2.OriginalDefinition.ToString().Contains("Sitecore.Diagnostics.Log.Error")
										|| x.Item2.OriginalDefinition.ToString().Contains("Sitecore.Abstractions.BaseLog.Error"));

			if (!logMethods.Any())
			{
				var noLog = Diagnostic.Create(NoRuleError, catchClause.GetLocation());
				context.ReportDiagnostic(noLog);
			}
			else if (logMethods.Any(x => !x.Item2.Parameters.Any(y => y.Type.ToString() == "System.Exception")))
			{
				foreach (var logMethod in logMethods)
				{
					if (!logMethod.Item2.Parameters.Any(y => y.Type.ToString() == "System.Exception"))
					{
						var noLog = Diagnostic.Create(NoRuleExceptionOnError, logMethod.Item1.GetLocation());
						context.ReportDiagnostic(noLog);
					}
				}			
			}
		}

		public static IEnumerable<(SyntaxNode,T)> GetAllSymbols<T>(CSharpCompilation compilation, SyntaxNode root) where T : ISymbol
		{
			var noDuplicates = new HashSet<ISymbol>();

			var model = compilation.GetSemanticModel(root.SyntaxTree);

			foreach (var node in root.DescendantNodesAndSelf())
			{
				switch (node.Kind())
				{
					case SyntaxKind.ExpressionStatement:
					case SyntaxKind.InvocationExpression:
						break;
					default:
						var symbol = model.GetSymbolInfo(node).Symbol;
						if (symbol != null && symbol is T)
						{
							if (noDuplicates.Add(symbol))
								yield return (node, (T)symbol);
						}
						break;
				}
			}
		}
	}
}
