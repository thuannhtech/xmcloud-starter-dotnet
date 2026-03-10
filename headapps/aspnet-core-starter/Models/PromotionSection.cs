using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;

/// <summary>
/// Model for the PromotionSection component.
/// Wraps a titled section that contains a nested placeholder
/// for child Promo components (placed via Sitecore CMS).
/// </summary>
public class PromotionSection : BaseModel
{
    [SitecoreComponentField]
    public TextField? SectionTitle { get; set; }

    [SitecoreComponentField]
    public TextField? SectionSubtitle { get; set; }
}
