using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Models;
using Sitecore.AspNetCore.Starter.Services;

namespace Sitecore.AspNetCore.Starter.ViewComponents;

[ViewComponent(Name = ViewComponentName)]
public class MenuHeaderBarViewComponent(IViewModelBinder binder, IDictionaryService dictionaryService) : ViewComponent
{
    public const string ViewComponentName = "MenuHeaderBar";

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
    {
        var model = await binder.Bind<MenuHeaderBar>(ViewContext);
        var variantName = model.FieldNames ?? MenuHeaderBar.VARIANT_DEFAULT;

        // Load dictionary for current language and pass to view via ViewData
        var language = HttpContext.Features.Get<Microsoft.AspNetCore.Localization.IRequestCultureFeature>()
            ?.RequestCulture.Culture.TwoLetterISOLanguageName ?? "en";
        var dictionary = await dictionaryService.GetAllAsync(language);
        ViewData["Dictionary"] = dictionary;

        return View(variantName, model);
    }
}
