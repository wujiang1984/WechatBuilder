using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.shangqiang
{
    public partial class index : WeiXinPage
    {
          public int wid;
         protected string openid;
        protected int aid;
        protected string bgMusic = "";
        protected int page = 1;
        protected int totalCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                wid = MyCommFun.RequestInt("wid");
                openid = MyCommFun.RequestOpenid();
                aid = MyCommFun.RequestInt("aid");
                if (wid == 0 || aid == 0)
                {
                    MessageBox.Show(this, "参数不正确！");
                    return;
                }
                page = MyCommFun.RequestInt("p",1);
                BindData();
            }
        }

        private void BindData()
        {
            BLL.wx_sq_act actBll = new BLL.wx_sq_act();
            Model.wx_sq_act act = actBll.GetModel(aid);
            if (act != null)
            {
                litBanner.Text = " <img src=\""+act.bannerPic+"\">";
            }
            BLL.wx_sq_piclist pBll = new BLL.wx_sq_piclist();
            string whereStr = "";
            if (act.shenghe)
            {
                //需要审核
                whereStr = "aid=" + aid + " and hasShenghe=1";
            }
            else
            { 
                //不需要审核
                whereStr = "aid=" + aid;
            }
           // IList<Model.wx_sq_piclist> plist = pBll.GetModelList(whereStr);
            DataSet artDs = pBll.GetList(20, this.page, whereStr, "createDate desc", out this.totalCount);
            rpPoto.DataSource = artDs;
            rpPoto.DataBind();
            //上一页
            if (this.page == 1)
            {
                aBefore.HRef = "javascript:;";
            }
            else
            {
                aBefore.HRef = MyCommFun.getWebSite() + "/weixin/shangqiang/index.aspx?wid="+wid+"&aid="+aid+"&openid="+openid+"&p="+(this.page-1);
            }

            //下一页
            if (this.page == totalCount)
            {
                aAfter.HRef = "javascript:;";
            }
            else
            {
                aAfter.HRef = MyCommFun.getWebSite() + "/weixin/shangqiang/index.aspx?wid=" + wid + "&aid=" + aid + "&openid="+openid+"&p=" + (this.page + 1);
            }
        
        }
    }
}