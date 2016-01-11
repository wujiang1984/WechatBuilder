using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.ucard
{
    public partial class user_baseinfo : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_users uBll = new wx_ucard_users();
        protected int sid = 0;
        protected int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            sid = MyCommFun.RequestInt("sid");
            id = MyCommFun.RequestInt("id");
            if (sid == 0 ||id==0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!uBll.Exists(id))
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
            Model.wx_ucard_users user = uBll.GetModel(id);
            txtrealName.Text = user.realName;
            lblcardNo.Text = user.cardNo;
            lblopenid.Text = user.openid;
            //等级
            BLL.wx_ucard_udegree degreeBll = new wx_ucard_udegree();
            IList<Model.wx_ucard_udegree> degreelist = degreeBll.GetModelList("sid=" + sid);

            int degreeNum = 0;
            string jibie = "";
            jibie = BLL.wx_ucard_fun.userDegree(id, MyCommFun.Obj2Int(user.ttScore), jibie, out degreeNum);

            lblDegree.Text = jibie;

            rblSex.SelectedValue = user.sex == null ? "3" : user.sex.Value.ToString();
            txtwxName.Text = user.wxName;
            txtage.Text = user.age==null?"0":user.age.ToString();
            txtttScore.Text = MyCommFun.ObjToStr(user.ttScore);
            txtqdScore.Text = MyCommFun.ObjToStr(user.qdScore);
            txtconsumeScore.Text = MyCommFun.ObjToStr(user.consumeScore);
            txtconsumeMoney.Text = MyCommFun.ObjToStr(user.consumeMoney);
            txtregTime.Text = MyCommFun.Obj2DateTime(user.regTime).ToString("yyyy-MM-dd HH:mm:ss");
            txtendDate.Text = MyCommFun.Obj2DateTime(user.endDate).ToString("yyyy-MM-dd HH:mm:ss");
            txtmobile.Text = MyCommFun.ObjToStr(user.mobile);
            txtaddr.Text = MyCommFun.ObjToStr(user.addr);
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtrealName.Text.Trim().Length == 0)
            {
                strErr += "姓名不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion
            Model.wx_ucard_users user = new Model.wx_ucard_users();

            if (id > 0)
            {
                user = uBll.GetModel(id);
            }

            user.realName = txtrealName.Text.Trim();
            user.sex = MyCommFun.Str2Int(rblSex.SelectedItem.Value);
            user.wxName = txtwxName.Text;
            user.age = MyCommFun.Str2Int(txtage.Text);
            user.ttScore = MyCommFun.Str2Int(txtttScore.Text);
            user.qdScore = MyCommFun.Str2Int(txtqdScore.Text);
            user.consumeScore = MyCommFun.Str2Int(txtconsumeScore.Text);
            user.consumeMoney = MyCommFun.Str2Decimal(txtconsumeMoney.Text);
            user.regTime = MyCommFun.Obj2DateTime(txtregTime.Text);
            user.endDate = MyCommFun.Obj2DateTime(txtendDate.Text);
            user.mobile = txtmobile.Text;
            user.addr = txtaddr.Text;

            if (id <= 0)
            {  //新增

                ////1新增主表
                //id = uBll.Add(user);
                //AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加会员，主键为" + id); //记录日志
                //JscriptMsg("添加会员成功！", "gift_list.aspx?id=" + sid, "Success");
            }
            else
            {   //修改
                //1修改主表
                uBll.Update(user);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员卡--会员信息，主键为" + id); //记录日志
                JscriptMsg("修改会员卡--会员信息成功！", "user_list.aspx?id=" + sid, "Success");
            }

        }



        /// <summary>
        /// 根据级别算级别
        /// </summary>
        /// <param name="score"></param>
        /// <param name="degreelist"></param>
        /// <returns></returns>
        private int  ComputeJiBie(int score, IList<Model.wx_ucard_udegree> degreelist)
        {
            int degreeNum = 0;

            IList<Model.wx_ucard_udegree> tmpDegree = (from d in degreelist where d.score_min <= score && d.score_max > score orderby d.degreeNum ascending select d).ToArray<Model.wx_ucard_udegree>();
            if (tmpDegree != null && tmpDegree.Count > 0)
            {
                degreeNum = tmpDegree[0].degreeNum.Value;
            }
            return degreeNum;
        }


    }
}