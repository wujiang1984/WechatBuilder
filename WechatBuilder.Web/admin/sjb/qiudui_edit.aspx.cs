using WechatBuilder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatBuilder.Web.admin.sjb
{
    public partial class qiudui_edit : Web.UI.ManagePage
    {
        protected int wid = 0;
        BLL.wx_sjb_qiudui qiuduibll = new BLL.wx_sjb_qiudui();
        Model.wx_sjb_qiudui qiudui = new Model.wx_sjb_qiudui();
        public int qiuduiid = 0;
        public string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            type = MyCommFun.QueryString("type");
            qiuduiid = MyCommFun.RequestInt("id");
            if (!Page.IsPostBack)
            {
                if (type == "edite")
                {
                    eidtelist(qiuduiid);
                }

            }
        }


        public void eidtelist(int qiuduiid)
        {
            qiudui = qiuduibll.GetModel(qiuduiid);
            if (qiudui!=null)
            {
            this.qdName.Text = qiudui.qdName;
            this.qdPic.Text = qiudui.qdPic;
            this.remark.InnerText = qiudui.remark;
            this.succTimes.Text = qiudui.succTimes.ToString();
            this.failTimes.Text = qiudui.failTimes.ToString();
            this.sort_id.Text = qiudui.sort_id.ToString();
            }

        }

        protected void save_qiudui_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            wid = weixin.id;
            qiuduiid = MyCommFun.RequestInt("id");
            if (type == "edite")
            {
                qiudui.id = qiuduiid;
                qiudui.wid = wid;
                qiudui.qdName = this.qdName.Text;
                qiudui.qdPic = this.qdPic.Text;
                qiudui.remark = this.remark.InnerText;
                if (this.succTimes.Text.ToString() != "")
                {
                    qiudui.succTimes = Convert.ToInt32(this.succTimes.Text.ToString());
                }
                else
                {
                    qiudui.succTimes = 0;
                }
                if (this.failTimes.Text.ToString() != "")
                {
                    qiudui.failTimes = Convert.ToInt32(this.failTimes.Text.ToString());
                }
                else
                {
                    qiudui.failTimes = 0;
                }

                if (this.sort_id.Text.ToString() != "")
                {
                    qiudui.sort_id = Convert.ToInt32(this.sort_id.Text.ToString());
                }
                else
                {
                    qiudui.sort_id = 0;
                }
                
                
            
                qiuduibll.Update(qiudui);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改球队设置，主键为" + qiuduiid); //记录日志
                JscriptMsg("修改成功！", "qiudui_list.aspx", "Success");
            }

            if (type=="add")
            {
                qiudui.wid = wid;
                qiudui.qdName = this.qdName.Text;
                qiudui.qdPic = this.qdPic.Text;
                qiudui.remark = this.remark.InnerText;
                qiudui.succTimes = Convert.ToInt32( this.succTimes.Text.ToString());
                if (this.succTimes.Text.ToString() != "")
                {
                    qiudui.succTimes = Convert.ToInt32(this.succTimes.Text.ToString());
                }
                else
                {
                    qiudui.succTimes = 0;
                }
                if (this.failTimes.Text.ToString() != "")
                {
                    qiudui.failTimes = Convert.ToInt32(this.failTimes.Text.ToString());
                }
                else
                {
                    qiudui.failTimes = 0;
                }

                if (this.sort_id.Text.ToString() != "")
                {
                    qiudui.sort_id = Convert.ToInt32(this.sort_id.Text.ToString());
                }
                else
                {
                    qiudui.sort_id = 0;
                }
                qiudui.createDate = DateTime.Now;
                int id = qiuduibll.Add(qiudui);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加球队设置，主键为" + id); //记录日志
                JscriptMsg("添加成功！", "qiudui_list.aspx", "Success");
            }

        }
    }
}