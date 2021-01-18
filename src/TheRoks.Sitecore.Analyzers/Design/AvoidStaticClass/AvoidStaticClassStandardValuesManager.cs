using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassStandardValuesManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassStandardValuesManager() : base(DiagnosticIds.AvoidStaticClassStandardValuesManager)
		{
		}
	}
}
