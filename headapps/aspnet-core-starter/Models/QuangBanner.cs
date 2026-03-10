using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;

/// <summary>
/// Model for the QuangBanner component.
/// Maps to QuangBanner component fields defined in Sitecore CMS.
/// </summary>
public class QuangBanner : BaseModel
{
    [SitecoreComponentField]
    public TextField? Title { get; set; }

    [SitecoreComponentField]
    public RichTextField? Description { get; set; }

    [SitecoreComponentField]
    public ImageField? Image { get; set; }

    [SitecoreComponentField]
    public HyperLinkField? CallToAction { get; set; }
}
