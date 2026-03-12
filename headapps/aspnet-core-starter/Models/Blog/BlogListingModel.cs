using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using Sitecore.AspNetCore.Starter.Models.Common;

namespace Sitecore.AspNetCore.Starter.Models.Blog
{
	public class BlogListingModel : BaseModel
	{
		[SitecoreComponentField(Name = "Title")]
		public TextField? Title { get; set; }

		[SitecoreComponentField(Name = "items")]
		public ContentListField? Blogs { get; set; } = new ContentListField();

		public IEnumerable<ItemLinkField> PagedBlogs { get; set; } = Enumerable.Empty<ItemLinkField>();

		public PagerModel Pager { get; set; } = new PagerModel();
	}
}