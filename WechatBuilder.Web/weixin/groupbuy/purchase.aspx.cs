using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.grouppurchase
{
    public partial class purchase : System.Web.UI.Page
    {

        protected Model.wx_purchase_customer customermodel;
        protected Model.wx_purchase_base basemodel;
        protected int totalCount = 0;
        protected int count = 0;
        protected int limitCount = 0;
        protected string huodname = "";
        protected int tuangj = 0;
        protected int yg = 0;
        protected string customerNum ="1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string  openid = MyCommFun.RequestOpenid();
                int id=MyCommFun.RequestInt("aid");
                BLL.wx_purchase_customer customerbll = new BLL.wx_purchase_customer();
                BLL.wx_purchase_base basebll = new BLL.wx_purchase_base();
                customermodel = customerbll.GetModelopenid(openid);
                basemodel=basebll.GetModel(id);

                if (basemodel!=null)
                {
                    totalCount = Convert.ToInt32(basemodel.totalCount);
                    limitCount = Convert.ToInt32(basemodel.limitCount);
                    count = totalCount- customerbll.GetRecordCount(id);//剩余
                    this.totalCount1.Value = totalCount.ToString();
                    this.limitCount1.Value = limitCount.ToString();
                    this.count1.Value = count.ToString();
                    huodname = basemodel.activityName;
                    tuangj = Convert.ToInt32( basemodel.groupPrice);

                   yg= customerbll.GetRecordyg(openid, id);
                   int aa = limitCount - yg;
                    if (aa<0)
                    {
                        aa = 0;
                    }
                   this.limit.Value = aa.ToString();
                    //
                }


                if (customermodel!=null && customermodel.status==0)
                {
                    this.sndiv.Visible = true;
                    this.sn.Visible = true;
                    this.sn.Value = customermodel.sn;
                    this.customerName.Value = customermodel.customerName;
                    this.tel.Value = customermodel.tel;
                 //   this.customerNum.Value = customermodel.customerNum.ToString();
                    customerNum = customermodel.customerNum.ToString();
                    this.address.Value = customermodel.address;
                    this.Remark.Value = customermodel.Remark;


                    this.pwddiv.Visible = true;

                    //this.pwd.Value = basemodel.shopsPwd;
                }

            }

        }
    }
}