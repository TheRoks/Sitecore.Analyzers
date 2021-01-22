using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassRuleManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassRuleManager() : base(DiagnosticIds.AvoidStaticClassRuleManager) { }
	}
}
