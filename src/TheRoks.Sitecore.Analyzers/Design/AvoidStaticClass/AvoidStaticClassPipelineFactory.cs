﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassPipelineFactory : BaseDesignAnalyzer
	{
		public AvoidStaticClassPipelineFactory() : base(DiagnosticIds.AvoidStaticClassPipelineFactory) { }
	}
}
