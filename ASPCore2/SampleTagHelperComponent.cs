using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore2
{
    public class SampleTagHelperComponent: TagHelperComponent
    {
        public override int Order => 100;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml("<link rel='stylesheet' type='text/css' href='miniprofiler.css'></link>");
            }
            if (string.Equals(context.TagName, "body", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml("<script src='miniprofiler.js'></script>");
            }
            if (string.Equals(context.TagName, "footer", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml("<p>Modified in a TagHelperComponent</p>");
            }
        }
    }

    [HtmlTargetElement("footer")]
    public class FooterTagHelper: TagHelperComponentTagHelper
    {
        public FooterTagHelper(
            ITagHelperComponentManager manager,
            ILoggerFactory logger) : base(manager, logger) { }
    }
}
