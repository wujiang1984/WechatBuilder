<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.albums.index" %>


<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <title>微相册</title>
    <meta name="viewport" content=" initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/templates.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">

        <!--_header-->
        <div class="lay_header" style="height: 45px">
            <div class="lay_toptab mod_tab" id="lay_head">
               <%-- <a class="tab_item" href="typelist.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_goback"></i></a>

                <a class="tab_item" href="index.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_icenter"></i></a>--%>

            </div>

            <div class="lay_toptab mod_tab fixed qb_none" id="lay_head_fixed">
               <%-- <a class="tab_item" href="typelist.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_goback"></i></a>

                <a class="tab_item" href="index.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_icenter"></i></a>--%>
            </div>



        </div>
        <!--/_header-->

        <div class="lay_page ">
            <div class="lay_page_wrap">
                <div class="fn_indexad">

                    <div class="mod_clipimg" tag="indexad">

                        <img class="ui_fluid default" lazy="<%=bgPic%>" />
                    </div>
                    <!--加class .animate-->
                    <div class="indexad_banner animate">
                        <ul class="banner_list">

                            <li class="list_item"><a href="typelist.aspx?wid=<%=wid%>&openid=<%=openid%>">全部类别</a></li>
                             <asp:Literal ID="litTypelist" runat="server" EnableViewState="false"></asp:Literal>
                           
                        </ul>
                    </div>

                </div>


                <div class="lay_footer qb_tac qb_fs_s mod_mb15">
                    <div class="fn_quicklinks">
                        <a class="mod_color_weak" href="index.aspx?wid=<%=wid%>&openid=<%=openid%>">首页</a>
                        <span class="mod_color_comment">|</span>
                        <a class="mod_color_weak" href="/index.aspx?wid=<%=wid%>&openid=<%=openid%>">官网</a>
                        <span class="mod_color_comment">|</span>
                        <a class="mod_color_weak" href="typelist.aspx?wid=<%=wid%>&openid=<%=openid%>">相册分类</a>
                    </div>
                    <div class="fn_copyright qb_bfc">
                        <div class="mod_color_comment bfc_c">
                            <asp:Literal ID="litCopyRight" runat="server" EnableViewState="false"></asp:Literal></div>
                    </div>
                </div>
            </div>
        </div>
        <script src="js/zepto.min.js"></script>
        <script type="text/javascript">
            var itemArray = { "1": [] }, lz = true;
            var topicType = 5;
        </script>
        <!--_share_js-->
       <script type="text/javascript">
           var shareData = {
               "send2Friend": { "content": "微相册", "img": "<%=bgPic%>", "link": "<%=mywebSite%>/weixin/albums/index.aspx?wid=<%=wid%>&openid=<%=openid%>", "title": "微相册" },
               "share2Friend": { "img": "<%=bgPic%>", "link": "<%=mywebSite%>/weixin/albums/index.aspx?wid=<%=wid%>&openid=<%=openid%>", "title": "微相册" },
               "share2qqBlog": { "content": "微相册", "link": "<%=mywebSite%>/weixin/albums/index.aspx?wid=<%=wid%>&openid=<%=openid%>" }
           };
           !function () {
               function c() {
                   var a = WeixinJSBridge; a.on("menu:share:appmessage", e), a.on("menu:share:weibo", f), a.on("menu:share:timeline", g), a.invoke("getNetworkType", {}, d)
               }
               function d(a) {
                   var b, c;
                   switch (a.err_msg) { case "network_type:wwan": b = 2e3; break; case "network_type:edge": b = 3e3; break; case "network_type:wifi": b = 4e3 } c = new Image, c.onerror = c.onload = function () { c = null }
               }
               function e() {
                   var a = window.shareData.send2Friend, b = h(a); a.content = b ? b.content : a.content, a.img = b && b.img ? b.img : a.img, WeixinJSBridge.invoke("sendAppMessage", { img_url: a.img, img_width: "640", img_height: "640", link: a.link, desc: a.content, title: a.title }, function () { })
               } function f() {
                   var b = window.shareData.share2qqBlog; WeixinJSBridge.invoke("shareWeibo", { content: a.isios ? b.content + b.link : b.content, url: b.link }, function () { })
               }
               function g() {
                   var a = window.shareData.share2Friend; WeixinJSBridge.invoke("shareTimeline", { img_url: a.img, img_width: "640", img_height: "640", link: a.link, desc: " ", title: a.title }, function () { })
               } function h() {
                   return "function" == typeof b ? b() : ""
               }
               var b, a = function () {
                   var a = window.navigator.userAgent; return this.isAndroid = a.match(/(Android)\s+([\d.]+)/) || a.match(/Silk-Accelerated/) ? !0 : !1, this.isiPad = a.match(/iPad/) ? !0 : !1, this.isiPod = a.match(/(iPod).*OS\s([\d_]+)/) ? !0 : !1, this.isiPhone = !this.isiPad && a.match(/(iPhone\sOS)\s([\d_]+)/) ? !0 : !1, this.isios = this.isiPhone || this.isiPad || this.isiPod, this
               }();
               window.shareData && document.addEventListener("WeixinJSBridgeReady", c, !1), window.setShareListener = function (a) { b = a }
           }();
    </script>
    <!--/_share_js-->	
        <script type="text/javascript">
            mobile.o2ocn.topic.init();
        </script>
    </form>
</body>
</html>
