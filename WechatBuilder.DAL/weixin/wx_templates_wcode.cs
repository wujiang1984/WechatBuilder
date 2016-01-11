using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_templates_wcode
	/// </summary>
	public partial class wx_templates_wcode
	{
		public wx_templates_wcode()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_templates_wcode"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_templates_wcode");
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
		public int Add(WechatBuilder.Model.wx_templates_wcode model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_templates_wcode(");
            strSql.Append("wid,tid,remark,createDate,extInt,extStr,extStr2,listTid,detailTid,channelTid,bmenuTid,topcolorTypeId,topcolorTypeName,topcolorHtml)");
            strSql.Append(" values (");
            strSql.Append("@wid,@tid,@remark,@createDate,@extInt,@extStr,@extStr2,@listTid,@detailTid,@channelTid,@bmenuTid,@topcolorTypeId,@topcolorTypeName,@topcolorHtml)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@listTid", SqlDbType.Int,4),
					new SqlParameter("@detailTid", SqlDbType.Int,4),
					new SqlParameter("@channelTid", SqlDbType.Int,4),
					new SqlParameter("@bmenuTid", SqlDbType.Int,4),
					new SqlParameter("@topcolorTypeId", SqlDbType.Int,4),
					new SqlParameter("@topcolorTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@topcolorHtml", SqlDbType.Text)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.tid;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.createDate;
            parameters[4].Value = model.extInt;
            parameters[5].Value = model.extStr;
            parameters[6].Value = model.extStr2;
            parameters[7].Value = model.listTid;
            parameters[8].Value = model.detailTid;
            parameters[9].Value = model.channelTid;
            parameters[10].Value = model.bmenuTid;
            parameters[11].Value = model.topcolorTypeId;
            parameters[12].Value = model.topcolorTypeName;
            parameters[13].Value = model.topcolorHtml;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(WechatBuilder.Model.wx_templates_wcode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_templates_wcode set ");
            strSql.Append("wid=@wid,");
            strSql.Append("tid=@tid,");
            strSql.Append("remark=@remark,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("extInt=@extInt,");
            strSql.Append("extStr=@extStr,");
            strSql.Append("extStr2=@extStr2,");
            strSql.Append("listTid=@listTid,");
            strSql.Append("detailTid=@detailTid,");
            strSql.Append("channelTid=@channelTid,");
            strSql.Append("bmenuTid=@bmenuTid,");
            strSql.Append("topcolorTypeId=@topcolorTypeId,");
            strSql.Append("topcolorTypeName=@topcolorTypeName,");
            strSql.Append("topcolorHtml=@topcolorHtml");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@extStr2", SqlDbType.VarChar,800),
					new SqlParameter("@listTid", SqlDbType.Int,4),
					new SqlParameter("@detailTid", SqlDbType.Int,4),
					new SqlParameter("@channelTid", SqlDbType.Int,4),
					new SqlParameter("@bmenuTid", SqlDbType.Int,4),
					new SqlParameter("@topcolorTypeId", SqlDbType.Int,4),
					new SqlParameter("@topcolorTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@topcolorHtml", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.tid;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.createDate;
            parameters[4].Value = model.extInt;
            parameters[5].Value = model.extStr;
            parameters[6].Value = model.extStr2;
            parameters[7].Value = model.listTid;
            parameters[8].Value = model.detailTid;
            parameters[9].Value = model.channelTid;
            parameters[10].Value = model.bmenuTid;
            parameters[11].Value = model.topcolorTypeId;
            parameters[12].Value = model.topcolorTypeName;
            parameters[13].Value = model.topcolorHtml;
            parameters[14].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("delete from wx_templates_wcode ");
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
			strSql.Append("delete from wx_templates_wcode ");
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
		public WechatBuilder.Model.wx_templates_wcode GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,wid,tid,remark,createDate,extInt,extStr,extStr2,listTid,detailTid,channelTid,bmenuTid,topcolorTypeId,topcolorTypeName,topcolorHtml  from wx_templates_wcode ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_templates_wcode model=new WechatBuilder.Model.wx_templates_wcode();
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
		public WechatBuilder.Model.wx_templates_wcode DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_templates_wcode model=new WechatBuilder.Model.wx_templates_wcode();
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
				if(row["tid"]!=null && row["tid"].ToString()!="")
				{
					model.tid=int.Parse(row["tid"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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

                if (row["listTid"] != null && row["listTid"].ToString() != "")
                {
                    model.listTid = int.Parse(row["listTid"].ToString());
                }
                if (row["detailTid"] != null && row["detailTid"].ToString() != "")
                {
                    model.detailTid = int.Parse(row["detailTid"].ToString());
                }
                if (row["channelTid"] != null && row["channelTid"].ToString() != "")
                {
                    model.channelTid = int.Parse(row["channelTid"].ToString());
                }
                if (row["bmenuTid"] != null && row["bmenuTid"].ToString() != "")
                {
                    model.bmenuTid = int.Parse(row["bmenuTid"].ToString());
                }
                if (row["topcolorTypeId"] != null && row["topcolorTypeId"].ToString() != "")
                {
                    model.topcolorTypeId = int.Parse(row["topcolorTypeId"].ToString());
                }
                if (row["topcolorTypeName"] != null)
                {
                    model.topcolorTypeName = row["topcolorTypeName"].ToString();
                }
                if (row["topcolorHtml"] != null)
                {
                    model.topcolorHtml = row["topcolorHtml"].ToString();
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
            strSql.Append("select id,wid,tid,remark,createDate,extInt,extStr,extStr2,listTid,detailTid,channelTid,bmenuTid,topcolorTypeId,topcolorTypeName,topcolorHtml ");
			strSql.Append(" FROM wx_templates_wcode ");
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
            strSql.Append(" id,wid,tid,remark,createDate,extInt,extStr,extStr2,listTid,detailTid,channelTid,bmenuTid,topcolorTypeId,topcolorTypeName,topcolorHtml ");
			strSql.Append(" FROM wx_templates_wcode ");
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
			strSql.Append("select count(1) FROM wx_templates_wcode ");
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
			strSql.Append(")AS Row, T.*  from wx_templates_wcode T ");
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

		#endregion  ExtensionMethod
	}
}

