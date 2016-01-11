<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vote_character_add.aspx.cs" Inherits="WechatBuilder.Web.admin.vote.vote_character_add" %>

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
          <!--导航栏-->
        <div class="location">
            <a href="message_list.aspx" class="home"><i></i><span>文本投票设置</span></a>
            <i class="arrow"></i>
             
            <span>文本投票设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">文本投票设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">投票选项</a></li>
                      
                    </ul>
                </div>
            </div>
        </div>


        <div  class="tab-content" >
            
                <dl>
                    <dt>投票标题：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="title" CssClass="input normal" datatype="*1-100" sucmsg=" " nullmsg=" "></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
          
               

                <dl>
                    <dt >投票图片：</dt>
                    <dd>
                        <asp:TextBox runat="server" CssClass="input normal upload-path" ID="votepic"></asp:TextBox>
                         <div class="upload-box upload-img"></div>
                   
                    </dd>
                </dl>

   
                <dl>
                    <dt>
                      图片显示：
                    </dt>
                    <dd>
                         <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="picdisplay" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="True" Selected="True">显示在投票页面</asp:ListItem>
                            <asp:ListItem  Value="False" >不显示在投票页面</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                    </dd>
                </dl>
               
                <dl>
                    <dt>投票说明：</dt>
                    <dd>
                     
                  <textarea name="txtactContent" rows="2" cols="20" id="txtactContent" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                    </dd>
                </dl>
                    

                  <dl>
                    <dt>单选/多选：</dt>
                    <dd>
               
                         <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="Radio" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="True" Selected="True">单选</asp:ListItem>
                            <asp:ListItem  Value="False" >多选</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                    </dd>
                </dl>
                <dl>
                    <dt>截止时间：</dt>
                    <dd>
                       <div class="input-date">
                      <asp:TextBox runat="server" ID="begindate" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                      </div>
                      到
                      <div class="input-date">
                      <asp:TextBox runat="server" ID="enddate" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                      </div>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                <dl>
                    <dt>投票结果：</dt>
                    <dd>
                        <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="resultShowtype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="1" Selected="True" >投票前可见</asp:ListItem>
                            <asp:ListItem  Value="2" >投票后可见</asp:ListItem>
                            <asp:ListItem  Value="3" >投票结束可见</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                      
                    </dd>
                </dl>

              <dl style="display:none">
                    <dt>投票后参加活动：</dt>
                    <dd>
                      <asp:TextBox runat="server" CssClass="input normal upload-path" ID="actUrl"></asp:TextBox>
                      
                    </dd>
                </dl>

        </div>

        <div class="tab-content" style="display: none">

               <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle1" runat="server" CssClass="input "  datatype="*1-100" sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid1" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="" nullmsg=" " />
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

          <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle2" runat="server" CssClass="input " datatype="*1-20" sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid2" runat="server" CssClass="input small " datatype="n" sucmsg=" " Text="" nullmsg=" " />
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>

                   <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle3" runat="server" CssClass="input " datatype="*0-100"  sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid3" runat="server" CssClass="input small" datatype="/^\d*$/"  sucmsg=" " Text="" />
                    
                </dd>
              </dl>

                <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle4" runat="server" CssClass="input " datatype="*0-100"  sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid4" runat="server" CssClass="input small" datatype="/^\d*$/"  sucmsg=" " Text="" />
               
                </dd>
              </dl>
               <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle5" runat="server" CssClass="input " datatype="*0-100"  sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid5" runat="server" CssClass="input small"  datatype="/^\d*$/" sucmsg=" " Text="" />
                   
                </dd>
              </dl>

              <dl>
                <dt>选项标题</dt>
                <dd>选项标题：<asp:TextBox ID="xuanxtitle6" runat="server" CssClass="input " datatype="*0-100"  sucmsg=" " Text="" />
                    排序：<asp:TextBox ID="Sortid6" runat="server" CssClass="input small"  datatype="/^\d*$/" sucmsg=" " Text="" />
                  
                </dd>
              </dl>

        </div>

           <div class="page-footer" >
            <div class="btn-list">
                  <asp:Button ID="Button1" runat="server"  CssClass="btn" Text="保存" OnClick="Button1_Click" />
                <a href="ggklist.aspx"><span class="btn yellow">取消</span></a>

            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
