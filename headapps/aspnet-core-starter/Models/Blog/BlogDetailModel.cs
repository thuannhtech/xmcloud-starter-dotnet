using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;

namespace Sitecore.AspNetCore.Starter.Models.Blog
{
	/// <summary>
	/// /sitecore/templates/Feature/Brother/Blog/Brother Blog Template
	/// </summary>
	public class BlogDetailModel : BaseModel
	{
		public TextField? Title { get; set; }

		public ImageField? Thumbnail { get; set; }

		public RichTextField? ContentBody { get; set; }

		public TextField? Url { get; set; }
	}
}