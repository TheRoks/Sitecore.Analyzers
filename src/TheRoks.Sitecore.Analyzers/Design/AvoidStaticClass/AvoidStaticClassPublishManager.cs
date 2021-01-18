using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassPublishManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassPublishManager() : base(DiagnosticIds.AvoidStaticClassPublishManager) { }
	}
}
