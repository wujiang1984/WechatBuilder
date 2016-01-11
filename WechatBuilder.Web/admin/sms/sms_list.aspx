<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sms_list.aspx.cs" Inherits="WechatBuilder.Web.admin.sms.sms_list" %>


<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>短信发送管理</title>
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
          
            <a href="javascript:;" class="home"><i></i><span>短信发送管理</span></a>
           
        </div>
        <!--/导航栏-->
         <div class="mytips">
            需要短信接口帐号和密码请与管理员沟通。
        </div>
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn folder" href="sms_config.aspx"  id="itemAddButton"><i></i><span>短信接口设置</span></a></li>
                         <li><a class="icon-btn add" href="sms_send.aspx"  id="A1"><i></i><span>短信发送</span></a></li>
                    </ul>
                </div>
                
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
                
            </div>
             <div class="r-list">
                     剩余短信条数： <asp:Label ID="lblsmsNum" runat="server" Text="" ForeColor="Red"></asp:Label> 条
                     </div>
        </div>
        <!--/工具栏-->

        <!--列表-->

        <asp:Repeater ID="rptList" runat="server"  >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                             <th width="20%">手机号</th>
                            <th >短信内容</th>
                            <th width="12%">状态</th>
                            <th width="12%">发送时间</th>
                            <th width="20%">模块名称</th>
                            <th width="17%">活动名称</th>
                        </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                     
                    <td>
                        <%# Eval("tel") %>
                    </td>
                    <td>
                        <%# Eval("smsContent") %>
                    </td>
                     <td>
                        <%# Eval("sStatus") %> 
                        
                    </td>
                      <td>
                          <%# Eval("createDate") %>
                    </td>
                    <td>
                          <%# Eval("moduleName") %>
                    </td>
                     <td>
                        <%# Eval("actionName") %>  
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
