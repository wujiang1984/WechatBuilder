using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;


namespace WechatBuilder.Web.shopmgr.setting
{
    public partial class shop_setting : Web.UI.ManagePage
    {
        WechatBuilder.BLL.wx_shop_setting bll = new WechatBuilder.BLL.wx_shop_setting();
        wx_requestRule rBll = new wx_requestRule();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            lblWSiteUrl.Text = MyCommFun.getWebSite() + "/shop/index.aspx?wid=" + weixin.id;

            IList<WechatBuilder.Model.wx_shop_setting> modellist = bll.GetModelList("wId=" + weixin.id);
            if (modellist == null || modellist.Count <= 0)
            {
                return;
            }
            WechatBuilder.Model.wx_shop_setting model = modellist[0];
            this.lblId.Text = model.id.ToString();
            this.txtshopName.Text = model.shopName;
            this.txtcopyright.Text = model.copyright;
            this.txtlogo.Text = model.logo;
            this.txtbgPic.Text = model.bgPic;
            this.txttel.Text = model.tel;
            this.txtaddr.Text = model.addr;


            //微支付配置信息
            lblzfsqml.Text = MyCommFun.getWebSite() + "/api/payment/";
            lblzfqqsl.Text = "paypage.aspx";
            lblwqtz.Text = MyCommFun.getWebSite() + "/api/payment/wxpay/feedback.aspx";
            lbljjtz.Text = MyCommFun.getWebSite() + "/api/payment/wxpay/warning.aspx";
        }
        #endregion

        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WechatBuilder.Model.wx_shop_setting model = new WechatBuilder.Model.wx_shop_setting();
            try
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                int wId = weixin.id;
                string shopName = this.txtshopName.Text;
                string copyright = this.txtcopyright.Text;
                string logo = this.txtlogo.Text;
                string bgPic = this.txtbgPic.Text;
                string tel = this.txttel.Text;
                string addr = this.txtaddr.Text;
                DateTime createDate = DateTime.Now;

                int id = int.Parse(lblId.Text.Trim());
                if (id != 0)
                {
                    //修改
                    model = bll.GetModel(id);
                }
                else
                {
                    //添加
                    model.wid = wId;
                    model.createDate = createDate;
                }

                model.shopName = shopName;
                model.copyright = copyright;
                model.logo = logo;
                model.bgPic = bgPic;
                model.tel = tel;
                model.addr = addr;
                if (id != 0)
                {
                    bll.Update(model);
                }
                else
                {
                    id = bll.Add(model);
                }
              
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改商城设置"); //记录日志
                JscriptMsg("修改商城设置成功！", "shop_setting.aspx", "Success");
            }
            catch
            {
                JscriptMsg("微网站设置失败！", "", "Error");
            }
        }

    }
}