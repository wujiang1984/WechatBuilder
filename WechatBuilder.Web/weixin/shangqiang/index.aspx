<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.shangqiang.index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>上墙上墙</title>

    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta charset="utf-8">
    <link href="../albums/css/photo.css" rel="stylesheet" type="text/css" />
    <link href="../albums/css/photoswipe.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../albums/js/klass.min.js"></script>
    <script type="text/javascript" src="../albums/js/code.photoswipe-3.0.5.min.js"></script>
    <script type="text/javascript">
        (function (window, PhotoSwipe) {
            document.addEventListener('DOMContentLoaded', function () {
                var
                    options = {},
                    instance = PhotoSwipe.attach(window.document.querySelectorAll('#Gallery a'), options);
            }, false);
        }(window, window.Code.PhotoSwipe));
    </script>
</head>
<body id="photo">
    <form id="form1" runat="server">

        <style>
            /*page*/
            .pagination {
                margin: 10px;
                text-align: center;
                text-align: center;
            }

                .pagination a {
                    margin: 0;
                    padding: 6px 25px;
                    border: 1px solid #D1D1D1;
                    background: #fefefe;
                    border: 1px solid #ABABAB;
                    background-image: linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                    background-image: -o-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                    background-image: -moz-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                    background-image: -webkit-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                    background-image: -ms-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                    background-image: -webkit-gradient( linear, left bottom, left top, color-stop(0, #E1E1E1), color-stop(1, #ffffff) );
                    -webkit-box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 1px rgba(0, 0, 0, 0.1);
                    -moz-box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 1px rgba(0, 0, 0, 0.1);
                    box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 1px rgba(0, 0, 0, 0.1);
                    -webkit-border-radius: 5px;
                    -moz-border-radius: 5px;
                    border-radius: 5px;
                    color: #666;
                    text-shadow: 0 1px #fff;
                    display: block;
                }

                    .pagination a:hover {
                        background-image: linear-gradient(bottom, #F5F2F2 0%, #ffffff 100%);
                        background-image: -o-linear-gradient(bottom, #F5F2F2 0%, #ffffff 100%);
                        background-image: -moz-linear-gradient(bottom, #F5F2F2 0%, #ffffff 100%);
                        background-image: -webkit-linear-gradient(bottom, #F5F2F2 0%, #ffffff 100%);
                        background-image: -ms-linear-gradient(bottom, #F5F2F2 0%, #ffffff 100%);
                        background-image: -webkit-gradient( linear, left bottom, left top, color-stop(0, #F5F2F2), color-stop(1, #ffffff) );
                    }

                    .pagination a:active {
                        background-image: linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                        background-image: -o-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                        background-image: -moz-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                        background-image: -webkit-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                        background-image: -ms-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                        background-image: -webkit-gradient( linear, left bottom, left top, color-stop(0, #ffffff), color-stop(1, #E1E1E1) );
                        -webkit-box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 2px rgba(0, 0, 0, 0.25);
                        -moz-box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 2px rgba(0, 0, 0, 0.25);
                        box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 2px rgba(0, 0, 0, 0.25);
                    }

                .pagination .disabled a, .pagination .disabled a:hover {
                    background: none;
                    border: 1px solid #cbcbcb;
                    -webkit-box-shadow: none;
                    -moz-box-shadow: none;
                    box-shadow: none;
                    color: A4A3A3;
                }

                .pagination .left {
                    float: left;
                }

                .pagination .right {
                    float: right;
                }
        </style>
        <!-- //再载入lazyload -->
        <script type="text/javascript" src="../albums/js/jquery.lazyload.js"></script>
        <script type="text/javascript">
            jQuery(document).ready(
            function ($) {
                $("img").lazyload({
                    placeholder: "index/images/grey.gif", //加载图片前的占位图片
                    effect: "fadeIn" //加载图片使用的效果(淡入)
                });
            });
        </script>
        <div class="qiandaobanner">
            <asp:Literal ID="litBanner" runat="server" EnableViewState="false"></asp:Literal>
        </div>
        <div id="main" role="main">
            <ul id="Gallery" class="gallery">
                <asp:Repeater ID="rpPoto" runat="server" EnableViewState="false">
                    <ItemTemplate>

                        <li>
                            <a href="<%# Eval("picUrl") %>">
                                <img src="<%# Eval("picUrl") %>" alt="<%# Eval("id") %> ">
                                <p><%# Eval("createDate","{0:yyyy-MM-dd HH:mm:ss}") %></p>
                            </a>

                        </li>
                    </ItemTemplate>
                </asp:Repeater>

                 
            </ul>
        </div>
        <div class="pagination">
            <div class="left  ">
                <a href="javascript:;" runat="server" id="aBefore">
                    上一页
                </a></div>
            <div class="right"><a href="javascript:;" runat="server" id="aAfter">下一页</a></div>
            <div class="clr"></div>
        </div>

        <!--jquery.min-->
        <script src="../../scripts/jquery/jquery-2.1.0.min.js" type="text/javascript"></script>
        <!--下面是瀑布流js-->
        <script src="../albums/js/jquery.imagesloaded.js"></script>
        <script src="../albums/js/jquery.wookmark.min.js"></script>
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
        <script src="js/plugback.js" type="text/javascript"></script>

    </form>
</body>
</html>
