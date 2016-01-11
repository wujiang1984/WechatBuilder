using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.shopmgr.setting
{
    public partial class payment_select : Web.UI.ManagePage
    {
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                RptBind();
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
            BLL.wx_payment_type bll = new BLL.wx_payment_type();
            Model.wx_userweixin weixin = GetWeiXinCode();
            this.rptList.DataSource = bll.GetList("id not in(select pTypeId from dt_payment where wid=" + weixin.id + ") and typeCode!='alipay'");
            this.rptList.DataBind();
        }
        #endregion

    }
}