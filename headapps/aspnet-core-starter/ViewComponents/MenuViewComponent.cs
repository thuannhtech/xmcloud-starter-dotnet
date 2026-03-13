using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Sitecore.AspNetCore.Starter.ViewComponents;

[ViewComponent(Name = ViewComponentName)]
public class MenuViewComponent(IViewModelBinder binder) : ViewComponent
{
    public const string ViewComponentName = "Menu";

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
    {
        var model = await binder.Bind<MenuFolder>(ViewContext);
        return View(model);
    }
}
