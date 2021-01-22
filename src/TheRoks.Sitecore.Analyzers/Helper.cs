using System;

namespace TheRoks.Sitecore.Analyzers
{
	internal class Helper
	{
		public static string ToDiagnosticId(DiagnosticIds id)
		{
			return $"SCQC" + ((int)id).ToString("0000");
		}

		public static DiagnosticIds FromDiagnosticId(string ruleId)
		{
			var id = ruleId.Replace("SCQC", string.Empty);
			DiagnosticIds diagnosticIds = (DiagnosticIds)Enum.Parse(typeof(DiagnosticIds), id, true);
			return diagnosticIds;
		}
	}
}
