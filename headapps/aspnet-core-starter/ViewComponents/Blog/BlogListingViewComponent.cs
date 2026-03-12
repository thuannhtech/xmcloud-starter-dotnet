using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding;
using Sitecore.AspNetCore.Starter.Models.Blog;
using Sitecore.AspNetCore.Starter.Models.Common;

namespace Sitecore.AspNetCore.Starter.Components.Blog
{
	[ViewComponent(Name = ViewComponentName)]
	public class BlogListingViewComponent(IViewModelBinder binder) : ViewComponent
	{
		public const string ViewComponentName = "BlogListing";

		private const int PageSize = 6;

		public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
		{
			var model = await binder.Bind<BlogListingModel>(ViewContext);
			model ??= new BlogListingModel();

			int currentPage = GetCurrentPage();
			string selectedSort = GetSelectedSort();

			if (model.Blogs != null)
			{
				var allItems = model.Blogs
					.Where(i => i.Fields.Count > 0)
					.ToList();

				BuildSortOptions(model, ref selectedSort);

				allItems = ApplySorting(allItems, selectedSort);

				ApplyPagination(model, allItems, currentPage);
			}

			model.SelectedSort = selectedSort;

			return View("~/Views/Blog/BlogListing/Default.cshtml", model);
		}

		private int GetCurrentPage()
		{
			return int.TryParse(ViewContext.HttpContext.Request.Query["page"], out var p) ? p : 1;
		}

		private string GetSelectedSort()
		{
			return ViewContext.HttpContext.Request.Query["sort"].ToString();
		}

		private void BuildSortOptions(BlogListingModel model, ref string selectedSort)
		{
			if (model.SortOptions == null)
				return;

			var sortOptions = model.SortOptions.Select(i =>
			{
				var title = i.ReadField<TextField>("Title");
				var value = i.ReadField<TextField>("Value");
				var isDefault = i.ReadField<CheckboxField>("IsDefault");

				return new SortOptionItem
				{
					Title = title?.Value ?? string.Empty,
					Value = value?.Value ?? string.Empty,
					IsDefault = isDefault?.Value ?? false
				};
			}).ToList();

			model.SortDropDownOptions = sortOptions;

			if (string.IsNullOrEmpty(selectedSort))
			{
				selectedSort = sortOptions
					.FirstOrDefault(x => x.IsDefault)?.Value ?? "date_desc";
			}
		}

		private List<ItemLinkField> ApplySorting(List<ItemLinkField> items, string sort)
		{
			return sort switch
			{
				"title_asc" => items
					.OrderBy(x => x.ReadField<TextField>("Title")?.Value)
					.ToList(),

				"title_desc" => items
					.OrderByDescending(x => x.ReadField<TextField>("Title")?.Value)
					.ToList(),

				"date_asc" => items
					.OrderBy(x => x.ReadField<DateField>("PublishDate")?.Value)
					.ToList(),

				_ => items
					.OrderByDescending(x => x.ReadField<DateField>("PublishDate")?.Value)
					.ToList()
			};
		}

		private void ApplyPagination(BlogListingModel model, List<ItemLinkField> items, int currentPage)
		{
			model.PagedBlogs = items
				.Skip((currentPage - 1) * PageSize)
				.Take(PageSize);

			model.Pager = new PagerModel
			{
				CurrentPage = currentPage,
				TotalPages = (int)Math.Ceiling((double)items.Count / PageSize)
			};
		}
	}
}