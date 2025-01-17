#pragma checksum "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "710e36f9f3647d3d143b493b4ab2df3c2c0792a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
#line 1 "C:\Users\hp\source\repos\DashboardWeb\Views\_ViewImports.cshtml"
using DashboardWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\source\repos\DashboardWeb\Views\_ViewImports.cshtml"
using DashboardWeb.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\source\repos\DashboardWeb\Views\_ViewImports.cshtml"
using DashboardWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\source\repos\DashboardWeb\Views\_ViewImports.cshtml"
using DashboardWeb.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hp\source\repos\DashboardWeb\Views\_ViewImports.cshtml"
using DashboardWeb.Controllers.API;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"710e36f9f3647d3d143b493b4ab2df3c2c0792a9", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1846f13053a8fb4cbf01fd857b68c494f55bb851", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"d-flex align-items-center box-shadow border p-4 ml-4 mb-4\">\r\n");
#nullable restore
#line 7 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
     foreach (var item in Model.Response.AllUsers)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"mr-4 border\" style=\"width:150px;height:150px;overflow:hidden;border-radius:100%\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "710e36f9f3647d3d143b493b4ab2df3c2c0792a94705", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral("~/images/");
#nullable restore
#line 10 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
                   WriteLiteral(item.Photo);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 426, "\"", 434, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n\r\n            <h1>");
#nullable restore
#line 15 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
           Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 15 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
                           Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n            <div>\r\n                <span class=\"user-details\">\r\n                    Job Role: User\r\n                </span>\r\n                <span class=\"user-details\">Email: ");
#nullable restore
#line 21 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
                                             Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span class=\"user-details\">Date Created: ");
#nullable restore
#line 22 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
                                                    Write(item.DateCreated.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 25 "C:\Users\hp\source\repos\DashboardWeb\Views\Account\Profile.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.UserManager<UserModel> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.SignInManager<UserModel> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
