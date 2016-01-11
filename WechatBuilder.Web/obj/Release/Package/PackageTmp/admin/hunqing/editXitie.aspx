<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editXitie.aspx.cs" Inherits="MxWeiXinPF.Web.admin.hunqing.editXitie" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑喜帖</title>
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
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.rar;*.zip;*.doc;*.xls;*.mp3;*.mp4" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;;*.mp3;*.mp4" });
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
            <a href="xitielist.aspx" class="back"><i></i><span>返回喜帖列表</span></a>
            <i class="arrow"></i>
            <span>编辑喜帖</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑喜帖</a></li>
                    </ul>
                </div>
            </div>
        </div>

          <div class="mytips">
                该喜帖的展示地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a>
         </div>


        <div class="tab-content">

            <dl>
                <dt>喜帖名称</dt>
                <dd>
                    <asp:TextBox ID="txtwxTitle" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*喜帖标题限制在十个字以内!</span>
                </dd>
            </dl>

            <dl>
                <dt>触发的关键词</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtKW" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*只能写一个关键词，用户输入此关键词将会触发此活动。</span>
                </dd>
            </dl>
            <dl>
                <dt>触发时的图片</dt>
                <dd>
                    <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/images/xitie/xite_fengmian.png" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path"  Text="/images/xitie/xite_fengmian.png" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>

                </dd>
            </dl>

            <dl>
                <dt>开场动画的图片</dt>
                <dd>
                    <asp:Image ID="imgKcdh" runat="server" ImageUrl="/images/xitie/xitie_kcdh.jpg" Style="max-height: 160px;" /><br />

                    <asp:TextBox ID="txtKcdh" runat="server" CssClass="input normal upload-path"  Text="/images/xitie/xitie_kcdh.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">上传400*400左右的新郎新娘合影图,用于喜帖打开时的动画中,图片大小不超过300K ;不想要开场动画图片地址留空即可!</span>
                </dd>
            </dl>

            <dl>
                <dt>缩略图</dt>
                <dd>
                    <asp:Image ID="imgdonghuaSlt" runat="server" ImageUrl="/images/xitie/xitie_slt.jpg" Style="max-height: 40px;" /><br />

                    <asp:TextBox ID="txtdonghuaSlt" runat="server" CssClass="input normal upload-path"  Text="/images/xitie/xitie_slt.jpg" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">默认40x40,显示在喜帖主页
                    </span>
                </dd>
            </dl>



            <dl>
                <dt>新郎名称</dt>
                <dd>
                    <asp:TextBox ID="txtmanName" runat="server" CssClass="input normal" datatype="*1-10" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*新郎名称 ,请不要多于10字!</span>
                </dd>
            </dl>
            <dl>
                <dt>新娘名称</dt>
                <dd>
                    <asp:TextBox ID="txtfelmanName" runat="server" CssClass="input normal" datatype="*1-10" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*新娘名称 ,请不要多于10字!</span>
                </dd>
            </dl>
            <dl>
                <dt>顺序</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="radNameSeq" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">新郎名字在前</asp:ListItem>
                            <asp:ListItem Value="2">新娘名字在前</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>

            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txttel" runat="server" CssClass="input normal" datatype="*1-30" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*如021-88888888</span>
                </dd>
            </dl>

            <dl>
                <dt>婚宴时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtstatedate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>开始时间</i>
                    </div>
                </dd>
            </dl>

            <dl>
                <dt>宴席地点</dt>
                <dd>
                    <asp:TextBox ID="txtaddr" runat="server" CssClass="input normal" datatype="*1-200" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*</span>
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
                    <asp:TextBox ID="txtLatXPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span> &nbsp;&nbsp;&nbsp;
                    经度（y）:
                    <asp:TextBox ID="txtLngYPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>


            <dl>
                <dt>喜帖视频</dt>
                <dd>
                    <asp:TextBox ID="txtvideo" runat="server" CssClass="input normal" datatype="*0-800" sucmsg=" " Text="" />
                     <span class="Validform_checktip"></span>
                    <span class="no_checktip">支持优酷视频地址如;http://v.youku.com/v_show/id_XNjI4ODk5NDQ4.html
                        <br />
                        腾讯fash视频地址：如http://static.video.qq.com/TPout.swf?vid=v0119s27wd5&auto=0
                        <br />
                        也支持mp4和ogg 格式地址 http://www.w3school.com.cn/example/html5/mov_bbb.mp4</span>
                </dd>
            </dl>


            <dl>
                <dt>背景音乐</dt>
                <dd>
                     <asp:TextBox ID="txtMusic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">只支持mp3格式的，尽量小;</span>
                </dd>
            </dl>


            <dl>
                <dt>想要给朋友说的话</dt>
                <dd>
                    <textarea name="txtword" rows="2" cols="20" id="txtword" class="input" runat="server" datatype="*1-200" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*喜帖文字限制在200字以内</span>
                </dd>
            </dl>

            <dl>
                <dt>二维码地址</dt>
                <dd>
                    <asp:TextBox ID="txtsqrurl" runat="server" CssClass="input normal" datatype="*0-800" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*默认100x100,显示在喜帖底部</span>
                </dd>
            </dl>


            <dl>
                <dt>底部版权</dt>
                <dd>
                    <textarea name="txtcopyrite" rows="2" cols="20" id="txtcopyrite" class="input" runat="server" datatype="*0-200" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>密码</dt>
                <dd>
                    <asp:TextBox ID="txtPwd" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" nullmsg="请填写信息，并且不要多于50字 " />
                    <span class="Validform_checktip">*设置微信上查看来宾名单的验证密码，请不要多于50字!</span>
                </dd>
            </dl>


        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="xitielist.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
