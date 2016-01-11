using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_shop_cart
	/// </summary>
	public partial class wx_shop_cart
	{
		public wx_shop_cart()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_shop_cart"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_shop_cart");
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
		public int Add(WechatBuilder.Model.wx_shop_cart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_shop_cart(");
			strSql.Append("openid,wid,productId,skuId,skuInfo,totPrice,productNum,createDate)");
			strSql.Append(" values (");
			strSql.Append("@openid,@wid,@productId,@skuId,@skuInfo,@totPrice,@productNum,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@skuId", SqlDbType.Int,4),
					new SqlParameter("@skuInfo", SqlDbType.VarChar,500),
					new SqlParameter("@totPrice", SqlDbType.Float,8),
					new SqlParameter("@productNum", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.openid;
			parameters[1].Value = model.wid;
			parameters[2].Value = model.productId;
			parameters[3].Value = model.skuId;
			parameters[4].Value = model.skuInfo;
			parameters[5].Value = model.totPrice;
			parameters[6].Value = model.productNum;
			parameters[7].Value = model.createDate;

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
		public bool Update(WechatBuilder.Model.wx_shop_cart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_shop_cart set ");
			strSql.Append("openid=@openid,");
			strSql.Append("wid=@wid,");
			strSql.Append("productId=@productId,");
			strSql.Append("skuId=@skuId,");
			strSql.Append("skuInfo=@skuInfo,");
			strSql.Append("totPrice=@totPrice,");
			strSql.Append("productNum=@productNum,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@productId", SqlDbType.Int,4),
					new SqlParameter("@skuId", SqlDbType.Int,4),
					new SqlParameter("@skuInfo", SqlDbType.VarChar,500),
					new SqlParameter("@totPrice", SqlDbType.Float,8),
					new SqlParameter("@productNum", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.openid;
			parameters[1].Value = model.wid;
			parameters[2].Value = model.productId;
			parameters[3].Value = model.skuId;
			parameters[4].Value = model.skuInfo;
			parameters[5].Value = model.totPrice;
			parameters[6].Value = model.productNum;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from wx_shop_cart ");
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
			strSql.Append("delete from wx_shop_cart ");
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
		public WechatBuilder.Model.wx_shop_cart GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,openid,wid,productId,skuId,skuInfo,totPrice,productNum,createDate from wx_shop_cart ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_shop_cart model=new WechatBuilder.Model.wx_shop_cart();
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
		public WechatBuilder.Model.wx_shop_cart DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_shop_cart model=new WechatBuilder.Model.wx_shop_cart();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["productId"]!=null && row["productId"].ToString()!="")
				{
					model.productId=int.Parse(row["productId"].ToString());
				}
				if(row["skuId"]!=null && row["skuId"].ToString()!="")
				{
					model.skuId=int.Parse(row["skuId"].ToString());
				}
				if(row["skuInfo"]!=null)
				{
					model.skuInfo=row["skuInfo"].ToString();
				}
				if(row["totPrice"]!=null && row["totPrice"].ToString()!="")
				{
					model.totPrice=decimal.Parse(row["totPrice"].ToString());
				}
				if(row["productNum"]!=null && row["productNum"].ToString()!="")
				{
					model.productNum=int.Parse(row["productNum"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
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
			strSql.Append("select id,openid,wid,productId,skuId,skuInfo,totPrice,productNum,createDate ");
			strSql.Append(" FROM wx_shop_cart ");
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
			strSql.Append(" id,openid,wid,productId,skuId,skuInfo,totPrice,productNum,createDate ");
			strSql.Append(" FROM wx_shop_cart ");
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
			strSql.Append("select count(1) FROM wx_shop_cart ");
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
			strSql.Append(")AS Row, T.*  from wx_shop_cart T ");
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
        /// 移除购物车里的商品
        /// </summary>
        public bool RemoveCartInfo(int wid,string openid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_shop_cart ");
            strSql.Append(" where wid=@wid and openid=@openid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
                    new SqlParameter("@openid", SqlDbType.VarChar,100)
			};
            parameters[0].Value = wid;
            parameters[1].Value = openid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 获得购物车里的数据
        /// </summary>
        public DataSet GetCartList(string openid,int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select c.id,openid,wid,productId,skuId,skuInfo,totPrice,productNum,createDate,pr.productName,pr.shortDesc,pr.pic,pr.stock FROM wx_shop_cart c left join (
select  id,productName,shortDesc,stock,(select top 1 original_path from wx_shop_albums where productid=p.id) as pic from wx_shop_product p 
) pr  on pr.id=c.productId  where c.openid=@openid and c.wid=@wid");

            SqlParameter[] parameters = {
                     new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = openid;
            parameters[1].Value = wid;

            return DbHelperSQL.Query(strSql.ToString(),parameters);
        }



        /// <summary>
        /// 更新购物车商品数量
        /// </summary>
        public bool UpdateNum(int cartId, int newNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_shop_cart set ");
            strSql.Append("productNum=@productNum, totprice=(totprice/productNum)*@productNum");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@productNum", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = newNum;

            parameters[1].Value = cartId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		#endregion  ExtensionMethod
	}
}

