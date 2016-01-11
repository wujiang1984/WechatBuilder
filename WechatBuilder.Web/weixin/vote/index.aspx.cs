using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.vote
{
    public partial class index : WeiXinPage
    {
        protected Model.wx_vote_base baseinfo;
        protected int toupNum = 0;
        protected bool hasVoted = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int wid = MyCommFun.RequestInt("wid");
                string openid = MyCommFun.RequestOpenid();
                int aid = MyCommFun.RequestInt("aid");
                if (wid == 0 || openid == "" || aid == 0)
                {
                    return;
                }
                BindData(wid, aid, openid);
            }

        }

        public void BindData(int wid, int aid, string openid)
        {
            //基本表信息
            BLL.wx_vote_base baseBll = new BLL.wx_vote_base();
            baseinfo = baseBll.GetModel(aid);
            if (baseinfo == null)
            {
                return;
            }
            //投票选项字符串设置\
            BLL.wx_vote_item itemBll = new BLL.wx_vote_item();
            IList<Model.wx_vote_item> itemlist = itemBll.GetModelList("baseid=" + baseinfo.id );
            if (itemlist == null || itemlist.Count <= 0)
            {
                return;
            }
            ItemListStr(itemlist,openid);

        }

        public void ItemListStr(IList<Model.wx_vote_item> itemlist,string openid)
        {
            toupNum = itemlist.Sum(i => i.tpTimes==null?0:i.tpTimes).Value;

            BLL.wx_vote_result retBll = new BLL.wx_vote_result();
            IList<Model.wx_vote_result> retList = retBll.GetModelList("baseid="+baseinfo.id);
            //投票总数
           
           // int ttCount = retList == null ? 0 : retList.Count;
            //toupNum = retBll.GetVotedPersonNum(baseinfo.id);
            int itemCount = 0;
            float bfb = 0;
            hasVoted = false;
            bool showReult = false;
            
            
            //判断这个人是否已经投票了
            IList<Model.wx_vote_result> myretList = (from r in retList where r.openId == openid select r).ToArray<Model.wx_vote_result>();


            if (myretList != null && myretList.Count>0)
            {
                hasVoted = true;
            }

            //判断是否显示结果
            if (baseinfo.resultShowtype == 1)
            {
                showReult = true;
            }
            else if (baseinfo.resultShowtype == 2 && hasVoted)
            {
                 showReult = true;
            }
            else if (baseinfo.resultShowtype == 3 && baseinfo.endTime <= DateTime.Now)
            {
                showReult = true;
            }


            StringBuilder sb = new StringBuilder();
            //留言集合
          //  IList<Model.wx_vote_result> retList_item = new List<Model.wx_vote_result>();
            IList<Model.wx_vote_result> retList_myresult = new List<Model.wx_vote_result>();
          

            if (baseinfo.voteType == 1)
            {  //文字 
                Model.wx_vote_item item=new Model.wx_vote_item();
                for (int i = 0; i < itemlist.Count; i++)
                {
                    item=itemlist[i];
                  //  retList_item = (from a in retList where a.itemid == item.sid select a).ToArray<Model.wx_vote_result>();
                    itemCount = item.tpTimes==null?0:item.tpTimes.Value;
                    bfb = computeBL(toupNum, itemCount);

                    retList_myresult=(from a in myretList where a.itemid == item.sid select a).ToArray<Model.wx_vote_result>();

                    sb.Append("<li>");
                    sb.Append(" <label for=\"square-checkbox-" + (i + 1) + "\">");
                    if (retList_myresult.Count > 0)
                    {
                        sb.Append(" <input class=\"ckbx\" tabindex=\"9\" name=\"id[]\" checked=\"checked\" " + disableStr() + " value=\"" + item.sid + "\" type=\"" + chektype() + "\" id=\"square-checkbox-" + (i + 1) + "\">");
                    }
                    else
                    {
                        sb.Append(" <input class=\"ckbx\" tabindex=\"9\" name=\"id[]\"  " + disableStr() + " value=\"" + item.sid + "\" type=\"" + chektype() + "\" id=\"square-checkbox-" + (i + 1) + "\">");
                    }
                    sb.Append(" <span>" + item.title + "</span>");
                    sb.Append("  </label>");

                
                    

                    if (showReult)
                    {
                        sb.Append("  <div id=\"voteshow" + i + "\" class=\"votebar\">");
                        sb.Append("     <div class=\"pbg\">");
                        sb.Append("         <div style=\"width: " + bfb + "%; background-color:" + bkColor(i) + "\" class=\"pbr\"></div>");
                        sb.Append("     </div>");
                        sb.Append("      <span class=\"percentage\" style=\"color: " + bkColor(i) + "\">" + bfb + "%<span class=\"user\">(" + itemCount + ")</span></span>");
                        sb.Append(" </div>");
                    }

                    sb.Append(" </li>");


                }

            }
            else
            { 
                //图片
                Model.wx_vote_item item = new Model.wx_vote_item();
                for (int i = 0; i < itemlist.Count; i++)
                {
                    item = itemlist[i];
                    itemCount = item.tpTimes == null ? 0 : item.tpTimes.Value;
                    bfb = computeBL(toupNum, itemCount);

                    retList_myresult = (from a in myretList where a.itemid == item.sid select a).ToArray<Model.wx_vote_result>();

                    sb.Append("<li>");
                    sb.Append(" <label for=\"square-checkbox-" + (i + 1) + "\">");
                    sb.Append("<p class=\"voteimg2\">");
                    sb.Append(" <img src=\""+item.pic_url +"\">");
                    sb.Append("</p>");

                    if (retList_myresult.Count > 0)
                    {
                        sb.Append(" <input class=\"ckbx\" tabindex=\"9\" name=\"id[]\" checked=\"checked\" " + disableStr() + " value=\"" + item.sid + "\" type=\"" + chektype() + "\" id=\"square-checkbox-" + (i + 1) + "\">");
                    }
                    else
                    {
                        sb.Append(" <input class=\"ckbx\" tabindex=\"9\" name=\"id[]\"  " + disableStr() + " value=\"" + item.sid + "\" type=\"" + chektype() + "\" id=\"square-checkbox-" + (i + 1) + "\">");
                    }
                 
                    sb.Append(" <span>" + item.title + "</span>");
                    sb.Append("  </label>");


                    if (showReult)
                    {
                        sb.Append("  <div id=\"voteshow" + i + "\" class=\"votebar\">");
                        sb.Append("     <div class=\"pbg\">");
                        sb.Append("         <div style=\"width: " + bfb + "%; background-color:" + bkColor(i) + "\" class=\"pbr\"></div>");
                        sb.Append("     </div>");
                        sb.Append("      <span class=\"percentage\" style=\"color: " + bkColor(i) + "\">" + bfb + "%<span class=\"user\">(" + itemCount + ")</span></span>");
                        sb.Append(" </div>");
                    }
                    sb.Append("<a href=\"" + item.pic_jump + "\" id=\"imgurl\">查看详情");
                    sb.Append("</a>");
                    sb.Append(" </li>");
                }
            
            }
            
             

          
            litMessageList.Text = sb.ToString();

            string btn = "<input id=\"btnSubmit\" class=\"pxbtn\"   type=\"button\" value=\"确认提交\" name=\"sssss\" />";
            if (hasVoted || baseinfo.endTime<=DateTime.Now)
            {
                litSubmitBtn.Text = "";
            }
            else
            {
                litSubmitBtn.Text = btn;
            }

        }

        /// <summary>
        /// 计算投票数比例
        /// </summary>
        /// <param name="ttCount"></param>
        /// <param name="itemCount"></param>
        /// <returns></returns>
        protected float computeBL(int ttCount, int itemCount)
        {
            if (ttCount == 0)
            {
                return (float)0.00;
            }

            float ret = (itemCount*100.0f) / ttCount;

            ret =(float) Math.Round(ret, 2);

            return ret;

        
        }

        /// <summary>
        /// 选择的控件类型：radio和checkbox
        /// </summary>
        /// <returns></returns>
        public string chektype()
        {
            if (baseinfo.isRadio)
            {
                return "radio";
            }
            else
            {
                return "checkbox";
            }
        
        }

        /// <summary>
        /// 背景色
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string bkColor(int i)
        {
            string ret = "";

            switch (i)
            { 
                case 0:
                    ret = "#ffcc00";
                    break;
                case 1:
                    ret = "#ff9900";
                    break;
                case 2:
                    ret = "#ff9900";
                    break;
                case 3:
                    ret = "#bd10d7";
                    break;
                case 4:
                    ret = "#da5ff8";
                    break;
                case 5:
                    ret = "#5aaf4a";
                    break;
                    
                default:
                    ret = "#ffcc00";
                    break;
            }



            return ret;
        }

        protected string myvoted(bool voted)
        {
            if (voted)
            {

                return "";
            }
            else
            { 
                
            return "checked=\"checked\"" ;
            }
        
        }


        protected string disableStr()
        {
            if (hasVoted || baseinfo.endTime <= DateTime.Now)
            {
                return "disabled";
            }
            else
            {

                return "";
            }
        
        }
    }



}
