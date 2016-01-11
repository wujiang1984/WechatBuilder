<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan_manage_indexdetail.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.diancai.caidan_manage_indexdetail" %>


<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title><%=hotelName %></title>

<meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="black">
<meta name="format-detection" content="telephone=no">
<link href="css/diancai.css" rel="stylesheet" type="text/css">
<script src="js/jquery.min.js" type="text/javascript"></script>
<style>
</style>
</head>

<body id="onlinebooking-b" >
<div class="qiandaobanner"> <img src="images/RTqs2yHIc9.jpg" > </div>
<div class="cardexplain">
<ul class="round">
<li class="title"><span class="none smallspan">订单详情</span></li>
 <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
<%=Dingdanlist %>
</table>

</ul>
<ul class="round">
 <%=dingdandatail %>  
</ul>


<ul class="round">
 <li class="title"><span class="none">商家操作</span></li>
 <li>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="cpbiaoge">
            
 <tr>
<td width="70">桌号：</td>
<td colspan="2"  ><select name="tablenums" class="dropdown-select" id="tablenums">
 <option      value=""></option>
        </select></td>
</tr>	
<tr>
<td width="70">订单操作</td>
<td><select name="state" class="dropdown-select" id="state">
<option selected  class="dropdown-option">请选择操作类型</option>
<option value="1" >确认订单</option>
<option value="0">拒绝订单</option>
</select></td>
</tr>
<tr>
<td valign="top" colspan="2"><textarea name="msg" class="pxtextarea" style=" height:99px;overflow-y:visible" id="msg"  placeholder="给客户留言"></textarea></td>
</tr>
</table>
</li>
</ul>

<div class="footReturn" style=" padding:0">
<a id="showcard"  class="submit" href="javascript:void(0)">确 定</a>
<div class="window" id="windowcenter">
<div id="title" class="wtitle">提交成功<span class="close" id="alertclose"></span></div>
<div class="content">
<div id="txt"></div>
</div>
</div>
</div>
<script type="text/javascript">
    var oLay = document.getElementById("overlay");
    $(document).ready(function () {


        $("#showcard").click(function () {
            var submitData = {
                msg: $("#msg").val(),
                tablenums: $("#tablenums").val(),
                orderid: "7859",
                formhash: "fe120c24",
                state: $("#state").val(),
                myact: "setstatus"
            };
            $.post('diancai_login.ashx?id=<%=id%>', submitData,
                            function (data) {
                                if (data.ret == "ok") {
                                    alert(data.content);

                                    window.location.href = "";

                     } else { alert(data.content); }
                            },
            "json")
            oLay.style.display = "block";
        });
    });

    $("#windowclosebutton").click(function () {
        $("#windowcenter").slideUp(500);
        oLay.style.display = "none";

    });
    $("#alertclose").click(function () {
        $("#windowcenter").slideUp(500);
        oLay.style.display = "none";

    });

    function alert(title) {
      
        $("#windowcenter").slideToggle("slow");
        $("#txt").html(title);
        setTimeout('$("#windowcenter").slideUp(500)', 4000);
    }

</script> 
</div>
</body>
</html>
