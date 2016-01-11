using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using System.Collections.Generic;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_shop_product
	/// </summary>
	public partial class wx_shop_product
	{
		public wx_shop_product()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_shop_product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_shop_product");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

	

		 
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_shop_product ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WechatBuilder.Model.wx_shop_product DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_shop_product model=new WechatBuilder.Model.wx_shop_product();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["categoryId"]!=null && row["categoryId"].ToString()!="")
				{
					model.categoryId=int.Parse(row["categoryId"].ToString());
				}
				if(row["brandId"]!=null && row["brandId"].ToString()!="")
				{
					model.brandId=int.Parse(row["brandId"].ToString());
				}
				if(row["sku"]!=null)
				{
					model.sku=row["sku"].ToString();
				}
				if(row["productName"]!=null)
				{
					model.productName=row["productName"].ToString();
				}
				if(row["shortDesc"]!=null)
				{
					model.shortDesc=row["shortDesc"].ToString();
				}
				if(row["unit"]!=null)
				{
					model.unit=row["unit"].ToString();
				}
				if(row["weight"]!=null && row["weight"].ToString()!="")
				{
					model.weight=decimal.Parse(row["weight"].ToString());
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
				}
				if(row["seo_title"]!=null)
				{
					model.seo_title=row["seo_title"].ToString();
				}
				if(row["seo_keywords"]!=null)
				{
					model.seo_keywords=row["seo_keywords"].ToString();
				}
				if(row["seo_description"]!=null)
				{
					model.seo_description=row["seo_description"].ToString();
				}
				if(row["focusImgUrl"]!=null)
				{
					model.focusImgUrl=row["focusImgUrl"].ToString();
				}
				if(row["thumbnailsUrll"]!=null)
				{
					model.thumbnailsUrll=row["thumbnailsUrll"].ToString();
				}
				if(row["recommended"]!=null && row["recommended"].ToString()!="")
				{
					if((row["recommended"].ToString()=="1")||(row["recommended"].ToString().ToLower()=="true"))
					{
						model.recommended=true;
					}
					else
					{
						model.recommended=false;
					}
				}
				if(row["latest"]!=null && row["latest"].ToString()!="")
				{
					if((row["latest"].ToString()=="1")||(row["latest"].ToString().ToLower()=="true"))
					{
						model.latest=true;
					}
					else
					{
						model.latest=false;
					}
				}
				if(row["hotsale"]!=null && row["hotsale"].ToString()!="")
				{
					if((row["hotsale"].ToString()=="1")||(row["hotsale"].ToString().ToLower()=="true"))
					{
						model.hotsale=true;
					}
					else
					{
						model.hotsale=false;
					}
				}
				if(row["specialOffer"]!=null && row["specialOffer"].ToString()!="")
				{
					if((row["specialOffer"].ToString()=="1")||(row["specialOffer"].ToString().ToLower()=="true"))
					{
						model.specialOffer=true;
					}
					else
					{
						model.specialOffer=false;
					}
				}
				if(row["costPrice"]!=null && row["costPrice"].ToString()!="")
				{
					model.costPrice=decimal.Parse(row["costPrice"].ToString());
				}
				if(row["marketPrice"]!=null && row["marketPrice"].ToString()!="")
				{
					model.marketPrice=decimal.Parse(row["marketPrice"].ToString());
				}
				if(row["salePrice"]!=null && row["salePrice"].ToString()!="")
				{
					model.salePrice=decimal.Parse(row["salePrice"].ToString());
				}
				if(row["upselling"]!=null && row["upselling"].ToString()!="")
				{
					if((row["upselling"].ToString()=="1")||(row["upselling"].ToString().ToLower()=="true"))
					{
						model.upselling=true;
					}
					else
					{
						model.upselling=false;
					}
				}
				if(row["stock"]!=null && row["stock"].ToString()!="")
				{
					model.stock=int.Parse(row["stock"].ToString());
				}
				if(row["addDate"]!=null && row["addDate"].ToString()!="")
				{
					model.addDate=DateTime.Parse(row["addDate"].ToString());
				}
				if(row["vistiCounts"]!=null && row["vistiCounts"].ToString()!="")
				{
					model.vistiCounts=int.Parse(row["vistiCounts"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["productionDate"]!=null && row["productionDate"].ToString()!="")
				{
					model.productionDate=DateTime.Parse(row["productionDate"].ToString());
				}
				if(row["ExpiryEndDate"]!=null && row["ExpiryEndDate"].ToString()!="")
				{
					model.ExpiryEndDate=DateTime.Parse(row["ExpiryEndDate"].ToString());
				}
				if(row["updateDate"]!=null && row["updateDate"].ToString()!="")
				{
					model.updateDate=DateTime.Parse(row["updateDate"].ToString());
				}

                if (row["catalogId"] != null && row["catalogId"].ToString() != "")
                {
                    model.catalogId = int.Parse(row["catalogId"].ToString());
                }

			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,wid,categoryId,brandId,sku,productName,shortDesc,unit,weight,description,seo_title,seo_keywords,seo_description,focusImgUrl,thumbnailsUrll,recommended,latest,hotsale,specialOffer,costPrice,marketPrice,salePrice,upselling,stock,addDate,vistiCounts,sort_id,productionDate,ExpiryEndDate,updateDate,catalogId ");
			strSql.Append(" FROM wx_shop_product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" id,wid,categoryId,brandId,sku,productName,shortDesc,unit,weight,description,seo_title,seo_keywords,seo_description,focusImgUrl,thumbnailsUrll,recommended,latest,hotsale,specialOffer,costPrice,marketPrice,salePrice,upselling,stock,addDate,vistiCounts,sort_id,productionDate,ExpiryEndDate,updateDate,catalogId ");
			strSql.Append(" FROM wx_shop_product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wx_shop_product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_shop_product T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		 

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WechatBuilder.Model.wx_shop_product GetModel(int id)
        {
            Model.wx_shop_product product = new Model.wx_shop_product();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,categoryId,brandId,sku,productName,shortDesc,unit,weight,description,seo_title,seo_keywords,seo_description,focusImgUrl,thumbnailsUrll,recommended,latest,hotsale,specialOffer,costPrice,marketPrice,salePrice,upselling,stock,addDate,vistiCounts,sort_id,productionDate,ExpiryEndDate,updateDate,catalogId from wx_shop_product ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_shop_product model = new WechatBuilder.Model.wx_shop_product();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                product= DataRowToModel(ds.Tables[0].Rows[0]);
            }
           

            return product;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.wx_shop_product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_shop_product(");
            strSql.Append("wid,categoryId,brandId,sku,productName,shortDesc,unit,weight,description,seo_title,seo_keywords,seo_description,focusImgUrl,thumbnailsUrll,recommended,latest,hotsale,specialOffer,costPrice,marketPrice,salePrice,upselling,stock,addDate,vistiCounts,sort_id,productionDate,ExpiryEndDate,updateDate,catalogId)");
            strSql.Append(" values (");
            strSql.Append("@wid,@categoryId,@brandId,@sku,@productName,@shortDesc,@unit,@weight,@description,@seo_title,@seo_keywords,@seo_description,@focusImgUrl,@thumbnailsUrll,@recommended,@latest,@hotsale,@specialOffer,@costPrice,@marketPrice,@salePrice,@upselling,@stock,@addDate,@vistiCounts,@sort_id,@productionDate,@ExpiryEndDate,@updateDate,@catalogId)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@categoryId", SqlDbType.Int,4),
					new SqlParameter("@brandId", SqlDbType.Int,4),
					new SqlParameter("@sku", SqlDbType.VarChar,20),
					new SqlParameter("@productName", SqlDbType.VarChar,500),
					new SqlParameter("@shortDesc", SqlDbType.VarChar,500),
					new SqlParameter("@unit", SqlDbType.VarChar,10),
					new SqlParameter("@weight", SqlDbType.Float,8),
					new SqlParameter("@description", SqlDbType.VarChar,2000),
					new SqlParameter("@seo_title", SqlDbType.VarChar,200),
					new SqlParameter("@seo_keywords", SqlDbType.VarChar,300),
					new SqlParameter("@seo_description", SqlDbType.VarChar,500),
					new SqlParameter("@focusImgUrl", SqlDbType.VarChar,800),
					new SqlParameter("@thumbnailsUrll", SqlDbType.VarChar,800),
					new SqlParameter("@recommended", SqlDbType.Bit,1),
					new SqlParameter("@latest", SqlDbType.Bit,1),
					new SqlParameter("@hotsale", SqlDbType.Bit,1),
					new SqlParameter("@specialOffer", SqlDbType.Bit,1),
					new SqlParameter("@costPrice", SqlDbType.Float,8),
					new SqlParameter("@marketPrice", SqlDbType.Float,8),
					new SqlParameter("@salePrice", SqlDbType.Float,8),
					new SqlParameter("@upselling", SqlDbType.Bit,1),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@addDate", SqlDbType.DateTime),
					new SqlParameter("@vistiCounts", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@productionDate", SqlDbType.DateTime),
					new SqlParameter("@ExpiryEndDate", SqlDbType.DateTime),
					new SqlParameter("@updateDate", SqlDbType.DateTime), 
                    new SqlParameter("@catalogId", SqlDbType.Int,4),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.categoryId;
            parameters[2].Value = model.brandId;
            parameters[3].Value = model.sku;
            parameters[4].Value = model.productName;
            parameters[5].Value = model.shortDesc;
            parameters[6].Value = model.unit;
            parameters[7].Value = model.weight;
            parameters[8].Value = model.description;
            parameters[9].Value = model.seo_title;
            parameters[10].Value = model.seo_keywords;
            parameters[11].Value = model.seo_description;
            parameters[12].Value = model.focusImgUrl;
            parameters[13].Value = model.thumbnailsUrll;
            parameters[14].Value = model.recommended;
            parameters[15].Value = model.latest;
            parameters[16].Value = model.hotsale;
            parameters[17].Value = model.specialOffer;
            parameters[18].Value = model.costPrice;
            parameters[19].Value = model.marketPrice;
            parameters[20].Value = model.salePrice;
            parameters[21].Value = model.upselling;
            parameters[22].Value = model.stock;
            parameters[23].Value = model.addDate;
            parameters[24].Value = model.vistiCounts;
            parameters[25].Value = model.sort_id;
            parameters[26].Value = model.productionDate;
            parameters[27].Value = model.ExpiryEndDate;
            parameters[28].Value = model.updateDate;
            parameters[29].Value = model.catalogId;
            parameters[30].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);


            #region  //图片相册
            if (model.albums != null)
            {
                StringBuilder strSql2;
                foreach (Model.wx_shop_albums modelt in model.albums)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into  wx_shop_albums(");
                    strSql2.Append("productId,thumb_path,original_path,remark)");
                    strSql2.Append(" values (");
                    strSql2.Append("@productId,@thumb_path,@original_path,@remark)");
                    SqlParameter[] parameters2 = {
					    new SqlParameter("@productId", SqlDbType.Int,4),
					    new SqlParameter("@thumb_path", SqlDbType.NVarChar,255),
					    new SqlParameter("@original_path", SqlDbType.NVarChar,255),
					    new SqlParameter("@remark", SqlDbType.NVarChar,500)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = modelt.thumb_path;
                    parameters2[2].Value = modelt.original_path;
                    parameters2[3].Value = modelt.remark;
                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }
            #endregion

            #region  //商品属性
            if (model.attrs != null)
            {
                StringBuilder strSql3;
                foreach (Model.wx_shop_productAttr_value modelt in model.attrs)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into  wx_shop_productAttr_value(");
                    strSql3.Append("productId,attributeId,paValue)");
                    strSql3.Append(" values (");
                    strSql3.Append("@productId,@attributeId,@paValue)");
                    SqlParameter[] parameters3= {
					    new SqlParameter("@productId", SqlDbType.Int,4),
					    new SqlParameter("@attributeId", SqlDbType.Int,4),
					    new SqlParameter("@paValue", SqlDbType.NVarChar,300)};
                    parameters3[0].Direction = ParameterDirection.InputOutput;
                    parameters3[1].Value = modelt.attributeId;
                    parameters3[2].Value = modelt.paValue;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }
            #endregion

            #region  //商品配件sku|规格
            if (model.skulist != null)
            {
                StringBuilder strSql4;
                foreach (Model.wx_shop_sku modelt in model.skulist)
                {
                    strSql4 = new StringBuilder();
                    strSql4.Append("insert into  wx_shop_sku(");
                    strSql4.Append("productId,attributeId,attributeValue,price)");
                    strSql4.Append(" values (");
                    strSql4.Append("@productId,@attributeId,@attributeValue,@price)");
                    SqlParameter[] parameters4 = {
					    new SqlParameter("@productId", SqlDbType.Int,4),
					    new SqlParameter("@attributeId", SqlDbType.Int,4),
					    new SqlParameter("@attributeValue", SqlDbType.NVarChar,300),
                        new SqlParameter("@price", SqlDbType.Float,10),
                                                 };
                    parameters4[0].Direction = ParameterDirection.InputOutput;
                    parameters4[1].Value = modelt.attributeId;
                    parameters4[2].Value = modelt.attributeValue;
                    parameters4[3].Value = modelt.price;
                    cmd = new CommandInfo(strSql4.ToString(), parameters4);
                    sqllist.Add(cmd);
                }
            }
            #endregion



            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[30].Value;


        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WechatBuilder.Model.wx_shop_product model)
        {

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {

                        #region 修改商品的主表

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update wx_shop_product set ");
                        strSql.Append("wid=@wid,");
                        strSql.Append("categoryId=@categoryId,");
                        strSql.Append("brandId=@brandId,");
                        strSql.Append("sku=@sku,");
                        strSql.Append("productName=@productName,");
                        strSql.Append("shortDesc=@shortDesc,");
                        strSql.Append("unit=@unit,");
                        strSql.Append("weight=@weight,");
                        strSql.Append("description=@description,");
                        strSql.Append("seo_title=@seo_title,");
                        strSql.Append("seo_keywords=@seo_keywords,");
                        strSql.Append("seo_description=@seo_description,");
                        strSql.Append("focusImgUrl=@focusImgUrl,");
                        strSql.Append("thumbnailsUrll=@thumbnailsUrll,");
                        strSql.Append("recommended=@recommended,");
                        strSql.Append("latest=@latest,");
                        strSql.Append("hotsale=@hotsale,");
                        strSql.Append("specialOffer=@specialOffer,");
                        strSql.Append("costPrice=@costPrice,");
                        strSql.Append("marketPrice=@marketPrice,");
                        strSql.Append("salePrice=@salePrice,");
                        strSql.Append("upselling=@upselling,");
                        strSql.Append("stock=@stock,");
                        strSql.Append("addDate=@addDate,");
                        strSql.Append("vistiCounts=@vistiCounts,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("productionDate=@productionDate,");
                        strSql.Append("ExpiryEndDate=@ExpiryEndDate,");
                        strSql.Append("updateDate=@updateDate,");
                        strSql.Append("catalogId=@catalogId");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@categoryId", SqlDbType.Int,4),
					new SqlParameter("@brandId", SqlDbType.Int,4),
					new SqlParameter("@sku", SqlDbType.VarChar,20),
					new SqlParameter("@productName", SqlDbType.VarChar,500),
					new SqlParameter("@shortDesc", SqlDbType.VarChar,500),
					new SqlParameter("@unit", SqlDbType.VarChar,10),
					new SqlParameter("@weight", SqlDbType.Float,8),
					new SqlParameter("@description", SqlDbType.VarChar,2000),
					new SqlParameter("@seo_title", SqlDbType.VarChar,200),
					new SqlParameter("@seo_keywords", SqlDbType.VarChar,300),
					new SqlParameter("@seo_description", SqlDbType.VarChar,500),
					new SqlParameter("@focusImgUrl", SqlDbType.VarChar,800),
					new SqlParameter("@thumbnailsUrll", SqlDbType.VarChar,800),
					new SqlParameter("@recommended", SqlDbType.Bit,1),
					new SqlParameter("@latest", SqlDbType.Bit,1),
					new SqlParameter("@hotsale", SqlDbType.Bit,1),
					new SqlParameter("@specialOffer", SqlDbType.Bit,1),
					new SqlParameter("@costPrice", SqlDbType.Float,8),
					new SqlParameter("@marketPrice", SqlDbType.Float,8),
					new SqlParameter("@salePrice", SqlDbType.Float,8),
					new SqlParameter("@upselling", SqlDbType.Bit,1),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@addDate", SqlDbType.DateTime),
					new SqlParameter("@vistiCounts", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@productionDate", SqlDbType.DateTime),
					new SqlParameter("@ExpiryEndDate", SqlDbType.DateTime),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@catalogId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.wid;
                        parameters[1].Value = model.categoryId;
                        parameters[2].Value = model.brandId;
                        parameters[3].Value = model.sku;
                        parameters[4].Value = model.productName;
                        parameters[5].Value = model.shortDesc;
                        parameters[6].Value = model.unit;
                        parameters[7].Value = model.weight;
                        parameters[8].Value = model.description;
                        parameters[9].Value = model.seo_title;
                        parameters[10].Value = model.seo_keywords;
                        parameters[11].Value = model.seo_description;
                        parameters[12].Value = model.focusImgUrl;
                        parameters[13].Value = model.thumbnailsUrll;
                        parameters[14].Value = model.recommended;
                        parameters[15].Value = model.latest;
                        parameters[16].Value = model.hotsale;
                        parameters[17].Value = model.specialOffer;
                        parameters[18].Value = model.costPrice;
                        parameters[19].Value = model.marketPrice;
                        parameters[20].Value = model.salePrice;
                        parameters[21].Value = model.upselling;
                        parameters[22].Value = model.stock;
                        parameters[23].Value = model.addDate;
                        parameters[24].Value = model.vistiCounts;
                        parameters[25].Value = model.sort_id;
                        parameters[26].Value = model.productionDate;
                        parameters[27].Value = model.ExpiryEndDate;
                        parameters[28].Value = model.updateDate;
                        parameters[29].Value = model.catalogId;
                        parameters[30].Value = model.id;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        #endregion

                        #region  //添加/修改相册
                        new wx_shop_albums().DeleteList(conn, trans, model.albums, model.id);
                        if (model.albums != null)
                        {
                            StringBuilder strSql3;
                            foreach (Model.wx_shop_albums modelt in model.albums)
                            {
                                strSql3 = new StringBuilder();
                                if (modelt.id > 0)
                                {
                                    strSql3.Append("update  wx_shop_albums set ");
                                    strSql3.Append("productId=@productId,");
                                    strSql3.Append("thumb_path=@thumb_path,");
                                    strSql3.Append("original_path=@original_path,");
                                    strSql3.Append("remark=@remark");
                                    strSql3.Append(" where id=@id");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@productId", SqlDbType.Int,4),
					                        new SqlParameter("@thumb_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@original_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@remark", SqlDbType.NVarChar,500),
                                            new SqlParameter("@id", SqlDbType.Int,4)};
                                    parameters3[0].Value = modelt.productId;
                                    parameters3[1].Value = modelt.thumb_path;
                                    parameters3[2].Value = modelt.original_path;
                                    parameters3[3].Value = modelt.remark;
                                    parameters3[4].Value = modelt.id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                                else
                                {
                                    strSql3.Append("insert into wx_shop_albums(");
                                    strSql3.Append("productId,thumb_path,original_path,remark)");
                                    strSql3.Append(" values (");
                                    strSql3.Append("@productId,@thumb_path,@original_path,@remark)");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@productId", SqlDbType.Int,4),
					                        new SqlParameter("@thumb_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@original_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@remark", SqlDbType.NVarChar,500)};
                                    parameters3[0].Value = modelt.productId;
                                    parameters3[1].Value = modelt.thumb_path;
                                    parameters3[2].Value = modelt.original_path;
                                    parameters3[3].Value = modelt.remark;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                            }
                        }
                        #endregion


                        //删除原来的属性和配件
                        StringBuilder strDeleteSql = new StringBuilder();
                        strDeleteSql.Append("delete from wx_shop_productAttr_value where productId=@productId;");
                        strDeleteSql.Append("delete from wx_shop_sku where productId=productId");
                        SqlParameter[] parameters4 = {
				        	new SqlParameter("@productId", SqlDbType.Int,4)
		            	};
                        parameters4[0].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strDeleteSql.ToString(), parameters4);

                        
                   
                        #region  //添加新属性
                        if (model.attrs != null)
                        {
                            StringBuilder strSql5;
                            foreach (Model.wx_shop_productAttr_value modelt in model.attrs)
                            {
                                strSql5 = new StringBuilder();
                                strSql5.Append("insert into  wx_shop_productAttr_value(");
                                strSql5.Append("productId,attributeId,paValue)");
                                strSql5.Append(" values (");
                                strSql5.Append("@productId,@attributeId,@paValue)");
                                SqlParameter[] parameters5 = {
					            new SqlParameter("@productId", SqlDbType.Int,4),
					            new SqlParameter("@attributeId", SqlDbType.Int,4),
					            new SqlParameter("@paValue", SqlDbType.NVarChar,300)};
                                parameters5[0].Value = model.id;
                                parameters5[1].Value = modelt.attributeId;
                                parameters5[2].Value = modelt.paValue;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql5.ToString(), parameters5);
                            }
                        }
                        #endregion

                        #region  //添加商品配件sku|规格
                        if (model.skulist != null)
                        {
                            StringBuilder strSql6;
                            foreach (Model.wx_shop_sku modelt in model.skulist)
                            {
                                strSql6 = new StringBuilder();
                                strSql6.Append("insert into  wx_shop_sku(");
                                strSql6.Append("productId,attributeId,attributeValue,price)");
                                strSql6.Append(" values (");
                                strSql6.Append("@productId,@attributeId,@attributeValue,@price)");
                                SqlParameter[] parameters6 = {
					    new SqlParameter("@productId", SqlDbType.Int,4),
					    new SqlParameter("@attributeId", SqlDbType.Int,4),
					    new SqlParameter("@attributeValue", SqlDbType.NVarChar,300),
                        new SqlParameter("@price", SqlDbType.Float,10),
                                                 };
                                parameters6[0].Value =model.id;
                                parameters6[1].Value = modelt.attributeId;
                                parameters6[2].Value = modelt.attributeValue;
                                parameters6[3].Value = modelt.price;

                                DbHelperSQL.ExecuteSql(conn, trans, strSql6.ToString(), parameters6);
                            }
                        }
                        #endregion


                        trans.Commit();

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;

        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            
            //删除商品的属性值
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from wx_shop_productAttr_value ");
            strSql1.Append(" where productId=@productId ");
            SqlParameter[] parameters1 = {
					new SqlParameter("@productId", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

            //删除商品配件
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from wx_shop_sku ");
            strSql2.Append(" where productId=@productId ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@productId", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //删除图片相册
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from wx_shop_albums ");
            strSql3.Append(" where productId=@productId ");
            SqlParameter[] parameters3 = {
                    new SqlParameter("@productId", SqlDbType.Int,4)};
            parameters3[0].Value = id;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            ////删除会员组价格
            //StringBuilder strSql4 = new StringBuilder();
            //strSql4.Append("delete from " + databaseprefix + "user_group_price ");
            //strSql4.Append(" where article_id=@article_id ");
            //SqlParameter[] parameters4 = {
            //        new SqlParameter("@article_id", SqlDbType.Int,4)};
            //parameters4[0].Value = id;
            //cmd = new CommandInfo(strSql4.ToString(), parameters4);
            //sqllist.Add(cmd);

            //删除评论
            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("delete from wx_shop_comment ");
            strSql5.Append(" where productId=@productId ");
            SqlParameter[] parameters5 = {
					new SqlParameter("@productId", SqlDbType.Int,4)};
            parameters5[0].Value = id;
            cmd = new CommandInfo(strSql5.ToString(), parameters5);
            sqllist.Add(cmd);


            //删除购物车
            StringBuilder strSql6 = new StringBuilder();
            strSql6.Append("delete from wx_shop_cart ");
            strSql6.Append(" where productId=@productId ");
            SqlParameter[] parameters6= {
					new SqlParameter("@productId", SqlDbType.Int,4)};
            parameters6[0].Value = id;
            cmd = new CommandInfo(strSql6.ToString(), parameters6);
            sqllist.Add(cmd);


            //删除主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_shop_product ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_shop_product set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int wid,  int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  link_url='',(select top 1 original_path from dbo.wx_shop_albums where  productId=p.id) as productpic,* from wx_shop_product p ");
            strSql.Append(" where  wid=" + wid);
            if (category_id > 0)
            {
                strSql.Append(" and categoryId in(select id from  wx_shop_category where class_list like '%," + category_id + ",%')");
                 
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        


		#endregion  ExtensionMethod
	}
}

