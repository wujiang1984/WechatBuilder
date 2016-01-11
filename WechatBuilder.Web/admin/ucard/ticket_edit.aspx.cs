using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;

namespace WechatBuilder.Web.admin.ucard
{
    public partial class ticket_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_ucard_ticket tBll = new wx_ucard_ticket();
        protected int sid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            sid = MyCommFun.RequestInt("sid");
            if (sid == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!tBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                BindUserDegree(sid);
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }

        private void BindUserDegree(int sid)
        {
            BLL.wx_ucard_udegree degreeBll = new wx_ucard_udegree();
            IList<Model.wx_ucard_udegree> degreelist = degreeBll.GetModelList("sid=" + sid);
            rlitRQ.DataValueField = "degreeNum";
            rlitRQ.DataTextField = "callName";
            rlitRQ.DataSource = degreelist;
            rlitRQ.DataBind();
            rlitRQ.Items.Insert(0, new ListItem("全部会员", "0"));
        }


        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_ucard_ticket ticket = tBll.GetModel(id);
            txtnName.Text = ticket.tName;
            txtusedContent.Value = ticket.usedContent;
            txtbeginDate.Text = ticket.beginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtendDate.Text = ticket.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtusedTimes.Text = ticket.usedTimes == null ? "0" : ticket.usedTimes.Value.ToString();
            if (ticket.typeId == 1)
            {
                radType1.Checked = true;
            }
            else
            {
                radType2.Checked = true;
                txtTypeMoney.Text = ticket.dyMoney.Value.ToString();
            }

            if (ticket.userType.Value  == 2001)
            {
                txtdcje.Text = ticket.consumeMoney.Value.ToString();
            }
            else if (ticket.userType.Value == 2002)
            {
                txtljje.Text = ticket.consumeMoney.Value.ToString();
            }
            MessageBox.ResponseScript(this, " $(\"input:radio[name='rlitRQ'][value=" + ticket.userType.Value + "]\").attr(\"checked\",\"checked\"); ");

        
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtnName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
            int rqType = MyCommFun.Str2Int(txtRQValue.Text.Trim(), -1);
            if (rqType == -1)
            {
                JscriptMsg("请选择人群的类型", "back", "Error");
                return;
            }
            #endregion
            Model.wx_ucard_ticket ticket = new Model.wx_ucard_ticket();

            if (id > 0)
            {
                ticket = tBll.GetModel(id);
            }

            ticket.tName = txtnName.Text.Trim();
            ticket.usedContent = txtusedContent.Value.Trim();
            ticket.sId = sid;
            ticket.beginDate = MyCommFun.Obj2DateTime(txtbeginDate.Text);
            ticket.endDate = MyCommFun.Obj2DateTime(txtendDate.Text);
            ticket.usedTimes = MyCommFun.Str2Int(txtusedTimes.Text);
            ticket.userType = rqType;
            if (rqType == 2001)
            {
                ticket.consumeMoney = MyCommFun.Str2Int(txtdcje.Text);
            }
            else if(rqType == 2002)
            {
                ticket.consumeMoney = MyCommFun.Str2Int(txtljje.Text);
            }
            if (radType1.Checked)
            {
                ticket.typeId = 1;
            }
            else
            {
                ticket.typeId = 2;
                ticket.dyMoney =MyCommFun.Str2Int( txtTypeMoney.Text);
            }
            if (id <= 0)
            {  //新增

                //1新增主表
                ticket.createDate = DateTime.Now;
                ticket.sort_id = 0;
                id = tBll.Add(ticket);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加会员商家优惠券，主键为" + id); //记录日志
                JscriptMsg("添加会员商家优惠券成功！", "ticket_list.aspx?id=" + sid, "Success");
            }
            else
            {   //修改
                //1修改主表
                tBll.Update(ticket);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改会员商家优惠券，主键为" + id); //记录日志
                JscriptMsg("修改会员商家优惠券成功！", "ticket_list.aspx?id=" + sid, "Success");
            }

        }

        /// <summary>
        /// 新增时候，优惠券立即发放（后台不需要做，在微信用户进去优惠券时候再取数据）
        /// </summary>
        /// <param name="userType"></param>
        private void AddPersonYqh(int userType)
        {
            BLL.wx_ucard_users userBll = new wx_ucard_users();
            IList<Model.wx_ucard_users> userlist = new List<Model.wx_ucard_users>();
            if (userType == 0)
            { //全部人员
                userlist = userBll.GetModelList("sid=" + sid);
            }
            else if (userType > 0 && userType < 1000)
            { //按照等级来取人员
                BLL.wx_ucard_udegree degreeBll = new wx_ucard_udegree();
                IList<Model.wx_ucard_udegree> degreelist = degreeBll.GetModelList("degreeNum=" + userType+" and sid="+sid);
                if (degreelist == null || degreelist.Count <= 0)
                {
                    return;
                }
                Model.wx_ucard_udegree degree = degreelist[0];
                userlist = userBll.GetModelList("ttScore<=" + degree.score_max + "  and ttScore>=" + degree.score_min+" and sid="+sid);
            }
            else if (userType > 1000 && userType < 2000)
            { 
                //按照开卡和消费情况来取人员

            
            }
            else if (userType > 2000)
            {
                //按照消费情况来取人员
                BLL.wx_ucard_users_consumeinfo cBll = new wx_ucard_users_consumeinfo();
                IList<Model.wx_ucard_users_consumeinfo> conlist = new List<Model.wx_ucard_users_consumeinfo>();
                if (userType == 2001)
                {  //单次消费超过x元
                    float dcje = MyCommFun.Str2Float(txtdcje.Text);
                    userlist = userBll.GetModelList("sid=" + sid + " and id in (select distinct uid from  wx_ucard_users_consumeinfo where sId=" + sid + " and consumeMoney>=" + dcje + ")");
                }
                else if (userType == 2002)
                {
                    //累计消费超过x元
                    float ljje = MyCommFun.Str2Float(txtljje.Text);
                    userlist = userBll.GetModelList("sid=" + sid + " and id in (select uid from wx_ucard_users_consumeinfo   group by uid having sum(consumeMoney)>" + ljje + ")");
                }
            }

        }

    }
}