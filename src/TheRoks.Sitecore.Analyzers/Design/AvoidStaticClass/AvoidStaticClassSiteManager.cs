using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassSiteManager : BaseDesignAnalyzer
	{

		public AvoidStaticClassSiteManager() : base(DiagnosticIds.AvoidStaticClassSiteManager)
		{
		}
	}
}
