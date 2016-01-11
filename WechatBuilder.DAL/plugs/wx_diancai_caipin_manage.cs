using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_diancai_caipin_manage
	/// </summary>
	public partial class wx_diancai_caipin_manage
	{
		public wx_diancai_caipin_manage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_diancai_caipin_manage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_diancai_caipin_manage");
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
		public int Add(WechatBuilder.Model.wx_diancai_caipin_manage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_diancai_caipin_manage(");
			strSql.Append("categoryid,cpName,categoryName,cpPrice,zkPrice,priceUnite,cpPic,picUrl,detailContent,createDate,shopid,sortid,scan)");
			strSql.Append(" values (");
			strSql.Append("@categoryid,@cpName,@categoryName,@cpPrice,@zkPrice,@priceUnite,@cpPic,@picUrl,@detailContent,@createDate,@shopid,@sortid,@scan)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@cpName", SqlDbType.VarChar,100),
					new SqlParameter("@categoryName", SqlDbType.VarChar,100),
					new SqlParameter("@cpPrice", SqlDbType.Float,8),
					new SqlParameter("@zkPrice", SqlDbType.Float,8),
					new SqlParameter("@priceUnite", SqlDbType.VarChar,100),
					new SqlParameter("@cpPic", SqlDbType.VarChar,300),
					new SqlParameter("@picUrl", SqlDbType.VarChar,300),
					new SqlParameter("@detailContent", SqlDbType.VarChar,300),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@scan", SqlDbType.Int,4)};
			parameters[0].Value = model.categoryid;
			parameters[1].Value = model.cpName;
			parameters[2].Value = model.categoryName;
			parameters[3].Value = model.cpPrice;
			parameters[4].Value = model.zkPrice;
			parameters[5].Value = model.priceUnite;
			parameters[6].Value = model.cpPic;
			parameters[7].Value = model.picUrl;
			parameters[8].Value = model.detailContent;
			parameters[9].Value = model.createDate;
			parameters[10].Value = model.shopid;
			parameters[11].Value = model.sortid;
			parameters[12].Value = model.scan;

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
		public bool Update(WechatBuilder.Model.wx_diancai_caipin_manage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_diancai_caipin_manage set ");
			strSql.Append("categoryid=@categoryid,");
			strSql.Append("cpName=@cpName,");
			strSql.Append("categoryName=@categoryName,");
			strSql.Append("cpPrice=@cpPrice,");
			strSql.Append("zkPrice=@zkPrice,");
			strSql.Append("priceUnite=@priceUnite,");
			strSql.Append("cpPic=@cpPic,");
			strSql.Append("picUrl=@picUrl,");
			strSql.Append("detailContent=@detailContent,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("shopid=@shopid,");
			strSql.Append("sortid=@sortid,");
			strSql.Append("scan=@scan");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@cpName", SqlDbType.VarChar,100),
					new SqlParameter("@categoryName", SqlDbType.VarChar,100),
					new SqlParameter("@cpPrice", SqlDbType.Float,8),
					new SqlParameter("@zkPrice", SqlDbType.Float,8),
					new SqlParameter("@priceUnite", SqlDbType.VarChar,100),
					new SqlParameter("@cpPic", SqlDbType.VarChar,300),
					new SqlParameter("@picUrl", SqlDbType.VarChar,300),
					new SqlParameter("@detailContent", SqlDbType.VarChar,300),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@sortid", SqlDbType.Int,4),
					new SqlParameter("@scan", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.categoryid;
			parameters[1].Value = model.cpName;
			parameters[2].Value = model.categoryName;
			parameters[3].Value = model.cpPrice;
			parameters[4].Value = model.zkPrice;
			parameters[5].Value = model.priceUnite;
			parameters[6].Value = model.cpPic;
			parameters[7].Value = model.picUrl;
			parameters[8].Value = model.detailContent;
			parameters[9].Value = model.createDate;
			parameters[10].Value = model.shopid;
			parameters[11].Value = model.sortid;
			parameters[12].Value = model.scan;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from wx_diancai_caipin_manage ");
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
			strSql.Append("delete from wx_diancai_caipin_manage ");
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
		public WechatBuilder.Model.wx_diancai_caipin_manage GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,categoryid,cpName,categoryName,cpPrice,zkPrice,priceUnite,cpPic,picUrl,detailContent,createDate,shopid,sortid,scan from wx_diancai_caipin_manage ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_diancai_caipin_manage model=new WechatBuilder.Model.wx_diancai_caipin_manage();
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
		public WechatBuilder.Model.wx_diancai_caipin_manage DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_diancai_caipin_manage model=new WechatBuilder.Model.wx_diancai_caipin_manage();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["categoryid"]!=null && row["categoryid"].ToString()!="")
				{
					model.categoryid=int.Parse(row["categoryid"].ToString());
				}
				if(row["cpName"]!=null)
				{
					model.cpName=row["cpName"].ToString();
				}
				if(row["categoryName"]!=null)
				{
					model.categoryName=row["categoryName"].ToString();
				}
				if(row["cpPrice"]!=null && row["cpPrice"].ToString()!="")
				{
					model.cpPrice=decimal.Parse(row["cpPrice"].ToString());
				}
				if(row["zkPrice"]!=null && row["zkPrice"].ToString()!="")
				{
					model.zkPrice=decimal.Parse(row["zkPrice"].ToString());
				}
				if(row["priceUnite"]!=null)
				{
					model.priceUnite=row["priceUnite"].ToString();
				}
				if(row["cpPic"]!=null)
				{
					model.cpPic=row["cpPic"].ToString();
				}
				if(row["picUrl"]!=null)
				{
					model.picUrl=row["picUrl"].ToString();
				}
				if(row["detailContent"]!=null)
				{
					model.detailContent=row["detailContent"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["shopid"]!=null && row["shopid"].ToString()!="")
				{
					model.shopid=int.Parse(row["shopid"].ToString());
				}
				if(row["sortid"]!=null)
				{
                    model.sortid = int.Parse(row["sortid"].ToString());
				}
				if(row["scan"]!=null && row["scan"].ToString()!="")
				{
					model.scan=int.Parse(row["scan"].ToString());
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
			strSql.Append("select id,categoryid,cpName,categoryName,cpPrice,zkPrice,priceUnite,cpPic,picUrl,detailContent,createDate,shopid,sortid,scan ");
			strSql.Append(" FROM wx_diancai_caipin_manage ");
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
			strSql.Append(" id,categoryid,cpName,categoryName,cpPrice,zkPrice,priceUnite,cpPic,picUrl,detailContent,createDate,shopid,sortid,scan ");
			strSql.Append(" FROM wx_diancai_caipin_manage ");
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
			strSql.Append("select count(1) FROM wx_diancai_caipin_manage ");
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
			strSql.Append(")AS Row, T.*  from wx_diancai_caipin_manage T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "wx_diancai_caipin_manage";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aa.id,aa.categoryid,aa.cpName,bb.categoryName as categoryName,aa.cpPrice,aa.zkPrice,aa.priceUnite,aa.cpPic,aa.picUrl,aa.detailContent,aa.createDate,aa.shopid,aa.sortid,aa.scan ");
            strSql.Append(" FROM wx_diancai_caipin_manage ");
            strSql.Append(" as aa left join (select * from  wx_diancai_caipin_category ) as bb on aa.categoryid=bb.id");
            strSql.Append(" where 1=1 ");//
            if (strWhere.Trim() != "")
            {
                strSql.Append( strWhere);
            }
            strSql.Append("");// order by  aa.sortid asc 
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        public DataSet GetList(int cateid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,categoryid,cpName,categoryName,cpPrice,zkPrice,priceUnite,cpPic,picUrl,detailContent,createDate,shopid,sortid,scan ");
			strSql.Append(" FROM wx_diancai_caipin_manage ");
            if (cateid != 0)
			{
                strSql.Append(" where categoryid=" + cateid + " ");
			}
            strSql.Append(" order by  sortid asc ");
			return DbHelperSQL.Query(strSql.ToString());
		}
		#endregion  ExtensionMethod
	}
}

