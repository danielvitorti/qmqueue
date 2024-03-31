#pragma checksum "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52ca8865a8dd329f7f70102e1737d60ce3616bc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Qmq_Monitor), @"mvc.1.0.view", @"/Views/Qmq/Monitor.cshtml")]
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
#line 1 "C:\projetos\net\QMessage\App\Views\_ViewImports.cshtml"
using QMessage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\projetos\net\QMessage\App\Views\_ViewImports.cshtml"
using QMessage.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52ca8865a8dd329f7f70102e1737d60ce3616bc9", @"/Views/Qmq/Monitor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e92fb154446bf621934c143896ce82081b1bda8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Qmq_Monitor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Qmq/Monitor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
  
    ViewData["Title"] = "Monitor";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>QMQ Monitor</h1>

    <div class=""card-header with-border"">
        <h5 class=""card-title text-center"">Mensagens de Entrada</h5>
        <div class=""card-tools"">
          <!--  <button type=""button"" class=""btn btn-primary btn-sm"" data-card-widget=""collapse"" title=""Collapse"">
                <i class=""fas fa-minus""></i>
            </button> -->
        </div>
    </div>
    
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-lg-3"">
                <label>Mensagem</label>
                <select name=""MessageTypeQmqInHeader"" id=""MessageTypeQmqInHeader"" class=""form-control"">
                </select>
            </div>
            <div class=""col-lg-3"">
                <label>De</label>
                <input type=""text"" name=""dtIniIn"" id=""dtIniIn"" class=""form-control data"" />
            </div>
            <div class=""col-lg-3"">
                <label>Até</label>
                <input type=""text"" name=""dtFinIn"" id=""dtFinIn"" class=""form-control data");
            WriteLiteral(@""" />
            </div>
        </div>
    </div>
    <div class=""card-footer"">
        <button type=""button"" class=""btn btn-primary pull-left"" name=""btnSearchMessageIn"" id=""btnSearchMessageIn"">
            <i class=""fa fa-search""></i> Buscar
        </button>
        <button type=""button"" class=""btn btn-default pull-right"" name=""btnCleanMessageIn"" id=""btnCleanMessageIn"">
            <i class=""fa fa-recycle""></i> Limpar
        </button>
        <button type=""button"" class=""btn btn-default pull-right updatePage"" name=""updatePage"" id=""updatePage"">
            <i class=""fa fa-circle""></i> Atualizar página
        </button>
    </div>


<table class=""table"" id=""dataTableMessageIn"">
    <thead>
        <tr>
<th>
                Sistema de Origem
            </th>
            <th>
                Id Mensagem
            </th>
            <th>
                Sistema de Destino
            </th>
            <th>
                Código da Mensagem
            </th>
            <th>
 ");
            WriteLiteral(@"               Observação
            </th>
            <th>
                Status
            </th>
            <th>
                Data de Processamento
            </th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>



    <div class=""card-header with-border"">
        <h5 class=""card-title text-center"">Mensagens de saída</h5>
        <div class=""card-tools"">
          <!--  <button type=""button"" class=""btn btn-primary btn-sm"" data-card-widget=""collapse"" title=""Collapse"">
                <i class=""fas fa-minus""></i>
            </button> -->
        </div>
    </div>
    
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-lg-3"">
                <label>Mensagem</label>
                <select name=""MessageTypeQmqOutHeader"" id=""MessageTypeQmqOutHeader"" class=""form-control"">
                </select>
            </div>
            <div class=""col-lg-3"">
                <label>De</label>
                <input type=""text"" name=""dt");
            WriteLiteral(@"IniOut"" id=""dtIniOut"" class=""form-control data"" />
            </div>
            <div class=""col-lg-3"">
                <label>Até</label>
                <input type=""text"" name=""dtFinOut"" id=""dtFinOut"" class=""form-control data"" />
            </div>
        </div>
    </div>

    <div class=""card-footer"">
        <button type=""button"" class=""btn btn-primary pull-left"" name=""btnSearchMessageOut"" id=""btnSearchMessageOut"">
            <i class=""fa fa-search""></i> Buscar
        </button>
        <button type=""button"" class=""btn btn-default pull-right"" name=""btnCleanMessageOut"" id=""btnCleanMessageOut"">
            <i class=""fa fa-recycle""></i> Limpar
        </button>
        <button type=""button"" class=""btn btn-default pull-right updatePage"" name=""btnMessageOut"" id=""btnMessageOut"">
            <i class=""fa fa-circle""></i> Atualizar página
        </button>
    </div>

<table class=""table"" id=""dataTableMessageOut"">
    <thead>
        <tr>
            <th>
                Sistema de Or");
            WriteLiteral(@"igem
            </th>
            <th>
                Id Mensagem
            </th>
            <th>
                Sistema de Destino
            </th>
            <th>
                Código da Mensagem
            </th>
            <th>
                Observação
            </th>
            <th>
                Status
            </th>
            <th>
                Data de Processamento
            </th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>


<input type=""hidden"" name=""Index"" id=""Index""");
            BeginWriteAttribute("value", " value=\"", 4694, "\"", 4730, 1);
