using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Models.Blog;

namespace Sitecore.AspNetCore.Starter.Components.Blog
{

	/// <summary>
	/// /sitecore/layout/Renderings/Project/sai-sitecore/BlogDetail
	/// </summary>
	[ViewComponent(Name = ViewComponentName)]
	public class BlogDetailViewComponent(IViewModelBinder binder) : ViewComponent
	{
		public const string ViewComponentName = "BlogDetail";

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await binder.Bind<BlogDetailModel>(ViewContext);

			model ??= new BlogDetailModel();

			return View("~/Views/Blog/BlogDetail/Default.cshtml", model);
		}
	}
}