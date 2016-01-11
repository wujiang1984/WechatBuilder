using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.diancai
{
    public partial class caidan_baobiao : Web.UI.ManagePage
    {
        BLL.wx_diancai_dingdan_caiping gbll = new BLL.wx_diancai_dingdan_caiping();
        protected int totalCount;
        protected int page;
        protected int pageSize;
        //
        public static int shopid = 0;
        BLL.wx_diancai_member memberbll=new BLL.wx_diancai_member();
        Model.wx_diancai_member menber = new Model.wx_diancai_member();
        public  int dingdantoday = 0;
        public  int dingdanzuotian = 0;
        public  int dingdanbenyue = 0;
        public  int dingdanshangyue = 0;
        public int dingdanzj = 0;


        public float yyetoday = 0;
        public float yyezuotian = 0;
        public float yyebenyue = 0;
        public float yyeshangyue = 0;
        public float yyezj = 0;


        public int khtoday = 0;
        public int khzuotian = 0;
        public int khbenyue = 0;
        public int khshangyue = 0;
        public int khzj = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
          
            if(!IsPostBack)
            {
                shopid = MyCommFun.RequestInt("shopid");
                //成功订单数
                  
                    //今日
                dingdantoday = memberbll.dingdantoday(shopid);

                    //昨日
                dingdanzuotian = memberbll.dingdanzuotian(shopid);
                    //本月
                dingdanbenyue = memberbll.dingdanbenyue(shopid);
                    //上月

                dingdanshangyue = memberbll.dingdanshangyue(shopid);

                dingdanzj = dingdantoday + dingdanzuotian + dingdanbenyue + dingdanshangyue;


                //营业额

                   //今日
                yyetoday = memberbll.yyetoday(shopid);
                   //昨日
                yyezuotian = memberbll.yyezuotian(shopid);
                   //本月
                yyebenyue = memberbll.yyebenyue(shopid);
                   //上月
                yyeshangyue = memberbll.yyeshangyue(shopid);

                yyezj = yyetoday + yyezuotian + yyebenyue + yyeshangyue;

                //新增顾客

                //今日
                khtoday = memberbll.khtoday(shopid);

                //昨日

                khzuotian = memberbll.khzuotian(shopid);
                //本月
                khbenyue = memberbll.khbenyue(shopid);
                //上月
                khshangyue = memberbll.khshangyue(shopid);

                //总计
                khzj = khtoday + khzuotian + khbenyue + khshangyue;

                RptBind(shopid);

            }

        }

        #region 数据绑定=================================

        /// <summary>
        /// 绑定按照时间的数据报表
        /// </summary>
        /// <param name="shopid"></param>
        private void RptBind(int shopid)
        {
            DataSet ds = gbll.GetTongjiByDate(shopid);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();
        }

        #endregion

        /// <summary>
        ///  
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }
    }
}