#pragma checksum "C:\Users\Emir\source\repos\ONECORE\OneCoreApp.WEB\Views\Shared\_NotificationPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83c99c4fbc89af82363254da6020da9b3ec98687"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(OneCore.WEB.Pages.Shared.Views_Shared__NotificationPartial), @"mvc.1.0.view", @"/Views/Shared/_NotificationPartial.cshtml")]
namespace OneCore.WEB.Pages.Shared
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
#line 1 "C:\Users\Emir\source\repos\ONECORE\OneCoreApp.WEB\Views\_ViewImports.cshtml"
using OneCore.WEB;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83c99c4fbc89af82363254da6020da9b3ec98687", @"/Views/Shared/_NotificationPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef4424fe80b7205e1462a92733120f1c9e3174d3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__NotificationPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Emir\source\repos\ONECORE\OneCoreApp.WEB\Views\Shared\_NotificationPartial.cshtml"
     if (TempData["notification"] != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Emir\source\repos\ONECORE\OneCoreApp.WEB\Views\Shared\_NotificationPartial.cshtml"
   Write(Html.Raw(TempData["notification"].ToString()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Emir\source\repos\ONECORE\OneCoreApp.WEB\Views\Shared\_NotificationPartial.cshtml"
                                                      ;    
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
