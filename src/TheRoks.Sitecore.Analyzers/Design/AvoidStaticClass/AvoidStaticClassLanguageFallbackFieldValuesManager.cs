using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassLanguageFallbackFieldValuesManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassLanguageFallbackFieldValuesManager() : base(DiagnosticIds.AvoidStaticClassLanguageFallbackFieldValuesManager) { }
	}
}
