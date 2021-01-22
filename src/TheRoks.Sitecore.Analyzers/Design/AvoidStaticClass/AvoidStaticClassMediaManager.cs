using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassMediaManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassMediaManager() : base(DiagnosticIds.AvoidStaticClassMediaManager) { }
	}
}
