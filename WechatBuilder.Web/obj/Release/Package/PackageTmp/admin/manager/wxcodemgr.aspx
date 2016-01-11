<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxcodemgr.aspx.cs" Inherits="MxWeiXinPF.Web.admin.manager.wxcodemgr" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>微帐号管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function parentToIndex(id) {
            parent.location.href = "/admin/Index.aspx?id=" + id;

        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location" style="display: none;">
            <a href="javascript:;" class="home"><i></i><span>微信帐号管理</span></a>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click">
                                <i></i><span>删除</span>
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                         <th width="4%">序号</th>
                        <th width="6%">选择</th>
                       
                        <th width="4%">主键</th>
                        <th>公众帐号名称</th>
                        <th width="12%">微信号</th>
                        <th width="12%">所属用户</th>
                        <th width="16%">有效期</th>
                        <th width="8%">管理</th>
 
                    </tr>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                     <td>
                          <%#Container.ItemIndex +1%>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                   
                     <td>
                       <span style="font-weight:bolder;"> <%# Eval("Id") %> </span>
                    </td>
                    <td>
                      <%# Eval("wxName") %> 
                    </td>
                    <td>
                        <%# Eval("weixinCode") %>
                    </td>
                    <td>
                        <%# Eval("user_name") %>
                    </td>
                    <td>
                         创建时间：<%#string.Format("{0:yyyy/MM/dd}",Eval("createDate"))%><br />
                        到期时间：<%#string.Format("{0:yyyy/MM/dd}",Eval("endDate"))%>
                    </td>
                    <td align="center"><a href="wxcode_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">管理</a></td>
                    

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
                 </tbody>
</table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
