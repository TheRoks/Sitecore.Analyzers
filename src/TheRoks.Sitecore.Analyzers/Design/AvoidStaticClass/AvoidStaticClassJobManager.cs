﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassJobManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassJobManager() : base(DiagnosticIds.AvoidStaticClassJobManager) { }
	}
}
