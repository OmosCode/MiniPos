#pragma checksum "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\Recete\Sepetekle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a04c63a27274aff536f19fcf37aa17854a7f5eca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Recete_Sepetekle), @"mvc.1.0.view", @"/Areas/Member/Views/Recete/Sepetekle.cshtml")]
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
#line 1 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\_ViewImports.cshtml"
using WebApplication2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\_ViewImports.cshtml"
using WebApplication2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\_ViewImports.cshtml"
using WebApplication2.Areas.Member.Models.VMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\_ViewImports.cshtml"
using WebApplication2.Areas.Member.Models.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\_ViewImports.cshtml"
using Model.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a04c63a27274aff536f19fcf37aa17854a7f5eca", @"/Areas/Member/Views/Recete/Sepetekle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09c942cfd6617a7f46ec8b7e5c9867a091c04d26", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Recete_Sepetekle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Basket>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""callout callout-info"">
                    <h5><i class=""fas fa-info""></i> Note:</h5>
                    This page has been enhanced for printing. Click the print button at the bottom of the invoice to test.
                </div>

                <div class=""invoice p-3 mb-3"">






");
#nullable restore
#line 18 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\Recete\Sepetekle.cshtml"
                     foreach (var item in Model)
                    {





#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-12 table-responsive"">
                <table class=""table table-striped"">
                    <thead>
                        <tr>
                            <th>Ürün </th>
                            <th>adet</th>
                            <th>Birim Fiyatı</th>
                            <th>Toplam Tutar</th>


                        </tr>
                    </thead>
                    <tbody>
                        <tr>

                            <td>");
#nullable restore
#line 40 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\Recete\Sepetekle.cshtml"
                           Write(item.UrunAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 41 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\Recete\Sepetekle.cshtml"
                           Write(item.Adet);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 42 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\Recete\Sepetekle.cshtml"
                           Write(item.Fiyat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 43 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\Recete\Sepetekle.cshtml"
                           Write(item.ToplamTutar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                        </tr>\n\n\n                    </tbody>\n                </table>\n            </div>\n\n        </div>");
#nullable restore
#line 52 "C:\Users\OGUZHAN\source\repos\Pos\WebApplication2\Areas\Member\Views\Recete\Sepetekle.cshtml"
              }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row\">\n\n\n\n\n\n                        <div class=\"row no-print\">\n\n                        </div>\n                    </div>\n\n                </div>\n            </div>\n        </div>\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Basket>> Html { get; private set; }
    }
}
#pragma warning restore 1591
