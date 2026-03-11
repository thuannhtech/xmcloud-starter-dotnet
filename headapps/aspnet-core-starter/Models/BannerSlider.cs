using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;
public class BannerSlider : BaseModel
{
    [SitecoreComponentField]
    public HyperLinkField? CTA { get; set; }

    [SitecoreComponentField]
    public ImageField? Image { get; set; }

    [SitecoreComponentField]
    public TextField? Title { get; set; }

    [SitecoreComponentField]
    public RichTextField? Description { get; set; }
}
