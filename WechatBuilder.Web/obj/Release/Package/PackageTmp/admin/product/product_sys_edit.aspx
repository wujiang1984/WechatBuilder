<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_sys_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.product.product_sys_edit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑产品库基本信息</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
             <a href="product_Sys.aspx" class="back"><i></i><span>返回列表页</span></a>
            <i class="arrow"></i>
            <a href="javascript:;" class="home"><i></i><span>编辑产品库基本信息</span></a>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑产品库基本信息</a></li>
                      
                    </ul>
                </div>
            </div>
        </div>
        <asp:Label ID="lblId" runat="server" Style="display: none;" Text="0"></asp:Label>
       

        <!--微网站基本信息-->
        <div class="tab-content">
            <dl>
                <dt>网址</dt>
                <dd>
                    <asp:Label ID="lblweixinUrl" runat="server" Text="保存后自动生成" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txthdTitle" runat="server" CssClass="input normal" datatype="*1-255" sucmsg=" " nullmsg="请填写网站名称"></asp:TextBox>
                    <span class="Validform_checktip">*任意字符，控制在255个字符内</span>
                </dd>
            </dl>
             
            <dl>
                <dt>封面图片</dt>
                <dd>
                     <asp:Image ID="imgBanner" runat="server" style=" height:80px;" ImageUrl="~/images/noneimg.jpg" /><br />
                    <asp:TextBox ID="txtbgPic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            
           

            <dl>
                <dt>简介</dt>
                <dd>
                    <asp:TextBox ID="txtwBrief" runat="server" CssClass="input" TextMode="MultiLine" />
                    <span class="Validform_checktip"> 简介</span>
                </dd>
            </dl>

           <dl>
                <dt>排序数字</dt>
                <dd>
                    <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                    <span class="Validform_checktip">*数字，越小越向前</span>
                </dd>
            </dl>
            
        </div>
        <!--/微网站基本信息-->
 

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                 
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
