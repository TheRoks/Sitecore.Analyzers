using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassLanguageFallbackManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassLanguageFallbackManager() : base(DiagnosticIds.AvoidStaticClassLanguageFallbackManager) { }
	}
}
