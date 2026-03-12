namespace Sitecore.AspNetCore.Starter.Models.Common
{
	public class SortOptionItem
	{
		public required string Title { get; set; }

		public required string Value { get; set; }

		public bool IsDefault { get; set; }
	}
}
