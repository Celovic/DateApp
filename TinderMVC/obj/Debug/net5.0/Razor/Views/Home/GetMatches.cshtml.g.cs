#pragma checksum "C:\Users\celal\source\repos\Tinder.Data\TinderMVC\Views\Home\GetMatches.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c8379dc4dc55a685e5f310991c8913cbef88190"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetMatches), @"mvc.1.0.view", @"/Views/Home/GetMatches.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c8379dc4dc55a685e5f310991c8913cbef88190", @"/Views/Home/GetMatches.cshtml")]
    public class Views_Home_GetMatches : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Tinder.Data.Entities.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\celal\source\repos\Tinder.Data\TinderMVC\Views\Home\GetMatches.cshtml"
      
    ViewData["Title"] = "Index";
    Layout = "~/Views/_Layout.cshtml";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\celal\source\repos\Tinder.Data\TinderMVC\Views\Home\GetMatches.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"margin-top:20%\"></div>\r\n    <table>\r\n        <tr>\r\n            <td>Your Matched User Name</td>\r\n            <td>Send Message</td>\r\n        </tr>\r\n        <tr style=\"margin-top:15%;\">\r\n            <td>");
#nullable restore
#line 16 "C:\Users\celal\source\repos\Tinder.Data\TinderMVC\Views\Home\GetMatches.cshtml"
           Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a class=\"btn btn-light\"");
            BeginWriteAttribute("href", " href=\"", 450, "\"", 476, 2);
            WriteAttributeValue("", 457, "/Home/Chat/", 457, 11, true);
#nullable restore
#line 17 "C:\Users\celal\source\repos\Tinder.Data\TinderMVC\Views\Home\GetMatches.cshtml"
WriteAttributeValue("", 468, item.Id, 468, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Send Message</a></td>\r\n        </tr>\r\n    </table>\r\n");
#nullable restore
#line 20 "C:\Users\celal\source\repos\Tinder.Data\TinderMVC\Views\Home\GetMatches.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Tinder.Data.Entities.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
