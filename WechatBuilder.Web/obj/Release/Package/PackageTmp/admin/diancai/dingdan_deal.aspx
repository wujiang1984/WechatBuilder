<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dingdan_deal.aspx.cs" Inherits="MxWeiXinPF.Web.admin.diancai.dingdan_deal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单处理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
       <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
     <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
   <%-- <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />--%>
        <link href="../../weixin/diancai/css/diancai.css" rel="stylesheet" type="text/css" />
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
          <div class="location">
            <a href="shop_list.aspx" class="home"><i></i><span>点菜系统</span></a>
            <i  class="arrow"></i><span><a href="dingdan_manage.aspx?shopid=<%=shopid %>">订单处理</a></span>
            <i class="arrow"></i>            
            <span>订单处理</span>
        </div>
       <div class="line10"></div>
        <!--/导航栏-->


        <div  class="tab-content"> 
       <ul class="round">
       <li class="title"><span class="none smallspan">订单详情</span></li>
       <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
      
      <%=Dingdanlist %>
      </table>

      </ul>

       <ul class="round">
       <li class="title"><span class="none smallspan">订单信息</span></li>
        
     <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
    <%=dingdanren %>
 </table>

</ul>  

</div>
         <div class="tab-content">
            <dl>
                <dt>状态调整为：</dt>
                <dd>
                    <asp:DropDownList ID="ddlStatusType" runat="server">
                        <asp:ListItem Text="未处理" Value="0"></asp:ListItem>
                        <asp:ListItem Text="成功" Value="1"></asp:ListItem>
                        <asp:ListItem Text="失败" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    
                </dd>
            </dl>
         </div>

           <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="save_groupbase" runat="server" CssClass="btn" Text="保存" OnClick="save_groupbase_Click"  />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
