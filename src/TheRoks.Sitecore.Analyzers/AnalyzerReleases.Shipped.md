## Release 0.1.5

### New Rules

Rule ID  | Category | Severity | Notes
---------|----------|----------|--------------------
SCQC0101 | Design | Warning | Avoid calling GetDatabase("master")
SCQC1001 | Performance | Warning | Using Axes.GetDescendants() can cause serious performance issues.
SCQC1002 | Performance | Warning | Using SelectItems(string) can cause serious performance issues.
SCQC3001 | Usage | Warning | Add Exception Type on Catch Block.
SCQC3002 | Usage | Warning | Log Error on Exception Handling
SCQC3003 | Usage | Warning |Include exception as parameter on log error

## Release 0.1.4

### New Rules
Rule ID | Category | Severity | Notes
--------|----------|----------|--------------------
SCQC0001 | Design | Warning | Avoid static class Log
SCQC0002 | Design | Warning | Avoid static class Settings
SCQC0003 | Design | Warning | Avoid static class LinkManager
SCQC0004 | Design | Warning | Avoid static class AccessRightManager
SCQC0005 | Design | Warning | Avoid static class ArchiveManager
SCQC0006 | Design | Warning | Avoid static class AuthorizationManager
SCQC0007 | Design | Warning | Avoid static class CacheManager
SCQC0008 | Design | Warning | Avoid static class Client
SCQC0009 | Design | Warning | Avoid static class ComparerFactory
SCQC0010 | Design | Warning | Avoid static class ControlManager
SCQC0011 | Design | Warning | Avoid static class CorePipeline
SCQC0012 | Design | Warning | Avoid static class DistributedPublishingManager
SCQC0013 | Design | Warning | Avoid static class DomainManager
SCQC0014 | Design | Warning | Avoid static class EventManager
SCQC0015 | Design | Warning | Avoid static class EventProvider
SCQC0016 | Design | Warning | Avoid static class Factory
SCQC0017 | Design | Warning | Avoid static class FeedManager
SCQC0018 | Design | Warning | Avoid static class FieldTypeManager
SCQC0019 | Design | Warning | Avoid static class HistoryManager
SCQC0020 | Design | Warning | Avoid static class ItemManager
SCQC0021 | Design | Warning | Avoid static class JobManager
SCQC0022 | Design | Warning | Avoid static class LanguageFallbackFieldValuesManager
SCQC0023 | Design | Warning | Avoid static class LanguageFallbackManager
SCQC0024 | Design | Warning | Avoid static class LanguageManager
SCQC0025 | Design | Warning | Avoid static class LayoutManager
SCQC0026 | Design | Warning | Avoid static class LinkStrategyFactory
SCQC0027 | Design | Warning | Avoid static class MediaManager
SCQC0028 | Design | Warning | Avoid static class MediaPathManager
SCQC0029 | Design | Warning | Avoid static class PipelineFactory
SCQC0030 | Design | Warning | Avoid static class PlaceholderCacheManager
SCQC0031 | Design | Warning | Avoid static class PresentationManager
SCQC0032 | Design | Warning | Avoid static class PreviewManager
SCQC0033 | Design | Warning | Avoid static class PublishManager
SCQC0034 | Design | Warning | Avoid static class RolesInRolesManager
SCQC0035 | Design | Warning | Avoid static class RuleFactory
SCQC0036 | Design | Warning | Avoid static class RuleManager
SCQC0037 | Design | Warning | Avoid static class ScriptFactory
SCQC0038 | Design | Warning | Avoid static class SiteContextFactory
SCQC0039 | Design | Warning | Avoid static class SiteManager
SCQC0040 | Design | Warning | Avoid static class StandardValuesManager
SCQC0041 | Design | Warning | Avoid static class TemplateManager
SCQC0042 | Design | Warning | Avoid static class ThemeManager
SCQC0043 | Design | Warning | Avoid static class TicketManager
SCQC0044 | Design | Warning | Avoid static class Translate
SCQC0045 | Design | Warning | Avoid static class UserManager
SCQC0046 | Design | Warning | Avoid static class ValidatorManager
