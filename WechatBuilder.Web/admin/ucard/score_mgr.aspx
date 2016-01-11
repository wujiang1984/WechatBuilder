<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="score_mgr.aspx.cs" Inherits="WechatBuilder.Web.admin.ucard.score_mgr" %>

<%@ Import Namespace="WechatBuilder.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>积分设置 </title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../../admin/js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="business_list.aspx" class="back"><i></i><span>返回会员卡商家管理</span></a>
            <a href="business_list.aspx" class="home"><i></i><span>会员卡商家管理</span></a>
            <i class="arrow"></i>
            <span>积分设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <asp:HiddenField ID="hidid" runat="server" Value="0" />
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">积分设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);" >会员等级积分设置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>会员卡使用说明：</dt>
                <dd>
                    <textarea name="txtuserdContent" rows="2" cols="20" id="txtuserdContent" class="input" runat="server" datatype="*1-300" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>积分规则说明：</dt>
                <dd>
                    <textarea name="txtscoreRegular" rows="2" cols="20" id="txtscoreRegular" class="input" runat="server" datatype="*1-300" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <thead>
                    <tr>
                        <th width="25%">策略名称</th>
                        <th width="25%">奖励积分</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody class="ltbody">
                    <tr class="td_c">
                        <td>每天签到奖励
                        </td>
                        <td>
                            <asp:TextBox ID="txtqiandaoScore" runat="server" Text="1" datatype="n" sucmsg=" " nullmsg=" "></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr class="td_c">
                        <td>连续6天签到奖励
                        </td>
                        <td>
                            <asp:TextBox ID="txtqiandao6Score" runat="server" Text="1" datatype="n" sucmsg=" " nullmsg=" "></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr class="td_c">
                        <td>消费
                        <asp:TextBox ID="txtconsumeMoney" runat="server" Text="1" datatype="n" sucmsg=" " nullmsg=" "></asp:TextBox>元奖励
                        </td>
                        <td>
                            <asp:TextBox ID="txtconsumeMoneyScore" runat="server" Text="10" datatype="n" sucmsg=" " nullmsg=" "></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tab-content" style="display:none;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <thead>
                    <tr>
                        <th width="10%">序号</th>
                        <th width="25%">会员等级</th>
                        <th width="25%">积分设置</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody class="ltbody">
                    <tr class="td_c">
                        <td>
                            1
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel1Name" runat="server" Text="" datatype="*0-100" class="input"></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtLevel1Min" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel1Max" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr class="td_c">
                        <td>
                           2
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel2Name" runat="server" Text="" datatype="*0-100" class="input"></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtLevel2Min" runat="server" Text=""  class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel2Max" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                     <tr class="td_c">
                        <td>
                            3
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel3Name" runat="server" Text="" datatype="*0-100" class="input"></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtLevel3Min" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel3Max" runat="server" Text=""  class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                     <tr class="td_c">
                        <td>
                            4
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel4Name" runat="server" Text="" datatype="*0-100" class="input"></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtLevel4Min" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel4Max" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                     <tr class="td_c">
                        <td>
                           5
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel5Name" runat="server" Text="" datatype="*0-100" class="input"></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtLevel5Min" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel5Max" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                     <tr class="td_c">
                        <td>
                           6
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel6Name" runat="server" Text="" datatype="*0-100" class="input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel6Min" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel6Max" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                     <tr class="td_c">
                        <td>
                           7
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel7Name" runat="server" Text="" datatype="*0-100" class="input" ></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtLevel7Min" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel7Max" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                     <tr class="td_c">
                        <td>
                           8
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel8Name" runat="server" Text="" datatype="*0-100" class="input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLevel8Min" runat="server" Text=""   class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                            -
                            <asp:TextBox ID="txtLevel8Max" runat="server" Text=""  class="input small" onkeydown="return checkNumber(event);"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>



                </tbody>
            </table>
        </div>


        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="business_list.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
