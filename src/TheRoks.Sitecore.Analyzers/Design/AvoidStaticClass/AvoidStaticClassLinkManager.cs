using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassLinkManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassLinkManager() : base(DiagnosticIds.AvoidStaticClassLinkManager) { }
	}
}
