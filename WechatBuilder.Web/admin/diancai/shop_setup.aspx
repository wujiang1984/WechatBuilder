<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shop_setup.aspx.cs" Inherits="WechatBuilder.Web.admin.diancai.shop_setup" %>

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
            <i class="arrow"></i>            
            <span>商城设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">商城设置</a></li>          
                        <li><a href="javascript:;" onclick="tabs(this);" >商城头部广告位设置</a></li>     
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>
        <div  class="tab-content" >
                     <dl>
                    <dt>招商说明：</dt>
                    <dd>
                        <textarea name="unionManage" rows="2" cols="20" id="unionManage" datatype="*1-1000" sucmsg=" " nullmsg=" "  class="input" runat="server"></textarea>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
                 <dl>
                    <dt>招商热线电话：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="unionTel" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
        </div>
         <div  class="tab-content" style="display:none" >
               <dl>
                    <dt>名称：</dt>
                    <dd>
                     <asp:TextBox runat="server" ID="advertisementName1" style="width:100px;" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100" ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     显示顺序：                   
                     <asp:TextBox runat="server" ID="sortid1" CssClass="input normal" sucmsg=" " nullmsg=" " style="width:50px;" datatype="n" ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     图片外链地址：
                   <asp:TextBox ID="picUrl1" runat="server" CssClass="input normal upload-path"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <div class="upload-box upload-img"></div>  
                     外链网站或活动：                  
                    <asp:TextBox ID="websetUrl1" runat="server" CssClass="input" style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <span class="Validform_checktip">*</span>
                
                    </dd>
                </dl>
                    <dl>
                    <dt>名称：</dt>
                    <dd>
                     <asp:TextBox runat="server" ID="advertisementName2" style="width:100px;" CssClass="input normal" sucmsg=" " nullmsg=" "  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     显示顺序：                   
                     <asp:TextBox runat="server" ID="sortid2" CssClass="input normal" sucmsg=" " nullmsg=" "  style="width:50px;"  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     图片外链地址：
                   <asp:TextBox ID="picUrl2" runat="server" CssClass="input normal upload-path"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <div class="upload-box upload-img"></div>  
                     外链网站或活动：                  
                    <asp:TextBox ID="websetUrl2" runat="server" CssClass="input"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                    <span class="Validform_checktip">*</span>
               
                    </dd>
                </dl>

                  <dl>
                    <dt>名称：</dt>
                    <dd>
                     <asp:TextBox runat="server" ID="advertisementName3" style="width:100px;" CssClass="input normal" sucmsg=" " nullmsg=" "  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     显示顺序：                   
                     <asp:TextBox runat="server" ID="sortid3" CssClass="input normal" sucmsg=" " nullmsg=" " style="width:50px;"  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     图片外链地址：
                   <asp:TextBox ID="picUrl3" runat="server" CssClass="input normal upload-path"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <div class="upload-box upload-img"></div>  
                     外链网站或活动：                  
                    <asp:TextBox ID="websetUrl3" runat="server" CssClass="input" style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <span class="Validform_checktip">*</span>
              
                    </dd>
                </dl>

                     <dl>
                    <dt>名称：</dt>
                    <dd>
                     <asp:TextBox runat="server" ID="advertisementName4" style="width:100px;" CssClass="input normal" sucmsg=" " nullmsg=" " ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     显示顺序：                   
                     <asp:TextBox runat="server" ID="sortid4" CssClass="input normal" sucmsg=" " nullmsg=" " style="width:50px;"  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     图片外链地址：
                   <asp:TextBox ID="picUrl4" runat="server" CssClass="input normal upload-path"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <div class="upload-box upload-img"></div>  
                     外链网站或活动：                  
                    <asp:TextBox ID="websetUrl4" runat="server" CssClass="input"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <span class="Validform_checktip">*</span>
            
                    </dd>
                </dl>

                    <dl>
                    <dt>名称：</dt>
                    <dd>
                     <asp:TextBox runat="server" ID="advertisementName5" style="width:100px;" CssClass="input normal" sucmsg=" " nullmsg=" "  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     显示顺序：                   
                     <asp:TextBox runat="server" ID="sortid5" CssClass="input normal" sucmsg=" " nullmsg=" " style="width:50px;"  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     图片外链地址：
                   <asp:TextBox ID="picUrl5" runat="server" CssClass="input normal upload-path"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <div class="upload-box upload-img"></div>  
                     外链网站或活动：                  
                    <asp:TextBox ID="websetUrl5" runat="server" CssClass="input"   style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <span class="Validform_checktip">*</span>
           
                    </dd>
                </dl>

                   <dl>
                    <dt>名称：</dt>
                    <dd>
                     <asp:TextBox runat="server" ID="advertisementName6" style="width:100px;" CssClass="input normal" sucmsg=" " nullmsg=" " ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     显示顺序：                   
                     <asp:TextBox runat="server" ID="sortid6" CssClass="input normal" sucmsg=" " nullmsg=" " style="width:50px;"  ></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                     图片外链地址：
                   <asp:TextBox ID="picUrl6" runat="server" CssClass="input normal upload-path"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                   <div class="upload-box upload-img"></div>  
                     外链网站或活动：                  
                    <asp:TextBox ID="websetUrl6" runat="server" CssClass="input"  style="width:100px;"  sucmsg=" " nullmsg=" "  />
                    <span class="Validform_checktip">*</span>
             
                    </dd>
                </dl>

             </div>
            <div class="page-footer" >
            <div class="btn-list">      
             <asp:Button ID="save_setup" runat="server"  CssClass="btn" Text="保存" OnClick="save_setup_Click"   />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
