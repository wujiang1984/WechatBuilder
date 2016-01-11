<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="business_edit.aspx.cs" Inherits="WechatBuilder.Web.admin.ucard.business_edit" %>

<%@ Import Namespace="WechatBuilder.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑会员卡商家</title>
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


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="business_list.aspx" class="back"><i></i><span>返回列表</span></a>
            <i class="arrow"></i>
            <span>商家设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
          <div class="mytips">
            该会员卡商城网址：<a href="javascript:;"><asp:Literal ID="litUrl" runat="server" Text="新增完自定生成"></asp:Literal></a> 可以直接融合代3G页面(使用关键词回复)
        </div>
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">商家设置</a></li>
                        
                    </ul>
                </div>
            </div>
        </div>
          <asp:HiddenField ID="hidid" runat="server" Value="0" />
        <div class="tab-content">
            <dl>
                <dt>关键词</dt>
                <dd>
                  
                    <asp:TextBox ID="txtKW" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*只能写一个关键词，用户输入此关键词将会触发此活动。</span>
                </dd>
            </dl>
            <dl>
                <dt>图文消息封面图片</dt>
                <dd>
                    <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/weixin/ucard/images/ucard_cover.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>

                </dd>
            </dl>


            <dl>
                <dt>商家名称</dt>
                <dd>
                    <asp:TextBox ID="txtstoreName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
            <dl>
                <dt>商家logo外链地址</dt>
                <dd>
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtLogo" runat="server" CssClass="input normal upload-path" datatype="*1-800" sucmsg=" "  nullmsg="请选择图片"/>
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽100像素，高100像素） 小于100k;</span>
                </dd>
            </dl>

            <dl>
                <dt>商家简介</dt>
                <dd>
                    <textarea name="txtcardBrief" rows="2" cols="20" id="txtcardBrief" class="input" runat="server" datatype="*1-300" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>分类</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlstoreCatagory" runat="server" datatype="*" sucmsg=" ">
                            <asp:ListItem Text="美食餐饮" Value="美食餐饮" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="休闲娱乐" Value="休闲娱乐"></asp:ListItem>
                            <asp:ListItem Text="购物" Value="购物"></asp:ListItem>
                            <asp:ListItem Text="丽人" Value="丽人"></asp:ListItem>
                            <asp:ListItem Text="结婚" Value="结婚"></asp:ListItem>
                            <asp:ListItem Text="亲子" Value="亲子"></asp:ListItem>
                            <asp:ListItem Text="运动健身" Value="运动健身"></asp:ListItem>
                            <asp:ListItem Text="酒店" Value="酒店"></asp:ListItem>
                            <asp:ListItem Text="爱车" Value="爱车"></asp:ListItem>
                            <asp:ListItem Text="生活服务" Value="生活服务"></asp:ListItem>
                            <asp:ListItem Text="其他" Value="其他"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>

            <dl>
                <dt>电话</dt>
                <dd>
                    <asp:TextBox ID="txttel" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>

            <dl>
                <dt>地址</dt>
                <dd>
                    <asp:TextBox ID="txtaddr" runat="server" CssClass="input normal" datatype="*1-300" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*  </span>
                </dd>
            </dl>
             <dl>
                <dt>地图选点</dt>
                <dd>
                    <iframe id="baiduframe" src="../lbs/MapSelectPoint.aspx?yjindu=121.526149&xweidu=31.222663" height="300" width="700" style="border: 1px solid #e1e1e1;"></iframe>
                </dd>
            </dl>
            <dl>
                <dt>&nbsp;</dt>
                <dd>纬度（x）: 
                    <asp:TextBox ID="txtLatXPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span> &nbsp;&nbsp;&nbsp;
                    经度（y）:
                    <asp:TextBox ID="txtLngYPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>消费确认密码</dt>
                <dd>
                    <asp:TextBox ID="txtconsumePwd" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text=""   nullmsg="  " />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>


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
