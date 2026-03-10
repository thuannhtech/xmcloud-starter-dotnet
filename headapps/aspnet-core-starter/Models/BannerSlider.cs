using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;

/// <summary>
/// Model for the BannerSlider component.
/// Maps to BannerSlider component fields defined in Sitecore CMS.
/// Each slide is represented as a BannerSlider component item placed
/// in the "headless-main" placeholder.
/// </summary>
public class BannerSlider : BaseModel
{
    [SitecoreComponentField]
    public ImageField? SlideImage { get; set; }

    [SitecoreComponentField]
    public TextField? SlideTitle { get; set; }

    [SitecoreComponentField]
    public TextField? SlideSubtitle { get; set; }

    [SitecoreComponentField]
    public HyperLinkField? SlideLink { get; set; }

    // If using a Multilist field named "ImageGallery" for multiple images
    [SitecoreComponentField]
    public List<ImageField>? ImageGallery { get; set; }

    // If using child items for slides (most common in XM Cloud)
    // Bind the 'data.item' to get children via GraphQL or simple binding
    // In SDK, we can access the children via the component properties if available.
    public List<BannerSlider>? ChildSlides { get; set; }
}
