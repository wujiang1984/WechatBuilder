<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.pano360.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <script type="text/javascript" src="js/zepto.min.js"></script>
    <link href="css/view.css" rel="stylesheet" />
    <title>360全景图</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="view_full" id="full3dDiv">
            <img id="bgImg" style="opacity: 1; width: 100%; margin: -968px 0px;" src="images/bg.jpg">
        </div>

        <div class="view_select" style="height: 267px; opacity: 1;">
            <div class="view_list" id="placeLink">
                <ul style="margin-left: 23px;">
                       <asp:Literal ID="litpanoList" runat="server" EnableViewState="false"></asp:Literal>
                   <%-- <li><a href="zw/demo.html">主卧</a></li>--%>
                  
                </ul>
            </div>
        </div>
<div class="view_house" style="opacity: 1;"><a id="currPlace" href="javascript:void(0);"><asp:Literal ID="litCopyRight" runat="server" EnableViewState="false"></asp:Literal></a></div>
        <a href="javascript:void(0);" id="closeBtn" class="btn_show_close"><span>关闭</span></a>
        <div id="popFail" style="display: none;">
	    <div class="bk"></div>
	    <div class="cont">
	        <img src="images/loading.gif" alt="loading...">
	        <span id="percentNum">正在加载...</span>
	    </div>
	</div>


        <div class="pop_tips" id="popTips" style="display:none;">
	    <div class="oval"></div>
	    <div class="pop_show">
	        <h4 id="tipsTitle">温馨提示</h4>
	        <div class="pop_info" id="tipsMsg">
	            <p></p>
	        </div>
	        <div class="pop_btns">
	            <a href="javascript:void(0);" id="tipsOK">确定</a>
	            <a href="javascript:void(0);" style="display:none;" id="tipsCancel">取消</a>
	        </div>
	    </div>
	</div>

        <div class="pop_mask" id="popMask" style="display: none;"></div>

        <script type="text/javascript">
            $(function () {
                function resizeLayout() {
                    $(".view_select").height($(window).height() - 92);
                    var $bgImg = $("#bgImg");
                    if ($bgImg.height() <= $(window).height()) {
                        $bgImg.css({ "height": "100%" });
                    } else {
                        var top = ($(window).height() - $bgImg.height()) / 2;
                        $bgImg.css({ "margin": top + "px 0px" });
                    }
                };
                $(window).on("resize", function () {
                    resizeLayout();
                });
                $("#bgImg").attr("src", "images/bg.jpg");
                $("#bgImg").on("load", function () {
                    $(this).css({ "opacity": "1" });
                    resizeLayout();
                    $("#popFail").hide();
                    $(".view_select,.view_house").animate({ "opacity": 1 }, 1000);
                });
            });
	</script>

    </form>
</body>
</html>
