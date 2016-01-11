using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_sjb_bisai
	/// </summary>
	public partial class wx_sjb_bisai
	{
		public wx_sjb_bisai()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_sjb_bisai"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_sjb_bisai");
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
		public int Add(WechatBuilder.Model.wx_sjb_bisai model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_sjb_bisai(");
			strSql.Append("bsPic,bsRemark,rcId,qd1Id,qd2Id,beginDate,endDate,jcBeginDate,jcEndDate,resultType,rType1Times,rType2Times,rType3Times,createDate)");
			strSql.Append(" values (");
			strSql.Append("@bsPic,@bsRemark,@rcId,@qd1Id,@qd2Id,@beginDate,@endDate,@jcBeginDate,@jcEndDate,@resultType,@rType1Times,@rType2Times,@rType3Times,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@bsPic", SqlDbType.VarChar,800),
					new SqlParameter("@bsRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@rcId", SqlDbType.Int,4),
					new SqlParameter("@qd1Id", SqlDbType.Int,4),
					new SqlParameter("@qd2Id", SqlDbType.Int,4),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@jcBeginDate", SqlDbType.DateTime),
					new SqlParameter("@jcEndDate", SqlDbType.DateTime),
					new SqlParameter("@resultType", SqlDbType.Int,4),
					new SqlParameter("@rType1Times", SqlDbType.Int,4),
					new SqlParameter("@rType2Times", SqlDbType.Int,4),
					new SqlParameter("@rType3Times", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.bsPic;
			parameters[1].Value = model.bsRemark;
			parameters[2].Value = model.rcId;
			parameters[3].Value = model.qd1Id;
			parameters[4].Value = model.qd2Id;
			parameters[5].Value = model.beginDate;
			parameters[6].Value = model.endDate;
			parameters[7].Value = model.jcBeginDate;
			parameters[8].Value = model.jcEndDate;
			parameters[9].Value = model.resultType;
			parameters[10].Value = model.rType1Times;
			parameters[11].Value = model.rType2Times;
			parameters[12].Value = model.rType3Times;
			parameters[13].Value = model.createDate;

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
		public bool Update(WechatBuilder.Model.wx_sjb_bisai model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_sjb_bisai set ");
			strSql.Append("bsPic=@bsPic,");
			strSql.Append("bsRemark=@bsRemark,");
			strSql.Append("rcId=@rcId,");
			strSql.Append("qd1Id=@qd1Id,");
			strSql.Append("qd2Id=@qd2Id,");
			strSql.Append("beginDate=@beginDate,");
			strSql.Append("endDate=@endDate,");
			strSql.Append("jcBeginDate=@jcBeginDate,");
			strSql.Append("jcEndDate=@jcEndDate,");
			strSql.Append("resultType=@resultType,");
			strSql.Append("rType1Times=@rType1Times,");
			strSql.Append("rType2Times=@rType2Times,");
			strSql.Append("rType3Times=@rType3Times,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@bsPic", SqlDbType.VarChar,800),
					new SqlParameter("@bsRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@rcId", SqlDbType.Int,4),
					new SqlParameter("@qd1Id", SqlDbType.Int,4),
					new SqlParameter("@qd2Id", SqlDbType.Int,4),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@jcBeginDate", SqlDbType.DateTime),
					new SqlParameter("@jcEndDate", SqlDbType.DateTime),
					new SqlParameter("@resultType", SqlDbType.Int,4),
					new SqlParameter("@rType1Times", SqlDbType.Int,4),
					new SqlParameter("@rType2Times", SqlDbType.Int,4),
					new SqlParameter("@rType3Times", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.bsPic;
			parameters[1].Value = model.bsRemark;
			parameters[2].Value = model.rcId;
			parameters[3].Value = model.qd1Id;
			parameters[4].Value = model.qd2Id;
			parameters[5].Value = model.beginDate;
			parameters[6].Value = model.endDate;
			parameters[7].Value = model.jcBeginDate;
			parameters[8].Value = model.jcEndDate;
			parameters[9].Value = model.resultType;
			parameters[10].Value = model.rType1Times;
			parameters[11].Value = model.rType2Times;
			parameters[12].Value = model.rType3Times;
			parameters[13].Value = model.createDate;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from wx_sjb_bisai ");
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
			strSql.Append("delete from wx_sjb_bisai ");
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
		public WechatBuilder.Model.wx_sjb_bisai GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,bsPic,bsRemark,rcId,qd1Id,qd2Id,beginDate,endDate,jcBeginDate,jcEndDate,resultType,rType1Times,rType2Times,rType3Times,createDate from wx_sjb_bisai ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_sjb_bisai model=new WechatBuilder.Model.wx_sjb_bisai();
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
		public WechatBuilder.Model.wx_sjb_bisai DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_sjb_bisai model=new WechatBuilder.Model.wx_sjb_bisai();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["bsPic"]!=null)
				{
					model.bsPic=row["bsPic"].ToString();
				}
				if(row["bsRemark"]!=null)
				{
					model.bsRemark=row["bsRemark"].ToString();
				}
				if(row["rcId"]!=null && row["rcId"].ToString()!="")
				{
					model.rcId=int.Parse(row["rcId"].ToString());
				}
				if(row["qd1Id"]!=null && row["qd1Id"].ToString()!="")
				{
					model.qd1Id=int.Parse(row["qd1Id"].ToString());
				}
				if(row["qd2Id"]!=null && row["qd2Id"].ToString()!="")
				{
					model.qd2Id=int.Parse(row["qd2Id"].ToString());
				}
				if(row["beginDate"]!=null && row["beginDate"].ToString()!="")
				{
					model.beginDate=DateTime.Parse(row["beginDate"].ToString());
				}
				if(row["endDate"]!=null && row["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(row["endDate"].ToString());
				}
				if(row["jcBeginDate"]!=null && row["jcBeginDate"].ToString()!="")
				{
					model.jcBeginDate=DateTime.Parse(row["jcBeginDate"].ToString());
				}
				if(row["jcEndDate"]!=null && row["jcEndDate"].ToString()!="")
				{
					model.jcEndDate=DateTime.Parse(row["jcEndDate"].ToString());
				}
				if(row["resultType"]!=null && row["resultType"].ToString()!="")
				{
					model.resultType=int.Parse(row["resultType"].ToString());
				}
				if(row["rType1Times"]!=null && row["rType1Times"].ToString()!="")
				{
					model.rType1Times=int.Parse(row["rType1Times"].ToString());
				}
				if(row["rType2Times"]!=null && row["rType2Times"].ToString()!="")
				{
					model.rType2Times=int.Parse(row["rType2Times"].ToString());
				}
				if(row["rType3Times"]!=null && row["rType3Times"].ToString()!="")
				{
					model.rType3Times=int.Parse(row["rType3Times"].ToString());
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
			strSql.Append("select id,bsPic,bsRemark,rcId,qd1Id,qd2Id,beginDate,endDate,jcBeginDate,jcEndDate,resultType,rType1Times,rType2Times,rType3Times,createDate ");
            strSql.Append(" FROM wx_sjb_bisai ");
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
			strSql.Append(" id,bsPic,bsRemark,rcId,qd1Id,qd2Id,beginDate,endDate,jcBeginDate,jcEndDate,resultType,rType1Times,rType2Times,rType3Times,createDate ");
			strSql.Append(" FROM wx_sjb_bisai ");
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
			strSql.Append("select count(1) FROM wx_sjb_bisai ");
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
			strSql.Append(")AS Row, T.*  from wx_sjb_bisai T ");
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
			parameters[0].Value = "wx_sjb_bisai";
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
            strSql.Append("select *,'' as status_s ,'' as qd1Name,'' as qd2Name  ");
            strSql.Append(" FROM wx_sjb_bisai ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public bool Updatejg(int id,int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  wx_sjb_bisai ");
            if (type==1)
            {
                strSql.Append(" set resultType=" + type + ",rType1Times=isnull(rType1Times,0)+1 ");
            }
            if (type == 2)
            {
                strSql.Append(" set resultType=" + type + ", rType2Times=isnull(rType2Times,0)+1 ");
            }
            if (type == 3)
            {
                strSql.Append(" set resultType=" + type + ", rType3Times=isnull(rType3Times,0)+1 ");
            }
           
            strSql.Append(" where id=" + id );
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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

