using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.BLL;


namespace WechatBuilder.Web.weixin.yuyue
{
    public partial class index : WeiXinPage
    {
        protected int id;
        protected int wid;
        protected string openid;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                wid = MyCommFun.RequestInt("wid");
                id = MyCommFun.RequestInt("id");
                openid = MyCommFun.RequestOpenid();
                if (wid == 0 || id==0 )
                {
                    MessageBox.Show(this, "参数不正确！");
                    return;
                }
                BLL.wx_yy_base yyBll = new BLL.wx_yy_base();
                Model.wx_yy_base yuyue = yyBll.GetModel(id);

                #region 预约的基本信息
                StringBuilder sbBase = new StringBuilder("");
                if (yuyue.picUrl != null && yuyue.picUrl.Trim() != "")
                {
                    sbBase.Append(" <div class=\"qiandaobanner\"><img src=\""+yuyue.picUrl+"\"></div>\r\n");
                }

                if (yuyue.content != null &&  yuyue.content.Trim().Length > 0)
                {
                    sbBase.Append(" <ul class=\"round\"><li><h2>说明</h2><div class=\"text\">"+yuyue.content+"</div></li></ul>\r\n");
                }
                if (yuyue.phone != null && yuyue.phone.Trim() != "" && yuyue.addr!=null && yuyue.addr.Trim()!="" )
                { 
                    //预约电话或者地址
                    sbBase.Append(" <ul class=\"round\">");

                    if (yuyue.addr != null && yuyue.addr.Trim() != "")
                    {
                        sbBase.Append("<li class=\"addr\"><span>" + yuyue.addr.Trim() + "</span></li>\r\n");
                    }
                    if (yuyue.phone != null && yuyue.phone.Trim() != "")
                    {
                        sbBase.Append("<li class=\"tel\"><a href=\"tel:" + yuyue.phone.Trim() + "\"><span>" + yuyue.phone.Trim() + " 电话</span> </a></li>\r\n");
                    }

                    sbBase.Append("</ul>");

                }

                litBaseInfo.Text = sbBase.ToString();
                #endregion

                this.Title = yuyue.title;
                BindControlers(id);
            }

        }

        /// <summary>
        /// 绑定控件
        /// </summary>
        /// <param name="id"></param>
        private void BindControlers(int id)
        {
            string openid = MyCommFun.RequestOpenid();
            int wid = MyCommFun.RequestInt("wid");
            //设置控件的string
            wx_yy_control yyctBll = new wx_yy_control();
            IList<Model.wx_yy_control> controllist = yyctBll.GetModelList("formId=" + id + " order by seq asc");
            if (controllist == null || controllist.Count <= 0)
            {
                return;
            }
            StringBuilder sbControl = new StringBuilder("");
            StringBuilder sbJs = new StringBuilder("<script type=\"text/javascript\">\r\n $(document).ready(function () {\r\n"); //必填项的js验证
            sbJs.Append(" $(\"#showcard\").click(function () {\r\n");
            StringBuilder sbValueJs = new StringBuilder("var submitData = {wid: '" + wid + "',\r\n  openid: '" + openid + "',\r\n formid:" + id + ",\r\n");
            for (int i = 0; i < controllist.Count; i++)
            {
                sbControl.Append(" <li class=\"nob\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"kuang\">\r\n<tr>");
                sbControl.Append("<th>" + controllist[i].cName + "</th>\r\n<td>");
                if (controllist[i].cType == "0")
                { //文本
                    if (controllist[i].sysControlerType == "date")
                    {
                        sbControl.Append("\r\n<input name=\"control_" + controllist[i].id + "\" class=\"px datetimepicker\" id=\"control_" + controllist[i].id + "\" value=\"\" type=\"text\" placeholder=\"请输入" + controllist[i].cName + "\">\r\n");
                    }
                    else
                    {
                        sbControl.Append("\r\n<input name=\"control_" + controllist[i].id + "\" class=\"px\" id=\"control_" + controllist[i].id + "\" value=\"\" type=\"text\" placeholder=\"请输入" + controllist[i].cName + "\">\r\n");
                    }
                }
                if (controllist[i].cType == "1")
                {
                    //下拉菜单
                    sbControl.Append("\r\n<select name=\"control_" + controllist[i].id + "\" id=\"control_" + controllist[i].id + "\" class=\"InputType\">\r\n");
                    string[] items = selectItem(controllist[i].defaultValue);
                    for (int j = 0; j < items.Length; j++)
                    {
                        if (items[j].Trim() != "")
                        {
                            sbControl.Append("<option value=\"" + items[j].Trim() + "\">" + items[j].Trim() + "</option>\r\n");
                        }
                    }

                    sbControl.Append("</select>\r\n");

                }
                sbControl.Append("</td></tr></table>\r\n</li>\r\n\r\n");
                if (controllist[i].isBiTian)
                {
                    sbJs.Append(" if ($(\"#control_" + controllist[i].id + "\").val() == '') { alert('" + controllist[i].cName + "不能为空'); return; }\r\n");
                }
                if (i != (controllist.Count - 1))
                {
                    sbValueJs.Append("control_" + +controllist[i].id + ":$(\"#control_" + controllist[i].id + "\").val(),\r\n");
                }
                else
                {
                    sbValueJs.Append("control_" + +controllist[i].id + ":$(\"#control_" + controllist[i].id + "\").val()\r\n");
                }

            }//end for
            sbValueJs.Append("};\r\n");
            sbJs.Append(sbValueJs.ToString());
            sbJs.Append(" $.post('yuyueApi.ashx', submitData, function (data) {\r\n");
            sbJs.Append("if (data.success == \"true\") {  alert(\"信息已经提交！请耐心等待！\");\r\n");
            sbJs.Append("setTimeout(\"window.location.reload()\", 2000);");
            sbJs.Append("return;  } \r\n else { alert(data.msg || \"保存失败\");  } }, \"json\");\r\n");
            sbJs.Append("oLay.style.display = \"block\";  }); });\r\n");
            sbJs.Append(" </script>");
            litJs.Text = sbJs.ToString();
            litFormStr.Text = sbControl.ToString();
        }
        /// <summary>
        /// 必填的字符串
        /// </summary>
        /// <param name="bitian"></param>
        /// <returns></returns>
        private string bitianStr(bool bitian)
        {
            string ret = "";
            if (bitian) { ret = "required"; }
            return ret;
        }

        private string[] selectItem(string str)
        {
            string[] itemArr = str.Split(',');
            return itemArr;
        }


    }
}