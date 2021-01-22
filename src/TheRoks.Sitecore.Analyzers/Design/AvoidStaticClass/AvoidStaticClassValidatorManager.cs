using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassValidatorManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassValidatorManager() : base(DiagnosticIds.AvoidStaticClassValidatorManager)
		{
		}
	}
}
