using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WechatBuilder.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 返回支付列表
        /// </summary>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_payment_list(int top, string strwhere)
        {
            DataTable dt = new DataTable();
            string _where = "is_lock=0";
            if (!string.IsNullOrEmpty(strwhere))
            {
                _where += " and " + strwhere;
            }
            dt = new BLL.payment().GetList(top, _where, "sort_id asc,id desc").Tables[0];
            return dt;
        }

        /// <summary>
        /// 返回支付类型的标题
        /// </summary>
        /// <param name="payment_id">ID</param>
        /// <returns>String</returns>
        protected string get_payment_title(int wid,int pTypeId)
        {
            return new BLL.payment().GetTitle(wid, pTypeId);
        }

        /// <summary>
        /// 返回支付费用金额
        /// </summary>
        /// <param name="payment_id">支付ID</param>
        /// <returns>decimal</returns>
        protected decimal get_payment_poundage_amount(int payment_id)
        {
            int group_id = 0;
            Model.users userModel = GetUserInfo();
            if (userModel != null)
            {
                group_id = userModel.group_id;
            }
            Model.payment payModel = new BLL.payment().GetModel(payment_id);
            if (payModel == null)
            {
                return 0;
            }
            decimal poundage_amount = payModel.poundage_amount;
            if (payModel.poundage_type == 1)
            {
                poundage_amount = (poundage_amount * Web.UI.ShopCart.GetTotal(group_id).real_amount) / 100;
            }
            return poundage_amount;
        }

    }
}
