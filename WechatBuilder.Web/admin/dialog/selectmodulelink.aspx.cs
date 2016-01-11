using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.dialog
{
    public partial class selectmodulelink : Web.UI.ManagePage
    {
        WechatBuilder.BLL.wx_link_module bll = new WechatBuilder.BLL.wx_link_module();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
            }
        }

        private void BindDdl()
        {
            IList<Model.wx_link_module> mlist = bll.GetModelList("");

            ddlModule.DataTextField = "lName";
            ddlModule.DataValueField = "id";
            ddlModule.DataSource = mlist;
            ddlModule.DataBind();
            ddlModule.Items.Insert(0, new ListItem("请选择融合类型", "0"));


        }
        /// <summary>
        /// 选择完类型信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            int  mId =MyCommFun.Str2Int( ddlModule.SelectedItem.Value);

            BindList(mId);
        }

        private void BindList(int  mId)
        {
            if (mId ==0)
            {
                litModulelistStr.Text = "";
                return;
            }
            StringBuilder sb = new StringBuilder("");
            Model.wx_link_module module = bll.GetModel(mId);
            string newurl = "";
            if (module.moduleType ==0)
            { //只有一条信息
                newurl = urlRuleReplace(module.urlRule);
                sb.Append(" <tr class=\"td_c\">  <td>  <label class=\"lbl_modulerad\"> <input id=\"rad_" + module.id + "\" class=\"s_modulerad\" type=\"radio\" name=\"modulerad\" /><label for=\"rad_" + module.id + "\" title=\"" + newurl + "\" class=\"lblUrl\">" + module.lName + "</label></label> </td>  </tr>");
                
            }
            else if (module.moduleType == 2)
            {
                //数据都存在wx_small_link里
                BLL.wx_small_link sbll = new BLL.wx_small_link();
                IList<Model.wx_small_link> slist = sbll.GetModelList("sType='" + module.moduleName + "'");
                if (slist != null && slist.Count > 0)
                {
                    Model.wx_small_link s = new Model.wx_small_link();
                    for (int i = 0; i < slist.Count; i++)
                    {
                        s = slist[i];
                        newurl = urlRuleReplace(s.url);
                        sb.Append(" <tr class=\"td_c\"><td><label class=\"lbl_modulerad\"> <input id=\"rad_" + s.id + "\" class=\"s_modulerad\" type=\"radio\" name=\"modulerad\" /><label for=\"rad_" + s.id + "\" title=\"" + newurl + "\" class=\"lblUrl\">" + s.sName + "</label></label> </td>  </tr>");
                    }
                }
            }
            else
            { 
                //多条数据,表不一样
                Model.wx_userweixin weixin = GetWeiXinCode();
                string tableName = module.tableName;
                newurl = urlRuleReplace(module.urlRule);
                string nameColumn = module.nameColumn;
                string idColumn = module.idColumn;
                string sql = "select  " + idColumn + "," + nameColumn + "  from " + tableName + " where wid=" + weixin.id;
               DataSet ds= bll.GetTableList(sql);
               if (ds != null && ds.Tables.Count > 0)
               {
                   DataRow dr;
                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                   {
                       dr = ds.Tables[0].Rows[i];
                       string id = dr[idColumn].ToString();
                       string name = dr[nameColumn].ToString();
                       newurl = newurl.Replace("{id}",id);
                       sb.Append(" <tr class=\"td_c\">  <td><label class=\"lbl_modulerad\"> <input id=\"rad_" + id + "\" class=\"s_modulerad\" type=\"radio\" name=\"modulerad\" /><label for=\"rad_" + id + "\" title=\"" + newurl + "\" class=\"lblUrl\">" + name + "[编码：" + id + "]</label></label> </td>  </tr>");
                    
                   }
               }


            }
            

            litModulelistStr.Text = sb.ToString();

        }

        private string urlRuleReplace(string url)
        {
            string newUrl = "";
            Model.wx_userweixin weixin = GetWeiXinCode();
            newUrl = url.Replace("{wid}",weixin.id.ToString());
            newUrl = newUrl.Replace("{yuming}",MyCommFun.getWebSite());
            return newUrl;
        
        }
    }
}