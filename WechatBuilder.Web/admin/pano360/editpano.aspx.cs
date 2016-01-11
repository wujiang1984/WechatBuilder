using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.pano360
{
    public partial class editpano : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_pano_jd pBll = new wx_pano_jd();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");

            int id = 0;

            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                  id = MyCommFun.RequestInt("id");
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!pBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_pano_jd pano = pBll.GetModel(id);
            hidid.Value = pano.id.ToString();
            txtpName.Text = pano.jdName.ToString();
            txtpContent.Value = pano.remark.ToString();

            this.txtpName.Text = pano.jdName;
            this.txtImgBefore.Text = pano.pic_front;
            imgBefore.ImageUrl = pano.pic_front;
            this.txtImgRight.Text = pano.pic_right;
            imgRight.ImageUrl = pano.pic_right;
            this.txtImgBehond.Text = pano.pic_behind;
            imgBehond.ImageUrl = pano.pic_behind;
            this.txtImgLeft.Text = pano.pic_left;
            imgLeft.ImageUrl = pano.pic_left;
            this.txtImgTop.Text = pano.pic_top;
            imgTop.ImageUrl = pano.pic_top;
            this.txtImgBottom.Text = pano.pic_bottom;
            imgBottom.ImageUrl = pano.pic_bottom;
            this.txtpContent.Value = pano.remark;

            litwUrl.Text = MyCommFun.getWebSite() + "/weixin/pano360/pano.aspx?wid=" + pano.wid + "&id=" + id;
 
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
           Model.wx_pano_jd model = new Model.wx_pano_jd();
            
           
            if (id != 0)
            {
                model = pBll.GetModel(id);
            }

            string strErr = "";


            if (this.txtpName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！\\n";
            }

            if (this.txtImgBefore.Text.Trim().Length == 0)
            {
                strErr += "图片-前不能为空！\\n";
            }
            if (this.txtImgRight.Text.Trim().Length == 0)
            {
                strErr += "图片-右不能为空！\\n";
            }
            if (this.txtImgBehond.Text.Trim().Length == 0)
            {
                strErr += "图片-后不能为空！\\n";
            }
            if (this.txtImgLeft.Text.Trim().Length == 0)
            {
                strErr += "图片-左不能为空！\\n";
            }
            if (this.txtImgTop.Text.Trim().Length == 0)
            {
                strErr += "图片-顶部不能为空！\\n";
            }
            if (this.txtImgBottom.Text.Trim().Length == 0)
            {
                strErr += "片-底部不能为空！\\n";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "", "Error");
                return;
            }

            string jdName = this.txtpName.Text;

            string music = "";
            string pic_front = this.txtImgBefore.Text;
            string pic_right = this.txtImgRight.Text;
            string pic_behind = this.txtImgBehond.Text;
            string pic_left = this.txtImgLeft.Text;
            string pic_top = this.txtImgTop.Text;
            string pic_bottom = this.txtImgBottom.Text;
            string pic_yulan = "";
            string remark = this.txtpContent.Value;
            int seq = 0;
            DateTime createDate = DateTime.Now;


            model.id = id;
            model.sysId = 1;
            model.wid = weixin.id;
            model.jdName = jdName;
            model.music = music;
            model.pic_front = pic_front;
            model.pic_right = pic_right;
            model.pic_behind = pic_behind;
            model.pic_left = pic_left;
            model.pic_top = pic_top;
            model.pic_bottom = pic_bottom;
            model.pic_yulan = pic_yulan;
            model.remark = remark;
            model.seq = seq;

            model.extStr = "";
            model.extStr2 = "";

            if (id != 0)
            {
                pBll.Update(model);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "修改360全景图信息，主键为" + id); //记录日志
                JscriptMsg("修改360全景图信息成功！", "index.aspx", "Success");
            }
            else
            {
                model.createDate = createDate;
                pBll.Add(model);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加360全景图信息，主键为" + id); //记录日志
                JscriptMsg("添加360全景图信息成功！", "index.aspx", "Success");
            }
        }
    }
}