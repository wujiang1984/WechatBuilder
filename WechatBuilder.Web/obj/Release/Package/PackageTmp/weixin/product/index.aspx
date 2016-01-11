<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.product.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <title></title>

    <base href=".">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta charset="utf-8">
    <link href="css/alltype.css" rel="stylesheet" type="text/css">
    <link href="css/listhome.css" rel="stylesheet" type="text/css">
    <link href="css/alltypelist.css" rel="stylesheet" type="text/css">
    <link href="css/car_reset.css" rel="stylesheet" type="text/css">
    <link href="css/mystyle.css" rel="stylesheet" type="text/css">
    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/jquery.query.js" type="text/javascript"></script>
    <style>
        .themeStyle {
            background: #E83407 !important;
            background-color: #E83407 !important;
        }
    </style>
</head>
<body id="cate9">
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgBanner" runat="server" Style="width: 100%;" EnableViewState="false" />
        </div>

        <div id="overlay"></div>
        <div class="body">

            <section>

        <ul class="list_ul list_ul_news">

                    <asp:Repeater ID="rpAction" runat="server"  >
                        <ItemTemplate>
                            <li>

                                <a href='<%#getDetailUrl(Eval("id"),Eval("typeId")) %> ' id="aDetail" class="tbox">
                                    <div  >
                                        <img alt="" src='<%# Eval("extStr2") %>' style="width:60px!important; height:60px;"/>

                                    </div>
                                      
                                    <div>
                                         
                                       <p> <asp:Literal ID="litAName" runat="server" Text='<%# Eval("hdName") %>'></asp:Literal>
                                        </p>
                                       

                                      <p style="padding-right:25px;"> <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("pSubject") %>'></asp:Literal> </p>

                                    </div>
                                 </a>
                              <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("showInfo") %>'></asp:Literal>
                           
                                    </li>

                        </ItemTemplate>
                    </asp:Repeater>


                </ul>

            </section>
        </div>


        <div class="Listpage">
            
            <section id="Page_wrapper">
            <div id="pNavDemo" class="c-pnav-con">
            <section class="c-p-sec">
                <asp:Literal ID="litGoBefore" runat="server" EnableViewState="false"></asp:Literal>
             
                <div class="c-p-cur">
                    <div class="c-p-arrow c-p-down">
                        <span>
                             <asp:Literal ID="litCurrentPage" runat="server" Text="" EnableViewState="false"></asp:Literal>/<asp:Literal ID="litTotalPage" runat="server" Text="" EnableViewState="false"></asp:Literal>
                        </span>
                        <span></span>
                    </div>
                     
                     <asp:Literal ID="litPSelect" runat="server" EnableViewState="false"></asp:Literal>
                </div>
                 <asp:Literal ID="litGoAfter" runat="server" EnableViewState="false"></asp:Literal>
             
            </section>
            </div>
        </section>
            <script type="text/javascript">
                function dourl(id) {
                    var openid = $.query.get("openid");
                    var typecode = $.query.get("typecode");
                    window.location.href = "detail.aspx?id=" + id + "&openid=" + openid + "&typecode=" + typecode;
                }

                function fenyedourl(url) {

                    window.location.href = url;
                }

                function doyuding(url) {
                    window.location.replace(url);
                }

            </script>
            <div class="copyright">&nbsp;</div>
            <script src="js/zepto.min.js" type="text/javascript"></script>
    </form>
</body>
</html>

