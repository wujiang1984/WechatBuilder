using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;
using System.Collections.Generic;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_lbs_shopInfo
	/// </summary>
	public partial class wx_lbs_shopInfo
	{
		public wx_lbs_shopInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_lbs_shopInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_lbs_shopInfo");
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
		public int Add(WechatBuilder.Model.wx_lbs_shopInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_lbs_shopInfo(");
			strSql.Append("wid,shopName,telphone,brief,shopContent,shopLogo,province,city,detailAddr,xPoint,yPoint,wUrl,seq,remark,createDate)");
			strSql.Append(" values (");
			strSql.Append("@wid,@shopName,@telphone,@brief,@shopContent,@shopLogo,@province,@city,@detailAddr,@xPoint,@yPoint,@wUrl,@seq,@remark,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@shopName", SqlDbType.VarChar,400),
					new SqlParameter("@telphone", SqlDbType.VarChar,30),
					new SqlParameter("@brief", SqlDbType.VarChar,500),
					new SqlParameter("@shopContent", SqlDbType.VarChar,2000),
					new SqlParameter("@shopLogo", SqlDbType.VarChar,500),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@detailAddr", SqlDbType.VarChar,1000),
					new SqlParameter("@xPoint", SqlDbType.Float,8),
					new SqlParameter("@yPoint", SqlDbType.Float,8),
					new SqlParameter("@wUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,4000),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.shopName;
			parameters[2].Value = model.telphone;
			parameters[3].Value = model.brief;
			parameters[4].Value = model.shopContent;
			parameters[5].Value = model.shopLogo;
			parameters[6].Value = model.province;
			parameters[7].Value = model.city;
			parameters[8].Value = model.detailAddr;
			parameters[9].Value = model.xPoint;
			parameters[10].Value = model.yPoint;
			parameters[11].Value = model.wUrl;
			parameters[12].Value = model.seq;
			parameters[13].Value = model.remark;
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
		public bool Update(WechatBuilder.Model.wx_lbs_shopInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_lbs_shopInfo set ");
			strSql.Append("wid=@wid,");
			strSql.Append("shopName=@shopName,");
			strSql.Append("telphone=@telphone,");
			strSql.Append("brief=@brief,");
			strSql.Append("shopContent=@shopContent,");
			strSql.Append("shopLogo=@shopLogo,");
			strSql.Append("province=@province,");
			strSql.Append("city=@city,");
			strSql.Append("detailAddr=@detailAddr,");
			strSql.Append("xPoint=@xPoint,");
			strSql.Append("yPoint=@yPoint,");
			strSql.Append("wUrl=@wUrl,");
			strSql.Append("seq=@seq,");
			strSql.Append("remark=@remark,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@shopName", SqlDbType.VarChar,400),
					new SqlParameter("@telphone", SqlDbType.VarChar,30),
					new SqlParameter("@brief", SqlDbType.VarChar,500),
					new SqlParameter("@shopContent", SqlDbType.VarChar,2000),
					new SqlParameter("@shopLogo", SqlDbType.VarChar,500),
					new SqlParameter("@province", SqlDbType.VarChar,100),
					new SqlParameter("@city", SqlDbType.VarChar,100),
					new SqlParameter("@detailAddr", SqlDbType.VarChar,1000),
					new SqlParameter("@xPoint", SqlDbType.Float,8),
					new SqlParameter("@yPoint", SqlDbType.Float,8),
					new SqlParameter("@wUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,4000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.shopName;
			parameters[2].Value = model.telphone;
			parameters[3].Value = model.brief;
			parameters[4].Value = model.shopContent;
			parameters[5].Value = model.shopLogo;
			parameters[6].Value = model.province;
			parameters[7].Value = model.city;
			parameters[8].Value = model.detailAddr;
			parameters[9].Value = model.xPoint;
			parameters[10].Value = model.yPoint;
			parameters[11].Value = model.wUrl;
			parameters[12].Value = model.seq;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.createDate;
			parameters[15].Value = model.id;

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
			strSql.Append("delete from wx_lbs_shopInfo ");
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
			strSql.Append("delete from wx_lbs_shopInfo ");
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
		public WechatBuilder.Model.wx_lbs_shopInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,shopName,telphone,brief,shopContent,shopLogo,province,city,detailAddr,xPoint,yPoint,wUrl,seq,remark,createDate from wx_lbs_shopInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_lbs_shopInfo model=new WechatBuilder.Model.wx_lbs_shopInfo();
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
		public WechatBuilder.Model.wx_lbs_shopInfo DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_lbs_shopInfo model=new WechatBuilder.Model.wx_lbs_shopInfo();
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
				if(row["telphone"]!=null)
				{
					model.telphone=row["telphone"].ToString();
				}
				if(row["brief"]!=null)
				{
					model.brief=row["brief"].ToString();
				}
				if(row["shopContent"]!=null)
				{
					model.shopContent=row["shopContent"].ToString();
				}
				if(row["shopLogo"]!=null)
				{
					model.shopLogo=row["shopLogo"].ToString();
				}
				if(row["province"]!=null)
				{
					model.province=row["province"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["detailAddr"]!=null)
				{
					model.detailAddr=row["detailAddr"].ToString();
				}
				if(row["xPoint"]!=null && row["xPoint"].ToString()!="")
				{
					model.xPoint=decimal.Parse(row["xPoint"].ToString());
				}
				if(row["yPoint"]!=null && row["yPoint"].ToString()!="")
				{
					model.yPoint=decimal.Parse(row["yPoint"].ToString());
				}
				if(row["wUrl"]!=null)
				{
					model.wUrl=row["wUrl"].ToString();
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select id,wid,shopName,telphone,brief,shopContent,shopLogo,province,city,detailAddr,xPoint,yPoint,wUrl,seq,remark,createDate ");
			strSql.Append(" FROM wx_lbs_shopInfo ");
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
			strSql.Append(" id,wid,shopName,telphone,brief,shopContent,shopLogo,province,city,detailAddr,xPoint,yPoint,wUrl,seq,remark,createDate ");
			strSql.Append(" FROM wx_lbs_shopInfo ");
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
			strSql.Append("select count(1) FROM wx_lbs_shopInfo ");
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
			strSql.Append(")AS Row, T.*  from wx_lbs_shopInfo T ");
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
			parameters[0].Value = "wx_lbs_shopInfo";
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
            strSql.Append("select * FROM  wx_lbs_shopInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }




        /// <summary>
        /// 获得包括城市名称等数据列
        /// 李朴2013-9-1
        /// </summary>
        public List<Model.wx_lbs_shopInfo> GetDetailList(int wid,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  id,wid,shopName,telphone,brief,shopContent,shopLogo,province,city,detailAddr,xPoint,yPoint,wUrl,seq,remark,createDate
 FROM wx_lbs_shopInfo s    where s.wid=" + wid);
            if (strWhere.Trim() != "")
            {
                strSql.Append("  and  " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return DataTableToList(ds.Tables[0]);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.wx_lbs_shopInfo> DataTableToList(DataTable dt)
        {
            List<Model.wx_lbs_shopInfo> modelList = new List<Model.wx_lbs_shopInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.wx_lbs_shopInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model =  DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }



      


		#endregion  ExtensionMethod
	}
}

