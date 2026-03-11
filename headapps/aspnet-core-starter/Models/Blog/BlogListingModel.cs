using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace Sitecore.AspNetCore.Starter.Models.Blog
{
	public class BlogListingModel: BaseModel
	{
		[SitecoreComponentField(Name = "Title")]
		public TextField? Title { get; set; }

		[SitecoreComponentField(Name = "items")]
		public ContentListField? Blogs { get; set; } = new ContentListField();
	}
}