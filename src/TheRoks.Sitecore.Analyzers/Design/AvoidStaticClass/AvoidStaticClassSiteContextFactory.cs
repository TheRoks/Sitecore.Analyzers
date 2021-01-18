using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassSiteContextFactory : BaseDesignAnalyzer
	{
		public AvoidStaticClassSiteContextFactory() : base(DiagnosticIds.AvoidStaticClassSiteContextFactory) { }
	}
}
