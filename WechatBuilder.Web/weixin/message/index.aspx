<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.message.index" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>测试留言</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/message.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
</head>
<body id="message">
    <form id="form1" runat="server">
        <div class="qiandaobanner">
            <a href="javascript:history.go(-1);">

                <asp:Image ID="zjpic" runat="server" ImageUrl="" EnableViewState="false" />
            </a>
        </div>

        <div class="cardexplain">


            <div class="window" id="windowcenter">
                <div id="title" class="wtitle">操作提示<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="txt"></div>
                </div>
            </div>
            <input type="hidden" id="adminOpenid"  runat="server" value="0" EnableViewState="false" />
            <input type="hidden" id="needSH" runat="server" value="false" EnableViewState="false" />
            

            <script type="text/javascript">
                $(document).ready(function () {
                    var wid = $.query.get("wid");
                    var openid=$.query.get("openid");
                    var hasSH = $("#needSH").val();


                    $("#showcard1").click(function () {
                        
                        var btn = $(this);
                        var wxname = $("#wxname1").val();
                        if (wxname == '') {
                            alert("请输入昵称");
                            return
                        }
                        var info = $("#info1").val();
                        if (info == '') {
                            alert("请输入内容");
                            return
                        }
                        var submitData = {
                            nickname: wxname,
                            info: info,
                            wid: wid,
                            openid: openid,
                            hasSH:hasSH,
                            myact: "commit"
                        };
                        $.post('message.ashx', submitData,
                        function (data) {
                            if (data.ret == "ok") {
                                alert(data.content);
                                setTimeout('window.location.href=location.href', 1000);
                                return
                            } else { alert(data.content); }
                        },
                        "json")
                    });

                    $("#showcard2").click(function () {

                        var btn = $(this);
                        var wxname = $("#wxname2").val();
                        if (wxname == '') {
                            alert("请输入昵称");
                            return
                        }
                        var info1 = $("#info2").val();
                        if (info1 == '') {
                            alert("请输入内容");
                            return
                        }
                        var submitData = {
                            nickname: wxname,
                            info: info,
                            wid: wid,
                            openid: openid,
                            hasSH: hasSH,
                            myact: "commit"
                        };
                        $.post('message.ashx', submitData,
                     function (data) {
                         if (data.ret == "ok") {
                             alert(data.content);
                             setTimeout('window.location.href=location.href', 1000);
                             return
                         } else { alert(data.content); }
                     },
                     "json")
                    });

                    
                    $(".hhsubmit").click(function () {

                        //回复

                        var objid = $(this).attr("date");
                      

                        var info = $(".hly" + objid).val();
                     
                        if (info == '') {
                            alert("请输入内容");
                            return
                        }
                        

                        var submitData = {
                            wid: wid,
                            openid: openid,
                            hasSH:hasSH,
                            nickname: $("#wxname1").val(),
                            parentid: objid,//parentid
                            info: info,
                            myact: "setly"
                        };

                        $.post('message.ashx', submitData,
                    function (data) {
                       if (data.ret == "ok") {
                           alert(data.content);
                           setTimeout('window.location.href=location.href', 1000);
                           return
                       } else { alert(data.content); }
                   },
                   "json")

                    });

                    //回复
                    $(".hfinfo").click(function () {


                        var objid = $(this).attr("date");

                        $(".hhly" + objid).slideToggle();


                    });
                    $(".hhbt").click(function () {


                        var objid = $(this).attr("date");

                        $(".hhly" + objid).slideToggle();


                    });
                });
                $("#windowclosebutton").click(function () {
                    $("#windowcenter").slideUp(500);

                });
                $("#alertclose").click(function () {
                    $("#windowcenter").slideUp(500);

                });

                function alert(title) {

                    $("#windowcenter").slideToggle("slow");
                    $("#txt").html(title);
                    setTimeout('$("#windowcenter").slideUp(500)', 4000);
                }
                $(document).ready(function () {
                    $(".first1").click(function () {
                        $(".ly1").slideToggle();
                    });
                });
                $(document).ready(function () {
                    $(".first2").click(function () {
                        $(".ly2").slideToggle();
                    });
                });
            </script>
           
            <div class="history">
                <div class="history-date">
                    <ul>
                        <a>
                            <h2 class="first first1" style="position: relative;">请点击留言</h2>
                        </a>
                        <!--<li class="nob  mb"><div class="beizhu">留言审核通过后才会显示在留言墙上！</div></li>-->
                        <li class="green bounceInDown nob ly1" style="display: none">
                            <dl>
                                <dt>
                                    <input name="wxname" type="text" class="px" id="wxname1" value="<%=nicheng %>" placeholder="请输入您的昵称"></dt>
                                <dt>
                                    <textarea name="info" class="pxtextarea" style="height: 60px;" id="info1" placeholder="请输入留言"></textarea></dt>
                                <dt><a id="showcard1" class="submit" href="javascript:void(0)">提交留言</a></dt>
                            </dl>
                        </li>

                         <asp:Literal ID="litMessageList" runat="server" EnableViewState="false" ></asp:Literal>

                       <%-- <li class="green bounceInDown">
                            <h3>
                                <!--<img src="http://www.apiwx.com/index/images/logo100x100.jpg">-->
                                健健康康<span>2014-05-04 14:49:28</span><div class="clr"></div>
                            </h3>
                            <dl>
                                <dt class="hfinfo" date="80689">她健健康康</dt>
                            </dl>

                            <dl class="huifu">
                                <dt><span><a class="hhbt czan" date="80689" href="javascript:void(0)">回复</a>
                                    <p style="display: none;" class="hhly80689">
                                        <textarea name="info" class="pxtextarea hly80689"></textarea>
                                        <a class="hhsubmit submit" date="80689" href="javascript:void(0)">确定</a>
                                    </p>
                                </span></dt>
                            </dl>

                            <dl class="huifu">
                                <dt><span>健健康康回复：刚刚好 </span></dt>
                            </dl>
                        </li>--%>
                     

                        <li class="green bounceInDown nob ly2" style="display: none">
                            <dl>
                                <dt>
                                    <input name="wxname" type="text" class="px" id="wxname2" value="<%=nicheng %>" placeholder="请输入您的昵称"></dt>
                                <dt>
                                    <textarea name="info" class="pxtextarea" style="height: 60px;" id="info2" placeholder="请输入留言"></textarea></dt>
                                <dt><a id="showcard2" class="submit" href="javascript:void(0)">提交留言</a> </dt>
                            </dl>
                        </li>


                        <a>
                            <h2 class="first first2" style="position: relative;">请点击留言</h2>
                        </a>


                    </ul>
                </div>


            </div>


        </div>
        <script src="js/plugback.js" type="text/javascript"></script>
    </form>
</body>
</html>
