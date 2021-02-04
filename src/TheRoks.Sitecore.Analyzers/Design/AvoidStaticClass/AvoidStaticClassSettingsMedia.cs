using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassSettingsMedia : BaseDesignAnalyzer
	{
		public AvoidStaticClassSettingsMedia() : base(DiagnosticIds.AvoidStaticClassSettingsMedia) { }
	}
}
