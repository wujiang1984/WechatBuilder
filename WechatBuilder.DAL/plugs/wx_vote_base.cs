using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_vote_base
	/// </summary>
	public partial class wx_vote_base
	{
		public wx_vote_base()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_vote_base"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_vote_base");
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
		public int Add(WechatBuilder.Model.wx_vote_base model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_vote_base(");
			strSql.Append("wid,title,votepic,picdisplay,votecontent,isRadio,beginTime,endTime,resultShowtype,actUrl,voteType,sort_id,creatDate)");
			strSql.Append(" values (");
			strSql.Append("@wid,@title,@votepic,@picdisplay,@votecontent,@isRadio,@beginTime,@endTime,@resultShowtype,@actUrl,@voteType,@sort_id,@creatDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,4000),
					new SqlParameter("@votepic", SqlDbType.VarChar,800),
					new SqlParameter("@picdisplay", SqlDbType.Bit,1),
					new SqlParameter("@votecontent", SqlDbType.VarChar,1500),
					new SqlParameter("@isRadio", SqlDbType.Bit,1),
					new SqlParameter("@beginTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
					new SqlParameter("@resultShowtype", SqlDbType.Int,4),
					new SqlParameter("@actUrl", SqlDbType.VarChar,800),
					new SqlParameter("@voteType", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@creatDate", SqlDbType.DateTime)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.votepic;
			parameters[3].Value = model.picdisplay;
			parameters[4].Value = model.votecontent;
			parameters[5].Value = model.isRadio;
			parameters[6].Value = model.beginTime;
			parameters[7].Value = model.endTime;
			parameters[8].Value = model.resultShowtype;
			parameters[9].Value = model.actUrl;
			parameters[10].Value = model.voteType;
			parameters[11].Value = model.sort_id;
			parameters[12].Value = model.creatDate;

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
		public bool Update(WechatBuilder.Model.wx_vote_base model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_vote_base set ");
			//strSql.Append("wid=@wid,");
			strSql.Append("title=@title,");
			strSql.Append("votepic=@votepic,");
			strSql.Append("picdisplay=@picdisplay,");
			strSql.Append("votecontent=@votecontent,");
			strSql.Append("isRadio=@isRadio,");
			strSql.Append("beginTime=@beginTime,");
			strSql.Append("endTime=@endTime,");
			strSql.Append("resultShowtype=@resultShowtype,");
			//strSql.Append("actUrl=@actUrl,");
			strSql.Append("voteType=@voteType,");
			strSql.Append("sort_id=@sort_id");
			//strSql.Append("creatDate=@creatDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,4000),
					new SqlParameter("@votepic", SqlDbType.VarChar,800),
					new SqlParameter("@picdisplay", SqlDbType.Bit,1),
					new SqlParameter("@votecontent", SqlDbType.VarChar,1500),
					new SqlParameter("@isRadio", SqlDbType.Bit,1),
					new SqlParameter("@beginTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
					new SqlParameter("@resultShowtype", SqlDbType.Int,4),
					new SqlParameter("@actUrl", SqlDbType.VarChar,800),
					new SqlParameter("@voteType", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@creatDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.votepic;
			parameters[3].Value = model.picdisplay;
			parameters[4].Value = model.votecontent;
			parameters[5].Value = model.isRadio;
			parameters[6].Value = model.beginTime;
			parameters[7].Value = model.endTime;
			parameters[8].Value = model.resultShowtype;
			parameters[9].Value = model.actUrl;
			parameters[10].Value = model.voteType;
			parameters[11].Value = model.sort_id;
			parameters[12].Value = model.creatDate;
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
		public bool Delete(int id,int wid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_vote_base ");
			strSql.Append(" where id=@id and wid=@wid");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@wid", SqlDbType.Int,4)
			};
			parameters[0].Value = id;
            parameters[1].Value = wid;

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

        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_vote_base ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
                  
			};
            parameters[0].Value = id;
        

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
			strSql.Append("delete from wx_vote_base ");
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
		public WechatBuilder.Model.wx_vote_base GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,title,votepic,picdisplay,votecontent,isRadio,beginTime,endTime,resultShowtype,actUrl,voteType,sort_id,creatDate from wx_vote_base ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_vote_base model=new WechatBuilder.Model.wx_vote_base();
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
		public WechatBuilder.Model.wx_vote_base DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_vote_base model=new WechatBuilder.Model.wx_vote_base();
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
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["votepic"]!=null)
				{
					model.votepic=row["votepic"].ToString();
				}
				if(row["picdisplay"]!=null && row["picdisplay"].ToString()!="")
				{
					if((row["picdisplay"].ToString()=="1")||(row["picdisplay"].ToString().ToLower()=="true"))
					{
						model.picdisplay=true;
					}
					else
					{
						model.picdisplay=false;
					}
				}
				if(row["votecontent"]!=null)
				{
					model.votecontent=row["votecontent"].ToString();
				}
				if(row["isRadio"]!=null && row["isRadio"].ToString()!="")
				{
					if((row["isRadio"].ToString()=="1")||(row["isRadio"].ToString().ToLower()=="true"))
					{
						model.isRadio=true;
					}
					else
					{
						model.isRadio=false;
					}
				}
				if(row["beginTime"]!=null && row["beginTime"].ToString()!="")
				{
					model.beginTime=DateTime.Parse(row["beginTime"].ToString());
				}
				if(row["endTime"]!=null && row["endTime"].ToString()!="")
				{
					model.endTime=DateTime.Parse(row["endTime"].ToString());
				}
				if(row["resultShowtype"]!=null && row["resultShowtype"].ToString()!="")
				{
					model.resultShowtype=int.Parse(row["resultShowtype"].ToString());
				}
				if(row["actUrl"]!=null)
				{
					model.actUrl=row["actUrl"].ToString();
				}
				if(row["voteType"]!=null && row["voteType"].ToString()!="")
				{
					model.voteType=int.Parse(row["voteType"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["creatDate"]!=null && row["creatDate"].ToString()!="")
				{
					model.creatDate=DateTime.Parse(row["creatDate"].ToString());
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
			strSql.Append("select id,wid,title,votepic,picdisplay,votecontent,isRadio,beginTime,endTime,resultShowtype,actUrl,voteType,sort_id,creatDate ");
			strSql.Append(" FROM wx_vote_base ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}


        public DataSet GetListByid(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,wid,title,votepic,picdisplay,votecontent,isRadio,beginTime,endTime,resultShowtype,actUrl,voteType,sort_id,creatDate ");
			strSql.Append(" FROM wx_vote_base ");
			if(id!=0)
			{
                strSql.Append(" where  id='" + id + "' ");
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,title,votepic,picdisplay,votecontent,isRadio,beginTime,endTime,resultShowtype,actUrl,voteType,sort_id,creatDate ");
            strSql.Append(" FROM wx_vote_base   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }


            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
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
			strSql.Append(" id,wid,title,votepic,picdisplay,votecontent,isRadio,beginTime,endTime,resultShowtype,actUrl,voteType,sort_id,creatDate ");
			strSql.Append(" FROM wx_vote_base ");
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
			strSql.Append("select count(1) FROM wx_vote_base ");
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
			strSql.Append(")AS Row, T.*  from wx_vote_base T ");
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
			parameters[0].Value = "wx_vote_base";
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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_vote_base set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

