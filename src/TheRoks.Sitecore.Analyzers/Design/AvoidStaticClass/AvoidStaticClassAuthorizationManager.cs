using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassAuthorizationManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassAuthorizationManager() : base(DiagnosticIds.AvoidStaticClassAuthorizationManager) { }
	}
}
