using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;
using WechatBuilder.BLL;
using System.Text;

namespace WechatBuilder.Web.shopmgr.product
{
    public partial class product_add : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_shop_catalog_attribute caBll = new wx_shop_catalog_attribute();
        public int catalogId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                  string frompage = MyCommFun.QueryString("frompage");
                  if (frompage != "")
                  {
                      litReturnPage.Text = "<a href=\"" + frompage + "\" class=\"back\"><i></i><span>返回</span></a>";
                  }
                TreeBind();
                bindCatalog();
            }
        }

        /// <summary>
        /// 绑定商品分类
        /// </summary>
        private void TreeBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            BLL.wx_shop_category bll = new BLL.wx_shop_category();
            DataTable dt = bll.GetWCodeList(weixin.id,0);

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

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


        /// <summary>
        /// 绑定商品类型
        /// </summary>
        private void bindCatalog()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            BLL.wx_shop_catalog cataBll = new wx_shop_catalog();
            IList<Model.wx_shop_catalog> cataList = cataBll.GetModelList("wid=" + weixin.id);
            ddlCatalog.DataTextField = "cTitle";
            ddlCatalog.DataValueField = "id";
            ddlCatalog.DataSource = cataList;
            ddlCatalog.DataBind();
            ddlCatalog.Items.Insert(0, new ListItem("请选择商品类型", "0"));

        }


       /// <summary>
       /// 商品录入
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string[] txtattr = Request.Form.GetValues("txtattr");
            //string[] ddlattr = Request.Form.GetValues("ddlattr");

            #region 商品基本信息
            string strErr = "";
              
            if (this.txtproductName.Text.Trim().Length == 0)
            {
                strErr += "商品名称不能为空！\\n";
            }
             
            if (!MyCommFun.isDecimal(txtcostPrice.Text))
            {
                strErr += "成本格式错误！\\n";
            }
            if (!MyCommFun.isDecimal(txtmarketPrice.Text))
            {
                strErr += "市场价格式错误！\\n";
            }
            if (!MyCommFun.isDecimal(txtsalePrice.Text))
            {
                strErr += "销售价格式错误！\\n";
            }
            if (!MyCommFun.isNumber(txtstock.Text))
            {
                strErr += "库存格式错误！\\n";
            }

            if (!MyCommFun.isNumber(txtsort_id.Text))
            {
                strErr += "排序号格式错误！\\n";
            }
              

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            Model.wx_userweixin weixin = GetWeiXinCode();


            int wid = weixin.id;
            int categoryId = int.Parse(this.ddlCategoryId.SelectedItem.Value);
            int catalogId = int.Parse(this.ddlCatalog.SelectedItem.Value);
            int brandId = 0;
            string sku = this.txtsku.Text;//货号
            if (sku.Trim() == "")
            {
                sku = Utils.Number(8, true);
            }
            string productName = this.txtproductName.Text;
            string shortDesc = this.txtshortDesc.Text;
            string unit = "";
            decimal weight = 0;
            string description = this.txtdescription.Value;
            //string seo_title = this.txtseo_title.Text;
            //string seo_keywords = this.txtseo_keywords.Text;
            //string seo_description = this.txtseo_description.Text;
            //string focusImgUrl = this.txtfocusImgUrl.Text;
            //string thumbnailsUrll = this.txtthumbnailsUrll.Text;

            bool recommended = false;
            bool latest = false;
            bool hotsale = false;
            bool specialOffer = false;

            int count=cblActionType.Items.Count;
            
            for (int i = 0; i < count; i++)
            {
                if (cblActionType.Items[i].Selected)
                {
                    if (cblActionType.Items[i].Value == "latest")
                    {
                        latest = true;
                    }
                    else if (cblActionType.Items[i].Value == "hotsale")
                    {
                        hotsale = true;
                    }
                    else if (cblActionType.Items[i].Value == "recommended")
                    {
                        recommended = true;
                    }
                    else if (cblActionType.Items[i].Value == "specialOffer")
                    {
                        specialOffer = true;
                    }
                }
            }

            decimal costPrice = decimal.Parse(this.txtcostPrice.Text);
            decimal marketPrice = decimal.Parse(this.txtmarketPrice.Text);
            decimal salePrice = decimal.Parse(this.txtsalePrice.Text);

            bool upselling = true;//上架
            if (radType.SelectedItem.Value == "2")
            {
                upselling = false;
            }
            int stock = int.Parse(this.txtstock.Text);
            DateTime addDate = DateTime.Now;
            int vistiCounts = 0;
            int sort_id = int.Parse(this.txtsort_id.Text);
            //DateTime productionDate = DateTime.Parse(this.txtproductionDate.Text);
            //DateTime ExpiryEndDate = DateTime.Parse(this.txtExpiryEndDate.Text);
            DateTime updateDate = DateTime.Now;

            WechatBuilder.Model.wx_shop_product model = new WechatBuilder.Model.wx_shop_product();
            model.wid = wid;
            model.categoryId = categoryId;
            model.brandId = brandId;
            model.sku = sku;
            model.productName = productName;
            model.shortDesc = shortDesc;
            model.unit = unit;
            model.weight = weight;
            model.description = description;
            //model.seo_title = seo_title;
            //model.seo_keywords = seo_keywords;
            //model.seo_description = seo_description;
            //model.focusImgUrl = focusImgUrl;
            //model.thumbnailsUrll = thumbnailsUrll;
            model.recommended = recommended;
            model.latest = latest;
            model.hotsale = hotsale;
            model.specialOffer = specialOffer;
            model.costPrice = costPrice;
            model.marketPrice = marketPrice;
            model.salePrice = salePrice;
            model.upselling = upselling;
            model.stock = stock;
            model.addDate = addDate;
            model.vistiCounts = vistiCounts;
            model.sort_id = sort_id;
            //model.productionDate = productionDate;
            //model.ExpiryEndDate = ExpiryEndDate;
            model.updateDate = updateDate;
            model.catalogId = catalogId;
            #endregion

            #region 保存相册====================
            //检查是否有自定义图片
            
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Model.wx_shop_albums> ls = new List<Model.wx_shop_albums>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.wx_shop_albums { original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.wx_shop_albums { original_path = imgArr[1], thumb_path = imgArr[2] });
                        }
                    }
                }
                model.albums = ls;
            }
            #endregion

            //属性和sku配件列表
            model.attrs = AddAttr();
            model.skulist = AddSku();
            

            WechatBuilder.BLL.wx_shop_product bll = new WechatBuilder.BLL.wx_shop_product();
           int id= bll.Add(model);
            AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加商品信息，商品信息主键id:" + id); //记录日志

            string frompage = MyCommFun.QueryString("frompage");
            if (frompage == "")
            {
                JscriptMsg("***商品录入成功,请继续录入***！", "product_add.aspx", "Success");
            }
            else
            {
                JscriptMsg("***商品录入成功***！", frompage, "Success");
            }
        }

        /// <summary>
        /// 商品类型选择以后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catalogId =MyCommFun.Str2Int(this.ddlCatalog.SelectedItem.Value); //商品类型id
            BLL.wx_shop_catalog_attribute caBll=new wx_shop_catalog_attribute();
            IList<Model.wx_shop_catalog_attribute> attrlist = caBll.GetModelList("catalogId="+catalogId+" order by sort_id asc");
            if (attrlist == null || attrlist.Count <= 0)
            {
                return;
            }
            Model.wx_shop_catalog_attribute attr = new Model.wx_shop_catalog_attribute();
            StringBuilder attrStr = new StringBuilder();
            for (int i = 0; i < attrlist.Count; i++)
            {
                attr = attrlist[i];
                if (attr.aType.Value == 1)
                {  //供客户查看
                    attrStr.Append("<dl>");
                    attrStr.Append(" <dt>"+attr.aName+"</dt>");
                    attrStr.Append("<dd>");
                    if (attr.aValue == null || attr.aValue.Trim() == "")
                    {
                        attrStr.Append("<input name=\"txtattr\" type=\"text\" id=\"extattr_" + attr.id + "\" attrid=\"" + attr.id + "\" class=\"input normal txt_attr \" datatype=\"*0-200\" sucmsg=\" \" nullmsg=\" \">");

                    }
                    else
                    {
                        //下拉菜单
                        string[] attrvalueArr =Utils.SplitString(attr.aValue,"\r\n");
                        if (attrvalueArr != null && attrvalueArr.Length > 0)
                        {
                            attrStr.Append("<select name=\"ddlattr\" id=\"extattr_" + attr.id + "\" attrid=\"" + attr.id + "\"  class=\"txt_attr\">");
                            attrStr.Append("<option value=\"\">请选择...</option>");
                            for (int j= 0; j < attrvalueArr.Length; j++)
                            {
                                attrStr.Append("<option value=\"" + attrvalueArr[j] + "\">" + attrvalueArr[j] + "</option>");
                            }
                            attrStr.Append("</select>");
                        }
                        attrStr.Append("");
                    }
                    attrStr.Append("</dd>");
                    attrStr.Append("</dl>");
                }
                else if (attr.aType.Value == 2)
                { //客户可选规格,SKU
                    if (attr.aValue == null || attr.aValue.Trim() == "")
                    {
                    }
                    else
                    {
                        attrStr.Append("<dl>");
                        attrStr.Append(" <dt>" + attr.aName + "</dt>");
                        attrStr.Append("<dd>");
                          string[] attrvalueArr =Utils.SplitString(attr.aValue,"\r\n");
                          if (attrvalueArr != null && attrvalueArr.Length > 0)
                          {

                              attrStr.Append(" <table class=\"ltable tb_sku\">  <thead> <tr> <th width=\"80\"> 使用 </th> <th> 名称  </th> <th width=\"120\">  属性加价格 </th> </tr></thead>");
                              attrStr.Append("<tbody class=\"ltbody\">");
                              for (int j = 0; j < attrvalueArr.Length; j++)
                              {
                                  attrStr.Append(" <tr class=\"td_c\">");
                                  attrStr.Append(" <td><input id=\"chk_skuvalue_" + j + "\" type=\"checkbox\" attrid=\"" + attr.id + "\" class=\"skuchk\"   /></td>");
                                  attrStr.Append(" <td> <label for=\"chk_skuvalue_" + j + "\" class=\"skuattrName\">" + attrvalueArr[j] + "</label> </td>");

                                  attrStr.Append("<td>");
                                  attrStr.Append("<input name=\"txtaddvalue\" type=\"text\"   id=\"txtaddvalue" + attrvalueArr[j] + "\" value=\"0\" class=\"input small skuvaddmenoy\" datatype=\"*0-10\" sucmsg=\" \">");
                                  attrStr.Append("</td>");
                                  attrStr.Append("</tr>");
                              }

                              attrStr.Append(" </tbody> </table>");
                             
                          }
                          attrStr.Append("</dd>");
                        attrStr.Append("</dl>");

                    }
                    


                }
            }//big for

            litAttr.Text = attrStr.ToString();

        }//end:function

        /// <summary>
        /// 获得商品的属性以及值
        /// </summary>
        /// <returns></returns>
        private  List<Model.wx_shop_productAttr_value> AddAttr()
        {
             List<Model.wx_shop_productAttr_value> attrvlist = new List<Model.wx_shop_productAttr_value>();

            string attrStr = hidAttrValueStr.Value;
            if (attrStr == null || attrStr.Trim() == "")
            {
                return null;
            }
            string[] attrStrArr = Utils.SplitString(attrStr, "||");
            string[] tmpattrValue;
            Model.wx_shop_productAttr_value attrEntity = new Model.wx_shop_productAttr_value();
            foreach (string attr in attrStrArr)
            {
                if (attr.Length <= 0)
                {
                    continue;
                }
                tmpattrValue = Utils.SplitString(attr,"_");
                if (tmpattrValue != null && tmpattrValue.Length>0)
                {
                    attrEntity = new Model.wx_shop_productAttr_value();
                    attrEntity.attributeId =MyCommFun.Str2Int(tmpattrValue[1]);
                    attrEntity.paValue = MyCommFun.ObjToStr(tmpattrValue[3]);
                    attrvlist.Add(attrEntity);
                }
            }

            return attrvlist;
        }


        /// <summary>
        /// 商品的sku库存信息
        /// </summary>
        /// <returns></returns>
        private  List<Model.wx_shop_sku> AddSku()
        {
             List<Model.wx_shop_sku> skulist = new List<Model.wx_shop_sku>();

             string attrStr = hidSkuVauleStr.Value;
            if (attrStr == null || attrStr.Trim() == "")
            {
                return null;
            }
            string[] attrStrArr = Utils.SplitString(attrStr, "||");
            string[] tmpattrValue;
            Model.wx_shop_sku attrEntity = new Model.wx_shop_sku();
            foreach (string attr in attrStrArr)
            {
                if (attr.Length <= 0)
                {
                    continue;
                }
                tmpattrValue = Utils.SplitString(attr, "_");
                if (tmpattrValue != null && tmpattrValue.Length > 0)
                {
                    attrEntity = new Model.wx_shop_sku();
                    attrEntity.attributeId = MyCommFun.Str2Int(tmpattrValue[1]);
                    attrEntity.price = MyCommFun.Str2Int(tmpattrValue[3]);
                    attrEntity.attributeValue = MyCommFun.ObjToStr(tmpattrValue[5]);
                    skulist.Add(attrEntity);
                }
            }

            return skulist;
        }

        
    }//end class
}