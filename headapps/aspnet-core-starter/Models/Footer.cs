using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;

/// <summary>
/// Model for the Footer component.
/// Maps to Footer component fields defined in Sitecore CMS.
/// Placed in the "headless-footer" placeholder.
/// </summary>
public class Footer : BaseModel
{
    [SitecoreComponentField]
    public ImageField? FooterLogo { get; set; }

    [SitecoreComponentField]
    public TextField? CopyrightText { get; set; }

    [SitecoreComponentField]
    public TextField? FooterTagline { get; set; }

    [SitecoreComponentField]
    public HyperLinkField? SocialFacebook { get; set; }

    [SitecoreComponentField]
    public HyperLinkField? SocialTwitter { get; set; }

    [SitecoreComponentField]
    public HyperLinkField? SocialInstagram { get; set; }
}
