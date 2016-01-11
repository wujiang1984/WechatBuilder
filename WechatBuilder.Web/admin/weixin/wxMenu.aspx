<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxMenu.aspx.cs" Inherits="WechatBuilder.Web.admin.weixin.wxMenu" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>关注时回复</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        thead td {
            font-weight: bolder;
            text-align: center;
            font-size: 18px;
            height:30px;
        }

        tbody tr td label {
            width: 100px;
        }

        .txtNameValue, .txtNameKey, .txtNameUrl {
            padding: 1px 2px;
            line-height: 20px;
            border: 1px solid #d4d4d4;
            background: #fff;
            vertical-align: middle;
            color: #333;
            font-size: 100%;
            margin:2px 0px  2px;
        }

        .txtNameValue {
            width: 150px;
        }

        .txtNameKey {
            width: 150px;
        }

        .txtNameUrl {
            width: 200px;
            margin-right:10px;
        }

        .form_table td {
            border: 1px solid #e1e1e1;
        }

        .innertable td {
            border: 0px;
        }
        .td_shengru {
        text-align: center; width:120px;
        }
        .td_titleName {
        width:45px;
        text-align:center;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>


</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--内容-->
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">设置自定义菜单</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">使用规则</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <table class="form_table">
                <thead>
                    <tr>
                        <td class="td_shengru">深度</td>
                        <td style="text-align: center;">第一列</td>
                        <td style="text-align: center;">第二列</td>
                        <td style="text-align: center;">第三列</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="td_shengru">一级菜单按钮</td>
                        <td>

                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop1" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop1Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop1Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop2" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop2Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop2Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop3" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop3Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtTop3Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;
                        </td>
                    </tr>

                    <tr>
                        <td class="td_shengru">二级菜单No.1</td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu11" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu11Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu11Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>

                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu21" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu21Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu21Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu31" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu31Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu31Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>

                    </tr>

                    <tr>
                        <td class="td_shengru">二级菜单No.2</td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu12" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu12Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu12Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>

                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu22" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu22Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu22Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu32" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu32Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu32Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>

                    </tr>


                    <tr>
                        <td class="td_shengru">二级菜单No.3</td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu13" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu13Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu13Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu23" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu23Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu23Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu33" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu33Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu33Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>

                    </tr>


                    <tr>
                        <td class="td_shengru">二级菜单No.4</td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu14" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu14Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu14Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu24" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu24Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu24Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu34" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu34Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu34Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td class="td_shengru">二级菜单No.5</td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu15" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu15Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu15Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu25" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu25Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu25Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" class="innertable">
                                <tr>
                                    <td class="td_titleName">名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu35" runat="server" CssClass="txtNameValue"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td class="td_titleName">key：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu35Key" runat="server" CssClass="txtNameKey"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="td_titleName">url：</td>
                                    <td>
                                        <asp:TextBox ID="txtMenu35Url" runat="server" CssClass="txtNameUrl"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>

                    </tr>

                </tbody>
            </table>
        </div>
        <div class="tab-content" style="display: none">

            <div style="padding-left: 20px; padding-bottom: 20px; line-height: 24px; font-size: 16px;">
                <h3>使用说明及规则，请仔细阅读</h3>
                <ul style="list-style-type: circle; padding-left: 20px;">

                    <li style="list-style-type: circle;">使用菜单需要成为“服务号”，或通过认证的“订阅号”，且开启了高级功能。到微信后台【高级功能 > 开发模式】下获取AppId和AppSecret，并且将这2个值填写在微信帐号相应位置。</li>
                    <li style="list-style-type: circle;">官方要求：一级菜单按钮个数为1-3个</li>
                    <li style="list-style-type: circle;">官方要求：如果设置了二级菜单按钮个数为1-5个</li>
                    <li style="list-style-type: circle;">官方要求：按钮描述，既按钮名字，不超过16个字节，子菜单不超过40个字节</li>
                    <li style="list-style-type: circle;">如果名称不填，此按钮将被忽略</li>
                    <li style="list-style-type: circle;">如果一级菜单为空，该列所有设置的二级菜单都会被忽略</li>
                     <li style="list-style-type: circle;">key对应自定义回复管理里的关键词</li>
                    <li style="list-style-type: circle;">key仅在SingleButton（单击按钮，无下级菜单）的状态下设置，如果此按钮有下级菜单，key将被忽略</li>
                    <li style="list-style-type: circle;">url为跳转到指定的页面。每个菜单key和Url只能填写一项，如果2个都填写，则按照Url跳转来设置</li>
                    <li style="list-style-type: circle;">所有二级菜单都为SingleButton，即子级菜单</li>
                    <li style="list-style-type: circle;">如果要快速看到微信上的菜单最新状态，需要重新关注，否则需要静静等待N小时</li>
               <li style="list-style-type: circle;">
                   若仍有问题，请点击下面的按钮，更新Access_Token值【注：请慎用】<br />
                    <asp:Button ID="Button1" runat="server" Text="更新Access_Token值" CssClass="btn" OnClick="FlushAT_Click" />

               </li>
                      </ul>
            </div>
        </div>


        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer" runat="server" id="div_gongju">
            <div class="btn-list">
                 <asp:Button ID="btnSubmit" runat="server" Text="生成自定义菜单" CssClass="btn" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnDelMenu" runat="server" Text="删除当前菜单" CssClass="btn yellow" OnClick="btnDelMenu_Click" />
                
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
