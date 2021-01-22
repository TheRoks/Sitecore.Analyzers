using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Architecture.Helix
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class FoundationToProjectLayerAnalyzer : HelixLayerAnalyzer
	{

		public FoundationToProjectLayerAnalyzer() : base(DiagnosticIds.HelixFoundationProjectLayer, "Foundation", "Project")
		{
		}
	}
}
