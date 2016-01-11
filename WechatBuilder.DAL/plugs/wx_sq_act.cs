using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_sq_act
	/// </summary>
	public partial class wx_sq_act
	{
		public wx_sq_act()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_sq_act"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_sq_act");
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
		public int Add(WechatBuilder.Model.wx_sq_act model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_sq_act(");
			strSql.Append("wid,isOpen,actName,brief,shenghe,noshengheTip,shengheTip,bannerPic,endDate,beginDate,createDate,sort_id)");
			strSql.Append(" values (");
			strSql.Append("@wid,@isOpen,@actName,@brief,@shenghe,@noshengheTip,@shengheTip,@bannerPic,@endDate,@beginDate,@createDate,@sort_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@isOpen", SqlDbType.Bit,1),
					new SqlParameter("@actName", SqlDbType.VarChar,200),
					new SqlParameter("@brief", SqlDbType.VarChar,500),
					new SqlParameter("@shenghe", SqlDbType.Bit,1),
					new SqlParameter("@noshengheTip", SqlDbType.VarChar,500),
					new SqlParameter("@shengheTip", SqlDbType.VarChar,500),
					new SqlParameter("@bannerPic", SqlDbType.VarChar,800),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.isOpen;
			parameters[2].Value = model.actName;
			parameters[3].Value = model.brief;
			parameters[4].Value = model.shenghe;
			parameters[5].Value = model.noshengheTip;
			parameters[6].Value = model.shengheTip;
			parameters[7].Value = model.bannerPic;
			parameters[8].Value = model.endDate;
			parameters[9].Value = model.beginDate;
			parameters[10].Value = model.createDate;
			parameters[11].Value = model.sort_id;

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
		public bool Update(WechatBuilder.Model.wx_sq_act model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_sq_act set ");
			strSql.Append("wid=@wid,");
			strSql.Append("isOpen=@isOpen,");
			strSql.Append("actName=@actName,");
			strSql.Append("brief=@brief,");
			strSql.Append("shenghe=@shenghe,");
			strSql.Append("noshengheTip=@noshengheTip,");
			strSql.Append("shengheTip=@shengheTip,");
			strSql.Append("bannerPic=@bannerPic,");
			strSql.Append("endDate=@endDate,");
			strSql.Append("beginDate=@beginDate,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("sort_id=@sort_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@isOpen", SqlDbType.Bit,1),
					new SqlParameter("@actName", SqlDbType.VarChar,200),
					new SqlParameter("@brief", SqlDbType.VarChar,500),
					new SqlParameter("@shenghe", SqlDbType.Bit,1),
					new SqlParameter("@noshengheTip", SqlDbType.VarChar,500),
					new SqlParameter("@shengheTip", SqlDbType.VarChar,500),
					new SqlParameter("@bannerPic", SqlDbType.VarChar,800),
					new SqlParameter("@endDate", SqlDbType.DateTime),
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.isOpen;
			parameters[2].Value = model.actName;
			parameters[3].Value = model.brief;
			parameters[4].Value = model.shenghe;
			parameters[5].Value = model.noshengheTip;
			parameters[6].Value = model.shengheTip;
			parameters[7].Value = model.bannerPic;
			parameters[8].Value = model.endDate;
			parameters[9].Value = model.beginDate;
			parameters[10].Value = model.createDate;
			parameters[11].Value = model.sort_id;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from wx_sq_act ");
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
			strSql.Append("delete from wx_sq_act ");
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
		public WechatBuilder.Model.wx_sq_act GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,isOpen,actName,brief,shenghe,noshengheTip,shengheTip,bannerPic,endDate,beginDate,createDate,sort_id from wx_sq_act ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_sq_act model=new WechatBuilder.Model.wx_sq_act();
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
		public WechatBuilder.Model.wx_sq_act DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_sq_act model=new WechatBuilder.Model.wx_sq_act();
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
				if(row["isOpen"]!=null && row["isOpen"].ToString()!="")
				{
					if((row["isOpen"].ToString()=="1")||(row["isOpen"].ToString().ToLower()=="true"))
					{
						model.isOpen=true;
					}
					else
					{
						model.isOpen=false;
					}
				}
				if(row["actName"]!=null)
				{
					model.actName=row["actName"].ToString();
				}
				if(row["brief"]!=null)
				{
					model.brief=row["brief"].ToString();
				}
				if(row["shenghe"]!=null && row["shenghe"].ToString()!="")
				{
					if((row["shenghe"].ToString()=="1")||(row["shenghe"].ToString().ToLower()=="true"))
					{
						model.shenghe=true;
					}
					else
					{
						model.shenghe=false;
					}
				}
				if(row["noshengheTip"]!=null)
				{
					model.noshengheTip=row["noshengheTip"].ToString();
				}
				if(row["shengheTip"]!=null)
				{
					model.shengheTip=row["shengheTip"].ToString();
				}
				if(row["bannerPic"]!=null)
				{
					model.bannerPic=row["bannerPic"].ToString();
				}
				if(row["endDate"]!=null && row["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(row["endDate"].ToString());
				}
				if(row["beginDate"]!=null && row["beginDate"].ToString()!="")
				{
					model.beginDate=DateTime.Parse(row["beginDate"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
			}
			return model;
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
			strSql.Append(" id,wid,isOpen,actName,brief,shenghe,noshengheTip,shengheTip,bannerPic,endDate,beginDate,createDate,sort_id ");
			strSql.Append(" FROM wx_sq_act ");
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
			strSql.Append("select count(1) FROM wx_sq_act ");
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
			strSql.Append(")AS Row, T.*  from wx_sq_act T ");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,isOpen,actName,brief,shenghe,noshengheTip,shengheTip,bannerPic,endDate,beginDate,createDate,sort_id,link_url='' ");
            strSql.Append(" FROM wx_sq_act ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_sq_act  set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 判断该时间段已经已经被设置了
        /// </summary>
        /// <param name="wid">微帐号id</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束</param>
        /// <returns>占用了，则返回true,否则返回false</returns>
        public bool hasZYDateSet(int id,int wid, DateTime begin, DateTime end)
        {
            bool noDate = true;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from wx_sq_act where wid=" + wid + " and beginDate <='" + end + "' and endDate>='" + begin + "' and isOpen=1 and id!="+id);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                noDate = true;
            }
            else
            {
                noDate = false;
            }
            return noDate;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WechatBuilder.Model.wx_sq_act GetModel(int wid,DateTime nowDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,isOpen,actName,brief,shenghe,noshengheTip,shengheTip,bannerPic,endDate,beginDate,createDate,sort_id from wx_sq_act ");
            strSql.Append(" where wid=@wid and  beginDate<'" + nowDate.ToString() + "' and endDate>'" + nowDate.ToString() + "' and isOpen=1");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;

            WechatBuilder.Model.wx_sq_act model = new WechatBuilder.Model.wx_sq_act();
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

