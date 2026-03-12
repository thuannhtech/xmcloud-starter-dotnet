using Sitecore.AspNetCore.Starter.Models.Common;

namespace Sitecore.AspNetCore.Starter.Models.Blog
{
	public class SortDropdownModel
	{
		public List<SortOptionItem> Options { get; set; } = new();

		public string? SelectedSort { get; set; }
	}
}
