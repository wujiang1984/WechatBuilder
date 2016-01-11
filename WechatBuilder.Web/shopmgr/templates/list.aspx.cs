using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.shopmgr.templates
{
    public partial class list : Web.UI.ManagePage
    {
        wx_module_templates tBll = new wx_module_templates();

        wx_module_templates_wcode twBll = new wx_module_templates_wcode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                RptBind(weixin.id);
            }
        }



        #region 数据绑定=================================
        /// <summary>
        /// 绑定模版,颜色
        /// </summary>
        /// <param name="wid"></param>
        private void RptBind(int wid)
        {

            // 模版数据绑定
            this.rptList2.DataSource = tBll.GetModelList("moduleCode='shop'");
            this.rptList2.DataBind();

            //绑定当前微帐号选择的模版Id和颜色
            IList<Model.wx_module_templates_wcode> twlist = twBll.GetModelList("wid=" + wid);
            if (twlist != null && twlist.Count() > 0)
            {
                hidWTId.Value = twlist[0].id.ToString();
                MessageBox.ResponseScript(this, "$(\"#rad" + twlist[0].tid + "\").attr(\"checked\",\"checked\");");


            }
        }




        #endregion


        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

           // int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);

        }


        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {

            int tId = MyCommFun.Str2Int(txtSelectTemplateId.Text);
            int colorId = MyCommFun.Str2Int(txtSelectColorId.Text);
            if (tId != 0)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();

                Model.wx_module_templates_wcode tw = new Model.wx_module_templates_wcode();
                bool isAdd = true;
                bool Succ = false;
                if (hidWTId.Value != "0")
                {
                    int wtId = MyCommFun.Str2Int(hidWTId.Value);
                    tw = twBll.GetModel(wtId);
                    if (tw != null)
                    {
                        isAdd = false;
                    }
                }
                tw.wid = weixin.id;
                tw.tid = tId;
                tw.createDate = DateTime.Now;

               

                if (isAdd)
                {
                    int id = twBll.Add(tw);
                    if (id > 0)
                    { Succ = true; }
                    hidWTId.Value = id.ToString();
                }
                else
                {
                    Succ = twBll.Update(tw);
                }
                if (Succ)
                {
                    JscriptMsg("模版设置成功！", "list.aspx", "Success");
                }
                else
                {
                    JscriptMsg("模版设置失败！", "", "Error");
                }
            }


        }
 
       
    }
}