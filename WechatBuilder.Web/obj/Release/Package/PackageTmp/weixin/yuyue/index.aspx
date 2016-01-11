<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.yuyue.index" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title></title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/fans.css" rel="stylesheet" type="text/css">
        <link href="../../scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../scripts/bootstrap/datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />

    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/jquery.query.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jquery/alert.js"></script>

    <script type="text/javascript" src="../../scripts/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js"></script>


    <style type="text/css">
        .InputType
        {
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            background-color: #FFFFFF;
            border: 1px solid #E8E8E8;
            margin: 5px 0 4px;
            padding: 5px 10px;
            line-height: 28px;
            padding-left: 50px;
            color: #666666;
        }
    </style>
</head>
<body id="news">
    <form id="form1" runat="server">
        
         <asp:Literal ID="litBaseInfo" runat="server" EnableViewState="false"></asp:Literal>

        <div class="cardexplain">
            <ul class="round">
                <li class="title mb"><span class="none">请填写资料</span></li>
                <li class="nob">
                    <div class="beizhu">
                        请认真填写！
                    </div>
                </li>
                 <asp:Literal ID="litFormStr" runat="server" EnableViewState="false"></asp:Literal>

               <%-- <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tbody>
                            <tr>
                                <th>采购类型
                                </th>
                                <td>
                                    <select id="caigou_type" name="caigou_type" class="InputType">
                                        <option>现有产品、工艺产品</option>
                                        <option>客户定制产品</option>
                                    </select>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </li>
                <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tbody>
                            <tr>
                                <th>所属行业
                                </th>
                                <td>
                                    <input name="hangye" type="text" class="px" id="hangye" value="" placeholder="所属行业">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </li>--%>
                
            </ul>
            <div class="footReturn">
                <a id="showcard" class="submit" href="javascript:void(0)">提 交</a>
                <div class="window" id="windowcenter">
                    <div id="title" class="wtitle">
                        保存成功<span class="close" id="alertclose"></span>
                    </div>
                    <div class="content">
                        <div id="txt">
                        </div>
                    </div>
                </div>
            </div>


             

        </div>

        <asp:Literal ID="litJs" runat="server" EnableViewState="false"></asp:Literal>

    </form>

        <script type="text/javascript">
            $(document).ready(function () {
                $('.datetimepicker').datetimepicker({
                    minView: "month", //选择日期后，不会再跳转去选择时分秒 
                    format: "yyyy-mm-dd", //选择日期后，文本框显示的日期格式 
                    language: 'zh-CN', //汉化 
                    autoclose: true //选择日期后自动关闭 
                });

            });
        </script>
</body>

</html>
