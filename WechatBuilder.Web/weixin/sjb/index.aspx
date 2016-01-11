<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.sjb.index" %>

<!DOCTYPE HTML>
<html lang="zh-CN">
<head runat="server">
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
                var obj = $(this);
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
                        obj.attr("disabled", "true");
                        obj.css("display","none");

                        //                        setTimeout(function () {
                        //                           
                        //                            window.location.href = "index.aspx?wid=" + wid + "&openid=" + openid;
                        //                        }, 1000);
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
            2014世界杯竞猜活动 
            <a href="user_jcret.aspx?wid=<%=wid %>&openid=<%=openid %>">[我的竞猜结果]</a>
        </div>

        <asp:Literal ID="litJcStr" runat="server" EnableViewState="false"></asp:Literal>

     <%--   <div class="jc_content">

            <div class="jc_main">
                <div class="jc_qiudui">
                    <img alt="" src="images/baxi.png" />
                    <div class="jc_wenzi">巴西</div>
                </div>
                <div class="jc_vs">
                    VS
                </div>
                <div class="jc_qiudui">
                    <img alt="" src="images/kldy.png" />
                    <div class="jc_wenzi">克罗地亚</div>
                </div>
            </div>
            <div class="jc_clear"></div>
            <div class="jc_form">
                <input id="radQd11" type="radio" name="jingcai1" value="1" /><label for="radQd11">巴西胜</label>
                <input id="radPJ13" type="radio" name="jingcai1" value="3" /><label for="radPJ13">平局</label>
                <input id="radQd12" type="radio" name="jingcai1" value="2" /><label for="radQd12">克罗地亚胜</label>
                <input id="btnJS1" class="btnJs" type="button" value="提交" group="jingcai1" />
            </div>
        </div>--%>

        
    </form>
</body>
</html>
