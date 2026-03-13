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
                              .AddModelBoundView<Navigation>("Navigation");
                              
        renderingEngineOptions.QuangLe();
        renderingEngineOptions.TuVan();

		return renderingEngineOptions;
	}


	private static RenderingEngineOptions QuangLe(this RenderingEngineOptions renderingEngineOptions)
	{
		renderingEngineOptions
		// ── Home page components ──────────────────────────────────
		//.AddModelBoundView<BannerSlider>("BannerSlider")
		//.AddModelBoundView<List<Slider>>("Slider")

		//.AddModelBoundView<PromotionSection>("PromotionSection")
		//.AddModelBoundView<Footer>("Footer")
		//.AddModelBoundView<QuangBanner>("QuangBanner")
		// ─────────────────────────────────────────────────────────
		.AddViewComponent(MenuHeaderBarViewComponent.ViewComponentName)
		.AddViewComponent(BannerSliderViewComponent.ViewComponentName)
        .AddViewComponent(MenuViewComponent.ViewComponentName)
        // Register rendering here
        ;

        return renderingEngineOptions;
	}


	private static RenderingEngineOptions TuVan(this RenderingEngineOptions renderingEngineOptions)
	{
		renderingEngineOptions.AddViewComponent(BlogListingViewComponent.ViewComponentName)
							  .AddViewComponent(BlogDetailViewComponent.ViewComponentName)
							  // Register rendering here
							  ;

		return renderingEngineOptions;
	}
}