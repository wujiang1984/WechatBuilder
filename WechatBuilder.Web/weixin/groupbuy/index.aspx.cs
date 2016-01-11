using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.weixin.groupbuy
{
    public partial class index : WeiXinPage
    {
        protected Model.wx_purchase_base model;
        protected Model.wx_purchase_customer customermodel;
        protected int wid = 0;
        protected int id = 0;
        protected string introduction = "";
        protected string shopstel = "";
        protected string address = "";
        protected string activityName = "";
        protected string days = "";
        protected int groupPrice = 0;
        protected int costPrice = 0;
        protected string copyrightSetup = "";
        protected string status = "";
        protected string imageUrl = "";
        protected string openid = "";
        protected int purchaseCount = 0;
        protected int chengtuanCount = 0;
        protected float txtLatXPoint = 0.0F;
        protected float txtLatYPoint = 0.0F;
        protected string tel = "";
    

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                openid = MyCommFun.RequestOpenid();
                wid = MyCommFun.RequestInt("wid");
                id = MyCommFun.RequestInt("aid");

             

                BLL.wx_purchase_base gbll = new BLL.wx_purchase_base();
                BLL.wx_purchase_customer customerbll = new BLL.wx_purchase_customer();
                // DataSet ds = gbll.GetList(id);
                 model = gbll.GetModel(id);



                if (model.activityTimebegin.Value > DateTime.Now)//活动未开始
                {
                    
                    TimeSpan ts3 = new TimeSpan(Convert.ToDateTime(model.activityTimebegin).Ticks);
                    TimeSpan ts4 = new TimeSpan(DateTime.Now.Ticks);
                    TimeSpan endtime = ts3.Subtract(ts4).Duration();
                    //活动未开始
                    Response.Write("距离团购开始还有"+endtime.Days.ToString() + "天" + endtime.Hours.ToString() + "小时" + endtime.Minutes.ToString() + "分" + endtime.Seconds.ToString() + "秒");
                    Response.End();
                    return;
                }

                if (model.activityTimeend.Value< DateTime.Now)//活动结束
                {
                    introduction = model.introduction;
                    this.specialRemind.Text = model.specialRemind;
                    this.activeDescription.Text = model.activeDescription;
                    shopstel = model.shopstel;
                    address = model.address;
                    if (model.txtLatXPoint != null && model.txtLngYPoint != null)
                    {
                        txtLatXPoint = (float)model.txtLatXPoint;
                        txtLatYPoint = (float)model.txtLngYPoint;
                    }
                    tel = model.shopstel;
                    activityName = model.activityName;
                    days = "";
                    groupPrice = Convert.ToInt32(model.groupPrice);
                    costPrice = Convert.ToInt32(model.costPrice);
                    copyrightSetup = model.copyrightSetup;
                    imageUrl = model.imageUrl;
                    status = "团购已结束";
                    return;
                    
                }


                purchaseCount = customerbll.GetRecordCount(id);
               // chengtuanCount = customerbll.GetRecord(id);
                chengtuanCount = Convert.ToInt32(model.virtualPerson);
                introduction = model.introduction;
                this.specialRemind.Text = model.specialRemind;
                this.activeDescription.Text = model.activeDescription;
                shopstel = model.shopstel;
                address = model.address;
                if (model.txtLatXPoint != null && model.txtLngYPoint != null)
                {
                txtLatXPoint = (float)model.txtLatXPoint;
                txtLatYPoint = (float)model.txtLngYPoint;
                }
                tel = model.shopstel;
                activityName = model.activityName;
                TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(model.activityTimeend).Ticks);
                TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(model.activityTimebegin).Ticks);
                TimeSpan endtime1 = ts1.Subtract(ts2).Duration();
                days ="团购结束还有"+ endtime1.Days.ToString()+"天"+endtime1.Hours.ToString()+"小时"+endtime1.Minutes.ToString()+"分"+endtime1.Seconds.ToString()+"秒";
                groupPrice = Convert.ToInt32(model.groupPrice);
                costPrice = Convert.ToInt32(model.costPrice);
                copyrightSetup = model.copyrightSetup;
                imageUrl = model.imageUrl;
                //if (customerbll.Exists(openid))
                //{
                //    status = "每人限购" + model.limitCount + "件";
                //}

                customermodel = customerbll.GetModelSN(openid);

                if (customermodel!=null)
                {
                    if (customermodel.status == 0)//未消费
                    {
                        status = customermodel.sn;
                    }
                    else if (customermodel.status == 2)
                    {
                        int count = customerbll.GetRecordCount(openid,id);
                        status = "已经抢购" + count + "件" + "  " + "继续抢购";
                    }
                }
                
                else
                {
                    status = "抢购";
                }
            }
        }
    }
}