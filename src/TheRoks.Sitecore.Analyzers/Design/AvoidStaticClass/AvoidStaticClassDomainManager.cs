using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassDomainManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassDomainManager() : base(DiagnosticIds.AvoidStaticClassDomainManager) { }
	}
}
