#pragma checksum "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\CodeEntry\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb9f68c7753d9115bd7503f8c2ad6f01161ba1ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CodeEntry_Index), @"mvc.1.0.view", @"/Views/CodeEntry/Index.cshtml")]
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
#nullable restore
#line 1 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\_ViewImports.cshtml"
using DTB.Wedding.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\_ViewImports.cshtml"
using DTB.Wedding.WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb9f68c7753d9115bd7503f8c2ad6f01161ba1ff", @"/Views/CodeEntry/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce6907c33f0e7223a4d0779b5795e8e94236649a", @"/Views/_ViewImports.cshtml")]
    public class Views_CodeEntry_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DTB.Wedding.BL.Models.Guest>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\CodeEntry\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\CodeEntry\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>RSVP Code</h1>\r\n\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Family Code Entry</h1>\r\n    <p>Please enter your family code. Reminder: code is case sensitive and has no spaces.</p>\r\n\r\n");
#nullable restore
#line 17 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\CodeEntry\Index.cshtml"
     using (Html.BeginForm("Index", "RSVPForm"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"text\" id=\"txtFamilyCode\" name=\"txtFamilyCode\" />\r\n        <input type=\"submit\" value=\"Submit Code\">\r\n");
#nullable restore
#line 21 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\CodeEntry\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DTB.Wedding.BL.Models.Guest>> Html { get; private set; }
    }
}
#pragma warning restore 1591