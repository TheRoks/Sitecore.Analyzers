using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Architecture.Helix
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class FoundationToFeatureLayerAnalyzer : HelixLayerAnalyzer
	{

		public FoundationToFeatureLayerAnalyzer() : base(DiagnosticIds.HelixFoundationFeatureLayer, "Foundation", "Feature")
		{
		}

	}
}
