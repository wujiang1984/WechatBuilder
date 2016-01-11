<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cards_add.aspx.cs" Inherits="MxWeiXinPF.Web.admin.cards.cards_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                 $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.mp3;" });
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
          <!--导航栏-->
        <div class="location">
            <a href="message_list.aspx" class="home"><i></i><span>贺卡管理</span></a>
            <i class="arrow"></i>
             
            <span>贺卡设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                         <li><a href="javascript:;" onclick="tabs(this);" class="selected">贺卡设置</a></li>
                   
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>


        <div  class="tab-content" >
            
                <dl>
                    <dt>标题名字：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="title" CssClass="input normal" datatype="*1-100"  sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
             
                <dl>
                    <dt >背景图片：</dt>
                    <dd>
                        <asp:Image ID="imgPic" runat="server" ImageUrl="" Style="max-height: 80px;" />
                        <asp:TextBox runat="server" CssClass="input normal upload-path" ID="backPic" datatype="*1-100"  sucmsg=" " nullmsg=" " ></asp:TextBox>
                         <div class="upload-box upload-img"></div>
                   
                    </dd>
                </dl>

                <dl>
                    <dt >背景音乐：</dt>
                    <dd>
                        <asp:TextBox runat="server" CssClass="input normal upload-path" ID="backMusic"  ></asp:TextBox>
                         <div class="upload-box upload-img"></div>
                    <span class="red">
                   建议留空
                    </span>
                   
                    </dd>
                </dl>

                 <dl>
                    <dt >选择背景动画：</dt>
                    <dd>
                   <select name="backCartoon" id="backCartoon"  runat="server">
                   <option value="" selected="selected">请选择</option>
                   <option value="0" >无动画</option>
                   <option value="1">下落的枫叶</option>
                   <option value="2">飘雪</option>
                   <option value="4">飘玫瑰</option>
                   <option value="5">驯鹿托礼物</option>
                  <option value="7">金元宝</option>
                  </select>
                    </dd>
                </dl>

                 <dl>
                    <dt >默认文字：</dt>
                    <dd>
                         <textarea name="characters" rows="2" cols="20" id="characters" datatype="*1-1000" sucmsg=" " nullmsg=""  class="input" runat="server"></textarea>
                         <span class="Validform_checktip">*</span>
                          <span class="red">
                      建议留空  尽量控制在60字左右，生日卡，就写生日祝语。 圣诞卡就圣诞祝语...
                    </span>
                   
                    </dd>
                </dl>

              <dl>
                    <dt >版权：</dt>
                    <dd>
                       <textarea name="copyRight" rows="2" cols="20" id="copyRight" datatype="*1-1000" sucmsg=" " nullmsg=""  class="input" runat="server"></textarea>
                        <span class="Validform_checktip">*</span>
                   
                    </dd>
                </dl>

                 <dl>
                    <dt >按钮文字：</dt>
                    <dd>
                       <asp:TextBox runat="server" ID="buttonCharacter" CssClass="input normal" datatype="*1-100"  sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                   
                    </dd>
                </dl>

   
                <dl>
                    <dt>
                      是否显示转发数：
                    </dt>
                    <dd>
                      <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="display" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="False" Selected="True">不显示</asp:ListItem>
                            <asp:ListItem  Value="True" >显示</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    </dd>
                </dl>

                  <dl>
                    <dt >默认名字：</dt>
                    <dd>
                       <asp:TextBox runat="server" ID="name" CssClass="input normal" datatype="*0-100"  sucmsg=" " nullmsg=" " ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    <span class="red">
                     建议留空
                    </span>
                    </dd>
                </dl>

                   <dl  style="display:none">
                    <dt >点击礼品外链地址：</dt>
                    <dd>
                        <asp:TextBox runat="server" CssClass="input normal upload-path" ID="url"  ></asp:TextBox>
                         <div class="upload-box upload-img"></div>
                     <span class="red">
                    建议使用微信后台发一篇引导关注的文章网址,微信的文章支持直接一键关注!
                    </span>
                   
                    </dd>
                </dl>


               
        </div>

    

           <div class="page-footer" >
            <div class="btn-list">
                  <asp:Button ID="Savecards" runat="server"  CssClass="btn" Text="保存" OnClick="Savecards_Click"  />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
