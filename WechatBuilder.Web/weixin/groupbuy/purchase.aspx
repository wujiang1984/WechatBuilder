<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchase.aspx.cs" Inherits="WechatBuilder.Web.admin.grouppurchase.purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/Groupbuying.css" media="all" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>




</head>

<body>
    <form id="form1" runat="server" class="form" method="post" action="index.aspx" target="_top" enctype="multipart/form-data">
        <input type="hidden" name="formhash" id="formhash" value="02f2f344" />
        <input type="hidden" name="oldBc" id="oldBc" value="<%=customerNum %>" />
        <section id="order_add" class="F_cqsmt box-shadow marg20" style="">
            <h2>订单信息</h2>
            <div class="dingdanxinxi">
                <p><strong>名称:</strong><span><%=huodname %></span></p>
                <p><strong>单价:</strong><span id="singlePrice" class="F_red"><%=tuangj %>￥</span></p>
                <p><strong>限购:</strong><span>每人<%=limitCount %>件,你已经团购<%=yg %>件</span></p>
            </div>

            <h2>详细信息</h2>
            <ul>
                <li id="sndiv" runat="server" visible="false"><strong>SN码:</strong><input id="sn" name="info" runat="server" htip="sn码" errtip="输入sn码" class="px" value="" /></li>
                <li><strong>姓名:</strong><input id="customerName" name="name" runat="server" type="text" htip="请输入正确的姓名，2~8个汉字" errtip="请输入正确的姓名，2~8个汉字" class="px" value="" /></li>
                <li><strong>手机:</strong><input id="tel" name="tel" runat="server" htip="请输入正确的手机号码" errtip="请输入正确的手机号码" class="px" maxlength="11" value="" /></li>
                <li><strong>数量:</strong><input id="customerNum" name="customerNum" onchange="ckit(this)" htip="输入产品数量" errtip="输入产品数量" class="px" type="number" tag="input" maxlength="11" value="<%=customerNum %>" /></li>
    
                <li><strong>地址:</strong><input id="address" name="address" runat="server" htip="输入你的地址" errtip="输入你的地址" class="px" value="" /></li>
                <li><strong>备注:</strong><input id="Remark" name="Remark" runat="server" htip="备注" errtip="输入备注信息" class="px" value="" /></li>
                <li id="pwddiv" runat="server" visible="false"><strong>消费密码:</strong><input id="shopsPwd" name="shopsPwd" runat="server" htip="消费密码" errtip="输入消费密码" class="px" tag="input" value="" /></li>
            </ul>




            <div class="footReturn">
                <ul>
                    <li class="footerbtn"><a id="showcard2" class="return right3" href="index.aspx?wid=wid&aid=aid">返回</a></li>
                    <li class="footerbtn">
                        <input type="button" id="BtnOrder" class="submit left3" value="提交" style="width: 100%" />
                    </li>
                    <div class="clr"></div>
                </ul>
            </div>
        </section>
        <div class="marg20"></div>

        <asp:HiddenField ID="limit" Value="" runat="server" />
        <asp:HiddenField ID="limitCount1" Value="" runat="server" />
        <asp:HiddenField ID="totalCount1" Value="" runat="server" />
        <asp:HiddenField ID="count1" Value="" runat="server" />
    </form>
    <section id="tipMessage" class="Fh_qdown_apv box-shadow" style="display: none; z-index: 10000;">
        <p class="F_red F_font">请输入正确的姓名，2~8个汉字</p>
        <span class="F_grey2">--微团购--</span>
    </section>
</body>
</html>

<script>

    $(document).ready(function () {

        $("#BtnOrder").click(function () {
            //if ($("#limit").val() == "0" )
            //{
            //    alert("超过抢购数量！");
            //    return;
            //}

            var wid = $.query.get("wid");
            var openid = $.query.get("openid");
            var aid = $.query.get("aid");

            var customerName = $("#customerName").val();
            var tel = $("#tel").val();
            var customerNum = $("#customerNum").val();
            var address = $("#address").val();
            var shopsPwd = $("#shopsPwd").val();
            var sn = $("#sn").val();
            var Remark = $("#Remark").val();
            var oldNum = $("#oldBc").val();

            var submitData = {
                wid: wid,
                openid: openid,
                baseid: aid,
                customerName: customerName,
                tel: tel,
                customerNum: customerNum,
                oldNum:oldNum,
                address: address,
                shopsPwd: shopsPwd,
                sn: sn,
                Remark: Remark,
                myact: "commit"

            };
            $.post('groupbuying.ashx', submitData,
         function (data) {
             if (data.ret == "ok") {
                 alert(data.content);

                 window.location.href = "index.aspx?wid=" + wid + "&aid=" + aid + "&openid=" + openid + "";

             } else { alert(data.content); }
         },
         "json")



        });



    });



</script>

<script>
    function ckit(obj) {
        var limitCount = $("#limitCount1").val();
        var totalCount = $("#totalCount1").val();
        var count = $("#count1").val();
        if (obj.value > limitCount && totalCount != "" && count != "") {

            if (limitCount > count) {
                alert('商品还剩' + 0 + '件！');
                obj.value = count;
            }
            else {
                alert('超过了允许的值！');
                obj.value = limitCount;
            }
        }

        if (obj.value <= 0) {
            alert('商品数不能为0！');
            obj.value = 1;
        }
    }

</script>
