using WechatBuilder.Common;
using WechatBuilder.Web.weixin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.vote
{


    public partial class vote_result : Web.UI.ManagePage
    {
 

        BLL.wx_vote_item gbll = new BLL.wx_vote_item();
        int aid = 0;
        int wid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            aid = MyCommFun.RequestInt("aid");
            wid = MyCommFun.RequestInt("wid");
            if (!Page.IsPostBack)
            {
                
                if (aid == 0)
                {
                    JscriptMsg("参数不正确！", "back", "Error");
                    return;
                }
                RptBind("id desc", aid);
            }

        }

        private void RptBind(string _strWhere, int aid)
        {
            _strWhere = "baseid=" + aid;

            DataSet ds = gbll.GetList(_strWhere);
            int ttCount = 0;


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ttCount = MyCommFun.Obj2Int(ds.Tables[0].Compute("sum(tpTimes)", "TRUE"));

                DataRow dr;

                int count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    //totalnum+= Convert.ToInt32(ds.Tables[0].Rows[i]["tpTimes"]);//总数
                    //百分比totalnum
                    // baifenbi = Convert.ToInt32(ds.Tables[0].Rows[i]["tpTimes"]) / totalnum;
                    if (dr["tpTimes"] == null || dr["tpTimes"].ToString().Trim() == "")
                    {
                        dr["tpTimes"] = 0;
                    }
                    dr["bili"] = computeBL(ttCount, MyCommFun.Obj2Int(dr["tpTimes"]));





                }
                ds.AcceptChanges();
            }
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

        }






        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
           
         
            Repeater rptList =  this.rptList;
                   
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int txttpTimes = 0;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txttpTimes")).Text.Trim(), out txttpTimes))
                {
                    txttpTimes = 0;
                }
                gbll.UpdateField(id, "tpTimes=" + txttpTimes.ToString());
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存投票结果成功"); //记录日志
            JscriptMsg("保存排序成功啦！", "vote_result.aspx?aid="+aid+"&wid="+wid, "Success");
        }



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

        public string bianjiStr(object id, object voteType)
        {
            if (voteType.ToString().ToLower() == "1")
            {
                //文字
                return "<a href=\"vote_editcharact.aspx?id=" + id.ToString() + "\"  >编辑</a>";
            }
            else
            { //图片

                return "<a href=\"vote_editepicture.aspx?id=" + id.ToString() + "\"  >编辑</a>";
            }
        }

        /// <summary>
        /// 计算投票数比例
        /// </summary>
        /// <param name="ttCount"></param>
        /// <param name="itemCount"></param>
        /// <returns></returns>
        protected float computeBL(int ttCount, int itemCount)
        {
            if (ttCount == 0)
            {
                return (float)0.00;
            }

            float ret = (itemCount * 100.0f) / ttCount;

            ret = (float)Math.Round(ret, 2);

            return ret;


        }


    }
}
