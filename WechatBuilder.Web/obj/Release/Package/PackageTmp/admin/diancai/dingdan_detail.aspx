<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dingdan_detail.aspx.cs" Inherits="MxWeiXinPF.Web.admin.diancai.dingdan_detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单详情</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
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
   <%-- <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />--%>
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
            <i  href="dingdan_manage.aspx?shopid=<%=shopid %>" class="arrow"></i><span>订单管理</span>
            <i class="arrow"></i>            
            <span>订单详情</span>
        </div>


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

    </form>
</body>
</html>
