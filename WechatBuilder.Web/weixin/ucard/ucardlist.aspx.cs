using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WechatBuilder.Web.weixin.ucard
{
    public partial class ucardlist : WeiXinPage
    {
        protected string openid = "";
        protected int wid = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestInt("wid");
            if (openid == "" || wid == 0)
            {
                hidStatus.Value = "-1";
                hidErrInfo.Value = "参数错误";
                return;
            }
            bindData();
        }

        private void bindData()
        {
            //头部图片
            BLL.wx_ucard_adver adverBll = new BLL.wx_ucard_adver();
            IList<Model.wx_ucard_adver> adverlist = adverBll.GetModelList("wid="+wid);
            if (adverlist != null && adverlist.Count > 0)
            {
                StringBuilder adverStr = new StringBuilder("");
                StringBuilder adverStrNum = new StringBuilder("");
                for (int i = 0; i < adverlist.Count; i++)
                {
                    adverStr.Append("<li> <p>"+adverlist[i].adverName+"</p>");
                    adverStr.Append("<img src=\""+adverlist[i].picUrl+"\"></li>");
                    if (i == 0)
                    {
                        adverStrNum.Append(" <li class=\"active\">1</li>");
                    }
                    else
                    {
                        adverStrNum.Append(" <li>"+(i+1)+"</li>");
                    }
                }
                litPic.Text = adverStr.ToString();
                litPicNum.Text = adverStrNum.ToString();
            }

            //店铺列表

            BLL.wx_ucard_store storeBll = new BLL.wx_ucard_store();
            DataSet storelist = storeBll.GetStorelist(wid, openid);
            if (storelist != null && storelist.Tables.Count > 0 && storelist.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                int count = storelist.Tables[0].Rows.Count;
                string logo = "";
                StringBuilder sbStore = new StringBuilder("");
                for (int i = 0; i < count; i++)
                {
                    dr = storelist.Tables[0].Rows[i];
                    logo = dr["logo"] == null ? "\\images\\noneimg.jpg" : dr["logo"].ToString();
                    sbStore.Append(" <li class=\"dandanb\">");
                    sbStore.Append(" <a href=\"index.aspx?wid=" + wid + "&id=" + dr["id"].ToString() + "&openid=" + openid + "\"><span class=\"none\">");
                    sbStore.Append(" <img src=\"" + logo + "\">");
                    sbStore.Append("<h2>" + dr["storeName"].ToString() + "</h2>");
                    sbStore.Append(" <p>" + dr["cardBrief"].ToString() + "</p>");
                    if (dr["uid"] == null || dr["uid"].ToString().Trim() == "")
                    {
                        sbStore.Append(" <em class=\"ok\">领卡</em>");
                    }
                    else
                    {
                        sbStore.Append(" <em class=\"error\">用卡</em>");
                    }

                    sbStore.Append(" </span></a></li>");
                }

                litStorelist.Text = sbStore.ToString();
            }

            //电话
            BLL.wx_ucard_sys sysBll = new BLL.wx_ucard_sys();
            IList<Model.wx_ucard_sys> sys = sysBll.GetModelList(" wid="+wid);
            if (sys == null || sys.Count <= 0)
            {
            }
            else
            {
                litTel.Text = "<a href=\"tel:" + sys[0].tradeTel + "\"><span>" + sys[0].tradeTel + " 招商热线</span></a>";
            }

            //查询会员已经开卡的数量
            BLL.wx_ucard_users userBll = new BLL.wx_ucard_users();
            int num = userBll.GetUserStoreNum(openid);
            lituStoreNum2.Text = num.ToString();
            lituStoreNum.Text = num.ToString();


        }
    }
}