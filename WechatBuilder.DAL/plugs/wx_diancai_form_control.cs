using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_diancai_form_control
	/// </summary>
	public partial class wx_diancai_form_control
	{
		public wx_diancai_form_control()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_diancai_form_control"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_diancai_form_control");
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
		public int Add(WechatBuilder.Model.wx_diancai_form_control model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_diancai_form_control(");
			strSql.Append("shopinfoId,cName,cType,minLength,maxLength,defaultValue,isBiTian,seq,createDate,remark,extInt,extStr,isSys,sysControlerType)");
			strSql.Append(" values (");
			strSql.Append("@shopinfoId,@cName,@cType,@minLength,@maxLength,@defaultValue,@isBiTian,@seq,@createDate,@remark,@extInt,@extStr,@isSys,@sysControlerType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@shopinfoId", SqlDbType.Int,4),
					new SqlParameter("@cName", SqlDbType.VarChar,50),
					new SqlParameter("@cType", SqlDbType.VarChar,4000),
					new SqlParameter("@minLength", SqlDbType.Int,4),
					new SqlParameter("@maxLength", SqlDbType.Int,4),
					new SqlParameter("@defaultValue", SqlDbType.VarChar,2000),
					new SqlParameter("@isBiTian", SqlDbType.Bit,1),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,800),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@isSys", SqlDbType.Bit,1),
					new SqlParameter("@sysControlerType", SqlDbType.VarChar,100)};
			parameters[0].Value = model.shopinfoId;
			parameters[1].Value = model.cName;
			parameters[2].Value = model.cType;
			parameters[3].Value = model.minLength;
			parameters[4].Value = model.maxLength;
			parameters[5].Value = model.defaultValue;
			parameters[6].Value = model.isBiTian;
			parameters[7].Value = model.seq;
			parameters[8].Value = model.createDate;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.extInt;
			parameters[11].Value = model.extStr;
			parameters[12].Value = model.isSys;
			parameters[13].Value = model.sysControlerType;

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
		public bool Update(WechatBuilder.Model.wx_diancai_form_control model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_diancai_form_control set ");
			strSql.Append("shopinfoId=@shopinfoId,");
			strSql.Append("cName=@cName,");
			strSql.Append("cType=@cType,");
			strSql.Append("minLength=@minLength,");
			strSql.Append("maxLength=@maxLength,");
			strSql.Append("defaultValue=@defaultValue,");
			strSql.Append("isBiTian=@isBiTian,");
			strSql.Append("seq=@seq,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("remark=@remark,");
			strSql.Append("extInt=@extInt,");
			strSql.Append("extStr=@extStr,");
			strSql.Append("isSys=@isSys,");
			strSql.Append("sysControlerType=@sysControlerType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@shopinfoId", SqlDbType.Int,4),
					new SqlParameter("@cName", SqlDbType.VarChar,50),
					new SqlParameter("@cType", SqlDbType.VarChar,4000),
					new SqlParameter("@minLength", SqlDbType.Int,4),
					new SqlParameter("@maxLength", SqlDbType.Int,4),
					new SqlParameter("@defaultValue", SqlDbType.VarChar,2000),
					new SqlParameter("@isBiTian", SqlDbType.Bit,1),
					new SqlParameter("@seq", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,800),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@extStr", SqlDbType.VarChar,500),
					new SqlParameter("@isSys", SqlDbType.Bit,1),
					new SqlParameter("@sysControlerType", SqlDbType.VarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.shopinfoId;
			parameters[1].Value = model.cName;
			parameters[2].Value = model.cType;
			parameters[3].Value = model.minLength;
			parameters[4].Value = model.maxLength;
			parameters[5].Value = model.defaultValue;
			parameters[6].Value = model.isBiTian;
			parameters[7].Value = model.seq;
			parameters[8].Value = model.createDate;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.extInt;
			parameters[11].Value = model.extStr;
			parameters[12].Value = model.isSys;
			parameters[13].Value = model.sysControlerType;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from wx_diancai_form_control ");
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
			strSql.Append("delete from wx_diancai_form_control ");
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
		public WechatBuilder.Model.wx_diancai_form_control GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,shopinfoId,cName,cType,minLength,maxLength,defaultValue,isBiTian,seq,createDate,remark,extInt,extStr,isSys,sysControlerType from wx_diancai_form_control ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_diancai_form_control model=new WechatBuilder.Model.wx_diancai_form_control();
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
		public WechatBuilder.Model.wx_diancai_form_control DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_diancai_form_control model=new WechatBuilder.Model.wx_diancai_form_control();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["shopinfoId"]!=null && row["shopinfoId"].ToString()!="")
				{
					model.shopinfoId=int.Parse(row["shopinfoId"].ToString());
				}
				if(row["cName"]!=null)
				{
					model.cName=row["cName"].ToString();
				}
				if(row["cType"]!=null)
				{
					model.cType=row["cType"].ToString();
				}
				if(row["minLength"]!=null && row["minLength"].ToString()!="")
				{
					model.minLength=int.Parse(row["minLength"].ToString());
				}
				if(row["maxLength"]!=null && row["maxLength"].ToString()!="")
				{
					model.maxLength=int.Parse(row["maxLength"].ToString());
				}
				if(row["defaultValue"]!=null)
				{
					model.defaultValue=row["defaultValue"].ToString();
				}
				if(row["isBiTian"]!=null && row["isBiTian"].ToString()!="")
				{
					if((row["isBiTian"].ToString()=="1")||(row["isBiTian"].ToString().ToLower()=="true"))
					{
						model.isBiTian=true;
					}
					else
					{
						model.isBiTian=false;
					}
				}
				if(row["seq"]!=null && row["seq"].ToString()!="")
				{
					model.seq=int.Parse(row["seq"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["extInt"]!=null && row["extInt"].ToString()!="")
				{
					model.extInt=int.Parse(row["extInt"].ToString());
				}
				if(row["extStr"]!=null)
				{
					model.extStr=row["extStr"].ToString();
				}
				if(row["isSys"]!=null && row["isSys"].ToString()!="")
				{
					if((row["isSys"].ToString()=="1")||(row["isSys"].ToString().ToLower()=="true"))
					{
						model.isSys=true;
					}
					else
					{
						model.isSys=false;
					}
				}
				if(row["sysControlerType"]!=null)
				{
					model.sysControlerType=row["sysControlerType"].ToString();
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
			strSql.Append("select id,shopinfoId,cName,cType,minLength,maxLength,defaultValue,isBiTian,seq,createDate,remark,extInt,extStr,isSys,sysControlerType ");
			strSql.Append(" FROM wx_diancai_form_control ");
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
			strSql.Append(" id,shopinfoId,cName,cType,minLength,maxLength,defaultValue,isBiTian,seq,createDate,remark,extInt,extStr,isSys,sysControlerType ");
			strSql.Append(" FROM wx_diancai_form_control ");
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
			strSql.Append("select count(1) FROM wx_diancai_form_control ");
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
			strSql.Append(")AS Row, T.*  from wx_diancai_form_control T ");
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
			parameters[0].Value = "wx_diancai_form_control";
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
        public bool DeleteZH(int shopinfoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_diancai_form_control ");
            strSql.Append(" where shopinfoId=@shopinfoId");
            SqlParameter[] parameters = {
					new SqlParameter("@shopinfoId", SqlDbType.Int,4)
			};
            parameters[0].Value = shopinfoId;

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


        public bool ExistsZH(int shopinfoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_diancai_form_control");
            strSql.Append(" where shopinfoId=@shopinfoId");
            SqlParameter[] parameters = {
					new SqlParameter("@shopinfoId", SqlDbType.Int,4)
			};
            parameters[0].Value = shopinfoId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetListZH(int shopid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,shopinfoId,cName,cType,minLength,maxLength,defaultValue,isBiTian,seq,createDate,remark,extInt,extStr,isSys,sysControlerType ");
            strSql.Append(" FROM wx_diancai_form_control where shopinfoId='" + shopid + "' ");
		
			return DbHelperSQL.Query(strSql.ToString());
		}
        
		#endregion  ExtensionMethod
	}
}

