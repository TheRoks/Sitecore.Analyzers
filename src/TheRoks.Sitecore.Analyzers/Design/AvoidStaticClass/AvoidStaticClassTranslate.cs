using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassTranslate : BaseDesignAnalyzer
	{
		public AvoidStaticClassTranslate() : base(DiagnosticIds.AvoidStaticClassTranslate)
		{
		}
	}
}
