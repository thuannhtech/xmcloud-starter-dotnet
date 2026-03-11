using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;

namespace Sitecore.AspNetCore.Starter.ViewComponents
{
    [ViewComponent(Name = ViewComponentName)]
    public class BannerSliderViewComponent(IViewModelBinder binder) : ViewComponent
    {
        public const string ViewComponentName = "BannerSlider";

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            
            var model = await binder.Bind<BannerSliderFolder>(ViewContext);
            return View(model);
        }
    }
}
