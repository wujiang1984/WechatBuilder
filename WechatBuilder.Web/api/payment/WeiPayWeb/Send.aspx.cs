using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WeiPayWeb
{
   
    public partial class Send : System.Web.UI.Page
    {
        private string UserOpenId = ""; //微信用户openid；

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.txtBody.Text = "商品描述";
                this.txtOrderSN.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
                this.txtOther.Text = "test";
                this.txtPrice.Text = "1";

                //获取当前用户的OpenId，如果可以通过系统获取用户Openid就不用调用该函数
               this.GetUserOpenId();

                this.lblOpenId.Text = this.UserOpenId;
            }

        }

        /// <summary>
        /// 提交支付信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //设置支付数据
            PayModel model = new PayModel();
            model.OrderSN = this.txtOrderSN.Text;
            model.TotalFee = int.Parse(this.txtPrice.Text);
            model.Body = this.txtBody.Text;
            model.Attach = this.txtOther.Text; //不能有中午
            model.OpenId = this.lblOpenId.Text;

            //跳转到 WeiPay.aspx 页面，请设置函数中WeiPay.aspx的页面地址
            this.Response.Redirect(model.ToString());
        }
    }

  
}
