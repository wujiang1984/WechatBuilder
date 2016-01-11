<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.lbs.index" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>lbs商家信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <link rel="stylesheet" href="css/themes/default/jquery.mobile-1.3.1.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.mobile-1.3.1.min.js"></script>
    <style type="text/css">
        a
        {
            color: #999;
        }

        .phone
        {
            width: 32px;
            height: 32px;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div data-role="page" data-theme="a" id="demo-page" class="my-page">
                
                <asp:Image ID="bannerPic" runat="server" style="width:100%;" EnableViewState="false" />
                <ul data-role="listview" data-split-icon="plus" data-theme="a" data-split-theme="b"
                    data-split-icon="delete" data-inset="true">
                    <li>
                        <h6>共查询到 <asp:Literal ID="litshopNum" runat="server" Text="0" EnableViewState="false" ></asp:Literal> 间门店</h6>
                    </li>

                     <asp:Literal ID="txtrpLocationStr" runat="server" EnableViewState="false" ></asp:Literal>

                </ul>
            </div>



        </div>
    </form>
</body>
</html>
