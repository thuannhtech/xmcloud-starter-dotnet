using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class MenuHeaderBar : BaseModel
    {
        public const string VARIANT_DEFAULT = "Default";

        [SitecoreComponentField]
        public ImageField? Text { get; set; }

        [SitecoreComponentField]
        public ContentListField? Languages { get; set; }
    }
}
