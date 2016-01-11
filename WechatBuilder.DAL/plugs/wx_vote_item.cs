using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_vote_item
	/// </summary>
	public partial class wx_vote_item
	{
		public wx_vote_item()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_vote_item"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_vote_item");
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
		public int Add(WechatBuilder.Model.wx_vote_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_vote_item(");
            strSql.Append("title,sort_id,pic_url,pic_jump,sid,createDate,baseid,tpTimes)");
			strSql.Append(" values (");
            strSql.Append("@title,@sort_id,@pic_url,@pic_jump,@sid,@createDate,@baseid,@tpTimes)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@pic_url", SqlDbType.VarChar,500),
					new SqlParameter("@pic_jump", SqlDbType.VarChar,500),
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@baseid", SqlDbType.Int,4),
					new SqlParameter("@tpTimes", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.sort_id;
			parameters[2].Value = model.pic_url;
			parameters[3].Value = model.pic_jump;
			parameters[4].Value = model.sid;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.baseid;
            parameters[7].Value = model.tpTimes;

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
		public bool Update(WechatBuilder.Model.wx_vote_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_vote_item set ");
			strSql.Append("title=@title,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("pic_url=@pic_url,");
			strSql.Append("pic_jump=@pic_jump,");
			strSql.Append("sid=@sid,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("baseid=@baseid,");
            strSql.Append("tpTimes=@tpTimes");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@pic_url", SqlDbType.VarChar,500),
					new SqlParameter("@pic_jump", SqlDbType.VarChar,500),
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@baseid", SqlDbType.Int,4),
                    new SqlParameter("@tpTimes", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.sort_id;
			parameters[2].Value = model.pic_url;
			parameters[3].Value = model.pic_jump;
			parameters[4].Value = model.sid;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.baseid;
            parameters[7].Value = model.tpTimes;
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
        public bool Delete(int baseid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_vote_item ");
            strSql.Append(" where baseid=@baseid");
			SqlParameter[] parameters = {
					new SqlParameter("@baseid", SqlDbType.Int,4)
			};
            parameters[0].Value = baseid;

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
			strSql.Append("delete from wx_vote_item ");
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
		public WechatBuilder.Model.wx_vote_item GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,title,sort_id,pic_url,pic_jump,sid,createDate,baseid,tpTimes  from wx_vote_item ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_vote_item model=new WechatBuilder.Model.wx_vote_item();
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
		public WechatBuilder.Model.wx_vote_item DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_vote_item model=new WechatBuilder.Model.wx_vote_item();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["pic_url"]!=null)
				{
					model.pic_url=row["pic_url"].ToString();
				}
				if(row["pic_jump"]!=null)
				{
					model.pic_jump=row["pic_jump"].ToString();
				}
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["baseid"]!=null && row["baseid"].ToString()!="")
				{
					model.baseid=int.Parse(row["baseid"].ToString());
				}
                if (row["tpTimes"] != null && row["tpTimes"].ToString() != "")
                {
                    model.tpTimes = int.Parse(row["tpTimes"].ToString());
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
            strSql.Append("select id,title,sort_id,pic_url,pic_jump,sid,createDate,baseid,tpTimes,0.0 as bili ");
			strSql.Append(" FROM wx_vote_item ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,sort_id,pic_url,pic_jump,sid,createDate,baseid,tpTimes ");
            strSql.Append(" FROM wx_vote_item ");
            if (id != 0)
            {
                strSql.Append(" where baseid='"+id+"' ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetListByid(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,sort_id,pic_url,pic_jump,sid,createDate,baseid,tpTimes ");
            strSql.Append(" FROM wx_vote_item ");
            if (id !=0)
            {
                strSql.Append(" where baseid='"+id+"' ");
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
            strSql.Append(" id,title,sort_id,pic_url,pic_jump,sid,createDate,baseid,tpTimes ");
			strSql.Append(" FROM wx_vote_item ");
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
			strSql.Append("select count(1) FROM wx_vote_item ");
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
			strSql.Append(")AS Row, T.*  from wx_vote_item T ");
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
			parameters[0].Value = "wx_vote_item";
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
        /// 更新一条数据
        /// </summary>
        public bool Update(int sid,int baseid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_vote_item set ");
            strSql.Append("tpTimes=isnull(tpTimes,0)+1");
            strSql.Append(" where sid=@sid and baseid=@baseid ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@baseid", SqlDbType.Int,4) };
            parameters[0].Value =sid;
            parameters[1].Value = baseid;
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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_vote_item  set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		#endregion  ExtensionMethod
	}
}

