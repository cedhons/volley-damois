#pragma checksum "D:\devWebB2\VolleyDamois\VolleyDamois\Views\Shared\_TitleLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b6016ad91f20d7664bfa8f8d9b0c96a5df1fe32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TitleLayout), @"mvc.1.0.view", @"/Views/Shared/_TitleLayout.cshtml")]
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
#line 1 "D:\devWebB2\VolleyDamois\VolleyDamois\Views\_ViewImports.cshtml"
using VolleyDamois;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\devWebB2\VolleyDamois\VolleyDamois\Views\_ViewImports.cshtml"
using VolleyDamois.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b6016ad91f20d7664bfa8f8d9b0c96a5df1fe32", @"/Views/Shared/_TitleLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22dbc4b75b9df700fdbb9af72bd2d66a362b00b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TitleLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\devWebB2\VolleyDamois\VolleyDamois\Views\Shared\_TitleLayout.cshtml"
  
    Layout = "/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"page-title\">");
#nullable restore
#line 4 "D:\devWebB2\VolleyDamois\VolleyDamois\Views\Shared\_TitleLayout.cshtml"
                  Write(ViewData["DisplayedTitle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 5 "D:\devWebB2\VolleyDamois\VolleyDamois\Views\Shared\_TitleLayout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(" \r\n    ");
#nullable restore
#line 7 "D:\devWebB2\VolleyDamois\VolleyDamois\Views\Shared\_TitleLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
