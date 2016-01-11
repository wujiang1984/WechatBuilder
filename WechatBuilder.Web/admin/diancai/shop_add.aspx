<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shop_add.aspx.cs" Inherits="WechatBuilder.Web.admin.diancai.shop_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            <span>商家设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">商家设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">商家图片</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>商家名称：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="hotelName" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>商家Logo：</dt>
                <dd>
                    <asp:TextBox ID="hotelLogo" runat="server" CssClass="input normal upload-path"  datatype="*1-200" Style="width: 200px;" sucmsg=" " nullmsg="" />
                    <div class="upload-box upload-img"></div>
                    <br />
                    <span class="red">外链地址(图片尺寸100x100
                    </span>

                </dd>
            </dl>

            <dl>
                <dt>营业时间：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="hoteltimeBegin" CssClass="input date" onfocus="WdatePicker({dateFmt:'HH:mm'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>到
                        <asp:TextBox runat="server" ID="hoteltimeEnd" CssClass="input date" onfocus="WdatePicker({dateFmt:'HH:mm'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
                <dd>
                    <asp:TextBox runat="server" ID="hoteltimeBegin1" CssClass="input date" onfocus="WdatePicker({dateFmt:'HH:mm'})" errormsg="请选择正确的日期"></asp:TextBox>
                    <span class="Validform_checktip">*</span>到
                        <asp:TextBox runat="server" ID="hoteltimeEnd1" CssClass="input date" onfocus="WdatePicker({dateFmt:'HH:mm'})" errormsg="请选择正确的日期"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
                <dd>
                    <asp:TextBox runat="server" ID="hoteltimeBegin2" CssClass="input date" onfocus="WdatePicker({dateFmt:'HH:mm'})" errormsg="请选择正确的日期"></asp:TextBox>
                    <span class="Validform_checktip">*</span>到
                        <asp:TextBox runat="server" ID="hoteltimeEnd2" CssClass="input date" onfocus="WdatePicker({dateFmt:'HH:mm'})" errormsg="请选择正确的日期"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>下单限制：</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="limiteOrder" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="True" Selected="True">关联营业时间</asp:ListItem>
                            <asp:ListItem Value="False">不关联营业时间</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>点单重命名：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="rename" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">4个字内(如 点菜,点单,外卖 )
                    </span>

                </dd>
            </dl>

            <dl>
                <dt>起送价格：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="sendPrice" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>配送费用：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="sendCost" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">默认为0表示都需要配送费
                    </span>
                </dd>
            </dl>

            <dl>
                <dt>订单满多少免配送费：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="freeSendcost" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>选择分类：</dt>
                <dd>
                    <select name="type" id="type" runat="server">
                        <option value="小吃快餐">小吃快餐</option>
                        <option value="自助餐">自助餐</option>
                        <option value="日韩料理">日韩料理</option>
                        <option value="面包甜点">面包甜点</option>
                        <option value="火锅">火锅</option>
                        <option value="西餐">西餐</option>
                        <option value="海鲜">海鲜</option>
                        <option value="烧烤">烧烤</option>
                        <option value="川菜">川菜</option>
                        <option value="咖啡厅">咖啡厅</option>
                        <option value="东南亚菜">东南亚菜</option>
                        <option value="闽菜">闽菜</option>
                        <option value="粤菜">粤菜</option>
                        <option value="湘菜">湘菜</option>
                        <option value="茶餐厅">茶餐厅</option>
                        <option value="创意菜">创意菜</option>
                        <option value="客家菜">客家菜</option>
                        <option value="东北菜">东北菜</option>
                        <option value="本帮江浙菜">本帮江浙菜</option>
                        <option value="湖北菜">湖北菜</option>
                        <option value="台湾菜">台湾菜</option>
                        <option value="西北菜">西北菜</option>
                        <option value="素菜">素菜</option>
                        <option value="江西菜">江西菜</option>
                        <option value="赣菜">赣菜</option>
                        <option value="水果店">水果店</option>
                        <option value="便利店">便利店</option>
                        <option value="小吃">小吃</option>
                        <option value="甜品">甜品</option>
                        <option value="外卖">外卖</option>
                        <option value="其他">其他</option>
                    </select>
                </dd>
            </dl>

            <dl>
                <dt>商家简短描述：</dt>
                <dd>
                    <textarea name="miaoshu" rows="2" cols="20" id="miaoshu" datatype="*1-1000" sucmsg=" " nullmsg=" " class="input" runat="server"></textarea>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">（12个字以内）
                    </span>
                </dd>
            </dl>

            <dl>
                <dt>服务半径：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="radius" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>配送区域：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="sendArea" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>联系电话：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="tel" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>联系地址：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="address" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
                <dd>纬度（x）: 
                      <asp:TextBox ID="txtLatXPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span> &nbsp;&nbsp;&nbsp;
                </dd>
                <dd>经度（y）:
                      <asp:TextBox ID="txtLngYPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
                <dd>
                    <iframe id="baiduframe" src="../lbs/MapSelectPoint.aspx?yjindu=121.526149&xweidu=31.222663" height="300" width="600" style="border: 1px solid #e1e1e1;"></iframe>
                </dd>
            </dl>

            <dl>
                <dt>每人每天允许下单次数：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="personLimite" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">0表示不限制，建议设置3，可以优先防止恶意刷单!
                    </span>
                </dd>
            </dl>

            <dl>
                <dt>商家公告：</dt>
                <dd>
                    <textarea name="notice" rows="2" cols="20" id="notice" sucmsg=" " nullmsg=" " class="input" runat="server"></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>商家简介：</dt>
                <dd>
                    <textarea name="hotelintroduction" rows="2" cols="20" id="hotelintroduction"  sucmsg=" " nullmsg=" " class="input" runat="server"></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>下单通知邮箱：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="email" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">当有用户下单时候会通过此邮箱通知！建议使用163邮箱 例如:123456789@163.com
                    </span>
                </dd>
            </dl>

            <dl style="display: none">
                <dt>邮箱登录密码：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="emailpwd" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl style="display: none">
                <dt>SMTP服务器：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="stmp" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>自定义CSS：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="css" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>


        </div>


        <div class="tab-content" style="display: none">
            <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="description1" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortid1" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n" Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="picUrl1" runat="server" CssClass="input normal upload-path" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="pictzUrl1" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="description2" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortid2" CssClass="input normal" datatype="n" sucmsg=" " nullmsg=" " Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="picUrl2" runat="server" CssClass="input normal upload-path" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="pictzUrl2" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="description3" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortid3" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="picUrl3" runat="server" CssClass="input normal upload-path" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="pictzUrl3" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="description4" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortid4" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="picUrl4" runat="server" CssClass="input normal upload-path" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="pictzUrl4" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="description5" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortid5" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="picUrl5" runat="server" CssClass="input normal upload-path" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="pictzUrl5" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="description6" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortid6" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="picUrl6" runat="server" CssClass="input normal upload-path" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="pictzUrl6" runat="server" CssClass="input" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

        </div>

        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="save_groupbase" runat="server" CssClass="btn" Text="保存" OnClick="save_groupbase_Click" />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
