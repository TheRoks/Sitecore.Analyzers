using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassFeedManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassFeedManager() : base(DiagnosticIds.AvoidStaticClassFeedManager) { }
	}
}
