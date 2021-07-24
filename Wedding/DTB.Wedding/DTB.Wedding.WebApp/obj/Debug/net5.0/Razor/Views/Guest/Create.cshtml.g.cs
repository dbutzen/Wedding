#pragma checksum "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "880d601fb82c7081eef614b81a700901ee59cf51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Guest_Create), @"mvc.1.0.view", @"/Views/Guest/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"880d601fb82c7081eef614b81a700901ee59cf51", @"/Views/Guest/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce6907c33f0e7223a4d0779b5795e8e94236649a", @"/Views/_ViewImports.cshtml")]
    public class Views_Guest_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTB.Wedding.WebApp.ViewModels.GuestFamilyTableViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
  
    ViewData["Title"] = "Create New Guest";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<hr />\r\n\r\n");
#nullable restore
#line 11 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
 using (Html.BeginForm("Create", "Guest"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-horizontal\">\r\n    <hr />\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 17 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
   Write(Html.LabelFor(model => model.Guest.Name, new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 19 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
       Write(Html.EditorFor(model => model.Guest.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 20 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
       Write(Html.ValidationMessageFor(model => model.Guest.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <div>\r\n                Has plus one\r\n                ");
#nullable restore
#line 28 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
           Write(Html.RadioButtonFor(model => model.Guest.PlusOne, "true", new { @class = "form-control col-md-4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 29 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Guest.Name, "", new { @class = "text-danger col-md-4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div>\r\n                No plus one\r\n                ");
#nullable restore
#line 33 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
           Write(Html.RadioButtonFor(model => model.Guest.PlusOne, "false", new { @class = "form-control col-md-4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 35 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Guest.Name, "", new { @class = "text-danger col-md-4" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 41 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
   Write(Html.LabelFor(model => model.Families, new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 43 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
       Write(Html.DropDownListFor(model => model.Guest.FamilyId, new SelectList(Model.Families, "Id", "Name", Model.Guest), null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 44 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
       Write(Html.ValidationMessageFor(model => model.Guest.FamilyId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" value=\"Create\" class=\"btn btn-default btn-primary\" />\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 54 "C:\tfs\WeddingWebsite\Wedding\DTB.Wedding\DTB.Wedding.WebApp\Views\Guest\Create.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "880d601fb82c7081eef614b81a700901ee59cf518497", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTB.Wedding.WebApp.ViewModels.GuestFamilyTableViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
