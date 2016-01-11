<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageSN.aspx.cs" Inherits="MxWeiXinPF.Web.admin.grouppurchase.manageSN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
             <a href="group_list.aspx" class="home"><i></i><span>团购活动</span></a>
            <i class="arrow"></i>
             <span>sn码管理</span>
        </div>
        <!--/导航栏-->
  
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
             <div class="l-list">
                    <ul class="icon-list">
                         <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    
                    </ul>
                        <div class="l-list">
                        <ul class="rule-single-select">
                            <li>
                                <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged">
                                    <asp:ListItem Value="all" Selected="True">全部</asp:ListItem>
                                    <asp:ListItem Value="w">未消费</asp:ListItem>
                                    
                                    <asp:ListItem Value="y">已消费</asp:ListItem>
                                </asp:DropDownList>
                                <%#new MxWeiXinPF.BLL.article_category().GetTitle(Convert.ToInt32(Eval("category_id")))%>
                            </li>
                        </ul>
                    </div>
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
                            <th  width="10%" >选择</th>
                            <th  width="10%" >SN码</th>
                            <th  width="10%" >参团用户</th>
                            <th  width="10%" >数量</th>
                            <th  width="10%" >地址</th>
                            <th width="10%" >电话</th>
                            <th width="10%" >状态</th>
                            <th width="10%" >参团时间/使用时间</th>
                          
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
                        <%# Eval("sn") %>
                    </td>
                    <td>
                        <%# Eval("customerName") %>
                    </td>
                     <td>
                        <%# Eval("customerNum") %>
                    </td>
                    <td>
                      <%# Eval("address") %>
                    </td>
                   <td>
                      <%# Eval("tel") %>
                    </td>
                   <td>
                   <%# Eval("status").ToString().ToLower()=="2"?"已消费":"未消费" %>
                    
                    </td>
                    <td>
                      <%# Eval("dateJoin") %><br/>
                      <%# Eval("dateUse") %>
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
