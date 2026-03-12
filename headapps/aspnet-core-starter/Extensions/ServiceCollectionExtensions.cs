using Sitecore.AspNetCore.SDK.RenderingEngine.Configuration;
using Sitecore.AspNetCore.Starter.Components.Blog;
using Sitecore.AspNetCore.Starter.Models.LinkList;
using Sitecore.AspNetCore.Starter.Models.Navigation;
using Sitecore.AspNetCore.Starter.Models.Title;
using Sitecore.AspNetCore.Starter.ViewComponents;

namespace Sitecore.AspNetCore.Starter.Extensions;

public static class ServiceCollectionExtensions
{
    public static RenderingEngineOptions AddStarterKitViews(this RenderingEngineOptions renderingEngineOptions)
    {
        renderingEngineOptions.AddModelBoundView<Title>("Title")
                              .AddModelBoundView<Container>("Container")
                              .AddModelBoundView<ColumnSplitter>("ColumnSplitter")
                              .AddModelBoundView<RowSplitter>("RowSplitter")
                              .AddModelBoundView<PageContent>("PageContent")
                              .AddModelBoundView<RichText>("RichText")
                              .AddModelBoundView<Promo>("Promo")
                              .AddModelBoundView<LinkList>("LinkList")
                              .AddModelBoundView<Image>("Image")
                              .AddModelBoundView<PartialDesignDynamicPlaceholder>("PartialDesignDynamicPlaceholder")
                              .AddModelBoundView<Navigation>("Navigation")
                              // ── Home page components ──────────────────────────────────
                              //.AddModelBoundView<BannerSlider>("BannerSlider")
                              //.AddModelBoundView<List<Slider>>("Slider")
                              .AddViewComponent(SliderViewComponent.ViewComponentName)
                              //.AddModelBoundView<PromotionSection>("PromotionSection")
                              //.AddModelBoundView<Footer>("Footer")
                              //.AddModelBoundView<QuangBanner>("QuangBanner")
                              // ─────────────────────────────────────────────────────────
                              .AddViewComponent(MenuHeaderBarViewComponent.ViewComponentName)
                              .AddViewComponent(BannerSliderViewComponent.ViewComponentName)
							  .AddViewComponent(BlogListingViewComponent.ViewComponentName)
							  .AddViewComponent(BlogDetailViewComponent.ViewComponentName);

		return renderingEngineOptions;
	}
}