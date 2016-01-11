<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_jcret.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.sjb.user_jcret" %>


<!DOCTYPE HTML>
<html lang="zh-CN">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;">
    <meta name="format-detection" content="telephone=no">
    <title>竞猜</title>
    <link rel="stylesheet" type="text/css" href="css/wei_bind.css">
    <link rel="stylesheet" type="text/css" href="css/wei_dialog.css">
    <link rel="stylesheet" type="text/css" href="css/mystyle.css">
    <style type="text/css">
        .hagen_submit {
            background: none repeat scroll 0 0 #8a0000;
        }
    </style>

    <script src="js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="js/alert.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/jquery.query.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".btnJs").click(function () {

                var group = $(this).attr("group");
                var bisaiId = $(this).attr("bisaiid");
                //选中项类型id
                var xzz = $("input[name='" + group + "']:checked").val();

                if (xzz == null) {
                    alert("请选中其一后再提交！");
                    return;
                }
                var openid = $.query.get("openid");
                var wid = $.query.get("wid");
                alert(11);
                var submitData = {
                    wid: wid,
                    openid: openid,
                    bisaiId: bisaiId,
                    jcRetType: xzz,
                    rad: Math.random()

                };
                $.post('jc.ashx?myact=jingcai', submitData,
                function (data) {
                    if (data.success == "1") {
                        alert("提交成功！");
                        setTimeout(function () {

                            window.location.href = "index.aspx?wid=" + wid + "&openid=" + openid;
                        }, 1000);
                    } else {
                        alert(data.msg);
                    }
                },
                "json")


            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
           <asp:HiddenField ID="hidStatus" runat="server" Value="" EnableViewState="false" />
            <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <div class="jc_header">
            2014世界杯竞猜活动（结果）
        </div>

        

         <div class="jc_content">
            <div class="jc_clear"></div>
            <div class="jc_form" style="height:100px;">
                <br />
                 <label for="radQd11">您已猜对 <asp:Literal ID="litRightTimes" runat="server" EnableViewState="false"></asp:Literal>
                      次</label><br />
                 <label for="radPJ13">猜错 <asp:Literal ID="litErrTimes" runat="server" EnableViewState="false"></asp:Literal>
                      次</label>
                <br />
            </div>
        </div> 

        
    </form>
</body>
</html>
