using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_diancai_shop_setup
	/// </summary>
	public partial class wx_diancai_shop_setup
	{
		public wx_diancai_shop_setup()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_diancai_shop_setup"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_diancai_shop_setup");
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
		public int Add(WechatBuilder.Model.wx_diancai_shop_setup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_diancai_shop_setup(");
			strSql.Append("wid,unionManage,unionTel,createDate,shopid)");
			strSql.Append(" values (");
			strSql.Append("@wid,@unionManage,@unionTel,@createDate,@shopid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@unionManage", SqlDbType.VarChar,500),
					new SqlParameter("@unionTel", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@shopid", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.unionManage;
			parameters[2].Value = model.unionTel;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.shopid;

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
		public bool Update(WechatBuilder.Model.wx_diancai_shop_setup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_diancai_shop_setup set ");
			strSql.Append("wid=@wid,");
			strSql.Append("unionManage=@unionManage,");
			strSql.Append("unionTel=@unionTel,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("shopid=@shopid");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@unionManage", SqlDbType.VarChar,500),
					new SqlParameter("@unionTel", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.unionManage;
			parameters[2].Value = model.unionTel;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.shopid;
			parameters[5].Value = model.id;

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
			strSql.Append("delete from wx_diancai_shop_setup ");
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
			strSql.Append("delete from wx_diancai_shop_setup ");
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
		public WechatBuilder.Model.wx_diancai_shop_setup GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,unionManage,unionTel,createDate,shopid from wx_diancai_shop_setup ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_diancai_shop_setup model=new WechatBuilder.Model.wx_diancai_shop_setup();
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
		public WechatBuilder.Model.wx_diancai_shop_setup DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_diancai_shop_setup model=new WechatBuilder.Model.wx_diancai_shop_setup();
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
				if(row["unionManage"]!=null)
				{
					model.unionManage=row["unionManage"].ToString();
				}
				if(row["unionTel"]!=null)
				{
					model.unionTel=row["unionTel"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["shopid"]!=null && row["shopid"].ToString()!="")
				{
					model.shopid=int.Parse(row["shopid"].ToString());
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
			strSql.Append("select id,wid,unionManage,unionTel,createDate,shopid ");
			strSql.Append(" FROM wx_diancai_shop_setup ");
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
			strSql.Append(" id,wid,unionManage,unionTel,createDate,shopid ");
			strSql.Append(" FROM wx_diancai_shop_setup ");
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
			strSql.Append("select count(1) FROM wx_diancai_shop_setup ");
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
			strSql.Append(")AS Row, T.*  from wx_diancai_shop_setup T ");
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
			parameters[0].Value = "wx_diancai_shop_setup";
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

        public DataSet Getsetup(int shopid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,wid,unionManage,unionTel,createDate,shopid ");
            strSql.Append(" FROM wx_diancai_shop_setup where shopid='" + shopid + "' ");

			return DbHelperSQL.Query(strSql.ToString());
		}



        public DataSet GetList(int shopid)
		{
			StringBuilder strSql=new StringBuilder();

		
           strSql.Append(" select aa.id,aa.wid,aa.unionManage,aa.unionTel,bb.advertisementName as advertisementName,bb.picUrl as picUrl,bb.websetUrl as websetUrl");
           strSql.Append(",");
           strSql.Append("bb.sortid as sortid,aa.createDate,shopid  from wx_diancai_shop_advertisement as bb ");
           strSql.Append("right join (select * from wx_diancai_shop_setup where shopid='" + shopid + "') as aa on aa.id=bb.setupid");

			return DbHelperSQL.Query(strSql.ToString());
		}



        public WechatBuilder.Model.wx_diancai_shop_setup GetModelset(int shopid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,unionManage,unionTel,createDate,shopid from wx_diancai_shop_setup ");
            strSql.Append(" where shopid=@shopid");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4)
			};
            parameters[0].Value = shopid;

			WechatBuilder.Model.wx_diancai_shop_setup model=new WechatBuilder.Model.wx_diancai_shop_setup();
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
        

		#endregion  ExtensionMethod
	}
}

