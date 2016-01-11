using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.product
{
    public partial class product_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
       
        private int id = 0;

        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = MXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.wx_product().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("productlist", MXEnums.ActionEnum.View.ToString()); //检查权限
               
                TreeBind(); //绑定类别
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.wx_product_type bll = new BLL.wx_product_type();
            DataTable dt = bll.GetWCodeList(weixin.id,0);

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["tName"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.wx_product bll = new BLL.wx_product();
            Model.wx_product model = bll.GetModel(_id);

            ddlCategoryId.SelectedValue = model.typeId.Value.ToString();

            this.lblid.Text = model.id.ToString();
            this.txtTitle.Text = model.hdName;
            this.txtpSubject.Text = model.pSubject;

            this.txtbeginDate.Text = model.beginDate == null ? "" : model.beginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            this.txtendDate.Text = model.endDate == null ? "" : model.endDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            this.txtaddr.Text = model.addr;
            this.txtContent.Value = model.pContent;
            txtImgUrl.Text = model.extStr2;
           
            this.txtPrice.Text = model.price == null ? "" : model.price.Value.ToString();
            this.chkShowDate.Checked = model.showDate;
            this.chkShowPrice.Checked = model.showPrice;
            this.chkShowYuDing.Checked = model.showYuDing;
            this.txtAnNiuTxt.Text = model.btnName == "" ? "预定" : model.btnName;
            this.txtSortId.Text = model.extInt == null ? "99" : model.extInt.Value.ToString();
            txtUrl.Text = model.url == null ? "" : model.url;

                
        }
        #endregion


        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            bool result = false;
            Model.wx_product model = new Model.wx_product();
            BLL.wx_product bll = new BLL.wx_product();

            string hdName = this.txtTitle.Text;
            string hdSubject = this.txtpSubject.Text;
            string hdAddr = this.txtaddr.Text;
            string hdContent = this.txtContent.Value;
            DateTime createTime = DateTime.Now;
            string tupian = txtImgUrl.Text;//封面图片
            decimal price = decimal.Parse(txtPrice.Text);
            bool showDate = chkShowDate.Checked;
            bool showPrice = chkShowPrice.Checked;
            bool showYuDing = chkShowYuDing.Checked;
            int seq =MyCommFun.Str2Int(txtSortId.Text);

            model.hdName = hdName;
            model.pSubject = hdSubject;

            model.addr = hdAddr;
            model.pContent = hdContent;
            model.extStr2 = tupian;
            model.btnName = txtAnNiuTxt.Text.Trim();
            model.typeId =MyCommFun.Str2Int( ddlCategoryId.SelectedItem.Value);
            model.price = price;
            model.showDate = showDate;
            model.showPrice = showPrice;
            model.showYuDing = showYuDing;
            model.extInt = seq;
            model.wid = weixin.id;
            model.url = txtUrl.Text.Trim();
            model.createDate = DateTime.Now;
            if (txtbeginDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtbeginDate.Text))
                {
                    model.beginDate = DateTime.Parse(txtbeginDate.Text);
                }
            }

            if (txtendDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtendDate.Text))
                {
                    model.endDate = DateTime.Parse(txtendDate.Text);
                }
            }
            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加产品库信息:" + model.hdName); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            bool result = false;
           
            BLL.wx_product bll = new BLL.wx_product();
            Model.wx_product model = bll.GetModel(_id);
            string hdName = this.txtTitle.Text;
            string hdSubject = this.txtpSubject.Text;
            string hdAddr = this.txtaddr.Text;
            string hdContent = this.txtContent.Value;
            DateTime createTime = DateTime.Now;
            string tupian = txtImgUrl.Text;//封面图片
            decimal price = decimal.Parse(txtPrice.Text);
            bool showDate = chkShowDate.Checked;
            bool showPrice = chkShowPrice.Checked;
            bool showYuDing = chkShowYuDing.Checked;
            int seq = MyCommFun.Str2Int(txtSortId.Text);

            model.hdName = hdName;
            model.pSubject = hdSubject;

            model.addr = hdAddr;
            model.pContent = hdContent;
            model.extStr2 = tupian;
            model.btnName = txtAnNiuTxt.Text.Trim();
            model.typeId = MyCommFun.Str2Int(ddlCategoryId.SelectedItem.Value);
            model.price = price;
            model.showDate = showDate;
            model.showPrice = showPrice;
            model.showYuDing = showYuDing;
            model.extInt = seq;

            if (txtbeginDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtbeginDate.Text))
                {
                    model.beginDate = DateTime.Parse(txtbeginDate.Text);
                }
            }
            else
            {
                model.beginDate = null;
            }

            if (txtendDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtendDate.Text))
                {
                    model.endDate = DateTime.Parse(txtendDate.Text);
                }
            }
            else
            {
                model.endDate = null;
            }

            //model.wid = weixin.id;
            model.url = txtUrl.Text.Trim();

            if (bll.Update(model))
            {

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改产品库内容id:" + model.id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion


        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！";
            }
            if (this.txtpSubject.Text.Trim().Length == 0)
            {
                strErr += "主题不能为空！";
            }


            if (ddlCategoryId.Items.Count <= 0)
            {
                strErr += "请先添加类别！";
            }
            if (!(txtPrice.Text != "" && MyCommFun.isDecimal(txtPrice.Text)))
            {
                strErr += "价格的格式不正确！";
            }

            if (txtbeginDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtbeginDate.Text))
                {
                    
                }
                else
                {
                    strErr += "开始时间格式错误！";
                }
            }

            if (txtendDate.Text.Trim() != "")
            {
                if (MyCommFun.isDateTime(txtendDate.Text))
                {
                    
                }
                else
                {
                    strErr += "结束时间格式错误！";
                }
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }


            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("productlist", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "product_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("productlist", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "product_list.aspx", "Success");
            }
        }
    }
}