﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassPresentationManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassPresentationManager() : base(DiagnosticIds.AvoidStaticClassPresentationManager) { }
	}
}
