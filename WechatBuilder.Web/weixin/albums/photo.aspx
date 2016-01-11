<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photo.aspx.cs" Inherits="WechatBuilder.Web.weixin.albums.photo" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>相册展示</title>
<meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="black">
<meta name="format-detection" content="telephone=no">
 
<meta charset="utf-8">
<link href="css/photo.css" rel="stylesheet" type="text/css" />
<link href="css/photoswipe.css" type="text/css" rel="stylesheet" />
 
<!--jquery.min-->
<script src="../../scripts/jquery/jquery-2.1.0.min.js" type="text/javascript"></script>
<script src="js/jquery.lazyload.js" type="text/javascript"></script> 
<script src="js/klass.min.js" type="text/javascript"></script>
<script src="js/code.photoswipe-3.0.5.min.js" type="text/javascript"></script>
<script src="js/shake.js" type="text/javascript"></script>
 
<script src="../xitie/js/wedding.js" type="text/javascript"></script>

<script type="text/javascript">
    (function (window, PhotoSwipe) {
        document.addEventListener('DOMContentLoaded', function () {
            var
            options = {preventSlideshow:false,autoStartSlideshow:true},
            instance = PhotoSwipe.attach(window.document.querySelectorAll('#Gallery a'), options);
        }, false);
    }(window, window.Code.PhotoSwipe));
</script>
<script type="text/javascript">
    jQuery(document).ready(
    function ($) {

        playbox.init("playbox");

        $("img").lazyload({
            placeholder: "路径/grey.gif",
            effect: "fadeIn"
        });
    });

    function yyl() {
        
        $(".ps-toolbar-next").trigger("click");
        
    }

    var shakeEventDidOccur = function () {
        var openid = document.getElementById("hdopenid").value;
        yyl();
        //window.location.href = "result.htm?openid=" + openid + "";
    };
    window.onload = function() {
         
        window.addEventListener('shake', yyl, false);
       
       
    };


</script> 

</head>
<body id="photo">
    <form id="form1" runat="server">
         <span id="playbox" class="btn_music on" onclick="playbox.init(this).play();">
                                <audio id="audio" loop="" src="<%=albums.music%>"></audio>
         </span>

        <div class="qiandaobanner"> 
               <asp:Literal ID="litBanner" runat="server" EnableViewState="false"></asp:Literal>
        </div>
        <div  id="main" role="main">
      <ul id="Gallery" class="gallery">
<asp:Repeater ID="rpPoto" runat="server" EnableViewState="false">
    <ItemTemplate>
          <li><a href='<%# Eval("photoPic") %>'><img src="<%# Eval("photoPic") %>" alt="  "></a></li>
    </ItemTemplate>
</asp:Repeater>
          
          </ul>
          </div>

        
<!--下面是瀑布流js-->
<script src="js/jquery.imagesloaded.js" type="text/javascript"></script>
<script src="js/jquery.wookmark.min.js" type="text/javascript"></script>
<script type="text/javascript">
    (function ($) {
        $('#Gallery').imagesLoaded(function () {
            // Prepare layout options.
            var options = {
                autoResize: true, // This will auto-update the layout when the browser window is resized.
                container: $('#main'), // Optional, used for some extra CSS styling
                offset: 4, // Optional, the distance between grid items
                itemWidth: 150 // Optional, the width of a grid item
            };

            // Get a reference to your grid items.
            var handler = $('#Gallery li');

            // Call the layout function.
            handler.wookmark(options);


        });
    })(jQuery);
  </script>
 <div class="copyright"> <asp:Literal ID="litCopyRight" runat="server" EnableViewState="false"></asp:Literal> </div> 



    </form>
</body>
</html>
