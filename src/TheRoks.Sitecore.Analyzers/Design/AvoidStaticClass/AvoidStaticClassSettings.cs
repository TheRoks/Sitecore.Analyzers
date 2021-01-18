using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassSettings : BaseDesignAnalyzer
	{
		public AvoidStaticClassSettings() : base(DiagnosticIds.AvoidStaticClassSettings) { }
	}
}
