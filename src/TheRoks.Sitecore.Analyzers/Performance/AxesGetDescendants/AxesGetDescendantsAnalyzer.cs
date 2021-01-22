using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Performance.AxesGetDescendants
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AxesGetDescendantsAnalyzer : DiagnosticAnalyzer
	{
		private static readonly LocalizableString Title =
			new LocalizableResourceString(nameof(Resources.Title), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString MessageFormat =
			new LocalizableResourceString(nameof(Resources.MessageFormat), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString Description =
			new LocalizableResourceString(nameof(Resources.Description), Resources.ResourceManager, typeof(Resources));

		private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(Helper.ToDiagnosticId(DiagnosticIds.AxesGetDescendants),
																					 Title,
																					 MessageFormat,
																					 nameof(Categories.Performance),
																					 DiagnosticSeverity.Warning,
																					 isEnabledByDefault: true,
																					 description: Description);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

		public override void Initialize(AnalysisContext context)
		{
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
			context.EnableConcurrentExecution();
			context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.InvocationExpression);
		}

		private void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
		{
			var invocationExpr = context.Node as InvocationExpressionSyntax;
			if (invocationExpr == null)
			{
				return;
			}

			var memberAccessExpr = invocationExpr.Expression as MemberAccessExpressionSyntax;
			if (memberAccessExpr?.Name == null || memberAccessExpr.Name.ToString() != "GetDescendants")
			{
				return;
			}

			var memberSymbol = context.SemanticModel.GetSymbolInfo(memberAccessExpr).Symbol as IMethodSymbol;
			if (memberSymbol == null)
			{
				return;
			}

			if (!memberSymbol.ToString().StartsWith("Sitecore.Data.Items.ItemAxes.GetDescendants()"))
			{
				return;
			}

			var diagnostic = Diagnostic.Create(Rule, memberAccessExpr.GetLocation());
			context.ReportDiagnostic(diagnostic);
		}
	}
}
