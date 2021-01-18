using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassDistributedPublishingManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassDistributedPublishingManager() : base(DiagnosticIds.AvoidStaticClassDistributedPublishingManager) { }
	}
}
