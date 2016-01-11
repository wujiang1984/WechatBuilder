<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectmodulelink.aspx.cs" Inherits="MxWeiXinPF.Web.admin.dialog.selectmodulelink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>选择图片</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type='text/javascript' src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
       

        //窗口API
        var api = frameElement.api, W = api.opener;
        api.button({
            name: '确定',
            focus: true,
            callback: function () {
            }
        }, {
            name: '取消'
        });

        $(function () {

            $(".lbl_modulerad").click(function () {

                var selectmodulrvalue = $(this).children(".lblUrl").attr("title");
                $("#" + $.query.get("url"), W.document).val(selectmodulrvalue);
            });
        });

      
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="tab-content">
            <dl>
                <dt>选择：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                </dd>
            </dl>
            <dl>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tbody class="ltbody">
                        <asp:Literal ID="litModulelistStr" runat="server" EnableViewState="false"></asp:Literal>
                    </tbody>
                </table>

            </dl>

        </div>
    </form>
</body>
</html>

