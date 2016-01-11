<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editpano.aspx.cs" Inherits="MxWeiXinPF.Web.admin.pano360.editpano" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑360全景图信息</title>
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
            <a href="index.aspx" class="home"><i></i><span>360全景图列表</span></a>
            <i class="arrow"></i>
            <span>编辑360全景图</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
           <div class="mytips">
            该全景图展示地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a>
               <br />
               请上传用pano2VR软件生成的6张全景图切片，图片大小不超过300K。
        </div>
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">360全景图</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtpName" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*尽量简单，不要超过20字.</span>
                </dd>
            </dl>
            <dl>
                <dt>图片-前</dt>
                <dd>
                    <asp:Image ID="imgBefore" runat="server" ImageUrl="/images/pano360/qian.jpg"  CssClass="panobigpic"/>
                    <asp:TextBox ID="txtImgBefore" runat="server" CssClass="input normal upload-path" Text="/images/pano360/qian.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"></span>

                </dd>
            </dl>

              <dl>
                <dt>图片-右</dt>
                <dd>
                    <asp:Image ID="imgRight" runat="server" ImageUrl="/images/pano360/you.jpg"  CssClass="panobigpic" />
                    <asp:TextBox ID="txtImgRight" runat="server" CssClass="input normal upload-path" Text="/images/pano360/you.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"></span>

                </dd>
            </dl>

              <dl>
                <dt>图片-后</dt>
                <dd>
                    <asp:Image ID="imgBehond" runat="server" ImageUrl="/images/pano360/hou.jpg" CssClass="panobigpic"/>
                    <asp:TextBox ID="txtImgBehond" runat="server" CssClass="input normal upload-path" Text="/images/pano360/hou.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"></span>

                </dd>
            </dl>

              <dl>
                <dt>图片-左</dt>
                <dd>
                    <asp:Image ID="imgLeft" runat="server" ImageUrl="/images/pano360/zuo.jpg" CssClass="panobigpic" />
                    <asp:TextBox ID="txtImgLeft" runat="server" CssClass="input normal upload-path" Text="/images/pano360/zuo.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"></span>

                </dd>
            </dl>

              <dl>
                <dt>图片-顶部</dt>
                <dd>
                    <asp:Image ID="imgTop" runat="server" ImageUrl="/images/pano360/ding.jpg"  CssClass="panobigpic" />
                    <asp:TextBox ID="txtImgTop" runat="server" CssClass="input normal upload-path" Text="/images/pano360/ding.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"></span>

                </dd>
            </dl>

              <dl>
                <dt>图片-底部</dt>
                <dd>
                    <asp:Image ID="imgBottom" runat="server" ImageUrl="/images/pano360/di.jpg"   CssClass="panobigpic" />
                    <asp:TextBox ID="txtImgBottom" runat="server" CssClass="input normal upload-path" Text="/images/pano360/di.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"></span>

                </dd>
            </dl>




            <dl>
                <dt>描述信息</dt>
                <dd>
                    <textarea name="txtpContent" rows="2" cols="20" id="txtpContent" class="input" runat="server" datatype="*0-300" sucmsg=" " nullmsg=" "></textarea>

                    <span class="Validform_checktip">*请简单描述内容，尽量控制在150文字以内。</span>
                </dd>
            </dl>

           
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
