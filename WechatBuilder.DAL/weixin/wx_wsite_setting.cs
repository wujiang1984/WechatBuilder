using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_wsite_setting
	/// </summary>
	public partial class wx_wsite_setting
	{
		public wx_wsite_setting()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_wsite_setting"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_wsite_setting");
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
		public int Add(WechatBuilder.Model.wx_wsite_setting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_wsite_setting(");
			strSql.Append("wId,wName,companyName,bgMusic,bgPic,bgDongHuaId,wCopyright,wBrief,remark,phone,addr,addrUrl,email,seo_title,seo_keywords,seo_desc,createDate,extInt,extStr,extStr2)");
			strSql.Append(" values (");
			strSql.Append("@wId,@wName,@companyName,@bgMusic,@bgPic,@bgDongHuaId,@wCopyright,@wBrief,@remark,@phone,@addr,@addrUrl,@email,@seo_title,@seo_keywords,@seo_desc,@createDate,@extInt,@extStr,@extStr2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4),
					new SqlParameter("@wName", SqlDbType.VarChar,500),
					new SqlParameter("@companyName", SqlDbType.VarChar,500),
					new SqlParameter("@bgMusic", SqlDbType.VarChar,800),
					new SqlParameter("@bgPic", SqlDbType.VarChar,800),
					new SqlParameter("@bgDongHuaId", SqlDbType.Int,4),
					new SqlParameter("@wCopyright", SqlDbType.VarChar,500),
					new SqlParameter("@wBrief", SqlDbType.VarChar,500),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@phone", SqlDbType.VarChar,200),
					new SqlParameter("@addr", SqlDbType.VarChar,1000),
					new SqlParameter("@addrUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@seo_title", SqlDbType.VarChar,500),
					new SqlParameter("@seo_keywords", SqlDbType.VarChar,500),
					new SqlParameter("@seo_desc", SqlDbType.VarChar,1000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800)};
			parameters[0].Value = model.wId;
			parameters[1].Value = model.wName;
			parameters[2].Value = model.companyName;
			parameters[3].Value = model.bgMusic;
			parameters[4].Value = model.bgPic;
			parameters[5].Value = model.bgDongHuaId;
			parameters[6].Value = model.wCopyright;
			parameters[7].Value = model.wBrief;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.phone;
			parameters[10].Value = model.addr;
			parameters[11].Value = model.addrUrl;
			parameters[12].Value = model.email;
			parameters[13].Value = model.seo_title;
			parameters[14].Value = model.seo_keywords;
			parameters[15].Value = model.seo_desc;
			parameters[16].Value = model.createDate;
			parameters[17].Value = model.extInt;
			parameters[18].Value = model.extStr;
			parameters[19].Value = model.extStr2;

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
		public bool Update(WechatBuilder.Model.wx_wsite_setting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_wsite_setting set ");
			strSql.Append("wId=@wId,");
			strSql.Append("wName=@wName,");
			strSql.Append("companyName=@companyName,");
			strSql.Append("bgMusic=@bgMusic,");
			strSql.Append("bgPic=@bgPic,");
			strSql.Append("bgDongHuaId=@bgDongHuaId,");
			strSql.Append("wCopyright=@wCopyright,");
			strSql.Append("wBrief=@wBrief,");
			strSql.Append("remark=@remark,");
			strSql.Append("phone=@phone,");
			strSql.Append("addr=@addr,");
			strSql.Append("addrUrl=@addrUrl,");
			strSql.Append("email=@email,");
			strSql.Append("seo_title=@seo_title,");
			strSql.Append("seo_keywords=@seo_keywords,");
			strSql.Append("seo_desc=@seo_desc,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4),
					new SqlParameter("@wName", SqlDbType.VarChar,500),
					new SqlParameter("@companyName", SqlDbType.VarChar,500),
					new SqlParameter("@bgMusic", SqlDbType.VarChar,800),
					new SqlParameter("@bgPic", SqlDbType.VarChar,800),
					new SqlParameter("@bgDongHuaId", SqlDbType.Int,4),
					new SqlParameter("@wCopyright", SqlDbType.VarChar,500),
					new SqlParameter("@wBrief", SqlDbType.VarChar,500),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@phone", SqlDbType.VarChar,200),
					new SqlParameter("@addr", SqlDbType.VarChar,1000),
					new SqlParameter("@addrUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@seo_title", SqlDbType.VarChar,500),
					new SqlParameter("@seo_keywords", SqlDbType.VarChar,500),
					new SqlParameter("@seo_desc", SqlDbType.VarChar,1000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wId;
			parameters[1].Value = model.wName;
			parameters[2].Value = model.companyName;
			parameters[3].Value = model.bgMusic;
			parameters[4].Value = model.bgPic;
			parameters[5].Value = model.bgDongHuaId;
			parameters[6].Value = model.wCopyright;
			parameters[7].Value = model.wBrief;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.phone;
			parameters[10].Value = model.addr;
			parameters[11].Value = model.addrUrl;
			parameters[12].Value = model.email;
			parameters[13].Value = model.seo_title;
			parameters[14].Value = model.seo_keywords;
			parameters[15].Value = model.seo_desc;
			parameters[16].Value = model.createDate;
			parameters[17].Value = model.extInt;
			parameters[18].Value = model.extStr;
			parameters[19].Value = model.extStr2;
			parameters[20].Value = model.id;

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
			strSql.Append("delete from wx_wsite_setting ");
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
			strSql.Append("delete from wx_wsite_setting ");
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
		public WechatBuilder.Model.wx_wsite_setting GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wId,wName,companyName,bgMusic,bgPic,bgDongHuaId,wCopyright,wBrief,remark,phone,addr,addrUrl,email,seo_title,seo_keywords,seo_desc,createDate,extInt,extStr,extStr2 from wx_wsite_setting ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_wsite_setting model=new WechatBuilder.Model.wx_wsite_setting();
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
		public WechatBuilder.Model.wx_wsite_setting DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_wsite_setting model=new WechatBuilder.Model.wx_wsite_setting();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wId"]!=null && row["wId"].ToString()!="")
				{
					model.wId=int.Parse(row["wId"].ToString());
				}
				if(row["wName"]!=null)
				{
					model.wName=row["wName"].ToString();
				}
				if(row["companyName"]!=null)
				{
					model.companyName=row["companyName"].ToString();
				}
				if(row["bgMusic"]!=null)
				{
					model.bgMusic=row["bgMusic"].ToString();
				}
				if(row["bgPic"]!=null)
				{
					model.bgPic=row["bgPic"].ToString();
				}
				if(row["bgDongHuaId"]!=null && row["bgDongHuaId"].ToString()!="")
				{
					model.bgDongHuaId=int.Parse(row["bgDongHuaId"].ToString());
				}
				if(row["wCopyright"]!=null)
				{
					model.wCopyright=row["wCopyright"].ToString();
				}
				if(row["wBrief"]!=null)
				{
					model.wBrief=row["wBrief"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["addr"]!=null)
				{
					model.addr=row["addr"].ToString();
				}
				if(row["addrUrl"]!=null)
				{
					model.addrUrl=row["addrUrl"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["seo_title"]!=null)
				{
					model.seo_title=row["seo_title"].ToString();
				}
				if(row["seo_keywords"]!=null)
				{
					model.seo_keywords=row["seo_keywords"].ToString();
				}
				if(row["seo_desc"]!=null)
				{
					model.seo_desc=row["seo_desc"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["extStr2"]!=null)
				{
					model.extStr2=row["extStr2"].ToString();
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
			strSql.Append("select id,wId,wName,companyName,bgMusic,bgPic,bgDongHuaId,wCopyright,wBrief,remark,phone,addr,addrUrl,email,seo_title,seo_keywords,seo_desc,createDate,extInt,extStr,extStr2 ");
			strSql.Append(" FROM wx_wsite_setting ");
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
			strSql.Append(" id,wId,wName,companyName,bgMusic,bgPic,bgDongHuaId,wCopyright,wBrief,remark,phone,addr,addrUrl,email,seo_title,seo_keywords,seo_desc,createDate,extInt,extStr,extStr2 ");
			strSql.Append(" FROM wx_wsite_setting ");
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
			strSql.Append("select count(1) FROM wx_wsite_setting ");
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
			strSql.Append(")AS Row, T.*  from wx_wsite_setting T ");
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
			parameters[0].Value = "wx_wsite_setting";
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
        /// 通过wid获得该微帐号的站点信息
        /// </summary>
        public WechatBuilder.Model.wx_wsite_setting GetModelByWid(int wid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wId,wName,companyName,bgMusic,bgPic,bgDongHuaId,wCopyright,wBrief,remark,phone,addr,addrUrl,email,seo_title,seo_keywords,seo_desc,createDate,extInt,extStr,extStr2 from wx_wsite_setting ");
            strSql.Append(" where wId=@wId");
            SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;

            WechatBuilder.Model.wx_wsite_setting model = new WechatBuilder.Model.wx_wsite_setting();
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

