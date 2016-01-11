using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_sjb_jcDetail
	/// </summary>
	public partial class wx_sjb_jcDetail
	{
		public wx_sjb_jcDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_sjb_jcDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_sjb_jcDetail");
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
		public int Add(WechatBuilder.Model.wx_sjb_jcDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_sjb_jcDetail(");
			strSql.Append("uid,rcId,bsId,jcRetType,retIsRight,createDate)");
			strSql.Append(" values (");
			strSql.Append("@uid,@rcId,@bsId,@jcRetType,@retIsRight,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@rcId", SqlDbType.Int,4),
					new SqlParameter("@bsId", SqlDbType.Int,4),
					new SqlParameter("@jcRetType", SqlDbType.Int,4),
					new SqlParameter("@retIsRight", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.rcId;
			parameters[2].Value = model.bsId;
			parameters[3].Value = model.jcRetType;
			parameters[4].Value = model.retIsRight;
			parameters[5].Value = model.createDate;

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
		public bool Update(WechatBuilder.Model.wx_sjb_jcDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_sjb_jcDetail set ");
			strSql.Append("uid=@uid,");
			strSql.Append("rcId=@rcId,");
			strSql.Append("bsId=@bsId,");
			strSql.Append("jcRetType=@jcRetType,");
			strSql.Append("retIsRight=@retIsRight,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@rcId", SqlDbType.Int,4),
					new SqlParameter("@bsId", SqlDbType.Int,4),
					new SqlParameter("@jcRetType", SqlDbType.Int,4),
					new SqlParameter("@retIsRight", SqlDbType.Bit,1),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.rcId;
			parameters[2].Value = model.bsId;
			parameters[3].Value = model.jcRetType;
			parameters[4].Value = model.retIsRight;
			parameters[5].Value = model.createDate;
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
			strSql.Append("delete from wx_sjb_jcDetail ");
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
			strSql.Append("delete from wx_sjb_jcDetail ");
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
		public WechatBuilder.Model.wx_sjb_jcDetail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,uid,rcId,bsId,jcRetType,retIsRight,createDate from wx_sjb_jcDetail ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_sjb_jcDetail model=new WechatBuilder.Model.wx_sjb_jcDetail();
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
		public WechatBuilder.Model.wx_sjb_jcDetail DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_sjb_jcDetail model=new WechatBuilder.Model.wx_sjb_jcDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["rcId"]!=null && row["rcId"].ToString()!="")
				{
					model.rcId=int.Parse(row["rcId"].ToString());
				}
				if(row["bsId"]!=null && row["bsId"].ToString()!="")
				{
					model.bsId=int.Parse(row["bsId"].ToString());
				}
				if(row["jcRetType"]!=null && row["jcRetType"].ToString()!="")
				{
					model.jcRetType=int.Parse(row["jcRetType"].ToString());
				}
				if(row["retIsRight"]!=null && row["retIsRight"].ToString()!="")
				{
					if((row["retIsRight"].ToString()=="1")||(row["retIsRight"].ToString().ToLower()=="true"))
					{
						model.retIsRight=true;
					}
					else
					{
						model.retIsRight=false;
					}
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
			strSql.Append("select id,uid,rcId,bsId,jcRetType,retIsRight,createDate ");
			strSql.Append(" FROM wx_sjb_jcDetail ");
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
			strSql.Append(" id,uid,rcId,bsId,jcRetType,retIsRight,createDate ");
			strSql.Append(" FROM wx_sjb_jcDetail ");
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
			strSql.Append("select count(1) FROM wx_sjb_jcDetail ");
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
			strSql.Append(")AS Row, T.*  from wx_sjb_jcDetail T ");
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
        /// 获取选中结果
        /// </summary>
        public int   GetjcRetType(int bsId,int uId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 jcRetType FROM wx_sjb_jcDetail where uid=@uid and bsId=@bsId");

            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@bsId", SqlDbType.Int,4)
			};
            parameters[0].Value = uId;
            parameters[1].Value = bsId;
 


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }



        public bool UpdateDetail(int richengid, int bisaiid, int resultType)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update wx_sjb_jcDetail set  retIsRight=1 ");
            strSql.Append(" where rcId='" + richengid + "' and  bsId='" + bisaiid + "'  ");
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
		#endregion  ExtensionMethod
	}
}

