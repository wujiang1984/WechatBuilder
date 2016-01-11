using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_shop_user_addr
	/// </summary>
	public partial class wx_shop_user_addr
	{
		public wx_shop_user_addr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_shop_user_addr"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_shop_user_addr");
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
		public int Add(WechatBuilder.Model.wx_shop_user_addr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_shop_user_addr(");
			strSql.Append("wid,openid,province,city,area,addrDetail,tel,jiedao,contractPerson,createDate)");
			strSql.Append(" values (");
			strSql.Append("@wid,@openid,@province,@city,@area,@addrDetail,@tel,@jiedao,@contractPerson,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,50),
					new SqlParameter("@city", SqlDbType.VarChar,50),
					new SqlParameter("@area", SqlDbType.VarChar,100),
					new SqlParameter("@addrDetail", SqlDbType.VarChar,200),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@jiedao", SqlDbType.VarChar,100),
					new SqlParameter("@contractPerson", SqlDbType.VarChar,30),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.province;
			parameters[3].Value = model.city;
			parameters[4].Value = model.area;
			parameters[5].Value = model.addrDetail;
			parameters[6].Value = model.tel;
			parameters[7].Value = model.jiedao;
			parameters[8].Value = model.contractPerson;
			parameters[9].Value = model.createDate;

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
		public bool Update(WechatBuilder.Model.wx_shop_user_addr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_shop_user_addr set ");
			strSql.Append("wid=@wid,");
			strSql.Append("openid=@openid,");
			strSql.Append("province=@province,");
			strSql.Append("city=@city,");
			strSql.Append("area=@area,");
			strSql.Append("addrDetail=@addrDetail,");
			strSql.Append("tel=@tel,");
			strSql.Append("jiedao=@jiedao,");
			strSql.Append("contractPerson=@contractPerson,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,50),
					new SqlParameter("@city", SqlDbType.VarChar,50),
					new SqlParameter("@area", SqlDbType.VarChar,100),
					new SqlParameter("@addrDetail", SqlDbType.VarChar,200),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@jiedao", SqlDbType.VarChar,100),
					new SqlParameter("@contractPerson", SqlDbType.VarChar,30),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.province;
			parameters[3].Value = model.city;
			parameters[4].Value = model.area;
			parameters[5].Value = model.addrDetail;
			parameters[6].Value = model.tel;
			parameters[7].Value = model.jiedao;
			parameters[8].Value = model.contractPerson;
			parameters[9].Value = model.createDate;
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
			strSql.Append("delete from wx_shop_user_addr ");
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
			strSql.Append("delete from wx_shop_user_addr ");
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
		public WechatBuilder.Model.wx_shop_user_addr GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,openid,province,city,area,addrDetail,tel,jiedao,contractPerson,createDate from wx_shop_user_addr ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_shop_user_addr model=new WechatBuilder.Model.wx_shop_user_addr();
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
		public WechatBuilder.Model.wx_shop_user_addr DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_shop_user_addr model=new WechatBuilder.Model.wx_shop_user_addr();
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
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["province"]!=null)
				{
					model.province=row["province"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["area"]!=null)
				{
					model.area=row["area"].ToString();
				}
				if(row["addrDetail"]!=null)
				{
					model.addrDetail=row["addrDetail"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["jiedao"]!=null)
				{
					model.jiedao=row["jiedao"].ToString();
				}
				if(row["contractPerson"]!=null)
				{
					model.contractPerson=row["contractPerson"].ToString();
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
			strSql.Append("select id,wid,openid,province,city,area,addrDetail,tel,jiedao,contractPerson,createDate ");
			strSql.Append(" FROM wx_shop_user_addr ");
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
			strSql.Append(" id,wid,openid,province,city,area,addrDetail,tel,jiedao,contractPerson,createDate ");
			strSql.Append(" FROM wx_shop_user_addr ");
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
			strSql.Append("select count(1) FROM wx_shop_user_addr ");
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
		 
		#endregion  BasicMethod
		#region  ExtensionMethod


        /// <summary>
        /// 获得微信用户的地址
        /// </summary>
        public DataSet GetOpenidAddr(string openid,int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,openid,province,city,area,addrDetail,tel,jiedao,contractPerson,createDate ");
            strSql.Append(" FROM wx_shop_user_addr where openid=@openid and wid=@wid ");

            SqlParameter[] parameters = {
                    new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = openid;
            parameters[1].Value = wid;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得微信用户的地址(把省份，城市，区域的名字展示出来)
        /// </summary>
        public DataSet GetOpenidAddrName(string openid, int wid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wid,openid,(select name from pre_common_district where id=a.province) province,(select name from pre_common_district where id=a.city) city,(select name from pre_common_district where id=a.area) area,addrDetail,tel,jiedao,contractPerson,createDate ");
            strSql.Append(" FROM wx_shop_user_addr a where openid=@openid and wid=@wid ");

            SqlParameter[] parameters = {
                    new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = openid;
            parameters[1].Value = wid;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

		#endregion  ExtensionMethod
	}
}

