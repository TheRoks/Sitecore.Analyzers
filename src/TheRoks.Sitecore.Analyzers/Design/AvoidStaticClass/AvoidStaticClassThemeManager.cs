using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassThemeManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassThemeManager() : base(DiagnosticIds.AvoidStaticClassThemeManager)
		{
		}
	}
}
