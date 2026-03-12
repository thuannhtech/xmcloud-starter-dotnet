namespace Sitecore.AspNetCore.Starter.Models.Common
{
	public class PagerModel
	{
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public string BaseUrl { get; set; } = "";
	}
}
