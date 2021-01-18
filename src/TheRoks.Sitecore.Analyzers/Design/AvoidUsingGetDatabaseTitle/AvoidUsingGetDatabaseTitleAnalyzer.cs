using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidUsingGetDatabaseTitle
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidUsingGetDatabaseTitleAnalyzer : DiagnosticAnalyzer
	{
		private static readonly LocalizableString Title =
			new LocalizableResourceString(nameof(Resources.Title), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString MessageFormat =
			new LocalizableResourceString(nameof(Resources.MessageFormat), Resources.ResourceManager, typeof(Resources));

		private static readonly LocalizableString Description =
			new LocalizableResourceString(nameof(Resources.Description), Resources.ResourceManager, typeof(Resources));

		private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(Helper.ToDiagnosticId(DiagnosticIds.AvoidUsingGetDatabase),
																					 Title,
																					 MessageFormat,
																					 nameof(Categories.Design),
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
			if (memberAccessExpr?.Name == null || memberAccessExpr.Name.ToString() != "GetDatabase")
			{
				return;
			}

			var memberSymbol = context.SemanticModel.GetSymbolInfo(memberAccessExpr).Symbol as IMethodSymbol;
			if (memberSymbol == null)
			{
				return;
			}

			if (!memberSymbol.ToString().StartsWith("Sitecore.Data.Database.GetDatabase"))
			{
				return;
			}

			var argumentList = invocationExpr.ArgumentList;
			if ((argumentList?.Arguments.Count ?? 0) < 1)
			{
				return;
			}

			var databaseLiteral = argumentList.Arguments[0].Expression as LiteralExpressionSyntax;
			if (databaseLiteral == null)
			{
				return;
			}

			var databaseOpt = context.SemanticModel.GetConstantValue(databaseLiteral);
			if (!databaseOpt.HasValue)
			{
				return;
			}

			var database = databaseOpt.Value as string;
			if (!string.Equals(database, "master", System.StringComparison.OrdinalIgnoreCase))
			{
				return;
			}

			var diagnostic = Diagnostic.Create(Rule, memberAccessExpr.GetLocation());
			context.ReportDiagnostic(diagnostic);
		}
	}
}
