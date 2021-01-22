using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassControlManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassControlManager() : base(DiagnosticIds.AvoidStaticClassControlManager) { }
	}
}
