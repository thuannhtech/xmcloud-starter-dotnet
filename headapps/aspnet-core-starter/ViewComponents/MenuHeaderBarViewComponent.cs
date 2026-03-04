using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Models;

namespace Sitecore.AspNetCore.Starter.ViewComponents;

[ViewComponent(Name = ViewComponentName)]
public class MenuHeaderBarViewComponent(IViewModelBinder binder) : ViewComponent
{
    public const string ViewComponentName = "MenuHeaderBar";

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
    {
        var model = await binder.Bind<MenuHeaderBar>(ViewContext);
        var variantName = model.FieldNames ?? MenuHeaderBar.VARIANT_DEFAULT;
        return View(variantName, model);
    }
}
