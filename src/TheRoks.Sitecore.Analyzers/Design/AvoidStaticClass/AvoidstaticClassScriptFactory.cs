﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidstaticClassScriptFactory : BaseDesignAnalyzer
	{
		public AvoidstaticClassScriptFactory() : base(DiagnosticIds.AvoidstaticClassScriptFactory) { }
	}
}
