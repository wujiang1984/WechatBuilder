<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="diancai_form.aspx.cs" Inherits="WechatBuilder.Web.admin.diancai.diancai_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>表单设置</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function parentToIndex(id) {
            parent.location.href = "/admin/Index.aspx?id=" + id;

        }

        $(function () {
            $("#form1").initValidform();

            $("input[name='rblSMSTXType']").click(function () {
                if ($(this).val() == "1") {
                    $("#chkTelNeed").attr("checked", "true");
                    $("#chkTelNeedBT").attr("checked", "true");
                }
            });
        });



    </script>
    <style>
        a.shenghe {
            color: red;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="location">
            <a href="hotel_list.aspx" class="home"><i></i><span>微酒店</span></a>
            <i class="arrow"></i>
            <span>表单设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">表单设置</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <thead>
                    <tr>
                        <th>字段类型
                        </th>
                        <th>字段名称
                        </th>
                        <th>初始内容(如为下拉选项用英文的逗号(,)隔开)
                        </th>

                    </tr>
                </thead>
                <tbody class="ltbody">
                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl1Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt1Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt1Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                    </tr>
                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl2Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt2Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt2Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>

                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl3Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt3Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt3Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />

                        </td>

                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl4Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt4Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt4Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl5Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt5Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt5Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />

                        </td>

                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl6Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt6Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt6Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />

                        </td>

                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl7Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt7Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt7Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />

                        </td>

                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl8Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt8Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt8Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />

                        </td>

                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl9Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt9Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt9Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />

                        </td>

                    </tr>

                </tbody>


            </table>
        </div>

        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />


            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
