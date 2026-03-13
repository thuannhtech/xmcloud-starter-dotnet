using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class MenuFolder : BaseModel
    {
        [SitecoreComponentField(Name = "items")]
        public ContentListField<Menu> Menus { get; set; }
    }
}
