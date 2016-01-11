using System;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.shopmgr.setting
{
    public partial class payment_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.payment model = new Model.payment();
        BLL.wx_payment_alipay aliBll = new BLL.wx_payment_alipay();
        BLL.wx_payment_wxpay wxBll = new BLL.wx_payment_wxpay();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = MXRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.payment().Exists(this.id))
            {
                JscriptMsg("支付方式不存在或已删除！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_payment", MXEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo(this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            BLL.payment bll = new BLL.payment();
            model = bll.GetModel(_id);
            txtTitle.Text = model.title;
          
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtSortId.Text = model.sort_id.ToString();
            rblPoundageType.SelectedValue = model.poundage_type.ToString();
            txtPoundageAmount.Text = model.poundage_amount.ToString();
            txtImgUrl.Text = model.img_url;
            txtRemark.Text = model.remark;
            if (model.pTypeId==2)
            {
                //支付宝
                Model.wx_payment_alipay alipay = aliBll.GetModelList("wid=" + weixin.id)[0];
                txtAlipaySellerEmail.Text = alipay.ownerName;
                txtAlipayPartner.Text = alipay.partner;
                txtAlipayKey.Text = alipay.e_key;
                txtprivate_key.Text = alipay.private_key;
                txtpublic_key.Text = alipay.public_key;
                hidPayId.Value = alipay.id.ToString();

            }
            else if (model.pTypeId==3)
            {
                //微信支付
                Model.wx_payment_wxpay wxpay = wxBll.GetModelByWid(weixin.id);
                txtpaySignKey.Text = wxpay.paySignKey;
                txtTenpayPartnerId.Text = wxpay.partnerId;
                txtTenpayKey.Text = wxpay.partnerKey;
                hidPayId.Value = wxpay.id.ToString();
                rblQuicklyFH.SelectedValue = wxpay.quicklyFH.ToString().ToLower()=="true" ? "1" : "0";
                txtAppId.Text=wxpay.appId ;

            }
            
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.payment bll = new BLL.payment();
            Model.payment model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.poundage_type = int.Parse(rblPoundageType.SelectedValue);
            model.poundage_amount = decimal.Parse(txtPoundageAmount.Text.Trim());
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            int payid = MyCommFun.Str2Int(hidPayId.Value);
            if (model.pTypeId==2)
            {
                //支付宝

                Model.wx_payment_alipay alipay = aliBll.GetModel(payid);
                alipay.ownerName = txtAlipaySellerEmail.Text.Trim();
                alipay.partner = txtAlipayPartner.Text.Trim();
                alipay.e_key = txtAlipayKey.Text.Trim();
                alipay.private_key = txtprivate_key.Text.Trim();
                alipay.public_key = txtpublic_key.Text.Trim();
                aliBll.Update(alipay);

                
            }
            else if (model.pTypeId==3)
            {
                //微支付
                Model.wx_payment_wxpay wxpay = wxBll.GetModel(payid);
                wxpay.paySignKey = txtpaySignKey.Text.Trim();
                wxpay.partnerId = txtTenpayPartnerId.Text.Trim();
                wxpay.partnerKey = txtTenpayKey.Text.Trim();
                wxpay.quicklyFH = rblQuicklyFH.SelectedItem.Value == "1" ? true : false;
                wxpay.appId = txtAppId.Text.Trim();
                wxBll.Update(wxpay);
                
            }
           

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改支付方式:" + model.title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("order_payment", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("修改配置成功！", "payment_list.aspx", "Success");
        }
    }
}