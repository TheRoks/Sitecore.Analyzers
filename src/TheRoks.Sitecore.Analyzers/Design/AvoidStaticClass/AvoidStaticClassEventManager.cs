﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassEventManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassEventManager() : base(DiagnosticIds.AvoidStaticClassEventManager) { }
	}
}
