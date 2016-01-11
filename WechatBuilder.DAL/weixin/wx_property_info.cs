using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_property_info
	/// </summary>
	public partial class wx_property_info
	{
		public wx_property_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_property_info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_property_info");
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
		public int Add(WechatBuilder.Model.wx_property_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_property_info(");
			strSql.Append("wid,typeId,typeName,iName,iContent,expires_in,createDate,count,categoryId,categoryName,remark)");
			strSql.Append(" values (");
			strSql.Append("@wid,@typeId,@typeName,@iName,@iContent,@expires_in,@createDate,@count,@categoryId,@categoryName,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@iName", SqlDbType.VarChar,200),
					new SqlParameter("@iContent", SqlDbType.VarChar,-1),
					new SqlParameter("@expires_in", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@categoryId", SqlDbType.Int,4),
					new SqlParameter("@categoryName", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.typeId;
			parameters[2].Value = model.typeName;
			parameters[3].Value = model.iName;
			parameters[4].Value = model.iContent;
			parameters[5].Value = model.expires_in;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.count;
			parameters[8].Value = model.categoryId;
			parameters[9].Value = model.categoryName;
			parameters[10].Value = model.remark;

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
		public bool Update(WechatBuilder.Model.wx_property_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_property_info set ");
			strSql.Append("wid=@wid,");
			strSql.Append("typeId=@typeId,");
			strSql.Append("typeName=@typeName,");
			strSql.Append("iName=@iName,");
			strSql.Append("iContent=@iContent,");
			strSql.Append("expires_in=@expires_in,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("count=@count,");
			strSql.Append("categoryId=@categoryId,");
			strSql.Append("categoryName=@categoryName,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,100),
					new SqlParameter("@iName", SqlDbType.VarChar,200),
					new SqlParameter("@iContent", SqlDbType.VarChar,-1),
					new SqlParameter("@expires_in", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@categoryId", SqlDbType.Int,4),
					new SqlParameter("@categoryName", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.typeId;
			parameters[2].Value = model.typeName;
			parameters[3].Value = model.iName;
			parameters[4].Value = model.iContent;
			parameters[5].Value = model.expires_in;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.count;
			parameters[8].Value = model.categoryId;
			parameters[9].Value = model.categoryName;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from wx_property_info ");
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
			strSql.Append("delete from wx_property_info ");
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
		public WechatBuilder.Model.wx_property_info GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,typeId,typeName,iName,iContent,expires_in,createDate,count,categoryId,categoryName,remark from wx_property_info ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_property_info model=new WechatBuilder.Model.wx_property_info();
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
		public WechatBuilder.Model.wx_property_info DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_property_info model=new WechatBuilder.Model.wx_property_info();
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
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["typeName"]!=null)
				{
					model.typeName=row["typeName"].ToString();
				}
				if(row["iName"]!=null)
				{
					model.iName=row["iName"].ToString();
				}
				if(row["iContent"]!=null)
				{
					model.iContent=row["iContent"].ToString();
				}
				if(row["expires_in"]!=null && row["expires_in"].ToString()!="")
				{
					model.expires_in=int.Parse(row["expires_in"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["count"]!=null && row["count"].ToString()!="")
				{
					model.count=int.Parse(row["count"].ToString());
				}
				if(row["categoryId"]!=null && row["categoryId"].ToString()!="")
				{
					model.categoryId=int.Parse(row["categoryId"].ToString());
				}
				if(row["categoryName"]!=null)
				{
					model.categoryName=row["categoryName"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,wid,typeId,typeName,iName,iContent,expires_in,createDate,count,categoryId,categoryName,remark ");
			strSql.Append(" FROM wx_property_info ");
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
			strSql.Append(" id,wid,typeId,typeName,iName,iContent,expires_in,createDate,count,categoryId,categoryName,remark ");
			strSql.Append(" FROM wx_property_info ");
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
			strSql.Append("select count(1) FROM wx_property_info ");
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
			strSql.Append(")AS Row, T.*  from wx_property_info T ");
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
			parameters[0].Value = "wx_property_info";
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
        /// <summary>
        /// 该微帐号是否存在记录
        /// </summary>
        public bool ExistsWid(int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_property_info");
            strSql.Append(" where wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		#endregion  ExtensionMethod
	}
}

