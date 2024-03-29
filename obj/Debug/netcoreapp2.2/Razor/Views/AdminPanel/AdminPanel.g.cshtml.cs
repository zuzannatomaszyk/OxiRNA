#pragma checksum "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ceaf448b253ede7c5701d64f133f77caf69cced9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminPanel_AdminPanel), @"mvc.1.0.view", @"/Views/AdminPanel/AdminPanel.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AdminPanel/AdminPanel.cshtml", typeof(AspNetCore.Views_AdminPanel_AdminPanel))]
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
#line 1 "c:\Repositories\OxiRNA\OxiRNA\Views\_ViewImports.cshtml"
using OxiRNA;

#line default
#line hidden
#line 2 "c:\Repositories\OxiRNA\OxiRNA\Views\_ViewImports.cshtml"
using OxiRNA.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ceaf448b253ede7c5701d64f133f77caf69cced9", @"/Views/AdminPanel/AdminPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5ffc6e6e3b2efded78d1eb9f7447208e57d2188", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminPanel_AdminPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TemporaryTableModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
  
      ViewData["Title"] = "AdminPanel";

#line default
#line hidden
            BeginContext(82, 676, true);
            WriteLiteral(@"<h1 class=""display-4"">OxiRNA</h1>


<div>
    <a class=""downloadButtonAdmin"" href=""/AdminPanel/AcceptData?id="">Accept all data and insert into OxiRNA database</a>
    <a class=""downloadButtonAdmin"" href=""/AdminPanel/RejectData?id="">Reject and dalete all data</a>
</div>

<div class=""table-responsive"">
    <table class=""ResultTable"">
        <tr>
            <th>Name</th>
            <th>Contact</th>
            <th>Genbank id</th>
            <th>Sequence name</th>
            <th>Sequence</th>
            <th>About</th>
            <th>Species</th>
            <th>Taxon</th>
            <th>Article</th>
            <th>Journal</th>
        </tr>
");
            EndContext();
#line 27 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
   foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(797, 11, true);
            WriteLiteral("        <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 808, "\"", 821, 1);
#line 29 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
WriteAttributeValue("", 813, item.id, 813, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(822, 37, true);
            WriteLiteral(">\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(860, 9, false);
#line 31 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.name);

#line default
#line hidden
            EndContext();
            BeginContext(869, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(925, 12, false);
#line 34 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.contact);

#line default
#line hidden
            EndContext();
            BeginContext(937, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(993, 12, false);
#line 37 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.genbank);

#line default
#line hidden
            EndContext();
            BeginContext(1005, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1061, 17, false);
#line 40 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.sequenceName);

#line default
#line hidden
            EndContext();
            BeginContext(1078, 80, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a>\r\n                    ");
            EndContext();
            BeginContext(1159, 13, false);
#line 44 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
               Write(item.sequence);

#line default
#line hidden
            EndContext();
            BeginContext(1172, 61, true);
            WriteLiteral("\r\n                </a>\r\n            </td>\r\n            <td>\r\n");
            EndContext();
#line 48 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
               if(!String.IsNullOrEmpty(item.about)) {

#line default
#line hidden
            BeginContext(1289, 73, true);
            WriteLiteral("                <div class=\"my-tooltip\">INFO<span class=\"my-tooltiptext\">");
            EndContext();
            BeginContext(1363, 10, false);
#line 49 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
                                                                    Write(item.about);

#line default
#line hidden
            EndContext();
            BeginContext(1373, 15, true);
            WriteLiteral("</span></div>\r\n");
            EndContext();
#line 50 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
              }

#line default
#line hidden
            BeginContext(1405, 53, true);
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1459, 12, false);
#line 53 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.species);

#line default
#line hidden
            EndContext();
            BeginContext(1471, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1527, 10, false);
#line 56 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.taxon);

#line default
#line hidden
            EndContext();
            BeginContext(1537, 65, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a href = ");
            EndContext();
            BeginContext(1603, 16, false);
#line 59 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
                     Write(item.articleLink);

#line default
#line hidden
            EndContext();
            BeginContext(1619, 70, true);
            WriteLiteral(" target=\"_blank\" rel=\"noopener noreferrer nofollow\">\r\n                ");
            EndContext();
            BeginContext(1690, 12, false);
#line 60 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.article);

#line default
#line hidden
            EndContext();
            BeginContext(1702, 77, true);
            WriteLiteral("\r\n                </a>\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1780, 12, false);
#line 64 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
           Write(item.journal);

#line default
#line hidden
            EndContext();
            BeginContext(1792, 133, true);
            WriteLiteral("\r\n            </td>\r\n             <td>\r\n                <a style=\"border-right:1px solid #ddd; color: LightGreen; font-weight: bold;\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1925, "\"", 1966, 2);
            WriteAttributeValue("", 1932, "/AdminPanel/AcceptData?id=", 1932, 26, true);
#line 67 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
WriteAttributeValue("", 1958, item.id, 1958, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1967, 111, true);
            WriteLiteral(">ACCEPT</a>\r\n            </td>\r\n             <td>\r\n                <a style=\"color: Tomato; font-weight: bold;\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2078, "\"", 2119, 2);
            WriteAttributeValue("", 2085, "/AdminPanel/RejectData?id=", 2085, 26, true);
#line 70 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
WriteAttributeValue("", 2111, item.id, 2111, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2120, 47, true);
            WriteLiteral(">REJECT</a>\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 73 "c:\Repositories\OxiRNA\OxiRNA\Views\AdminPanel\AdminPanel.cshtml"
    }

#line default
#line hidden
            BeginContext(2174, 22, true);
            WriteLiteral("    </table>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TemporaryTableModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
