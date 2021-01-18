using System.Collections.Generic;

namespace TheRoks.Sitecore.Analyzers.Design.AvoidStaticClass
{
	internal class Constants
	{
		public static Dictionary<DiagnosticIds, (string StaticClass, string BaseClass)> Analyzers = new Dictionary<DiagnosticIds, (string StaticClass, string BaseClass)>()
		{
			{ DiagnosticIds.AvoidStaticClassLog, (StaticClass: "Sitecore.Diagnostics.Log", BaseClass: "BaseLog") },
			{ DiagnosticIds.AvoidStaticClassSettings, (StaticClass: "Sitecore.Configuration.Settings", BaseClass: "BaseSettings") },
			{ DiagnosticIds.AvoidStaticClassLinkManager, (StaticClass: "Sitecore.Links.LinkManager", BaseClass: "BaseLinkManager") },
			{ DiagnosticIds.AvoidStaticClassAccessRightManager, (StaticClass: "Sitecore.Security.AccessControl.AccessRightManager", BaseClass: "BaseAccessRightManager") },
			{ DiagnosticIds.AvoidStaticClassArchiveManager, (StaticClass: "Sitecore.Data.Archiving.ArchiveManager", BaseClass: "BaseArchiveManager") },
			{ DiagnosticIds.AvoidStaticClassAuthorizationManager, (StaticClass: "Sitecore.Security.AccessControl.AuthorizationManager", BaseClass: "BaseAuthorizationManager") },
			{ DiagnosticIds.AvoidStaticClassCacheManager, (StaticClass: "Sitecore.Caching.CacheManager", BaseClass: "BaseCacheManager") },
			{ DiagnosticIds.AvoidStaticClassClient, (StaticClass: "Sitecore.Client", BaseClass: "BaseClient") },
			{ DiagnosticIds.AvoidStaticClassComparerFactory, (StaticClass: "Sitecore.Data.Comparers.ComparerFactory", BaseClass: "BaseComparerFactory") },
			{ DiagnosticIds.AvoidStaticClassControlManager, (StaticClass: "Sitecore.Presentation.ControlManager", BaseClass: "BaseControlManager") },
			{ DiagnosticIds.AvoidStaticClassCorePipeline, (StaticClass: "Sitecore.Pipelines.CorePipeline", BaseClass: "BaseCorePipelineManager") },
			{ DiagnosticIds.AvoidStaticClassDistributedPublishingManager, (StaticClass: "Sitecore.Publishing.DistributedPublishingManager", BaseClass: "BaseDistributedPublishingManager") },
			{ DiagnosticIds.AvoidStaticClassDomainManager, (StaticClass: "Sitecore.SecurityModel.DomainManager", BaseClass: "BaseDomainManager") },
			{ DiagnosticIds.AvoidStaticClassEventManager, (StaticClass: "Sitecore.Eventing.EventManager", BaseClass: "BaseEventManager") },
			{ DiagnosticIds.AvoidStaticClassEventProvider, (StaticClass: "Sitecore.Eventing.EventProvider", BaseClass: "BaseEventQueueProvider") },
			{ DiagnosticIds.AvoidStaticClassFactory, (StaticClass: "Sitecore.Configuration.Factory", BaseClass: "BaseFactory") },
			{ DiagnosticIds.AvoidStaticClassFeedManager, (StaticClass: "Sitecore.Syndication.FeedManager", BaseClass: "BaseFeedManager") },
			{ DiagnosticIds.AvoidStaticClassFieldTypeManager, (StaticClass: "Sitecore.Data.Fields.FieldTypeManager", BaseClass: "BaseFieldTypeManager") },
			{ DiagnosticIds.AvoidStaticClassHistoryManager, (StaticClass: "Sitecore.Data.Managers.HistoryManager", BaseClass: "BaseHistoryManager") },
			{ DiagnosticIds.AvoidStaticClassItemManager, (StaticClass: "Sitecore.Data.Managers.ItemManager", BaseClass: "BaseItemManager") },
			{ DiagnosticIds.AvoidStaticClassJobManager, (StaticClass: "Sitecore.Jobs.JobManager", BaseClass: "BaseJobManager") },
			{ DiagnosticIds.AvoidStaticClassLanguageFallbackFieldValuesManager, (StaticClass: "Sitecore.Data.LanguageFallback.LanguageFallbackFieldValuesManager", BaseClass: "BaseLanguageFallbackFieldValuesManager") },
			{ DiagnosticIds.AvoidStaticClassLanguageFallbackManager, (StaticClass: "Sitecore.Data.Managers.LanguageFallbackManager", BaseClass: "BaseLanguageFallbackManager") },
			{ DiagnosticIds.AvoidStaticClassLanguageManager, (StaticClass: "Sitecore.Data.Managers.LanguageManager", BaseClass: "BaseLanguageManager") },
			{ DiagnosticIds.AvoidStaticClassLayoutManager, (StaticClass: "Sitecore.Visualization.LayoutManager", BaseClass: "BaseLayoutManager") },
			{ DiagnosticIds.AvoidStaticClassLinkStrategyFactory, (StaticClass: "Sitecore.Links.LinkStrategyFactory", BaseClass: "BaseLinkStrategyFactory") },
			{ DiagnosticIds.AvoidStaticClassMediaManager, (StaticClass: "Sitecore.Resources.Media.MediaManager", BaseClass: "BaseMediaManager") },
			{ DiagnosticIds.AvoidStaticClassMediaPathManager, (StaticClass: "Sitecore.Resources.Media.MediaPathManager", BaseClass: "BaseMediaPathManager") },
			{ DiagnosticIds.AvoidStaticClassPipelineFactory, (StaticClass: "Sitecore.Pipelines.PipelineFactory", BaseClass: "BasePipelineFactory") },
			{ DiagnosticIds.AvoidStaticClassPlaceholderCacheManager, (StaticClass: "Sitecore.Caching.Placeholders.PlaceholderCacheManager", BaseClass: "BasePlaceholderCacheManager") },
			{ DiagnosticIds.AvoidStaticClassPresentationManager, (StaticClass: "Sitecore.Presentation.PresentationManager", BaseClass: "BasePresentationManager") },
			{ DiagnosticIds.AvoidStaticClassPreviewManager, (StaticClass: "Sitecore.Publishing.PreviewManager", BaseClass: "BasePreviewManager") },
			{ DiagnosticIds.AvoidStaticClassPublishManager, (StaticClass: "Sitecore.Publishing.PublishManager", BaseClass: "BasePublishManager") },
			{ DiagnosticIds.AvoidStaticClassRolesInRolesManager, (StaticClass: "Sitecore.Security.Accounts.RolesInRolesManager", BaseClass: "BaseRolesInRolesManager") },
			{ DiagnosticIds.AvoidStaticClassRuleFactory, (StaticClass: "Sitecore.Rules.RuleFactory", BaseClass: "BaseRuleFactory") },
			{ DiagnosticIds.AvoidStaticClassRuleManager, (StaticClass: "Sitecore.Visualization.RuleManager", BaseClass: "BaseRuleManager") },
			{ DiagnosticIds.AvoidstaticClassScriptFactory, (StaticClass: "Sitecore.CodeDom.Scripts.ScriptFactory", BaseClass: "BaseScriptFactory") },
			{ DiagnosticIds.AvoidStaticClassSiteContextFactory, (StaticClass: "Sitecore.Sites.SiteContextFactory", BaseClass: "BaseSiteContextFactory") },
			{ DiagnosticIds.AvoidStaticClassSiteManager, (StaticClass: "Sitecore.Sites.SiteManager", BaseClass: "BaseSiteManager") },
			{ DiagnosticIds.AvoidStaticClassStandardValuesManager, (StaticClass: "Sitecore.Data.StandardValuesManager", BaseClass: "BaseStandardValuesManager") },
			{ DiagnosticIds.AvoidStaticClassTemplateManager, (StaticClass: "Sitecore.Data.Managers.TemplateManager", BaseClass: "BaseTemplateManager") },
			{ DiagnosticIds.AvoidStaticClassThemeManager, (StaticClass: "Sitecore.Data.Manager.ThemeManager", BaseClass: "BaseThemeManager") },
			{ DiagnosticIds.AvoidStaticClassTicketManager, (StaticClass: "Sitecore.Web.Authentication.TicketManager", BaseClass: "BaseTicketManager") },
			{ DiagnosticIds.AvoidStaticClassTranslate, (StaticClass: "Sitecore.Globalisation.Translate", BaseClass: "BaseTranslate") },
			{ DiagnosticIds.AvoidStaticClassUserManager, (StaticClass: "Sitecore.Security.Accounts.UserManager", BaseClass: "BaseUserManager") },
			{ DiagnosticIds.AvoidStaticClassValidatorManager, (StaticClass: "Sitecore.Data.Validators.ValidatorManager", BaseClass: "BaseValidatorManager") }
		};
	}
}
