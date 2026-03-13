using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class Menu : BaseModel
    {
        [SitecoreComponentField]
        public HyperLinkField? Link { get; set; }

        [SitecoreComponentField]
        public CheckboxField? ShowInMenu { get; set; }

        [SitecoreComponentField]
        public TextField? Title { get; set; }
    }
}
