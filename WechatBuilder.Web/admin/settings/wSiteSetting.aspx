<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wSiteSetting.aspx.cs" Inherits="WechatBuilder.Web.admin.settings.wSiteSetting" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>微网站设置</title>
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
            <a href=":;" class="home"><i></i><span>微网站设置</span></a>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">微网站基本信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">微信回复设置</a></li>
                        <li style="display: none;"><a href="javascript:;" onclick="tabs(this);">短信平台设置</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <asp:Label ID="lblsiteId" runat="server" Style="display: none;" Text="0"></asp:Label>
        <asp:Label ID="lblrId" runat="server" Style="display: none;" Text="0"></asp:Label>
        <asp:Label ID="lblrcId" runat="server" Style="display: none;" Text="0"></asp:Label>

        <!--微网站基本信息-->
        <div class="tab-content">
            <dl>
                <dt>微网站网址</dt>
                <dd>
                    <asp:Label ID="lblWSiteUrl" runat="server" Text="http://" Style="color: #16a0d3; font-weight: bolder;"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>网站名称</dt>
                <dd>
                    <asp:TextBox ID="txtwName" runat="server" CssClass="input normal" datatype="*1-255" sucmsg=" " nullmsg="请填写网站名称"></asp:TextBox>
                    <span class="Validform_checktip">*任意字符，控制在255个字符内</span>
                </dd>
            </dl>
            <dl>
                <dt>公司名称</dt>
                <dd>
                    <asp:TextBox ID="txtcompanyName" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" " />
                    <span class="Validform_checktip">非必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>背景音乐</dt>
                <dd>
                    <asp:TextBox ID="txtbgMusic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl>
                <dt>logo</dt>
                <dd>
                    <asp:TextBox ID="txtbgPic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl style="display:none;">
                <dt>背景动画</dt>
                <dd>
                    <asp:TextBox ID="txtbgDongHuaId" runat="server" CssClass="input normal" Text="1" />
                </dd>
            </dl>
            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txtphone" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip">非必填，区号+电话号码</span>
                </dd>
            </dl>
            <dl>
                <dt>地址</dt>
                <dd>
                    <asp:TextBox ID="txtaddr" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip">非必填</span>
                </dd>
            </dl>
            <dl>
                <dt>百度地图地址url</dt>
                <dd>
                    <asp:TextBox ID="txtaddrUrl" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip">非必填</span>
                </dd>
            </dl>

            <dl>
                <dt>微网站简介</dt>
                <dd>
                    <asp:TextBox ID="txtwBrief" runat="server" CssClass="input" TextMode="MultiLine" />
                    <span class="Validform_checktip">微网站简介</span>
                </dd>
            </dl>

            <dl>
                <dt>网站版权信息</dt>
                <dd>
                    <asp:TextBox ID="txtwCopyright" runat="server" CssClass="input" TextMode="MultiLine" />
                    <span class="Validform_checktip">支持HTML</span>
                </dd>
            </dl>
            <dl>

                <dd style="color: #16a0d3;">微网站SEO设置，非必填项</dd>
            </dl>
            <dl>
                <dt>首页标题(SEO)</dt>
                <dd>
                    <asp:TextBox ID="txtseo_title" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip">自定义的首页标题</span>
                </dd>
            </dl>
            <dl>
                <dt>页面关健词(SEO)</dt>
                <dd>
                    <asp:TextBox ID="txtseo_keywords" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip">页面关键词(keyword)</span>
                </dd>
            </dl>
            <dl>
                <dt>页面描述(SEO)</dt>
                <dd>
                    <asp:TextBox ID="txtseo_desc" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip">页面描述(description)</span>
                </dd>
            </dl>



        </div>
        <!--/微网站基本信息-->

        <!--微信回复设置-->
        <div class="tab-content" style="display: none">
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:TextBox ID="txtreqKeywords" runat="server" CssClass="input normal " datatype="*0-1000" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">
                        <br />
                        *多个关键词请用|格开：例如: 美丽|漂亮|好看</span></dd>
            </dl>
            <dl>
                <dt>关键词类型</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblisLikeSearch" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">完全匹配</asp:ListItem>
                            <asp:ListItem Value="1">包含匹配</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <span class="Validform_checktip">
                        <br />
                        *完全匹配，用户输入的和此关键词一样才会触发!<br />
                        包含匹配 (只要用户输入的文字包含本关键词就触发!)</span>
                </dd>
            </dl>

            <dl>
                <dt>标题</dt>
                <dd>
                    <textarea name="txtTitle" rows="2" cols="20" id="txtTitle" class="input" runat="server"></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>图片</dt>
                <dd>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <textarea name="txtContent" rows="2" cols="20" id="txtContent" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

        </div>
        <!--/微信回复设置-->

        <!--短信平台设置-->
        <div class="tab-content" style="display: none">
            <dl>
                <dt>短信剩余数量</dt>
                <dd>
                    <asp:Label ID="labSmsCount" runat="server" />
                    <span class="Validform_checktip">尚未申请？<a href="http://www.yubom.net" target="_blank">请点击这里注册</a></span>
                </dd>
            </dl>
            <dl>
                <dt>短信API地址</dt>
                <dd>
                    <asp:TextBox ID="smsapiurl" runat="server" CssClass="input normal" />
                    <span class="Validform_checktip">*以“http://”开头</span>
                </dd>
            </dl>
            <dl>
                <dt>平台登录账户</dt>
                <dd>
                    <asp:TextBox ID="smsusername" runat="server" CssClass="input txt" />
                    <span class="Validform_checktip">*短信平台注册的用户名</span>
                </dd>
            </dl>
            <dl>
                <dt>平台登录密码</dt>
                <dd>
                    <asp:TextBox ID="smspassword" runat="server" CssClass="input txt" TextMode="Password" />
                    <span class="Validform_checktip">*短信平台注册的密码</span>
                </dd>
            </dl>
            <dl>
                <dt>短信尾部签名</dt>
                <dd>
                    <asp:TextBox ID="smsnickname" runat="server" CssClass="input txt" />
                    <span class="Validform_checktip">*手机短信息尾部文字，自动附加到短信，例如：动力启航</span>
                </dd>
            </dl>
            <dl>
                <dt>短信平台说明</dt>
                <dd>请不要使用系统默认账户test，因为它是公用的测试账号；<br />
                    如果您尚未申请开通，<a href="http://www.yubom.net" target="_blank">请点击这里注册</a>成功后填写您的用户名和密码均可正常使用。
                </dd>
            </dl>
        </div>
        <!--/短信平台设置-->


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
