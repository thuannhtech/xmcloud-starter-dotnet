using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class Slider : BaseModel
    {
        [SitecoreComponentField]
        public ImageField? Logo { get; set; }

        [SitecoreComponentField]
        public TextField? Test { get; set; }

    }
}
