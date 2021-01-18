using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassLanguageManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassLanguageManager() : base(DiagnosticIds.AvoidStaticClassLanguageManager) { }
	}
}
