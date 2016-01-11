using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_pano_jd
	/// </summary>
	public partial class wx_pano_jd
	{
		public wx_pano_jd()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_pano_jd"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_pano_jd");
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
		public int Add(WechatBuilder.Model.wx_pano_jd model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_pano_jd(");
			strSql.Append("sysId,wid,jdName,music,pic_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,extStr,extStr2)");
			strSql.Append(" values (");
			strSql.Append("@sysId,@wid,@jdName,@music,@pic_front,@pic_right,@pic_behind,@pic_left,@pic_top,@pic_bottom,@pic_yulan,@remark,@seq,@createDate,@extStr,@extStr2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@sysId", SqlDbType.Int,4),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@jdName", SqlDbType.VarChar,100),
					new SqlParameter("@music", SqlDbType.VarChar,800),
					new SqlParameter("@pic_front", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_right", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_behind", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_left", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_top", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_bottom", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_yulan", SqlDbType.VarChar,1000),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extStr", SqlDbType.VarChar,800),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.sysId;
			parameters[1].Value = model.wid;
			parameters[2].Value = model.jdName;
			parameters[3].Value = model.music;
			parameters[4].Value = model.pic_front;
			parameters[5].Value = model.pic_right;
			parameters[6].Value = model.pic_behind;
			parameters[7].Value = model.pic_left;
			parameters[8].Value = model.pic_top;
			parameters[9].Value = model.pic_bottom;
			parameters[10].Value = model.pic_yulan;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.seq;
			parameters[13].Value = model.createDate;
			parameters[14].Value = model.extStr;
			parameters[15].Value = model.extStr2;

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
		public bool Update(WechatBuilder.Model.wx_pano_jd model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_pano_jd set ");
			strSql.Append("sysId=@sysId,");
			strSql.Append("wid=@wid,");
			strSql.Append("jdName=@jdName,");
			strSql.Append("music=@music,");
			strSql.Append("pic_front=@pic_front,");
			strSql.Append("pic_right=@pic_right,");
			strSql.Append("pic_behind=@pic_behind,");
			strSql.Append("pic_left=@pic_left,");
			strSql.Append("pic_top=@pic_top,");
			strSql.Append("pic_bottom=@pic_bottom,");
			strSql.Append("pic_yulan=@pic_yulan,");
			strSql.Append("remark=@remark,");
			strSql.Append("seq=@seq,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("extStr2=@extStr2");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sysId", SqlDbType.Int,4),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@jdName", SqlDbType.VarChar,100),
					new SqlParameter("@music", SqlDbType.VarChar,800),
					new SqlParameter("@pic_front", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_right", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_behind", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_left", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_top", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_bottom", SqlDbType.VarChar,1000),
					new SqlParameter("@pic_yulan", SqlDbType.VarChar,1000),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extStr", SqlDbType.VarChar,800),
					new SqlParameter("@extStr2", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sysId;
			parameters[1].Value = model.wid;
			parameters[2].Value = model.jdName;
			parameters[3].Value = model.music;
			parameters[4].Value = model.pic_front;
			parameters[5].Value = model.pic_right;
			parameters[6].Value = model.pic_behind;
			parameters[7].Value = model.pic_left;
			parameters[8].Value = model.pic_top;
			parameters[9].Value = model.pic_bottom;
			parameters[10].Value = model.pic_yulan;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.seq;
			parameters[13].Value = model.createDate;
			parameters[14].Value = model.extStr;
			parameters[15].Value = model.extStr2;
			parameters[16].Value = model.id;

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
			strSql.Append("delete from wx_pano_jd ");
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
			strSql.Append("delete from wx_pano_jd ");
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
		public WechatBuilder.Model.wx_pano_jd GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sysId,wid,jdName,music,pic_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,extStr,extStr2 from wx_pano_jd ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_pano_jd model=new WechatBuilder.Model.wx_pano_jd();
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
		public WechatBuilder.Model.wx_pano_jd DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_pano_jd model=new WechatBuilder.Model.wx_pano_jd();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sysId"]!=null && row["sysId"].ToString()!="")
				{
					model.sysId=int.Parse(row["sysId"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["jdName"]!=null)
				{
					model.jdName=row["jdName"].ToString();
				}
				if(row["music"]!=null)
				{
					model.music=row["music"].ToString();
				}
				if(row["pic_front"]!=null)
				{
					model.pic_front=row["pic_front"].ToString();
				}
				if(row["pic_right"]!=null)
				{
					model.pic_right=row["pic_right"].ToString();
				}
				if(row["pic_behind"]!=null)
				{
					model.pic_behind=row["pic_behind"].ToString();
				}
				if(row["pic_left"]!=null)
				{
					model.pic_left=row["pic_left"].ToString();
				}
				if(row["pic_top"]!=null)
				{
					model.pic_top=row["pic_top"].ToString();
				}
				if(row["pic_bottom"]!=null)
				{
					model.pic_bottom=row["pic_bottom"].ToString();
				}
				if(row["pic_yulan"]!=null)
				{
					model.pic_yulan=row["pic_yulan"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
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
			strSql.Append("select id,sysId,wid,jdName,music,pic_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,extStr,extStr2 ");
			strSql.Append(" FROM wx_pano_jd ");
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
			strSql.Append(" id,sysId,wid,jdName,music,pic_front,pic_right,pic_behind,pic_left,pic_top,pic_bottom,pic_yulan,remark,seq,createDate,extStr,extStr2 ");
			strSql.Append(" FROM wx_pano_jd ");
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
			strSql.Append("select count(1) FROM wx_pano_jd ");
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
			strSql.Append(")AS Row, T.*  from wx_pano_jd T ");
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
			parameters[0].Value = "wx_pano_jd";
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from wx_pano_jd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  ExtensionMethod
	}
}

