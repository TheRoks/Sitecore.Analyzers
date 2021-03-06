﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class AvoidStaticClassTicketManager : BaseDesignAnalyzer
	{
		public AvoidStaticClassTicketManager() : base(DiagnosticIds.AvoidStaticClassTicketManager)
		{
		}
	}
}
