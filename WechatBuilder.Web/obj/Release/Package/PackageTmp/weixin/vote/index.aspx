<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.vote.index" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>dd</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/vote.css" rel="stylesheet" type="text/css">
    <link href="css/all.css" rel="stylesheet">
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery.icheck.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/jquery.query.js" type="text/javascript"></script>

</head>

<body id="<%=baseinfo.voteType==1?"vote-text":"vote-img" %>">
    <div class="vote">
        <form class="form" method="post" action="index.aspx" target="_top" enctype="multipart/form-data">
            <div class="votecontent">
                <h2><%=baseinfo.title %></h2>
                <span class="date"><%=baseinfo.creatDate.Value.ToString("yyyy-MM-dd") %></span>
                <div class="voteimg">
                    <img src="<%=baseinfo.picdisplay? baseinfo.votepic:"" %>">
                </div>
                <p class="content">
                    <span style="color: #444444; font-size: 14px; font-weight: bold; line-height: 16px; background-color: #fcfcfc;"><%=baseinfo.votecontent %></span>
                </p>


                <p class="modus">单选投票，<span class="number">共有<%=toupNum %>人参与投票</span></p>
                <ul class="list" id="list">

                    

                    <asp:Literal ID="litMessageList" runat="server" EnableViewState="false"></asp:Literal>

                </ul>
                <asp:Literal ID="litSubmitBtn" runat="server" EnableViewState="false"></asp:Literal> 
                
            </div>
        </form>
    </div>
    <script>

        $(document).ready(function () {



            $('input').iCheck({
                checkboxClass: 'icheckbox_flat',
                radioClass: 'iradio_flat'
            });

            $("ins").click(function () {
               
                //var i = 0;
                //$(".checked").each(function () {
                //    i++;
                //});
                //if (i > 2) {
                //    $(this).click();
                     
                //}
            });
 
            var isradio="<%=baseinfo.isRadio.ToString().ToLower()%>";


            $("#btnSubmit").click(function () {

                var wid = $.query.get("wid");
                var openid = $.query.get("openid");
                var aid = $.query.get("aid");
                var selectItemid = "";

                if (isradio == "true") {
                    var list = $('input:radio[class="ckbx"]:checked').val();

                    if (list == null) {
                        alert("请选中一个!");
                        return false;
                    }
                    else {
                        selectItemid = list;

                    }

                }
                else {
                        
                    $('input[class="ckbx"]:checked').each(function () {
                        selectItemid += $(this).val() + ',';
                    });
                    if (selectItemid == "")
                    {
                        alert("请选中一个!");
                        return;
                    }
                    if (selectItemid.length > 0) {
                      
                        selectItemid = selectItemid.substring(0, selectItemid.length - 1);
                    }
                  //  alert(selectItemid);

                }

                var submitData = {
                    wid: wid,
                    openid: openid,
                    baseid: aid,
                    itemid: selectItemid,
                    isradio:isradio,
                    myact: "commit"
                };
                $.post('vote.ashx', submitData,
             function (data) {
                 if (data.ret == "ok") {
                     alert(data.content);
                     window.location.href = location.href;
                    
                 } else { alert(data.content); }
             },
             "json")



            });


          
        });



    </script>

</body>
</html>
