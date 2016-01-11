<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editYuyue.aspx.cs" Inherits="WechatBuilder.Web.admin.yuyue.editYuyue" ValidateRequest="false"  %>

<%@ Import Namespace="WechatBuilder.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑预约信息</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
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

            $("input[name='rblSMSTXType']").click(function () {
                if ($(this).val() == "1") {
                    $("#chkTelNeed").attr("checked", "true");
                    $("#chkTelNeedBT").attr("checked", "true");
                }
            });
           

        });
    </script>
     
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="index.aspx" class="back"><i></i><span>返回预约列表</span></a>
            <i class="arrow"></i>
            <span>编辑预约信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <div class="mytips">
            该预约的地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a>
        </div>


        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑基本信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">表单设置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>活动名称</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*尽量简单，不要超过20字.</span>
                </dd>
            </dl>

            <dl>
                <dt>公司地址</dt>
                <dd>
                    <textarea name="txtaddr" rows="2" cols="20" id="txtaddr" class="input" runat="server" datatype="*0-300" sucmsg=" " nullmsg=" "></textarea>

                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>客服电话</dt>
                <dd>
                    <asp:TextBox ID="txtphone" runat="server" CssClass="input normal" datatype="*0-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>预约说明</dt>
                <dd>
                    <textarea name="txtcontent" rows="2" cols="20" id="txtcontent" class="input" runat="server" datatype="*0-500" sucmsg=" " nullmsg=" "></textarea>

                    <span class="Validform_checktip">*请描述预约说明</span>
                </dd>
            </dl>
             <dl>
                <dt>手机短信提醒</dt>
                <dd>
                      <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblSMSTXType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <span class="Validform_checktip">*选择是，则需要设置短信接口帐号，并且在表单设置里勾选手机号</span>
                </dd>
            </dl>

            <dl>
                <dt>首页图片</dt>
                <dd>
                    <asp:Image ID="imgfacePicPic" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" /><br />
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>

                </dd>
            </dl>
        </div>
        <div class="tab-content" style="display: none;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <thead>
                    <tr>
                        <th>类型
                        </th>
                        <th>显示名称
                        </th>
                        <th>值(选项用英文的逗号(,)隔开)
                        </th>
                        <th>必填项
                        </th>
                        <th>排序
                        </th>
                    </tr>
                </thead>
                <tbody class="ltbody">
                    <tr class="td_c">
                        <td>
                            手机
                        </td>
                        <td>
                            【<asp:CheckBox ID="chkTelNeed" runat="server" Text="需要显示则勾上" />】
                            <asp:TextBox ID="txtTelNeedName" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="手机" />
                             
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelNeedValue" runat="server" CssClass="input normal" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkTelNeedBT" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelNeedSortid" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>
                     <tr class="td_c">
                        <td>
                            姓名
                        </td>
                        <td>
                            【<asp:CheckBox ID="chkNameNeed" runat="server" Text="需要显示则勾上" />】
                            <asp:TextBox ID="txtNameNeedName" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="姓名" />
                             
                        </td>
                        <td>
                            <asp:TextBox ID="txtNameNeedValue" runat="server" CssClass="input normal" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkNameNeedBT" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtNameNeedSortid" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                     <tr class="td_c">
                        <td>
                            时间
                        </td>
                        <td>
                            【<asp:CheckBox ID="chkDateNeed" runat="server" Text="需要显示则勾上" />】
                            <asp:TextBox ID="txtDateNeedName" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="预约时间" />
                             
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateNeedValue" runat="server" CssClass="input normal" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkDateNeedBT" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateNeedSortid" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>


                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl1Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt1Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt1Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk1Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt1Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>
                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl2Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt2Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt2Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk2Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt2Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl3Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt3Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt3Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk3Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt3Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl4Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt4Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt4Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk4Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt4Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl5Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt5Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt5Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk5Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt5Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl6Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt6Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt6Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk6Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt6Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl7Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt7Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt7Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk7Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt7Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl8Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt8Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt8Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk8Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt8Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                        </td>
                    </tr>

                    <tr class="td_c">
                        <td>
                            <asp:DropDownList ID="ddl9Type" runat="server">
                                <asp:ListItem Text="文本" Value="0"></asp:ListItem>
                                <asp:ListItem Text="下拉选择" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt9Name" runat="server" CssClass="input   txtname" datatype="*0-20" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt9Value" runat="server" CssClass="input normal" datatype="*0-500" sucmsg=" " Text="" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chk9Btx" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt9Seq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
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
                <a href="index.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
