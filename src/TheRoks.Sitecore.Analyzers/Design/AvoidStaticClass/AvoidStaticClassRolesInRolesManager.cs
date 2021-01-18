using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassRolesInRolesManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassRolesInRolesManager() : base(DiagnosticIds.AvoidStaticClassRolesInRolesManager) { }
	}
}
