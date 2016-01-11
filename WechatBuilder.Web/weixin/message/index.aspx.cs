using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.message
{
    public partial class index : WeiXinPage
    {
        protected int wid = 0;
        protected string nicheng = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string openid = MyCommFun.RequestOpenid();
              
                wid = MyCommFun.RequestInt("wid");
                if (  wid == 0 || openid == "")
                {
                    return;
                }

                BLL.wx_message_list gbll = new BLL.wx_message_list();
                DataSet ds = gbll.GetListDetail(wid);



                BLL.wx_message_setting sBll = new BLL.wx_message_setting();
                IList<Model.wx_message_setting> settinglist = sBll.GetModelList(wid);
                if (settinglist == null || settinglist.Count <= 0)
                {
                    return;
                }

                this.zjpic.ImageUrl = settinglist[0].picUrl;
                this.Title = settinglist[0].title;
                this.adminOpenid.Value = settinglist[0].adminOpenid;
                this.needSH.Value = settinglist[0].needSH.ToString();


                IList<Model.wx_message_list> mlist = new List<Model.wx_message_list>();
                if (settinglist[0].needSH)
                {
                    mlist = gbll.GetModelList("wid=" + wid + " and hasSH='"+true+"' order by createDate desc");
                }
                else
                {
                    mlist = gbll.GetModelList("wid=" + wid + " order by createDate desc");
                }
                if (mlist != null && mlist.Count > 0)
                {
                    MessageStr(mlist);

                    IList<Model.wx_message_list> mlist_last = (from m in mlist where m.openId == openid orderby m.createDate descending select m).ToArray<Model.wx_message_list>();
                    if (mlist_last != null && mlist_last.Count > 0)
                    {
                        nicheng = mlist_last[0].userName;
                    }

                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glist"></param>
        public void MessageStr( IList<Model.wx_message_list> glist)
        {
            //留言集合
            IList<Model.wx_message_list> mlist = (from a in glist where a.parentId == 0 select a).ToArray<Model.wx_message_list>();
            if (mlist == null || mlist.Count <= 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder("");

            IList<Model.wx_message_list> mlist_hf = new List<Model.wx_message_list>();
            for (int i = 0; i < mlist.Count; i++)
            {  //留言的列表
                sb.Append(" <li class=\"green bounceInDown\">");
                sb.Append("<h3>");
                sb.Append(" "+mlist[i].userName+"<span>"+mlist[i].createDate+"</span><div class=\"clr\"></div>");
                sb.Append(" </h3>");
                sb.Append(" <dl> <dt class=\"hfinfo\" date=\""+mlist[i].id+"\">"+mlist[i].title+"</dt>  </dl>");

                 sb.Append("<dl class=\"huifu\"><dt><span>");
                 sb.Append("<a class=\"hhbt czan\" date=\"" + mlist[i].id + "\" href=\"javascript:void(0)\">回复</a>");
                 sb.Append("<p style=\"display: none;\" class=\"hhly" + mlist[i].id + "\">");
                 sb.Append("<textarea name=\"info\" class=\"pxtextarea hly" + mlist[i].id + "\"></textarea>");
                 sb.Append("<a class=\"hhsubmit submit\" date=\"" + mlist[i].id + "\" href=\"javascript:void(0)\">确定</a>");
                 sb.Append("</p>");
                 sb.Append("</span></dt></dl>");

                mlist_hf = new List<Model.wx_message_list>();
                mlist_hf = (from a in glist where a.parentId == mlist[i].id select a).ToArray<Model.wx_message_list>();
                if (mlist_hf == null || mlist_hf.Count <= 0)
                {

                }
                else
                {

                    for (int j = 0; j < mlist_hf.Count; j++)
                    {
                        //回复的列表
                        sb.Append("<dl class=\"huifu\"><dt><span>");
                        sb.Append("" + mlist_hf[j].userName + " 回复 " +"："+ mlist_hf[j].title + "");
                        sb.Append("</span></dt></dl>");
                               

                    }
                }

                sb.Append("</li>");
                litMessageList.Text = sb.ToString();
                
            }
        
        }

    }
}