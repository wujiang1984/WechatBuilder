using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_ucard_score
	/// </summary>
	public partial class wx_ucard_score
	{
		public wx_ucard_score()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_ucard_score"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_ucard_score");
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
		public int Add(WechatBuilder.Model.wx_ucard_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_ucard_score(");
			strSql.Append("wid,userdContent,scoreRegular,qiandaoScore,qiandao6Score,consumeMoney,consumeMoneyScore,sId)");
			strSql.Append(" values (");
			strSql.Append("@wid,@userdContent,@scoreRegular,@qiandaoScore,@qiandao6Score,@consumeMoney,@consumeMoneyScore,@sId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@userdContent", SqlDbType.VarChar,1500),
					new SqlParameter("@scoreRegular", SqlDbType.VarChar,1500),
					new SqlParameter("@qiandaoScore", SqlDbType.Int,4),
					new SqlParameter("@qiandao6Score", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Int,4),
					new SqlParameter("@consumeMoneyScore", SqlDbType.Int,4),
					new SqlParameter("@sId", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.userdContent;
			parameters[2].Value = model.scoreRegular;
			parameters[3].Value = model.qiandaoScore;
			parameters[4].Value = model.qiandao6Score;
			parameters[5].Value = model.consumeMoney;
			parameters[6].Value = model.consumeMoneyScore;
			parameters[7].Value = model.sId;

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
		public bool Update(WechatBuilder.Model.wx_ucard_score model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_ucard_score set ");
			strSql.Append("wid=@wid,");
			strSql.Append("userdContent=@userdContent,");
			strSql.Append("scoreRegular=@scoreRegular,");
			strSql.Append("qiandaoScore=@qiandaoScore,");
			strSql.Append("qiandao6Score=@qiandao6Score,");
			strSql.Append("consumeMoney=@consumeMoney,");
			strSql.Append("consumeMoneyScore=@consumeMoneyScore,");
			strSql.Append("sId=@sId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@userdContent", SqlDbType.VarChar,1500),
					new SqlParameter("@scoreRegular", SqlDbType.VarChar,1500),
					new SqlParameter("@qiandaoScore", SqlDbType.Int,4),
					new SqlParameter("@qiandao6Score", SqlDbType.Int,4),
					new SqlParameter("@consumeMoney", SqlDbType.Int,4),
					new SqlParameter("@consumeMoneyScore", SqlDbType.Int,4),
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.userdContent;
			parameters[2].Value = model.scoreRegular;
			parameters[3].Value = model.qiandaoScore;
			parameters[4].Value = model.qiandao6Score;
			parameters[5].Value = model.consumeMoney;
			parameters[6].Value = model.consumeMoneyScore;
			parameters[7].Value = model.sId;
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
			strSql.Append("delete from wx_ucard_score ");
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
			strSql.Append("delete from wx_ucard_score ");
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
		public WechatBuilder.Model.wx_ucard_score GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,userdContent,scoreRegular,qiandaoScore,qiandao6Score,consumeMoney,consumeMoneyScore,sId from wx_ucard_score ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_ucard_score model=new WechatBuilder.Model.wx_ucard_score();
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
		public WechatBuilder.Model.wx_ucard_score DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_ucard_score model=new WechatBuilder.Model.wx_ucard_score();
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
				if(row["userdContent"]!=null)
				{
					model.userdContent=row["userdContent"].ToString();
				}
				if(row["scoreRegular"]!=null)
				{
					model.scoreRegular=row["scoreRegular"].ToString();
				}
				if(row["qiandaoScore"]!=null && row["qiandaoScore"].ToString()!="")
				{
					model.qiandaoScore=int.Parse(row["qiandaoScore"].ToString());
				}
				if(row["qiandao6Score"]!=null && row["qiandao6Score"].ToString()!="")
				{
					model.qiandao6Score=int.Parse(row["qiandao6Score"].ToString());
				}
				if(row["consumeMoney"]!=null && row["consumeMoney"].ToString()!="")
				{
					model.consumeMoney=int.Parse(row["consumeMoney"].ToString());
				}
				if(row["consumeMoneyScore"]!=null && row["consumeMoneyScore"].ToString()!="")
				{
					model.consumeMoneyScore=int.Parse(row["consumeMoneyScore"].ToString());
				}
				if(row["sId"]!=null && row["sId"].ToString()!="")
				{
					model.sId=int.Parse(row["sId"].ToString());
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
			strSql.Append("select id,wid,userdContent,scoreRegular,qiandaoScore,qiandao6Score,consumeMoney,consumeMoneyScore,sId ");
			strSql.Append(" FROM wx_ucard_score ");
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
			strSql.Append(" id,wid,userdContent,scoreRegular,qiandaoScore,qiandao6Score,consumeMoney,consumeMoneyScore,sId ");
			strSql.Append(" FROM wx_ucard_score ");
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
			strSql.Append("select count(1) FROM wx_ucard_score ");
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
			strSql.Append(")AS Row, T.*  from wx_ucard_score T ");
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

        public int GetStoreQDScore(int sid, string strWhere)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id from wx_ucard_score  ");
            strSql.Append(" where sId=" + sid);
            if (strWhere != null && strWhere.Length > 0)
            {
                strSql.Append(" and " + strWhere);
            }
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString());

            while (sr.Read())
            {
                ret = int.Parse(sr["id"].ToString());
            }
            sr.Close();

            return ret;
        }

        /// <summary>
        /// 店铺的积分规则
        /// </summary>
        public WechatBuilder.Model.wx_ucard_score GetStoreModel(int sId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,userdContent,scoreRegular,qiandaoScore,qiandao6Score,consumeMoney,consumeMoneyScore,sId from wx_ucard_score ");
            strSql.Append(" where sId=@sId");
            SqlParameter[] parameters = {
					new SqlParameter("@sId", SqlDbType.Int,4)
			};
            parameters[0].Value = sId;

            WechatBuilder.Model.wx_ucard_score model = new WechatBuilder.Model.wx_ucard_score();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
		#endregion  ExtensionMethod
	}
}

