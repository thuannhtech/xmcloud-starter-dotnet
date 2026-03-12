using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;

public class BannerSliderFolder : BaseModel
{
    [SitecoreComponentField(Name = "items")]
    public ContentListField BannerSliders { get; set; }
}