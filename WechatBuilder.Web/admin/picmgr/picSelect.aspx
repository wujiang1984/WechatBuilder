<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picSelect.aspx.cs" Inherits="WechatBuilder.Web.admin.picmgr.picSelect" %>

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
                selectedIco();
                return false;
            }
        }, {
            name: '取消'
        });

        $(function () {
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });

        });

        function selectedIco() {
            var opener = $($(api.data).parent().parent());
            var selectPicValue = "";

            if ($("#div_userupload").is(":hidden")) {

                if ($('input:radio[name="radPic"]:checked').val() == undefined) {
                    //说明没有选中任意一个选项
                }
                else {
                    var val = $('input:radio[name="radPic"]:checked').val();
                    selectPicValue = val;
                }
            }
            else {
                selectPicValue = $("#txtImgUrl").val();
            }

            if ($.query.get("txt").length == 0) {

                //  $("#txtImgICO", W.document).val(selectPicValue);
            }
            else {
                $("#" + $.query.get("txt"), W.document).val(selectPicValue);
            }

            if ($.query.get("img").length > 0) {

                if (selectPicValue.indexOf("/") >= 0) {
                    $("#" + $.query.get("img"), W.document).attr("src", selectPicValue);
                } else {
                    $("#" + $.query.get("img"), W.document).hide();
                    $("#" + $.query.get("img") + "_Container", W.document).append("<span class=\"" + selectPicValue + "\"></span>");

                }
            }

            api.close();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="tab-content">
            <dl>
                <dt>选择：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlTemplates" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTemplates_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                </dd>
            </dl>
            <dl>
                <table>
                    <tr>
                        <td>
                            <ul class="picUl">

                                <asp:Literal ID="litPicStr" runat="server" EnableViewState="false"></asp:Literal>
                            </ul>

                        </td>

                    </tr>

                </table>
            </dl>
            <div class="div-content" id="div_userupload" runat="server">

                <dl>
                    <dt>上传：</dt>
                    <dd>


                        <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                        <div class="upload-box upload-img"></div>
                        <span class="Validform_checktip">
                            <br />
                            推荐宽300高300像素正方形图片，个别模版需要宽720高400像素图片</span>


                    </dd>
                </dl>


            </div>
        </div>






    </form>
</body>
</html>
