using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	public abstract class BaseDesignAnalyzer : DiagnosticAnalyzer
	{
		internal DiagnosticIds DiagnosticId { get; }
		internal BaseDesignAnalyzer(DiagnosticIds diagnosticId)
		{
			DiagnosticId = diagnosticId;
			Rule = new DiagnosticDescriptor(Helper.ToDiagnosticId(diagnosticId),
																Title,
																MessageFormat,
																nameof(Categories.Design),
																DiagnosticSeverity.Warning,
																isEnabledByDefault: true,
																description: Description);
		}

		private static readonly LocalizableString Title =
			new LocalizableResourceString(nameof(Resources.Title), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString MessageFormat =
			new LocalizableResourceString(nameof(Resources.MessageFormat), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString Description =
			new LocalizableResourceString(nameof(Resources.Description), Resources.ResourceManager, typeof(Resources));

		private DiagnosticDescriptor Rule;
		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

		public override void Initialize(AnalysisContext context)
		{
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
			context.EnableConcurrentExecution();
			context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.InvocationExpression);
			context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.SimpleMemberAccessExpression);
		}

		private void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
		{
			Analyze(context, Rule);
		}

		protected static void Analyze(SyntaxNodeAnalysisContext context, DiagnosticDescriptor rule)
		{
			MemberAccessExpressionSyntax memberAccessExpr;

			switch (context.Node)
			{
				case InvocationExpressionSyntax ies:
					memberAccessExpr = ies.Expression as MemberAccessExpressionSyntax;
					break;
				case MemberAccessExpressionSyntax maes:
					if (maes.Parent is MemberAccessExpressionSyntax || maes.Parent is InvocationExpressionSyntax)
					{
						memberAccessExpr = null;
					}
					else
					{
						memberAccessExpr = maes;
					}
					break;
				default:
					memberAccessExpr = null;
					break;
			}

			if (memberAccessExpr == null)
			{
				return;
			}

			var memberSymbol = context.SemanticModel.GetSymbolInfo(memberAccessExpr).Symbol;

			if (memberSymbol == null)
			{
				return;
			}

			var id = Helper.FromDiagnosticId(rule.Id);
			var staticClass = Constants.Analyzers[id].StaticClass;
			if (!memberSymbol.ToString().StartsWith(staticClass))
			{
				return;
			}

			var baseClass = Constants.Analyzers[id].BaseClass;
			var diagnostic = Diagnostic.Create(rule, memberAccessExpr.GetLocation(), staticClass, baseClass);
			context.ReportDiagnostic(diagnostic);
		}
	}
}
