using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using System.Text;

namespace WechatBuilder.Web.weixin.ucard
{
    public partial class duihuan : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        protected int sid = 0;//店铺的主键id
        protected int degreeNum = 0;
        protected int uid = 0;
        BLL.wx_ucard_users_consumeinfo conBll = new BLL.wx_ucard_users_consumeinfo();
        BLL.wx_ucard_gift giftBLL = new BLL.wx_ucard_gift();
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestInt("wid");
            sid = MyCommFun.RequestInt("sid");
            if (openid == "" || wid == 0 || sid == 0)
            {
                hidStatus.Value = "-1";
                hidErrInfo.Value = "参数错误";
                return;
            }
            bindData();
        }

        private void bindData()
        {
            BLL.wx_ucard_cardinfo cardBll = new BLL.wx_ucard_cardinfo();
            Model.wx_ucard_cardinfo cardinfo = cardBll.GetModelBySid(sid);
            if (cardinfo != null)
            {
                imgTopPic.ImageUrl = cardinfo.privilegesPic;
            }
            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            Model.wx_ucard_users user = userBll.GetStoreUserInfo(openid, sid);
            if (user == null)
            {
                return;
            }
            uid = user.id;
         
            DateTime today = DateTime.Now;
            IList<Model.wx_ucard_gift> glist = giftBLL.GetModelList(" sid="+sid+" and  beginDate<='" + today.ToString() + "' and endDate>='" + today.ToString() + "'");
            StringBuilder pStr = new StringBuilder();
            if (glist != null && glist.Count > 0)
            {
                Model.wx_ucard_gift gift = new Model.wx_ucard_gift();
                string sn = "";
                int syNum = 0; //剩余次数
                for (int i = 0; i < glist.Count; i++)
                {
                    gift = glist[i];
                 
                    sn = Utils.Number(16, true);
                    if (i == 0)
                    {
                        //第一条数据
                        pStr.Append(" <div id=\"test0-header\" class=\"accordion_headings  header_highlight \">");
                        pStr.Append(" <div class=\"tab  gift \">");
                        pStr.Append(" <span class=\"title\">" + gift.gName + "(<span id=\"cid" + gift.id + "\">" +MyCommFun.Obj2Int(gift.score) + "</span>积分)<p>有效期至" + gift.endDate.Value.ToString("yyyy年MM月dd日") + "</p></span>");
                        pStr.Append(" </div>");
                        pStr.Append(" <div id=\"test0-content\" style=\"display: block; overflow: hidden; opacity: 1; \">");
                        pStr.Append(" <div class=\"accordion_child\">");
                        pStr.Append("  <p class=\"num\" onclick=\"jQ('#test0-content').height(210);document.getElementById('queren0').style.display=''\" id=\"sn0\">" + sn + "</p>");
                        pStr.Append("  <div id=\"queren0\" style=\"display: none\">");
                        pStr.Append("  <p style=\"margin: 10px 0\">");
                        pStr.Append("  <input name=\"\" class=\"px\" id=\"parssword0\" value=\"\" type=\"password\" placeholder=\"请输入管理员密码\">");
                        pStr.Append("  </p> <p style=\"margin: 10px 0\">");
                        pStr.Append("<a id=\"showcard0\" class=\"submit\" href=\"javascript:void(0)\" onclick=\"gift(0,'" + sn + "','" + gift.id + "')\">确定使用</a>");
                        pStr.Append("   </p> </div>");
                        pStr.Append("  <p class=\"explain_sn\"><span>点击处理</span></p>");
                        /*
                         *  <p class="ewmimg">
                         *   <img width="220" onclick="jQ('#test0-content').height(210);document.getElementById('queren0').style.display=''" src="http://comment.duapp.com/qrcode.php?url=http%3A%2F%2Fwww.apiwx.com%2Findex.php%3Fac%3Dcardpower3%26tid%3D4486%26c%3Do99epjsmex1G-PTaaHYb7vmeP588%26qrcode%3D1%26cid%3D0" /></p>
                         * **/
                        pStr.Append(" <b>详情说明</b>");
                        pStr.Append("<ul>" + gift.useContent + "</ul></div> </div> </div>");

                    }
                    else
                    {
                        pStr.Append(" <div id=\"test" + i + "-header\" class=\"accordion_headings \">");
                        pStr.Append("  <div class=\"tab  gift \">");
                        pStr.Append(" <span class=\"title\">" + gift.gName + "(<span id=\"cid" + gift.id + "\">" + MyCommFun.Obj2Int(gift.score) + "</span>积分)<p>有效期至" + gift.endDate.Value.ToString("yyyy年MM月dd日") + "</p>");
                        pStr.Append(" </span>  </div>");
                        pStr.Append(" <div id=\"test" + i + "-content\" style=\"display: none; overflow: hidden;\">");
                        pStr.Append("  <div class=\"accordion_child\">");
                        pStr.Append("<p class=\"num\" onclick=\"jQ('#test" + i + "-content').height(210);document.getElementById('queren" + i + "').style.display=''\" id=\"sn" + i + "\">" + sn + "</p>");
                        pStr.Append("<div id=\"queren" + i + "\" style=\"display: none\">  <p style=\"margin: 10px 0\">");
                        pStr.Append("  <input name=\"\" class=\"px\" id=\"parssword" + i + "\" value=\"\" type=\"password\" placeholder=\"请输入管理员密码\">");
                        pStr.Append("   </p><p style=\"margin: 10px 0\">");
                        pStr.Append(" <a id=\"showcard" + i + "\" class=\"submit\" href=\"javascript:void(0)\" onclick=\"gift(" + i + ",'" + sn + "','" + gift.id + "')\">确定使用</a>");
                        pStr.Append("  </p></div>");
                        pStr.Append(" <p class=\"explain_sn\"><span>点击处理</span></p>");
                        pStr.Append("  <b>详情说明</b>");
                        pStr.Append("  <ul>" + gift.useContent + "</ul></div> </div> </div>");
                    }
                }

            }
            litGiftlist.Text = pStr.ToString();
        }
    }
}