#nullable restore
#line 149 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
WriteAttributeValue("", 4702, Url.Action("Monitor","Qmq"), 4702, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" name=\"GetQmqInHeaderMessageType\" id=\"GetQmqInHeaderMessageType\"");
            BeginWriteAttribute("value", " value=\"", 4820, "\"", 4874, 1);
#nullable restore
#line 150 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
WriteAttributeValue("", 4828, Url.Action("GetQmqInHeaderMessageType","Qmq"), 4828, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" name=\"GetQmqOutHeaderMessageType\" id=\"GetQmqOutHeaderMessageType\"");
            BeginWriteAttribute("value", " value=\"", 4966, "\"", 5021, 1);
#nullable restore
#line 151 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
WriteAttributeValue("", 4974, Url.Action("GetQmqOutHeaderMessageType","Qmq"), 4974, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" name=\"GetMessageInBodyByMessageId\" id=\"GetMessageInBodyByMessageId\"");
            BeginWriteAttribute("value", " value=\"", 5115, "\"", 5171, 1);
#nullable restore
#line 152 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
WriteAttributeValue("", 5123, Url.Action("GetMessageInBodyByMessageId","Qmq"), 5123, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" name=\"GetDataQmqInHeaderByMessageTypeAndPeriod\" id=\"GetDataQmqInHeaderByMessageTypeAndPeriod\"");
            BeginWriteAttribute("value", " value=\"", 5291, "\"", 5360, 1);
#nullable restore
#line 153 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
WriteAttributeValue("", 5299, Url.Action("GetDataQmqInHeaderByMessageTypeAndPeriod","Qmq"), 5299, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" name=\"GetDataQmqOutHeaderByMessageTypeAndPeriod\" id=\"GetDataQmqOutHeaderByMessageTypeAndPeriod\"");
            BeginWriteAttribute("value", " value=\"", 5482, "\"", 5552, 1);
#nullable restore
#line 154 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
WriteAttributeValue("", 5490, Url.Action("GetDataQmqOutHeaderByMessageTypeAndPeriod","Qmq"), 5490, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"hidden\" name=\"GetMessageOutBodyByMessageId\" id=\"GetMessageOutBodyByMessageId\"");
            BeginWriteAttribute("value", " value=\"", 5648, "\"", 5705, 1);
#nullable restore
#line 155 "C:\projetos\net\QMessage\App\Views\Qmq\Monitor.cshtml"
WriteAttributeValue("", 5656, Url.Action("GetMessageOutBodyByMessageId","Qmq"), 5656, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52ca8865a8dd329f7f70102e1737d60ce3616bc911835", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
