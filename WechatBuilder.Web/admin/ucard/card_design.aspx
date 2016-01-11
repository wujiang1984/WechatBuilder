<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="card_design.aspx.cs" Inherits="WechatBuilder.Web.admin.ucard.card_design" %>

<%@ Import Namespace="WechatBuilder.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>卡版面设置 </title>
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
    <script type="text/javascript" src="../../scripts/jscolor/jscolor.js"></script>
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

            $("#txtcardNameColor").blur(function () {

                $("#vipname").css("color", "#" + $(this).val());
                // alert("#" + $(this).val());
            });
            $("#txtcardNoColor").blur(function () {
                $('#number').css("color", "#" + $(this).val());
            });

            $("#txtcardName").keyup(function () {
                $("#vipname").html($("#txtcardName").val());
            });

            $("#btnSelectICO").click(function () {

                selectico("cardlogo", "txtImgICO");
            });

            //atxtnoticePic


            $("#cardlogo").change(function () {
                if ($.trim($(this).attr("src")) == "") {
                    $(this).hide();
                }
            });

        });

        function selectico(imgControlId, txtUrlControlId) {
            $.dialog({
                id: 'selectIco',
                fixed: true,
                lock: true,
                max: false,
                min: false,
                title: "选择图片",
                content: "url:/admin/picmgr/picSelect.aspx?img=" + imgControlId + "&txt=" + txtUrlControlId,
                height: 420,
                width: 750
            });

        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="business_list.aspx" class="back"><i></i><span>返回会员卡商家管理</span></a>
            <a href="business_list.aspx" class="home"><i></i><span>会员卡商家管理</span></a>
            <i class="arrow"></i>
            <span>卡版面设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <asp:HiddenField ID="hidid" runat="server" Value="0" />
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">卡版面基本设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">内容页头部Banner图片设置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>会员卡效果图</dt>
                <dd id="cardxgt">

                    <div id="vipcard" class="vipcard">
                        <img id="cardbg" src="/weixin/ucard/images/cardbg/card_bg01.png" runat="server">
                        <img id="cardlogo" class="cardlogo" src="" runat="server">
                        <h1 id="vipname" style="color: #1B820C" runat="server">会员卡</h1>
                        <strong class="pdo verify" id="number" style="color: #387A17" runat="server"><span><em>会员卡号</em>888 8888</span></strong>
                    </div>

                </dd>

            </dl>
            <dl>
                <dt>会员卡的名称：</dt>
                <dd>
                    <asp:TextBox ID="txtcardName" runat="server" CssClass="input normal" Text="会员卡" datatype="*1-100" nullmsg="最多50个字符" sucmsg=" " />
                    <span class="Validform_checktip">*最多50个字符</span>

                    &nbsp;&nbsp;&nbsp;&nbsp;
                    颜色：<asp:TextBox ID="txtcardNameColor" runat="server" CssClass="input normal color small " Text="1B820C" />

                </dd>
            </dl>
            <dl>
                <dt>会员卡的图标：</dt>
                <dd>
                    <asp:TextBox ID="txtImgICO" runat="server" CssClass="input normal" ReadOnly="true"></asp:TextBox>
                    <input id="btnSelectICO" type="button" value="选择" class="btn" />
                    <span class="Validform_checktip">Logo宽370px高170px，图案上下左右居中,请填写你的logo外链地址</span>
                </dd>
            </dl>
            <dl>
                <dt>会员卡的背景：</dt>
                <dd>
                    <asp:DropDownList ID="ddlbgTypeId" runat="server" Width="100" datatype="*" sucmsg=" " onchange="document.getElementById('cardbg').src=this.options[this.selectedIndex].value;document.getElementById('suicai2').value=this.options[this.selectedIndex].value;">
                       
                         <asp:ListItem Text="1" Value="/weixin/ucard/images/cardbg/card_bg01.png"></asp:ListItem>
                        <asp:ListItem Text="2" Value="/weixin/ucard/images/cardbg/card_bg02.png"></asp:ListItem>
                        <asp:ListItem Text="3" Value="/weixin/ucard/images/cardbg/card_bg03.png"></asp:ListItem>
                        <asp:ListItem Text="4" Value="/weixin/ucard/images/cardbg/card_bg04.png"></asp:ListItem>
                        <asp:ListItem Text="5" Value="/weixin/ucard/images/cardbg/card_bg05.png"></asp:ListItem>
                        <asp:ListItem Text="6" Value="/weixin/ucard/images/cardbg/card_bg06.png"></asp:ListItem>
                        <asp:ListItem Text="7" Value="/weixin/ucard/images/cardbg/card_bg07.png"></asp:ListItem>
                        <asp:ListItem Text="8" Value="/weixin/ucard/images/cardbg/card_bg08.png"></asp:ListItem>
                        <asp:ListItem Text="9" Value="/weixin/ucard/images/cardbg/card_bg09.png"></asp:ListItem>
                        <asp:ListItem Text="10" Value="/weixin/ucard/images/cardbg/card_bg10.png"></asp:ListItem>
                        <asp:ListItem Text="11" Value="/weixin/ucard/images/cardbg/card_bg11.png"></asp:ListItem>
                        <asp:ListItem Text="12" Value="/weixin/ucard/images/cardbg/card_bg12.png"></asp:ListItem>
                        <asp:ListItem Text="13" Value="/weixin/ucard/images/cardbg/card_bg13.png"></asp:ListItem>
                        <asp:ListItem Text="14" Value="/weixin/ucard/images/cardbg/card_bg14.png"></asp:ListItem>
                        <asp:ListItem Text="15" Value="/weixin/ucard/images/cardbg/card_bg15.png"></asp:ListItem>
                        <asp:ListItem Text="16" Value="/weixin/ucard/images/cardbg/card_bg16.png"></asp:ListItem>
                        <asp:ListItem Text="17" Value="/weixin/ucard/images/cardbg/card_bg17.png"></asp:ListItem>
                        <asp:ListItem Text="18" Value="/weixin/ucard/images/cardbg/card_bg18.png"></asp:ListItem>
                        <asp:ListItem Text="19" Value="/weixin/ucard/images/cardbg/card_bg19.png"></asp:ListItem>
                        <asp:ListItem Text="20" Value="/weixin/ucard/images/cardbg/card_bg20.png"></asp:ListItem>
                        <asp:ListItem Text="21" Value="/weixin/ucard/images/cardbg/card_bg21.png"></asp:ListItem>
                        <asp:ListItem Text="22" Value="/weixin/ucard/images/cardbg/card_bg22.png"></asp:ListItem>
                        <asp:ListItem Text="23" Value="/weixin/ucard/images/cardbg/card_bg23.png"></asp:ListItem>

                    </asp:DropDownList>

                </dd>
            </dl>

            <dl>
                <dt>自己设计背景:</dt>
                <dd>
                    <asp:TextBox ID="txtbgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">背景图宽534px高318px，图片类型png</span>
                </dd>
            </dl>
            <dl>
                <dt>卡号文字颜色:</dt>
                <dd>
                    <asp:TextBox ID="txtcardNoColor" runat="server" CssClass="input normal color small " Text="387A17" />
                </dd>
            </dl>
            <dl>
                <dt>下载模版:</dt>
                <dd>
                    <a href="/weixin/ucard/images/template.rar" class="green">请下载模板</a>
                </dd>
            </dl>
        </div>
        <div class="tab-content" style="display:none;">
             <div class="mytips">
               备注：图片宽640px高109px或者更高，但是不要高太多；图片类型为jpg，签到图片外与其他图片高度不同，尽量根据模板图片修改。
            </div>

            <table class="userinfoArea" style="margin: 0;" border="0" cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td align="center" valign="top">
                            <div class="banner">
                                <img src="/weixin/ucard/images/themes/1/news-2.jpg">
                                <img id="news" src="/weixin/ucard/images/themes/1/news.jpg" runat="server">
                                <img src="/weixin/ucard/images/themes/1/news-3.jpg">
                            </div>
                        </td>
                        <td align="center" valign="top">
                            <div class="banner">
                                <img src="/weixin/ucard/images/themes/1/vippower-2.jpg">
                                <img id="vippower" src="/weixin/ucard/images/themes/1/vippower.jpg" runat="server">
                                <img src="/weixin/ucard/images/themes/1/vippower-3.jpg">
                            </div>
                        </td>
                        <td align="center" valign="top">
                            <div class="banner">
                                <img src="/weixin/ucard/images/themes/1/qiandao-2.jpg">
                                <img id="qiandao" src="/weixin/ucard/images/themes/1/qiandao.jpg" runat="server">
                                <div class="bannerbtn">
                                    <img src="/weixin/ucard/images/themes/1/qiandao-3.jpg">
                                    <img class="qiaodaobtn" src="/weixin/ucard/images/themes/1/qiandao-4.png">
                                </div>
                            </div>
                        </td>
                        <td align="center" valign="top">
                            <div class="banner">
                                <img src="/weixin/ucard/images/themes/1/shopping-2.jpg">
                                <img id="shopping" src="/weixin/ucard/images/themes/1/shopping.jpg" runat="server">
                                <img src="/weixin/ucard/images/themes/1/shopping-3.jpg">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">填写外链地址查看效果</td>
                        <td align="center">填写外链地址查看效果</td>
                        <td align="center">填写外链地址查看效果</td>
                        <td align="center">填写外链地址查看效果</td>
                    </tr>
                    <tr>
                        <td align="center">
                            <textarea name="noticebenner" class="px" id="txtnoticePic" runat="server"  style="width: 210px; height: 36px" onblur="document.getElementById('news').src=document.getElementById('txtnoticePic').value;">/weixin/ucard/images/themes/1/news.jpg</textarea>
                           <br /> 
                            <a href="javascript:void(0)" class="green" id="atxtnoticePic" onclick="selectico('news','noticebenner')">选择</a>

                        </td>
                        <td align="center">
                            <textarea name="txtprivilegesPic" class="px" id="txtprivilegesPic" runat="server" style="width: 210px; height: 36px" onblur="document.getElementById('vippower').src=document.getElementById('txtprivilegesPic').value;">/weixin/ucard/images/themes/1/vippower.jpg</textarea>
                            <br /> <a href="javascript:void(0)" class="green" id="scsmembers4" onclick="selectico('vippower','txtprivilegesPic')">选择</a>

                        </td>
                        <td align="center">
                            <textarea name="txtqiandaoPic" class="px" id="txtqiandaoPic" runat="server" style="width: 210px; height: 36px" onblur="document.getElementById('qiandao').src=document.getElementById('txtqiandaoPic').value;">/weixin/ucard/images/themes/1/qiandao.jpg</textarea>
                           <br />  <a href="javascript:void(0)" class="green" id="scsmembers5" onclick="selectico('qiandao','txtqiandaoPic')">选择</a>

                        </td>
                        <td align="center">
                            <textarea name="txtshopingPic" class="px" id="txtshopingPic" runat="server" style="width: 210px; height: 36px" onblur="document.getElementById('shopping').src=document.getElementById('txtshopingPic').value;">/weixin/ucard/images/themes/1/shopping.jpg</textarea>
                            <br /> <a href="javascript:void(0)" class="green" id="scsmembers6" onclick="selectico('shopping','txtshopingPic');">选择</a>

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <div class="banner">
                                <img src="/weixin/ucard/images/themes/1/user-2.jpg">
                                <img id="user" src="/weixin/ucard/images/themes/1/user.jpg" runat="server">
                                <img src="/weixin/ucard/images/themes/1/user-3.jpg">
                            </div>
                        </td>
                        <td align="center" valign="top">
                            <div class="banner">
                                <img src="/weixin/ucard/images/themes/1/info-2.jpg">
                                <img id="info" src="/weixin/ucard/images/themes/1/info.jpg" runat="server">
                                <img src="/weixin/ucard/images/themes/1/info-3.jpg">
                            </div>
                        </td>
                        <td align="center" valign="top">
                            <div class="banner">
                                <img src="/weixin/ucard/images/themes/1/addr-2.jpg">
                                <img id="addr" src="/weixin/ucard/images/themes/1/addr.jpg" runat="server">
                                <img src="/weixin/ucard/images/themes/1/addr-3.jpg">
                            </div>
                        </td>
                        <td align="center" valign="middle">
                            <span class="red"></span><a href="/weixin/ucard/images/template2.rar" class="green">请下载模板</a>

                        </td>
                    </tr>
                    <tr>
                        <td align="center">填写外链地址查看效果</td>
                        <td align="center">填写外链地址查看效果</td>
                        <td align="center">填写外链地址查看效果</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">
                            <textarea name="zlbenner" class="px" id="txtperinfoPic" runat="server" style="width: 210px; height: 36px" onblur="document.getElementById('user').src=document.getElementById('txtperinfoPic').value;">/weixin/ucard/images/themes/1/user.jpg</textarea>
                             <br /><a href="javascript:void(0)" class="green" id="scsmembers7" onclick="selectico('user','txtperinfoPic');">选择</a>

                        </td>
                        <td align="center">
                            <textarea name="smbenner" class="px" id="txtinstructionsPic" runat="server" style="width: 210px; height: 36px" onblur="document.getElementById('info').src=document.getElementById('txtinstructionsPic').value;">/weixin/ucard/images/themes/1/info.jpg</textarea>
                            <br /> <a href="javascript:void(0)" class="green" id="scsmembers8" onclick="selectico('info','txtinstructionsPic');">选择</a>

                        </td>
                        <td align="center">
                            <textarea name="lxbenner" class="px" id="txtcontactusPic" runat="server" style="width: 210px; height: 36px" onblur="document.getElementById('addr').src=document.getElementById('txtcontactusPic').value;">/weixin/ucard/images/themes/1/addr.jpg</textarea>
                             <br /><a href="javascript:void(0)" class="green" id="scsmembers9" onclick="selectico('addr','txtcontactusPic');">选择</a>

                        </td>
                        <td>
                            &nbsp;
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
