using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.TagHelpers
{
    [HtmlTargetElement("sc-field-wrapper")]
    public class SitecoreFieldWrapperTagHelper : TagHelper
    {
        [HtmlAttributeName("metadata")]
        public object MetaData { get; set; }

        [HtmlAttributeName("is-editing")]
        public bool IsEditing { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // By default, do not output the <sc-field-wrapper> container element itself.
            output.TagName = null;

            // Wait for all inner HTML elements to finish rendering inside our tag wrapper.
            var childContent = await output.GetChildContentAsync();

            // If not in edit mode or missing metadata, just output the normal HTML exactly as-is.
            if (!IsEditing || MetaData == null)
            {
                output.Content.SetHtmlContent(childContent.GetContent());
                return;
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(MetaData, settings);
            var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            var modified = obj.ToDictionary(
                k => k.Key.Equals("DataSource", StringComparison.OrdinalIgnoreCase)
                    ? "datasource"
                    : char.ToLowerInvariant(k.Key[0]) + k.Key.Substring(1),
                v => v.Value
            );

            var metadataJson = JsonConvert.SerializeObject(modified);

            // Reconstruct the HTML output wrapped precisely in Sitecore editor JSON tags. 
            // This mirrors EXACTLY what you were writing inline inside Default.cshtml.
            output.Content.SetHtmlContent(
                $"<code type=\"text/sitecore\" chrometype=\"field\" kind=\"open\" class=\"scpm\">{metadataJson}</code>" +
                $"\n{childContent.GetContent()}\n" +
                $"<code type=\"text/sitecore\" chrometype=\"field\" kind=\"close\" class=\"scpm\"></code>"
            );
        }
    }
}
