using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_cards
	/// </summary>
	public partial class wx_cards
	{
		public wx_cards()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_cards"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_cards");
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
		public int Add(WechatBuilder.Model.wx_cards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_cards(");
			strSql.Append("wid,openid,title,backPic,backMusic,backCartoon,characters,copyRight,buttonCharacter,display,name,url,ckCount,zfCount,createDate)");
			strSql.Append(" values (");
			strSql.Append("@wid,@openid,@title,@backPic,@backMusic,@backCartoon,@characters,@copyRight,@buttonCharacter,@display,@name,@url,@ckCount,@zfCount,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,200),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@backPic", SqlDbType.VarChar,500),
					new SqlParameter("@backMusic", SqlDbType.VarChar,600),
					new SqlParameter("@backCartoon", SqlDbType.VarChar,500),
					new SqlParameter("@characters", SqlDbType.VarChar,500),
					new SqlParameter("@copyRight", SqlDbType.VarChar,500),
					new SqlParameter("@buttonCharacter", SqlDbType.VarChar,500),
					new SqlParameter("@display", SqlDbType.Bit,1),
					new SqlParameter("@name", SqlDbType.VarChar,500),
					new SqlParameter("@url", SqlDbType.VarChar,500),
					new SqlParameter("@ckCount", SqlDbType.Int,4),
					new SqlParameter("@zfCount", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.title;
			parameters[3].Value = model.backPic;
			parameters[4].Value = model.backMusic;
			parameters[5].Value = model.backCartoon;
			parameters[6].Value = model.characters;
			parameters[7].Value = model.copyRight;
			parameters[8].Value = model.buttonCharacter;
			parameters[9].Value = model.display;
			parameters[10].Value = model.name;
			parameters[11].Value = model.url;
			parameters[12].Value = model.ckCount;
			parameters[13].Value = model.zfCount;
			parameters[14].Value = model.createDate;

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
		public bool Update(WechatBuilder.Model.wx_cards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_cards set ");
			strSql.Append("wid=@wid,");
			strSql.Append("openid=@openid,");
			strSql.Append("title=@title,");
			strSql.Append("backPic=@backPic,");
			strSql.Append("backMusic=@backMusic,");
			strSql.Append("backCartoon=@backCartoon,");
			strSql.Append("characters=@characters,");
			strSql.Append("copyRight=@copyRight,");
			strSql.Append("buttonCharacter=@buttonCharacter,");
			strSql.Append("display=@display,");
			strSql.Append("name=@name,");
			strSql.Append("url=@url");
			//strSql.Append("ckCount=@ckCount,");
			//strSql.Append("zfCount=@zfCount,");
	        //strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,200),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@backPic", SqlDbType.VarChar,500),
					new SqlParameter("@backMusic", SqlDbType.VarChar,600),
					new SqlParameter("@backCartoon", SqlDbType.VarChar,500),
					new SqlParameter("@characters", SqlDbType.VarChar,500),
					new SqlParameter("@copyRight", SqlDbType.VarChar,500),
					new SqlParameter("@buttonCharacter", SqlDbType.VarChar,500),
					new SqlParameter("@display", SqlDbType.Bit,1),
					new SqlParameter("@name", SqlDbType.VarChar,500),
					new SqlParameter("@url", SqlDbType.VarChar,500),
					//new SqlParameter("@ckCount", SqlDbType.Int,4),
					//new SqlParameter("@zfCount", SqlDbType.Int,4),
					//new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.title;
			parameters[3].Value = model.backPic;
			parameters[4].Value = model.backMusic;
			parameters[5].Value = model.backCartoon;
			parameters[6].Value = model.characters;
			parameters[7].Value = model.copyRight;
			parameters[8].Value = model.buttonCharacter;
			parameters[9].Value = model.display;
			parameters[10].Value = model.name;
			parameters[11].Value = model.url;
			//parameters[12].Value = model.ckCount;
			//parameters[13].Value = model.zfCount;
			//parameters[14].Value = model.createDate;
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
			strSql.Append("delete from wx_cards ");
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
			strSql.Append("delete from wx_cards ");
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
		public WechatBuilder.Model.wx_cards GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,openid,title,backPic,backMusic,backCartoon,characters,copyRight,buttonCharacter,display,name,url,ckCount,zfCount,createDate from wx_cards ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_cards model=new WechatBuilder.Model.wx_cards();
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
		public WechatBuilder.Model.wx_cards DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_cards model=new WechatBuilder.Model.wx_cards();
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
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["backPic"]!=null)
				{
					model.backPic=row["backPic"].ToString();
				}
				if(row["backMusic"]!=null)
				{
					model.backMusic=row["backMusic"].ToString();
				}
				if(row["backCartoon"]!=null)
				{
					model.backCartoon=row["backCartoon"].ToString();
				}
				if(row["characters"]!=null)
				{
					model.characters=row["characters"].ToString();
				}
				if(row["copyRight"]!=null)
				{
					model.copyRight=row["copyRight"].ToString();
				}
				if(row["buttonCharacter"]!=null)
				{
					model.buttonCharacter=row["buttonCharacter"].ToString();
				}
				if(row["display"]!=null && row["display"].ToString()!="")
				{
					if((row["display"].ToString()=="1")||(row["display"].ToString().ToLower()=="true"))
					{
						model.display=true;
					}
					else
					{
						model.display=false;
					}
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["ckCount"]!=null && row["ckCount"].ToString()!="")
				{
					model.ckCount=int.Parse(row["ckCount"].ToString());
				}
				if(row["zfCount"]!=null && row["zfCount"].ToString()!="")
				{
					model.zfCount=int.Parse(row["zfCount"].ToString());
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
			strSql.Append("select id,wid,openid,title,backPic,backMusic,backCartoon,characters,copyRight,buttonCharacter,display,name,url,ckCount,zfCount,createDate ");
			strSql.Append(" FROM wx_cards ");
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
			strSql.Append(" id,wid,openid,title,backPic,backMusic,backCartoon,characters,copyRight,buttonCharacter,display,name,url,ckCount,zfCount,createDate ");
			strSql.Append(" FROM wx_cards ");
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
			strSql.Append("select count(1) FROM wx_cards ");
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
			strSql.Append(")AS Row, T.*  from wx_cards T ");
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
			parameters[0].Value = "wx_cards";
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
            strSql.Append("select id,wid,openid,title,backPic,backMusic,backCartoon,characters,copyRight,buttonCharacter,display,name,url,ckCount,zfCount,createDate ");
            strSql.Append(" FROM wx_cards ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }


            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        public bool update(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  wx_cards set zfCount=isnull(zfCount,0)+1 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool updateck(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  wx_cards set ckCount=isnull(ckCount,0)+1 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		#endregion  ExtensionMethod
	}
}

