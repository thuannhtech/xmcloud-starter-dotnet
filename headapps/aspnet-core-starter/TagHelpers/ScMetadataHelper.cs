using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.TagHelpers
{
    // ScImageTagHelper.cs
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [HtmlTargetElement("sc-image", Attributes = "asp-for")]
    public class ScImageTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ImageField For { get; set; }

        [HtmlAttributeName("class")]
        public string CssClass { get; set; }

        [HtmlAttributeName("alt")]
        public string AltOverride { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null; // suppress the <sc-image> tag itself

            if (For == null) return;

            var imgSrc = For.Value?.Src;
            var metadata = BuildMetadata(For);

            // Render open metadata code tag
            if (!string.IsNullOrEmpty(metadata))
            {
                output.PreContent.AppendHtml(
                    $"""<code type="text/sitecore" chrometype="field" kind="open" class="scpm">{metadata}</code>"""
                );
            }

            // Render <img>
            if (!string.IsNullOrWhiteSpace(imgSrc))
            {
                var alt = AltOverride ?? For.Value?.Alt ?? string.Empty;
                var cssAttr = !string.IsNullOrEmpty(CssClass) ? $""" class="{CssClass}" """ : string.Empty;
                output.Content.AppendHtml(
                    $"""<img{cssAttr} src="{imgSrc}" alt="{alt}" />"""
                );
            }

            // Render close metadata code tag
            if (!string.IsNullOrEmpty(metadata))
            {
                output.PostContent.AppendHtml(
                    """<code type="text/sitecore" chrometype="field" kind="close" class="scpm"></code>"""
                );
            }
        }

        private static string BuildMetadata(ImageField field)
        {
            if (field?.MetaData == null) return null;

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(field.MetaData, settings);
            var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            var modified = obj.ToDictionary(
                k =>
                {
                    if (k.Key.Equals("DataSource", StringComparison.OrdinalIgnoreCase))
                        return "datasource";

                    return char.ToLowerInvariant(k.Key[0]) + k.Key.Substring(1);
                },
                v => v.Value
            );

            return JsonConvert.SerializeObject(modified);
        }
    }
}
