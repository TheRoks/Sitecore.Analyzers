using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassLinkStrategyFactory : BaseDesignAnalyzer
	{
		public AvoidStaticClassLinkStrategyFactory() : base(DiagnosticIds.AvoidStaticClassLinkStrategyFactory) { }
	}
}
