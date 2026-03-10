using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;

namespace Sitecore.AspNetCore.Starter.ViewComponents
{
    [ViewComponent(Name = ViewComponentName)]
    public class SliderViewComponent(IViewModelBinder binder) : ViewComponent
    {
        public const string ViewComponentName = "Slider";

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var model = await binder.Bind<Slider>(ViewContext);
            return View(model);
        }
    }
}
