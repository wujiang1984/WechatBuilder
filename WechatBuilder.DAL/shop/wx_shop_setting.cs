using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_shop_setting
	/// </summary>
	public partial class wx_shop_setting
	{
		public wx_shop_setting()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_shop_setting"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_shop_setting");
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
		public int Add(WechatBuilder.Model.wx_shop_setting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_shop_setting(");
			strSql.Append("wid,shopName,copyright,logo,bgPic,tel,addr,createDate,extInt,extStr)");
			strSql.Append(" values (");
			strSql.Append("@wid,@shopName,@copyright,@logo,@bgPic,@tel,@addr,@createDate,@extInt,@extStr)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@shopName", SqlDbType.VarChar,200),
					new SqlParameter("@copyright", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,500),
					new SqlParameter("@bgPic", SqlDbType.VarChar,500),
					new SqlParameter("@tel", SqlDbType.VarChar,30),
					new SqlParameter("@addr", SqlDbType.VarChar,300),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,200)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.shopName;
			parameters[2].Value = model.copyright;
			parameters[3].Value = model.logo;
			parameters[4].Value = model.bgPic;
			parameters[5].Value = model.tel;
			parameters[6].Value = model.addr;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.extInt;
			parameters[9].Value = model.extStr;

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
		public bool Update(WechatBuilder.Model.wx_shop_setting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_shop_setting set ");
			strSql.Append("wid=@wid,");
			strSql.Append("shopName=@shopName,");
			strSql.Append("copyright=@copyright,");
			strSql.Append("logo=@logo,");
			strSql.Append("bgPic=@bgPic,");
			strSql.Append("tel=@tel,");
			strSql.Append("addr=@addr,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@shopName", SqlDbType.VarChar,200),
					new SqlParameter("@copyright", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,500),
					new SqlParameter("@bgPic", SqlDbType.VarChar,500),
					new SqlParameter("@tel", SqlDbType.VarChar,30),
					new SqlParameter("@addr", SqlDbType.VarChar,300),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.shopName;
			parameters[2].Value = model.copyright;
			parameters[3].Value = model.logo;
			parameters[4].Value = model.bgPic;
			parameters[5].Value = model.tel;
			parameters[6].Value = model.addr;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.extInt;
			parameters[9].Value = model.extStr;
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
			strSql.Append("delete from wx_shop_setting ");
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
			strSql.Append("delete from wx_shop_setting ");
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
		public WechatBuilder.Model.wx_shop_setting GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,shopName,copyright,logo,bgPic,tel,addr,createDate,extInt,extStr from wx_shop_setting ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_shop_setting model=new WechatBuilder.Model.wx_shop_setting();
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
		public WechatBuilder.Model.wx_shop_setting DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_shop_setting model=new WechatBuilder.Model.wx_shop_setting();
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
				if(row["shopName"]!=null)
				{
					model.shopName=row["shopName"].ToString();
				}
				if(row["copyright"]!=null)
				{
					model.copyright=row["copyright"].ToString();
				}
				if(row["logo"]!=null)
				{
					model.logo=row["logo"].ToString();
				}
				if(row["bgPic"]!=null)
				{
					model.bgPic=row["bgPic"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["addr"]!=null)
				{
					model.addr=row["addr"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,wid,shopName,copyright,logo,bgPic,tel,addr,createDate,extInt,extStr ");
			strSql.Append(" FROM wx_shop_setting ");
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
			strSql.Append(" id,wid,shopName,copyright,logo,bgPic,tel,addr,createDate,extInt,extStr ");
			strSql.Append(" FROM wx_shop_setting ");
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
			strSql.Append("select count(1) FROM wx_shop_setting ");
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
			strSql.Append(")AS Row, T.*  from wx_shop_setting T ");
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
			parameters[0].Value = "wx_shop_setting";
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
        /// 是否存在该记录
        /// </summary>
        public bool ExistsWid(int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_shop_setting");
            strSql.Append(" where wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		#endregion  ExtensionMethod
	}
}

