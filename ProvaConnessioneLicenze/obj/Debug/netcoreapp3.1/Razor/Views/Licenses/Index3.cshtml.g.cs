#pragma checksum "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f3f7307f445703da47d0de03c4b0eadf272295c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Licenses_Index3), @"mvc.1.0.view", @"/Views/Licenses/Index3.cshtml")]
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
#line 1 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\_ViewImports.cshtml"
using ProvaConnessioneLicenze;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\_ViewImports.cshtml"
using ProvaConnessioneLicenze.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f3f7307f445703da47d0de03c4b0eadf272295c", @"/Views/Licenses/Index3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98884349e1e892c3c7563dbe7c87bc511ea2f196", @"/Views/_ViewImports.cshtml")]
    public class Views_Licenses_Index3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProvaConnessioneLicenze.Models.License>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-customerid", new global::Microsoft.AspNetCore.Html.HtmlString("0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("customer-edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
  
    ViewData["Title"] = "Licenze";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en-US\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3f7307f445703da47d0de03c4b0eadf272295c6503", async() => {
                WriteLiteral(@"
    <link href=""https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.3.1/css/bootstrap.min.css"" rel=""stylesheet"">
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <title>Bootstrap Simple Data Table</title>
    <link href=""https://fonts.googleapis.com/css?family=Roboto"" rel=""stylesheet"">
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/icon?family=Material+Icons"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js""></script>
    <link rel=""stylesheet"" type=""text/css"" href=""../DataTables/DataTables-1.10.20/css/jquery.dataTables.css");
                WriteLiteral(@""" />
    <script type=""text/javascript"" charset=""utf8"" src=""../DataTables/DataTables-1.10.20/js/jquery.dataTables.js""></script>

    <style>

        body {
            color: #566787;
            background: #f5f5f5;
            font-family: 'Roboto', sans-serif;
        }

        .table-responsive {
            margin: 30px 0;
        }

        .table-wrapper {
            min-width: 1000px;
            background: #fff;
            padding: 20px;
            box-shadow: 0 1px 1px rgba(0,0,0,.05);
        }

        .table-title {
            padding-bottom: 10px;
            margin: 0 0 10px;
        }

            .table-title h2 {
                margin: 8px 0 0;
                font-size: 22px;
            }

        .search-box {
            position: relative;
            float: right;
        }

            .search-box input {
                height: 34px;
                border-radius: 20px;
                padding-left: 35px;
                border-color: ");
                WriteLiteral(@"#ddd;
                box-shadow: none;
            }

                .search-box input:focus {
                    border-color: #3FBAE4;
                }

            .search-box i {
                color: #a0a5b1;
                position: absolute;
                font-size: 19px;
                top: 8px;
                left: 10px;
            }

        table.table tr th, table.table tr td {
            border-color: #e9e9e9;
        }

        table.table-striped tbody tr:nth-of-type(odd) {
            background-color: #fcfcfc;
        }

        table.table-striped.table-hover tbody tr:hover {
            background: #f5f5f5;
        }

        table.table th i {
            font-size: 13px;
            margin: 0 5px;
            cursor: pointer;
        }

        table.table td:last-child {
            width: 130px;
        }

        table.table td a {
            color: #a0a5b1;
            display: inline-block;
            margin: 0 5px;
        }
");
                WriteLiteral(@"
            table.table td a.view {
                color: #03A9F4;
            }

            table.table td a.edit {
                color: #FFC107;
            }

            table.table td a.delete {
                color: #E34724;
            }

        table.table td i {
            font-size: 19px;
        }

        .pagination {
            float: right;
            margin: 0 0 5px;
        }

            .pagination li a {
                border: none;
                font-size: 95%;
                width: 30px;
                height: 30px;
                color: #999;
                margin: 0 2px;
                line-height: 30px;
                border-radius: 30px !important;
                text-align: center;
                padding: 0;
            }

                .pagination li a:hover {
                    color: #666;
                }

            .pagination li.active a {
                background: #03A9F4;
            }

                .p");
                WriteLiteral(@"agination li.active a:hover {
                    background: #0397d6;
                }

            .pagination li.disabled i {
                color: #ccc;
            }

            .pagination li i {
                font-size: 16px;
                padding-top: 6px
            }

        .hint-text {
            float: left;
            margin-top: 6px;
            font-size: 95%;
        }
    </style>
    <script>
        $(document).ready(function () {
            $('[data-toggle=""tooltip""]').tooltip();
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3f7307f445703da47d0de03c4b0eadf272295c12321", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""table-responsive"">
            <div class=""table-wrapper"">
                <div class=""table-title"">
                    <div class=""col-sm-8""><h2><b>Elenco Licenze</b></h2></div>
                    <br /><br /><br />
                    <div class=""col-sm-12"">
                        <div class=""row"">
                            <div class=""col-lg-4 "">
                                <div class=""input-group "">
                                    <input type=""search"" placeholder=""Search..."" class=""form-control search-input"" data-table=""customers-list"" />
                                </div>
                            </div>
                            <div class=""col-lg-8 text-right"">
                                <span>Totale elementi: ");
#nullable restore
#line 188 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                                                  Write(Model.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                <button type=""button"" class=""btn btn-info"" data-toggle=""customer-search"">
                                    <i class=""fa fa-search"" aria-hidden=""true""></i>
                                </button>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3f7307f445703da47d0de03c4b0eadf272295c14025", async() => {
                    WriteLiteral("\r\n                                    <i class=\"fa fa-plus-square\" aria-hidden=\"true\"></i>\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
                <br />

                <table id=""ciao"" class=""table table-striped table-hover table-bordered mt32 customers-list"">
                    <thead>
                        <tr>
                            <th>
                                Stato
                            </th>
                            <th>
                                ");
#nullable restore
#line 209 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                           Write(Html.DisplayNameFor(model => model.Activationcode));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 212 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                           Write(Html.DisplayNameFor(model => model.Duedate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 215 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                           Write(Html.DisplayNameFor(model => model.Licensetype));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 218 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                           Write(Html.DisplayNameFor(model => model.Customerid));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                Utente\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 224 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                           Write(Html.DisplayNameFor(model => model.Locked));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>Azioni</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 230 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ...\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 237 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Activationcode));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 240 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Duedate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 243 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Licensetype));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 246 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Customerid));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ...\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 252 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Locked));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3f7307f445703da47d0de03c4b0eadf272295c21569", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 257 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                                                           WriteLiteral(item.Customerid);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" |\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3f7307f445703da47d0de03c4b0eadf272295c23926", async() => {
                    WriteLiteral("Details");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 258 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                                                              WriteLiteral(item.Customerid);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" |\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f3f7307f445703da47d0de03c4b0eadf272295c26289", async() => {
                    WriteLiteral("Delete");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 259 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                                                             WriteLiteral(item.Customerid);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 262 "C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\Views\Licenses\Index3.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <script>
        (function (document) {
            'use strict';

            var TableFilter = (function (myArray) {
                var search_input;

                function _onInputSearch(e) {
                    search_input = e.target;
                    var tables = document.getElementsByClassName(search_input.getAttribute('data-table'));
                    myArray.forEach.call(tables, function (table) {
                        myArray.forEach.call(table.tBodies, function (tbody) {
                            myArray.forEach.call(tbody.rows, function (row) {
                                var text_content = row.textContent.toLowerCase();
                                var search_val = search_input.value.toLowerCase();
                                row.style.display = text_content.indexOf(search_val) > -1 ? '' : 'none';
                            });
                     ");
                WriteLiteral(@"   });
                    });
                }

                return {
                    init: function () {
                        var inputs = document.getElementsByClassName('search-input');
                        myArray.forEach.call(inputs, function (input) {
                            input.oninput = _onInputSearch;
                        });
                    }
                };
            })(Array.prototype);

            document.addEventListener('readystatechange', function () {
                if (document.readyState === 'complete') {
                    TableFilter.init();
                }
            });

        })(document);
    </script>

    <script>
        $(document).ready(function () {
            $('table').DataTable();
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProvaConnessioneLicenze.Models.License>> Html { get; private set; }
    }
}
#pragma warning restore 1591
