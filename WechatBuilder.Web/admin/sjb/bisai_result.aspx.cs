using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.sjb
{
    public partial class bisai_result : Web.UI.ManagePage
    {
        BLL.wx_sjb_bisai bisaibll = new BLL.wx_sjb_bisai();
        Model.wx_sjb_bisai bisai = new Model.wx_sjb_bisai();
    
        public int richengid = 0;
        public int bisaiid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           richengid= MyCommFun.RequestInt("rcid");
           bisaiid = MyCommFun.RequestInt("id");
        
           if (!IsPostBack)
           {
               bisai = bisaibll.GetModel(bisaiid);
               if (bisai.resultType != null && bisai.resultType.ToString().Length > 0)
               {
                   resultType.SelectedValue = bisai.resultType.ToString();
                   save_qiudui.Visible = false;

               }

           }

        }



        protected void save_qiudui_Click(object sender, EventArgs e)
        {

           //结果
            if (this.resultType.SelectedValue == null || this.resultType.SelectedValue.Trim().Length <= 0)
            {
                JscriptMsg("必须选择一个结果！", "back", "Error");
                return;
            }
            int resultType = Convert.ToInt32( this.resultType.SelectedValue);
            bisai = bisaibll.GetModel(bisaiid);
            if (bisai.resultType != null && bisai.resultType.ToString().Length > 0)
            {
                return;         
            }
            bisaibll.Updatejg(bisaiid, resultType);


            //修改wx_sjb_jcDetail
            BLL.wx_sjb_jcDetail yonghu = new BLL.wx_sjb_jcDetail();
            yonghu.UpdateDetail(richengid, bisaiid, resultType);



            //修改wx_sjb_users
            BLL.wx_sjb_users uerbll = new BLL.wx_sjb_users();
            uerbll.UpdateField(bisaiid,resultType);//成功个数
            uerbll.UpdateField1(bisaiid, resultType);//成功个数

            //修改wx_sjb_qiudui
            bisai = bisaibll.GetModel(bisaiid);

            //修改球队的基本表
            BLL.wx_sjb_qiudui qdBll = new BLL.wx_sjb_qiudui();
            if (resultType == 1)
            {
                //修改球队1的胜利次数
                qdBll.UpdateField(bisai.qd1Id.Value, " succTimes  =isnull(succTimes,0)+1");
            }
            else if (resultType == 2)
            {
                qdBll.UpdateField(bisai.qd2Id.Value, " succTimes  =isnull(succTimes,0)+1");
            }
            else if (resultType == 3)
            {

                qdBll.UpdateField(bisai.qd1Id.Value, " succTimes  =isnull(succTimes,0)+1");
                qdBll.UpdateField(bisai.qd2Id.Value, " succTimes  =isnull(succTimes,0)+1");

            }


            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改球队设置，主键为" + bisaiid); //记录日志
            JscriptMsg("修改成功！", "bisai_list.aspx?id=" + richengid, "Success");


        }
    }
}