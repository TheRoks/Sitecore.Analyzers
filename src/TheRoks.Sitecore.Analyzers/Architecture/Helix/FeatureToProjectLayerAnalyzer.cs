using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Architecture.Helix
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class FeatureToProjectLayerAnalyzer : HelixLayerAnalyzer
	{

		public FeatureToProjectLayerAnalyzer() : base(DiagnosticIds.HelixFeatureProjectLayer, "Feature", "Project")
		{
		}
	}
}
