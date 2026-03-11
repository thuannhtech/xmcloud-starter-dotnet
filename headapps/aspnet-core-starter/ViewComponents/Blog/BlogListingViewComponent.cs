using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Models.Blog;

namespace Sitecore.AspNetCore.Starter.Components.Blog
{
	[ViewComponent(Name = ViewComponentName)]
	public class BlogListingViewComponent(IViewModelBinder binder) : ViewComponent
	{
		public const string ViewComponentName = "BlogListing";

		public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
		{
			var context = ViewContext.HttpContext.GetSitecoreRenderingContext();
			var model = await binder.Bind<BlogListingModel>(ViewContext);
			model ??= new BlogListingModel();

			return View("~/Views/Blog/BlogListing/Default.cshtml", model);
		}
	}
}