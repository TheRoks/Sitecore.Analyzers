using System.Collections.Generic;

namespace TheRoks.Sitecore.Analyzers.Design
{
	internal class Constants
	{
		public const string Title = "Avoid static class";
		public const string MessageFormat = "Avoid the use of the '{0}' static class. Refactor to use {1}";
		public const string Category = "Design";
		public const string Description = "Avoid using static classes";

		public static Dictionary<string, (string StaticClass, string BaseClass)> Analyzers = new Dictionary<string, (string StaticClass, string BaseClass)>()
		{
			{ nameof(SCD0001), (StaticClass: "Sitecore.Diagnostics.Log", BaseClass: "BaseLog") },
			{ nameof(SCD0002), (StaticClass: "Sitecore.Configuration.Settings", BaseClass: "BaseSettings") },
			{ nameof(SCD0003), (StaticClass: "Sitecore.Links.LinkManager", BaseClass: "BaseLinkManager") },
			{ nameof(SCD0004), (StaticClass: "Sitecore.Security.AccessControl.AccessRightManager", BaseClass: "BaseAccessRightManager") },
			{ nameof(SCD0005), (StaticClass: "Sitecore.Data.Archiving.ArchiveManager", BaseClass: "BaseArchiveManager") },
			{ nameof(SCD0006), (StaticClass: "Sitecore.Security.AccessControl.AuthorizationManager", BaseClass: "BaseAuthorizationManager") },
			{ nameof(SCD0007), (StaticClass: "Sitecore.Caching.CacheManager", BaseClass: "BaseCacheManager") },
			{ nameof(SCD0008), (StaticClass: "Sitecore.Client", BaseClass: "BaseClient") },
			{ nameof(SCD0009), (StaticClass: "Sitecore.Data.Comparers.ComparerFactory", BaseClass: "BaseComparerFactory") },
			{ nameof(SCD0010), (StaticClass: "Sitecore.Presentation.ControlManager", BaseClass: "BaseControlManager") },
			{ nameof(SCD0011), (StaticClass: "Sitecore.Pipelines.CorePipeline", BaseClass: "BaseCorePipelineManager") },
			{ nameof(SCD0012), (StaticClass: "Sitecore.Publishing.DistributedPublishingManager", BaseClass: "BaseDistributedPublishingManager") },
			{ nameof(SCD0013), (StaticClass: "Sitecore.SecurityModel.DomainManager", BaseClass: "BaseDomainManager") },
			{ nameof(SCD0014), (StaticClass: "Sitecore.Eventing.EventManager", BaseClass: "BaseEventManager") },
			{ nameof(SCD0015), (StaticClass: "Sitecore.Eventing.EventProvider", BaseClass: "BaseEventQueueProvider") },
			{ nameof(SCD0016), (StaticClass: "Sitecore.Configuration.Factory", BaseClass: "BaseFactory") },
			{ nameof(SCD0017), (StaticClass: "Sitecore.Syndication.FeedManager", BaseClass: "BaseFeedManager") },
			{ nameof(SCD0018), (StaticClass: "Sitecore.Data.Fields.FieldTypeManager", BaseClass: "BaseFieldTypeManager") },
			{ nameof(SCD0019), (StaticClass: "Sitecore.Data.Managers.HistoryManager", BaseClass: "BaseHistoryManager") },
			{ nameof(SCD0020), (StaticClass: "Sitecore.Data.Managers.ItemManager", BaseClass: "BaseItemManager") },
			{ nameof(SCD0021), (StaticClass: "Sitecore.Jobs.JobManager", BaseClass: "BaseJobManager") },
			{ nameof(SCD0022), (StaticClass: "Sitecore.Data.LanguageFallback.LanguageFallbackFieldValuesManager", BaseClass: "BaseLanguageFallbackFieldValuesManager") },
			{ nameof(SCD0023), (StaticClass: "Sitecore.Data.Managers.LanguageFallbackManager", BaseClass: "BaseLanguageFallbackManager") },
			{ nameof(SCD0024), (StaticClass: "Sitecore.Data.Managers.LanguageManager", BaseClass: "BaseLanguageManager") },
			{ nameof(SCD0025), (StaticClass: "Sitecore.Visualization.LayoutManager", BaseClass: "BaseLayoutManager") },
			{ nameof(SCD0026), (StaticClass: "Sitecore.Links.LinkStrategyFactory", BaseClass: "BaseLinkStrategyFactory") },
			{ nameof(SCD0027), (StaticClass: "Sitecore.Resources.Media.MediaManager", BaseClass: "BaseMediaManager") },
			{ nameof(SCD0028), (StaticClass: "Sitecore.Resources.Media.MediaPathManager", BaseClass: "BaseMediaPathManager") },
			{ nameof(SCD0029), (StaticClass: "Sitecore.Pipelines.PipelineFactory", BaseClass: "BasePipelineFactory") },
			{ nameof(SCD0030), (StaticClass: "Sitecore.Caching.Placeholders.PlaceholderCacheManager", BaseClass: "BasePlaceholderCacheManager") },
			{ nameof(SCD0031), (StaticClass: "Sitecore.Presentation.PresentationManager", BaseClass: "BasePresentationManager") },
			{ nameof(SCD0032), (StaticClass: "Sitecore.Publishing.PreviewManager", BaseClass: "BasePreviewManager") },
			{ nameof(SCD0033), (StaticClass: "Sitecore.Publishing.PublishManager", BaseClass: "BasePublishManager") },
			{ nameof(SCD0034), (StaticClass: "Sitecore.Security.Accounts.RolesInRolesManager", BaseClass: "BaseRolesInRolesManager") },
			{ nameof(SCD0035), (StaticClass: "Sitecore.Rules.RuleFactory", BaseClass: "BaseRuleFactory") },
			{ nameof(SCD0036), (StaticClass: "Sitecore.Visualization.RuleManager", BaseClass: "BaseRuleManager") },
			{ nameof(SCD0037), (StaticClass: "Sitecore.CodeDom.Scripts.ScriptFactory", BaseClass: "BaseScriptFactory") },
			{ nameof(SCD0038), (StaticClass: "Sitecore.Sites.SiteContextFactory", BaseClass: "BaseSiteContextFactory") },
			{ nameof(SCD0039), (StaticClass: "Sitecore.Sites.SiteManager", BaseClass: "BaseSiteManager") },
			{ nameof(SCD0040), (StaticClass: "Sitecore.Data.StandardValuesManager", BaseClass: "BaseStandardValuesManager") },
			{ nameof(SCD0041), (StaticClass: "Sitecore.Data.Managers.TemplateManager", BaseClass: "BaseTemplateManager") },
			{ nameof(SCD0042), (StaticClass: "Sitecore.Data.Manager.ThemeManager", BaseClass: "BaseThemeManager") },
			{ nameof(SCD0043), (StaticClass: "Sitecore.Web.Authentication.TicketManager", BaseClass: "BaseTicketManager") },
			{ nameof(SCD0044), (StaticClass: "Sitecore.Globalisation.Translate", BaseClass: "BaseTranslate") },
			{ nameof(SCD0045), (StaticClass: "Sitecore.Security.Accounts.UserManager", BaseClass: "BaseUserManager") },
			{ nameof(SCD0046), (StaticClass: "Sitecore.Data.Validators.ValidatorManager", BaseClass: "BaseValidatorManager") }
		};
	}
}