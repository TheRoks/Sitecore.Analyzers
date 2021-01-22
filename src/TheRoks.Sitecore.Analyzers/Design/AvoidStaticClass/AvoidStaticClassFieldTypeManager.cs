using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassFieldTypeManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassFieldTypeManager() : base(DiagnosticIds.AvoidStaticClassFieldTypeManager) { }
	}
}
