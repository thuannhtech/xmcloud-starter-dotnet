using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Constants;

namespace Sitecore.AspNetCore.Starter.ViewComponents;

[ViewComponent(Name = ViewComponentName)]
public class MenuHeaderViewComponent(IViewModelBinder binder) : ViewComponent
{
    public const string ViewComponentName = "MenuHeader";

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
    {
        var model = await binder.Bind<MenuHeader>(ViewContext);
        var variantName = model.FieldNames ?? Variant.VariantDefault;
        return View(variantName, model);
    }
}