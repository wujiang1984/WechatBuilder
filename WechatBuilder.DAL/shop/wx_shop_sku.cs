using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using System.Collections.Generic;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_shop_sku
	/// </summary>
	public partial class wx_shop_sku
	{
		public wx_shop_sku()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_shop_sku"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_shop_sku");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WechatBuilder.Model.wx_shop_sku model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_shop_sku(");
			strSql.Append("productId,sku,stock,price,attributeValue,attributeId)");
			strSql.Append(" values (");
			strSql.Append("@productId,@sku,@stock,@price,@attributeValue,@attributeId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@sku", SqlDbType.VarChar,16),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@attributeValue", SqlDbType.VarChar,500),
					new SqlParameter("@attributeId", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.sku;
			parameters[2].Value = model.stock;
			parameters[3].Value = model.price;
			parameters[4].Value = model.attributeValue;
			parameters[5].Value = model.attributeId;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_shop_sku model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_shop_sku set ");
			strSql.Append("productId=@productId,");
			strSql.Append("sku=@sku,");
			strSql.Append("stock=@stock,");
			strSql.Append("price=@price,");
			strSql.Append("attributeValue=@attributeValue,");
			strSql.Append("attributeId=@attributeId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@sku", SqlDbType.VarChar,16),
					new SqlParameter("@stock", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@attributeValue", SqlDbType.VarChar,500),
					new SqlParameter("@attributeId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.sku;
			parameters[2].Value = model.stock;
			parameters[3].Value = model.price;
			parameters[4].Value = model.attributeValue;
			parameters[5].Value = model.attributeId;
			parameters[6].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_shop_sku ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_shop_sku ");
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
		public WechatBuilder.Model.wx_shop_sku GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,productId,sku,stock,price,attributeValue,attributeId,aName='' from wx_shop_sku ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_shop_sku model=new WechatBuilder.Model.wx_shop_sku();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WechatBuilder.Model.wx_shop_sku DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_shop_sku model=new WechatBuilder.Model.wx_shop_sku();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["productId"]!=null && row["productId"].ToString()!="")
				{
					model.productId=int.Parse(row["productId"].ToString());
				}
				if(row["sku"]!=null)
				{
					model.sku=row["sku"].ToString();
				}
				if(row["stock"]!=null && row["stock"].ToString()!="")
				{
					model.stock=int.Parse(row["stock"].ToString());
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["attributeValue"]!=null)
				{
					model.attributeValue=row["attributeValue"].ToString();
				}
				if(row["attributeId"]!=null && row["attributeId"].ToString()!="")
				{
					model.attributeId=int.Parse(row["attributeId"].ToString());
				}
                if (row["aName"] != null)
                {
                    model.attrName = row["aName"].ToString();
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
            strSql.Append("select id,productId,sku,stock,price,attributeValue,attributeId,aName='' ");
			strSql.Append(" FROM wx_shop_sku ");
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
            strSql.Append(" id,productId,sku,stock,price,attributeValue,attributeId,aName='' ");
			strSql.Append(" FROM wx_shop_sku ");
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
			strSql.Append("select count(1) FROM wx_shop_sku ");
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
			strSql.Append(")AS Row, T.*  from wx_shop_sku T ");
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
        /// 得到商品的配件列表
        /// </summary>
        public List<WechatBuilder.Model.wx_shop_sku> GetpSkuModelList(int productId)
        {
            List<WechatBuilder.Model.wx_shop_sku> pStuList = new List<Model.wx_shop_sku>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    v.id,v.productId,v.sku,v.stock,v.price,v.attributeValue,v.attributeId ,a.aName from wx_shop_sku v,wx_shop_catalog_attribute a where v.attributeId=a.id ");
            strSql.Append(" and  v.productId=@productId");
            SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.Int,4)
			};
            parameters[0].Value = productId;

            WechatBuilder.Model.wx_shop_sku model = new WechatBuilder.Model.wx_shop_sku();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = DataRowToModel(ds.Tables[0].Rows[i]);
                    pStuList.Add(model);
                }
            }

            return pStuList;
           
        }

		#endregion  ExtensionMethod
	}
}

