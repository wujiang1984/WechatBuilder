<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dianyuan_add.aspx.cs" Inherits="WechatBuilder.Web.admin.diancai.dianyuan_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title></title>
   <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
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
      <div class="location">
            <a href="shop_list.aspx" class="home"><i></i><span>点菜系统</span></a>
            <i class="arrow"></i><span><a href="dianyuan_manage.aspx?shopid=<%=shopid %>" >店员信息管理</a></span>
            <i class="arrow"></i>            
            <span>店员信息管理</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">店员信息管理</a></li>
                    
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>

                 <div  class="tab-content" >
                <dl>
                    <dt>姓名：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="dianyuanName" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                   <dl>
                    <dt>用户名：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="userName" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                   <dl>
                    <dt>密码：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="pwd" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                  <dl>
                    <dt>入职时间：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="beginTime"  CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"  datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                 <dl>
                    <dt>在职状态：</dt>
                    <dd>
                                <select name="userStatus" id="userStatus"  runat="server">
                                  <option value="1">在职</option>
                                  <option value="0">离职</option>
                                  
                                 
                  </select>
                    </dd>
                </dl>

                  <dl>
                    <dt>备注：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="remark" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                  <dl>
                    <dt>电话：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="dianyuanTel" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                 <dl>
                    <dt>离职时间：</dt>
                    <dd>
                         <asp:TextBox runat="server" ID="endTime"  CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"  errormsg="请选择正确的日期"  ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>

          </div>
           <div class="page-footer" >
            <div class="btn-list">      
             <asp:Button ID="save_dianyuan" runat="server"  CssClass="btn" Text="保存" OnClick="save_dianyuan_Click"    />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
