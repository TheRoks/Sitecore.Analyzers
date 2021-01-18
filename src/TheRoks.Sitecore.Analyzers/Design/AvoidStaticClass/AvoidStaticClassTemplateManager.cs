using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassTemplateManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassTemplateManager() : base(DiagnosticIds.AvoidStaticClassTemplateManager)
		{
		}
	}
}
