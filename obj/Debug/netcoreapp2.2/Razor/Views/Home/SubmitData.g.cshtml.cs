#pragma checksum "c:\Repositories\OxiRNA\OxiRNA\Views\Home\SubmitData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c07e667f11951c8505e7eda5b0c22cd7d9615bad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SubmitData), @"mvc.1.0.view", @"/Views/Home/SubmitData.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/SubmitData.cshtml", typeof(AspNetCore.Views_Home_SubmitData))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07e667f11951c8505e7eda5b0c22cd7d9615bad", @"/Views/Home/SubmitData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5ffc6e6e3b2efded78d1eb9f7447208e57d2188", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SubmitData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/api/SubmitData"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("application/x-www-form-urlencoded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "c:\Repositories\OxiRNA\OxiRNA\Views\Home\SubmitData.cshtml"
  
    ViewData["Title"] = "Submit";

#line default
#line hidden
            BeginContext(42, 2054, true);
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Enter your data</h1>
</div>

<hr class=""line"">
<div class=""table-responsive"">
    <table class=""SubmitTable"">
        <tr>
            <td>
            <tspan>Name</tspan>
            </td>
            <td>
            <input class=""textInputLong"" id=""name""></input>
            </td>
        </tr>
        <tr>
            <td>
            <tspan>Contact</tspan>
            </td>
            <td>
            <input class=""textInputLong"" id=""contact""></input>
            </td>
        </tr>
        <tr>
            <td>
                <tspan>Sequence name*</tspan>
            </td>
            <td>
                <input class=""textInputLong"" id=""sequenceName""></input>
            </td>
        </tr>
        <tr>
            <td>
                <tspan>Genbank id*</tspan>
            </td>
            <td>
                <input class=""textInputLong"" id=""genbank""></input>
            </td>
        </tr>
        <tr>
   ");
            WriteLiteral(@"         <td>
                <tspan>Sequence*</tspan>
            </td>
            <td>
                <div style=""padding: 5px;margin: 5px;"">
                    <input  type=""file"" id=""sequenceFile"" name=""file"" onchange='getStringFromFile(event)'>
                    <input style=""display: None;"" id=""sequenceFileString""></input><br>
                    <tspan>or paste it</tspan>
                </div>
                    
                <div>
                    <input class=""textInputBig"" id=""sequence""></input>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <tspan>Additional information about sequence (not required)</tspan>
            </td>
            <td>
            <input class=""textInputBig"" id=""about""></input>
            </td>
        </tr>
        <tr>
            <td>
                <tspan>Taxon*</tspan>
            </td>
            <td>
                <select style=""width: 300px;"" id=""taxon"">
              ");
            WriteLiteral("      ");
            EndContext();
            BeginContext(2096, 25, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c07e667f11951c8505e7eda5b0c22cd7d9615bad7080", async() => {
                BeginContext(2104, 8, true);
                WriteLiteral("Animalia");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2121, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(2143, 24, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c07e667f11951c8505e7eda5b0c22cd7d9615bad8278", async() => {
                BeginContext(2151, 7, true);
                WriteLiteral("Plantae");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2167, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(2189, 22, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c07e667f11951c8505e7eda5b0c22cd7d9615bad9475", async() => {
                BeginContext(2197, 5, true);
                WriteLiteral("Fungi");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2211, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(2233, 25, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c07e667f11951c8505e7eda5b0c22cd7d9615bad10670", async() => {
                BeginContext(2241, 8, true);
                WriteLiteral("Bacteria");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2258, 1215, true);
            WriteLiteral(@"
                </select>
            </td>
        </tr>
        <tr>
            <td>
            <tspan>Species*</tspan>
            </td>
            <td>
            <input class=""textInputLong"" id=""species""></input>
            </td>
        </tr>
        <tr>
            <td>
            <tspan>Journal*</tspan>
            </td>
            <td>
            <input class=""textInputLong"" id=""journal""></input>
            </td>
        </tr>
        <tr>
            <td>
            <tspan>Article name*</tspan>
            </td>
            <td>
            <input class=""textInputLong"" id=""article""></input>
            </td>
        </tr>
        <tr>
            <td>
            <tspan>Article link*</tspan>
            </td>
            <td>
            <input class=""textInputLong"" id=""articleLink""></input>
            </td>
        </tr>
    </table>        
</div>
<div style=""text-align: center;"">
  <a id=""EmptyFields"" style=""color: Tomato; font-weight: bold; vis");
            WriteLiteral("ibility: hidden;\">Required fields not completed</a>\r\n  </div>\r\n<div style=\"text-align: center;\">\r\n    <button class=\"searchButton\" onclick=\"gatherAndSubmitData()\">SUBMIT</button>\r\n</div> \r\n\r\n");
            EndContext();
            BeginContext(3473, 1024, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c07e667f11951c8505e7eda5b0c22cd7d9615bad13136", async() => {
                BeginContext(3573, 917, true);
                WriteLiteral(@"
    <input style=""display: None;"" name=""name"" id=""nameForm""></input>
    <input style=""display: None;"" name=""contact"" id=""contactForm""></input>
    <input style=""display: None;"" name=""genbank"" id=""genbankForm""></input>
    <input style=""display: None;"" name=""sequenceName"" id=""sequenceNameForm""></input>
    <input style=""display: None;"" name=""sequence"" id=""sequenceForm""></input>
    <input style=""display: None;"" name=""about"" id=""aboutForm""></input>
    <input style=""display: None;"" name=""species"" id=""speciesForm""></input>
    <input style=""display: None;"" name=""taxon"" id=""taxonForm""></input>
    <input style=""display: None;"" name=""article"" id=""articleForm""></input>
    <input style=""display: None;"" name=""articleLink"" id=""articleLinkForm""></input>
    <input style=""display: None;"" name=""journal"" id=""journalForm""></input>
    <input style=""display: None;"" id=""realSubmitButton"" type=""submit""/>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4497, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591