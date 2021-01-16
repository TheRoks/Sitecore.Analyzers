using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design
{
	public abstract class BaseDesignAnalyzer : DiagnosticAnalyzer
	{
		protected static void Analyze(SyntaxNodeAnalysisContext context, DiagnosticDescriptor rule)
		{
			var invocationExpr = context.Node as InvocationExpressionSyntax;
			if (invocationExpr == null)
			{
				return;
			}

			var memberAccessExpr = invocationExpr.Expression as MemberAccessExpressionSyntax;
			if (memberAccessExpr == null)
			{
				return;
			}

			var memberSymbol = context.SemanticModel.GetSymbolInfo(memberAccessExpr).Symbol as IMethodSymbol;

			if (memberSymbol == null)
			{
				return;
			}

			var staticClass = Constants.Analyzers[rule.Id].StaticClass;
			if (!memberSymbol.ToString().StartsWith(staticClass))
			{
				return;
			}

			var baseClass = Constants.Analyzers[rule.Id].BaseClass;
			var diagnostic = Diagnostic.Create(rule, memberAccessExpr.GetLocation(), staticClass, baseClass);
			context.ReportDiagnostic(diagnostic);
		}
	}
}
