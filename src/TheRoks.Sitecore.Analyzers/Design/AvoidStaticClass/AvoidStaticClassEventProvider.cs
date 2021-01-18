﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassEventProvider : BaseDesignAnalyzer
	{
		public AvoidStaticClassEventProvider() : base(DiagnosticIds.AvoidStaticClassEventProvider) { }
	}
}
