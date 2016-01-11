<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pano.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.pano360.pano" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
  
    <style type="text/css" title="Default">
        html, body {
            height: 100%;
            padding: 0;
            margin: 0;
        }

        body {
            font-size: 10pt;
            background: #ffffff;
        }
        /* fix for scroll bars on webkit & Mac OS X Lion */
        ::-webkit-scrollbar {
            background-color: rgba(0,0,0,0.5);
            width: 0.75em;
        }

        ::-webkit-scrollbar-thumb {
            background-color: rgba(255,255,255,0.5);
        }
    </style>
</head>
<body>
    <script src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
     <script src="../../scripts/jquery/jquery.query.js"></script>
        <script type="text/javascript" src="js/pano2vr_player.js">
        </script>
        <div id="container" style="width: 100%; height: 100%;">
            This content requires HTML5/CSS3, WebGL, or Adobe Flash Player Version 9 or higher.
        </div>
         
        <script type="text/javascript">
            // create the panorama player with the container
            var req_id = $.query.get("id");
            pano = new pano2vrPlayer("container");
            pano.readConfigUrl("xmlstr.aspx?id=" + req_id);
            // hide the URL bar on the iPhone
            hideUrlBar();

        </script>
        <noscript>
        <p><b>Please enable Javascript!</b></p>
    </noscript>

        <p>
     
</body>
</html>
