using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassArchiveManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassArchiveManager() : base(DiagnosticIds.AvoidStaticClassArchiveManager) { }
	}
}
