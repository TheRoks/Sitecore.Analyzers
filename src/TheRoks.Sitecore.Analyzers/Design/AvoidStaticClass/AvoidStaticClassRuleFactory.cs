﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassRuleFactory : BaseDesignAnalyzer
	{
		public AvoidStaticClassRuleFactory() : base(DiagnosticIds.AvoidStaticClassRuleFactory) { }
	}
}
