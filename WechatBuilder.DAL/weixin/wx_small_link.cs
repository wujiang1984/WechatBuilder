using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_small_link
	/// </summary>
	public partial class wx_small_link
	{
		public wx_small_link()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_small_link"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_small_link");
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
		public int Add(WechatBuilder.Model.wx_small_link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_small_link(");
			strSql.Append("sName,url,sType,sortId,isGlobal,companyName,comTel,remark)");
			strSql.Append(" values (");
			strSql.Append("@sName,@url,@sType,@sortId,@isGlobal,@companyName,@comTel,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,100),
					new SqlParameter("@url", SqlDbType.VarChar,1000),
					new SqlParameter("@sType", SqlDbType.VarChar,50),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@isGlobal", SqlDbType.Bit,1),
					new SqlParameter("@companyName", SqlDbType.VarChar,100),
					new SqlParameter("@comTel", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.sName;
			parameters[1].Value = model.url;
			parameters[2].Value = model.sType;
			parameters[3].Value = model.sortId;
			parameters[4].Value = model.isGlobal;
			parameters[5].Value = model.companyName;
			parameters[6].Value = model.comTel;
			parameters[7].Value = model.remark;

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
		public bool Update(WechatBuilder.Model.wx_small_link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_small_link set ");
			strSql.Append("sName=@sName,");
			strSql.Append("url=@url,");
			strSql.Append("sType=@sType,");
			strSql.Append("sortId=@sortId,");
			strSql.Append("isGlobal=@isGlobal,");
			strSql.Append("companyName=@companyName,");
			strSql.Append("comTel=@comTel,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,100),
					new SqlParameter("@url", SqlDbType.VarChar,1000),
					new SqlParameter("@sType", SqlDbType.VarChar,50),
					new SqlParameter("@sortId", SqlDbType.Int,4),
					new SqlParameter("@isGlobal", SqlDbType.Bit,1),
					new SqlParameter("@companyName", SqlDbType.VarChar,100),
					new SqlParameter("@comTel", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sName;
			parameters[1].Value = model.url;
			parameters[2].Value = model.sType;
			parameters[3].Value = model.sortId;
			parameters[4].Value = model.isGlobal;
			parameters[5].Value = model.companyName;
			parameters[6].Value = model.comTel;
			parameters[7].Value = model.remark;
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
			strSql.Append("delete from wx_small_link ");
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
			strSql.Append("delete from wx_small_link ");
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
		public WechatBuilder.Model.wx_small_link GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sName,url,sType,sortId,isGlobal,companyName,comTel,remark from wx_small_link ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_small_link model=new WechatBuilder.Model.wx_small_link();
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
		public WechatBuilder.Model.wx_small_link DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_small_link model=new WechatBuilder.Model.wx_small_link();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sName"]!=null)
				{
					model.sName=row["sName"].ToString();
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["sType"]!=null)
				{
					model.sType=row["sType"].ToString();
				}
				if(row["sortId"]!=null && row["sortId"].ToString()!="")
				{
					model.sortId=int.Parse(row["sortId"].ToString());
				}
				if(row["isGlobal"]!=null && row["isGlobal"].ToString()!="")
				{
					if((row["isGlobal"].ToString()=="1")||(row["isGlobal"].ToString().ToLower()=="true"))
					{
						model.isGlobal=true;
					}
					else
					{
						model.isGlobal=false;
					}
				}
				if(row["companyName"]!=null)
				{
					model.companyName=row["companyName"].ToString();
				}
				if(row["comTel"]!=null)
				{
					model.comTel=row["comTel"].ToString();
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
			strSql.Append("select id,sName,url,sType,sortId,isGlobal,companyName,comTel,remark ");
			strSql.Append(" FROM wx_small_link ");
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
			strSql.Append(" id,sName,url,sType,sortId,isGlobal,companyName,comTel,remark ");
			strSql.Append(" FROM wx_small_link ");
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
			strSql.Append("select count(1) FROM wx_small_link ");
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
			strSql.Append(")AS Row, T.*  from wx_small_link T ");
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
			parameters[0].Value = "wx_small_link";
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

		#endregion  ExtensionMethod
	}
}

