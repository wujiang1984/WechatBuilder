<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ticket_list.aspx.cs" Inherits="WechatBuilder.Web.admin.ucard.ticket_list" %>

<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员相关优惠券</title>
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
</head>

<body class="mainbody">
    <form id="form1" runat="server">
          <!--导航栏-->
        <div class="location">
            <a href="business_list.aspx" class="back"><i></i><span>返回会员卡商家管理</span></a>
             <a href="business_list.aspx" class="home"><i></i><span>会员卡商家管理</span></a>
         
            <i class="arrow"></i>
            <span>会员相关优惠券</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="ticket_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>&sid=<%=sid %>"  id="itemAddButton"><i></i><span>新增会员优惠券</span></a></li>
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

        <asp:Repeater ID="rptList" runat="server" >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                             <th width="10%">名称</th>
                             <th width="10%">分类</th>
                              <th width="15%">生效日期</th>
                              <th width="15%">过期时间</th>
                            <th width="15%">操作</th>
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
                        <%# Eval("tName") %> 
                    </td>
                      <td>
                          <asp:Label ID="litType" runat="server" Text='<%# Eval("typeId")=="1"?"打折优惠券":"打折优惠券" %>'></asp:Label> 
                    </td>
                     <td>
                        <%# Eval("beginDate") %> 
                    </td>
                       <td>
                        <%# Eval("endDate") %> 
                    </td>
                   
                     <td>
                        <a  href='ticket_edit.aspx?id=<%#Eval("id") %>&action=<%=MXEnums.ActionEnum.Edit %>&sid=<%=sid %>' class="operator">编辑</a>
                       <a  href='ticket_userd_tj.aspx?id=<%#Eval("id") %>&sid=<%=sid %>' class="operator">使用统计</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
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
