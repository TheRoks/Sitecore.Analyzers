using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{

	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassLog : BaseDesignAnalyzer
	{
		public AvoidStaticClassLog() : base(DiagnosticIds.AvoidStaticClassLog) { }
	}
}
