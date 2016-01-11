using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_product_comment
	/// </summary>
	public partial class wx_product_comment
	{
		public wx_product_comment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_product_comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_product_comment");
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
		public int Add(WechatBuilder.Model.wx_product_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_product_comment(");
			strSql.Append("hdId,openId,commentContent,commentType,commentRemark,createDate,replyStatus,replyPerson,replyContent,replyDate)");
			strSql.Append(" values (");
			strSql.Append("@hdId,@openId,@commentContent,@commentType,@commentRemark,@createDate,@replyStatus,@replyPerson,@replyContent,@replyDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@hdId", SqlDbType.Int,4),
					new SqlParameter("@openId", SqlDbType.VarChar,200),
					new SqlParameter("@commentContent", SqlDbType.VarChar,500),
					new SqlParameter("@commentType", SqlDbType.Int,4),
					new SqlParameter("@commentRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@replyStatus", SqlDbType.Int,4),
					new SqlParameter("@replyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@replyContent", SqlDbType.VarChar,1000),
					new SqlParameter("@replyDate", SqlDbType.DateTime)};
			parameters[0].Value = model.hdId;
			parameters[1].Value = model.openId;
			parameters[2].Value = model.commentContent;
			parameters[3].Value = model.commentType;
			parameters[4].Value = model.commentRemark;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.replyStatus;
			parameters[7].Value = model.replyPerson;
			parameters[8].Value = model.replyContent;
			parameters[9].Value = model.replyDate;

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
		public bool Update(WechatBuilder.Model.wx_product_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_product_comment set ");
			strSql.Append("hdId=@hdId,");
			strSql.Append("openId=@openId,");
			strSql.Append("commentContent=@commentContent,");
			strSql.Append("commentType=@commentType,");
			strSql.Append("commentRemark=@commentRemark,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("replyStatus=@replyStatus,");
			strSql.Append("replyPerson=@replyPerson,");
			strSql.Append("replyContent=@replyContent,");
			strSql.Append("replyDate=@replyDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@hdId", SqlDbType.Int,4),
					new SqlParameter("@openId", SqlDbType.VarChar,200),
					new SqlParameter("@commentContent", SqlDbType.VarChar,500),
					new SqlParameter("@commentType", SqlDbType.Int,4),
					new SqlParameter("@commentRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@replyStatus", SqlDbType.Int,4),
					new SqlParameter("@replyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@replyContent", SqlDbType.VarChar,1000),
					new SqlParameter("@replyDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.hdId;
			parameters[1].Value = model.openId;
			parameters[2].Value = model.commentContent;
			parameters[3].Value = model.commentType;
			parameters[4].Value = model.commentRemark;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.replyStatus;
			parameters[7].Value = model.replyPerson;
			parameters[8].Value = model.replyContent;
			parameters[9].Value = model.replyDate;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from wx_product_comment ");
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
			strSql.Append("delete from wx_product_comment ");
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
		public WechatBuilder.Model.wx_product_comment GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,hdId,openId,commentContent,commentType,commentRemark,createDate,replyStatus,replyPerson,replyContent,replyDate from wx_product_comment ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_product_comment model=new WechatBuilder.Model.wx_product_comment();
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
		public WechatBuilder.Model.wx_product_comment DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_product_comment model=new WechatBuilder.Model.wx_product_comment();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["hdId"]!=null && row["hdId"].ToString()!="")
				{
					model.hdId=int.Parse(row["hdId"].ToString());
				}
				if(row["openId"]!=null)
				{
					model.openId=row["openId"].ToString();
				}
				if(row["commentContent"]!=null)
				{
					model.commentContent=row["commentContent"].ToString();
				}
				if(row["commentType"]!=null && row["commentType"].ToString()!="")
				{
					model.commentType=int.Parse(row["commentType"].ToString());
				}
				if(row["commentRemark"]!=null)
				{
					model.commentRemark=row["commentRemark"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["replyStatus"]!=null && row["replyStatus"].ToString()!="")
				{
					model.replyStatus=int.Parse(row["replyStatus"].ToString());
				}
				if(row["replyPerson"]!=null)
				{
					model.replyPerson=row["replyPerson"].ToString();
				}
				if(row["replyContent"]!=null)
				{
					model.replyContent=row["replyContent"].ToString();
				}
				if(row["replyDate"]!=null && row["replyDate"].ToString()!="")
				{
					model.replyDate=DateTime.Parse(row["replyDate"].ToString());
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
			strSql.Append("select id,hdId,openId,commentContent,commentType,commentRemark,createDate,replyStatus,replyPerson,replyContent,replyDate ");
			strSql.Append(" FROM wx_product_comment ");
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
			strSql.Append(" id,hdId,openId,commentContent,commentType,commentRemark,createDate,replyStatus,replyPerson,replyContent,replyDate ");
			strSql.Append(" FROM wx_product_comment ");
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
			strSql.Append("select count(1) FROM wx_product_comment ");
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
			strSql.Append(")AS Row, T.*  from wx_product_comment T ");
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
			parameters[0].Value = "wx_product_comment";
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

