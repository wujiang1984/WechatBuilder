<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_list.aspx.cs" Inherits="MxWeiXinPF.Web.admin.grouppurchase.group_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>团购活动管理</title>
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

        });
    </script>
    <style>
       a.shenghe {
        color:red;
        
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>团购活动管理</span></a>
        </div>
        <!--/导航栏-->
       <%--  <div class="mytips">
                微留言地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a><br />
             添加管理员方法：你自己留言后，就可以看到管理员Openid了，拷贝粘帖到管理员输入框就可以了。
         </div>--%>
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="group_base_add.aspx?action=<%=MxWeiXinPF.Common.MXEnums.ActionEnum.Add %>"  id="itemAddButton"><i></i><span>新增团购活动</span></a></li>
                        
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
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

        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th width="15%">团购名称</th>
                            <th width="8%">最小成团人数</th>
                            <th >有效参与人数</th>
                            <th >虚拟参与人数</th>
                            <th>开始时间/结束时间</th>
                            <th>查看</th>
                            <th >操作</th>
                        </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                    <td>
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td>
                        <%# Eval("activityName") %>
                    </td>
                    <td>
                        <%# Eval("groupPerson") %>
                    </td>
                     <td>
                        <%# Eval("groupPerson") %>
                        
                    </td>
                  
                    <td>
                      <%# Eval("virtualPerson") %>
                    </td>
                    <td>
                      <%# Eval("activityTimebegin") %><br />
                      <%# Eval("activityTimeend") %>
                    </td>
                     <td>
                        <a href="javascript:;"><%=yuming%>/weixin/groupbuy/index.aspx?wid=<%=wid %>&aid=<%#Eval("id") %></a>
                    </td>
                     <td>
                        <a  href='group_base_add.aspx?id=<%#Eval("id") %>' >编辑活动</a>
                        <a  href='manageSN.aspx?id=<%#Eval("id") %>' >SN码管理</a>
                      <%--  <a  href='group_base_add.aspx?id=<%#Eval("id") %>&type=delete'>删除</a>--%>
                    </td>
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
