using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Models.Blog;
using Sitecore.AspNetCore.Starter.Models.Common;

namespace Sitecore.AspNetCore.Starter.Components.Blog
{
	[ViewComponent(Name = ViewComponentName)]
	public class BlogListingViewComponent(IViewModelBinder binder) : ViewComponent
	{
		public const string ViewComponentName = "BlogListing";

		public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
		{
			var model = await binder.Bind<BlogListingModel>(ViewContext);
			model ??= new BlogListingModel();

			int pageSize = 6;
			int currentPage = int.TryParse(ViewContext.HttpContext.Request.Query["page"], out var p) ? p : 1;

			if (model.Blogs != null)
			{
				var allItems = model.Blogs.ToList();
				model.PagedBlogs = allItems.Skip((currentPage - 1) * pageSize).Take(pageSize);

				model.Pager = new PagerModel
				{
					CurrentPage = currentPage,
					TotalPages = (int)Math.Ceiling((double)allItems.Count / pageSize)
				};
			}

			return View("~/Views/Blog/BlogListing/Default.cshtml", model);
		}
	}
}