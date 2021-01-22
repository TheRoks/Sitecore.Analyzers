using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassLayoutManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassLayoutManager() : base(DiagnosticIds.AvoidStaticClassLayoutManager) { }
	}
}
