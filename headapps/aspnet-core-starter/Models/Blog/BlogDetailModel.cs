using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models.Blog
{
	public class BlogDetailModel : BaseModel
	{
		[SitecoreComponentField]
		public TextField? Title { get; set; }

		[SitecoreComponentField]
		public ImageField? Thumbnail { get; set; }

		[SitecoreComponentField(Name = "ContentBody")] // Khớp chính xác tên field trong Sitecore
		public RichTextField? ContentBody { get; set; }

		[SitecoreComponentField]
		public TextField? Url { get; set; }
	}
}