using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_message_list
	/// </summary>
	public partial class wx_message_list
	{
		public wx_message_list()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_message_list"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_message_list");
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
		public int Add(WechatBuilder.Model.wx_message_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_message_list(");
            strSql.Append("wid,userName,title,parentId,openId,createDate,sort_id,hasSH)");
			strSql.Append(" values (");
            strSql.Append("@wid,@userName,@title,@parentId,@openId,@createDate,@sort_id,@hasSH)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.VarChar,800),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@openId", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
                    new SqlParameter("@hasSH", SqlDbType.Bit,1)
                                        };
			parameters[0].Value = model.wid;
			parameters[1].Value = model.userName;
			parameters[2].Value = model.title;
			parameters[3].Value = model.parentId;
			parameters[4].Value = model.openId;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.sort_id;
            parameters[7].Value = model.hasSH;

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
		public bool Update(WechatBuilder.Model.wx_message_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_message_list set ");
			strSql.Append("wid=@wid,");
			//strSql.Append("userName=@userName,");
			//strSql.Append("title=@title,");
			//strSql.Append("parentId=@parentId,");
			//strSql.Append("openId=@openId,");
           // strSql.Append("createDate=@createDate,");
			//strSql.Append("sort_id=@sort_id,");
            strSql.Append("hasSH=@hasSH");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					//new SqlParameter("@userName", SqlDbType.VarChar,100),
					//new SqlParameter("@title", SqlDbType.VarChar,800),
					//new SqlParameter("@parentId", SqlDbType.Int,4),
					//new SqlParameter("@openId", SqlDbType.VarChar,100),
					//new SqlParameter("@createDate", SqlDbType.DateTime),
					//new SqlParameter("@sort_id", SqlDbType.Int,4),
                    new SqlParameter("@hasSH", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			//parameters[1].Value = model.userName;
			//parameters[2].Value = model.title;
			//parameters[3].Value = model.parentId;
			//parameters[4].Value = model.openId;
			//parameters[5].Value = model.createDate;
			//parameters[6].Value = model.sort_id;
            parameters[1].Value = model.hasSH;
			parameters[2].Value = model.id;

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
			strSql.Append("delete from wx_message_list ");
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

        public bool Deleteopenid(string openId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_message_list ");
            strSql.Append(" where openId=@openId");
            SqlParameter[] parameters = {
					new SqlParameter("@openId", SqlDbType.VarChar,500)
			};
            parameters[0].Value = openId;

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

        public bool Delete(int id,int wid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_message_list ");
            strSql.Append(" where id=@id and wid=@wid ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = id;
            parameters[1].Value = wid;
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_message_list ");
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
		public WechatBuilder.Model.wx_message_list GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,wid,userName,title,parentId,openId,createDate,sort_id,hasSH  from wx_message_list ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_message_list model=new WechatBuilder.Model.wx_message_list();
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
		public WechatBuilder.Model.wx_message_list DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_message_list model=new WechatBuilder.Model.wx_message_list();
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
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["openId"]!=null)
				{
					model.openId=row["openId"].ToString();
				}
                if (row["createDate"] != null && row["createDate"].ToString() != "")
				{
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList( string strWhere )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,userName,title,parentId,openId,createDate,sort_id,hasSH ");
            strSql.Append(" FROM wx_message_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
           
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,wid,userName,title,parentId,openId,createDate,sort_id,hasSH ");
			strSql.Append(" FROM wx_message_list ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}


            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
		}

        /// <summary>
        /// 获得所有的留言信息
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public DataSet GetListDetail(int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,userName,title,parentId,openId,createDate,sort_id,hasSH ");
            strSql.Append(" FROM wx_message_list ");
            if ( wid !=0)
            {
                strSql.Append(" where  wid='"+wid+"'  ");
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
            strSql.Append(" id,wid,userName,title,parentId,openId,createDate,sort_id,hasSH ");
			strSql.Append(" FROM wx_message_list ");
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
			strSql.Append("select count(1) FROM wx_message_list ");
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
			strSql.Append(")AS Row, T.*  from wx_message_list T ");
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
			parameters[0].Value = "wx_message_list";
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

