using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_diancai_member
	/// </summary>
	public partial class wx_diancai_member
	{
		public wx_diancai_member()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_diancai_member"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_diancai_member");
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
		public int Add(WechatBuilder.Model.wx_diancai_member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_diancai_member(");
            strSql.Append("shopid,Name,openid,createDate,weixinName,memberName,menberTel,memberAddress,successDingdan,failDingdan,cancelDingdan,status,zongjifen,zongcje)");
			strSql.Append(" values (");
            strSql.Append("@shopid,@Name,@openid,@createDate,@weixinName,@memberName,@menberTel,@memberAddress,@successDingdan,@failDingdan,@cancelDingdan,@status,@zongjifen,@zongcje)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,4000),
					new SqlParameter("@openid", SqlDbType.VarChar,300),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@weixinName", SqlDbType.VarChar,300),
					new SqlParameter("@memberName", SqlDbType.VarChar,200),
					new SqlParameter("@menberTel", SqlDbType.VarChar,100),
					new SqlParameter("@memberAddress", SqlDbType.VarChar,300),
					new SqlParameter("@successDingdan", SqlDbType.Int,4),
					new SqlParameter("@failDingdan", SqlDbType.Int,4),
					new SqlParameter("@cancelDingdan", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@zongjifen", SqlDbType.Int,4),
					new SqlParameter("@zongcje", SqlDbType.Float,8)};
			parameters[0].Value = model.shopid;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.openid;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.weixinName;
			parameters[5].Value = model.memberName;
			parameters[6].Value = model.menberTel;
			parameters[7].Value = model.memberAddress;
			parameters[8].Value = model.successDingdan;
			parameters[9].Value = model.failDingdan;
			parameters[10].Value = model.cancelDingdan;
            parameters[11].Value = model.status;
			parameters[12].Value = model.zongjifen;
			parameters[13].Value = model.zongcje;

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
		public bool Update(WechatBuilder.Model.wx_diancai_member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_diancai_member set ");
			strSql.Append("shopid=@shopid,");
			strSql.Append("Name=@Name,");
			strSql.Append("openid=@openid,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("weixinName=@weixinName,");
			strSql.Append("memberName=@memberName,");
			strSql.Append("menberTel=@menberTel,");
			strSql.Append("memberAddress=@memberAddress,");
			strSql.Append("successDingdan=@successDingdan,");
			strSql.Append("failDingdan=@failDingdan,");
			strSql.Append("cancelDingdan=@cancelDingdan,");
            strSql.Append("status=@status,");
			strSql.Append("zongjifen=@zongjifen,");
			strSql.Append("zongcje=@zongcje");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,4000),
					new SqlParameter("@openid", SqlDbType.VarChar,300),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@weixinName", SqlDbType.VarChar,300),
					new SqlParameter("@memberName", SqlDbType.VarChar,200),
					new SqlParameter("@menberTel", SqlDbType.VarChar,100),
					new SqlParameter("@memberAddress", SqlDbType.VarChar,300),
					new SqlParameter("@successDingdan", SqlDbType.Int,4),
					new SqlParameter("@failDingdan", SqlDbType.Int,4),
					new SqlParameter("@cancelDingdan", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@zongjifen", SqlDbType.Int,4),
					new SqlParameter("@zongcje", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.shopid;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.openid;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.weixinName;
			parameters[5].Value = model.memberName;
			parameters[6].Value = model.menberTel;
			parameters[7].Value = model.memberAddress;
			parameters[8].Value = model.successDingdan;
			parameters[9].Value = model.failDingdan;
			parameters[10].Value = model.cancelDingdan;
            parameters[11].Value = model.status;
			parameters[12].Value = model.zongjifen;
			parameters[13].Value = model.zongcje;
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
			strSql.Append("delete from wx_diancai_member ");
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
			strSql.Append("delete from wx_diancai_member ");
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
		public WechatBuilder.Model.wx_diancai_member GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,shopid,Name,openid,createDate,weixinName,memberName,menberTel,memberAddress,successDingdan,failDingdan,cancelDingdan,status,zongjifen,zongcje from wx_diancai_member ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_diancai_member model=new WechatBuilder.Model.wx_diancai_member();
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
		public WechatBuilder.Model.wx_diancai_member DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_diancai_member model=new WechatBuilder.Model.wx_diancai_member();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["shopid"]!=null && row["shopid"].ToString()!="")
				{
					model.shopid=int.Parse(row["shopid"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["weixinName"]!=null)
				{
					model.weixinName=row["weixinName"].ToString();
				}
				if(row["memberName"]!=null)
				{
					model.memberName=row["memberName"].ToString();
				}
				if(row["menberTel"]!=null)
				{
					model.menberTel=row["menberTel"].ToString();
				}
				if(row["memberAddress"]!=null)
				{
					model.memberAddress=row["memberAddress"].ToString();
				}
				if(row["successDingdan"]!=null && row["successDingdan"].ToString()!="")
				{
					model.successDingdan=int.Parse(row["successDingdan"].ToString());
				}
				if(row["failDingdan"]!=null && row["failDingdan"].ToString()!="")
				{
					model.failDingdan=int.Parse(row["failDingdan"].ToString());
				}
				if(row["cancelDingdan"]!=null && row["cancelDingdan"].ToString()!="")
				{
					model.cancelDingdan=int.Parse(row["cancelDingdan"].ToString());
				}
                if (row["status"] != null && row["status"].ToString() != "")
				{
                    model.status = int.Parse(row["status"].ToString());
				}
				if(row["zongjifen"]!=null && row["zongjifen"].ToString()!="")
				{
					model.zongjifen=int.Parse(row["zongjifen"].ToString());
				}
				if(row["zongcje"]!=null && row["zongcje"].ToString()!="")
				{
					model.zongcje=decimal.Parse(row["zongcje"].ToString());
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
            strSql.Append("select id,shopid,Name,openid,createDate,weixinName,memberName,menberTel,memberAddress,successDingdan,failDingdan,cancelDingdan,status,zongjifen,zongcje ");
			strSql.Append(" FROM wx_diancai_member ");
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
            strSql.Append(" id,shopid,Name,openid,createDate,weixinName,memberName,menberTel,memberAddress,successDingdan,failDingdan,cancelDingdan,status,zongjifen,zongcje ");
			strSql.Append(" FROM wx_diancai_member ");
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
			strSql.Append("select count(1) FROM wx_diancai_member ");
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
			strSql.Append(")AS Row, T.*  from wx_diancai_member T ");
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
			parameters[0].Value = "wx_diancai_member";
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
        //今日订单数
        public int dingdantoday(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where  DateDiff(dd,createDate,getdate())=0  and  shopinfoid='" + shopid + "' and payStatus='1' ");
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

        //昨日订单数
        public int dingdanzuotian(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where  DateDiff(day,-1,createDate)=0   and  shopinfoid='" + shopid + "' and payStatus='1' ");
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
        //本月订单数
        public int dingdanbenyue(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*)  FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where datediff(month,[createDate],getdate())=0   and  shopinfoid='" + shopid + "' and payStatus='1'  ");
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
        //上月订单数
        public int dingdanshangyue(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where datediff(month,[createDate],getdate())=-1   and  shopinfoid='" + shopid + "' and payStatus='1' ");
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
        //今日营业额
        public float yyetoday(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(payAmount),0.0) FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where DateDiff(dd,createDate,getdate())=0   and  shopinfoid='" + shopid + "' and payStatus='1' ");
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
        //昨日营业额
        public float yyezuotian(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(payAmount),0.0) FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where DateDiff(day,-1,createDate)=0   and  shopinfoid='" + shopid + "' and payStatus='1' ");
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

        //本月营业额
        public float yyebenyue(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(payAmount),0.0) FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where datediff(month,[createDate],getdate())=0    and  shopinfoid='" + shopid + "' and payStatus='1' ");
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


        //上月营业额
        public float yyeshangyue(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(payAmount),0.0) FROM wx_diancai_dingdan_manage  ");
            if (shopid != 0)
            {
                strSql.Append(" where datediff(month,[createDate],getdate())=-1   and  shopinfoid='" + shopid + "' and payStatus='1' ");
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

        //今日新增客户
        public int khtoday(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM wx_diancai_member  ");
            if (shopid != 0)
            {
                strSql.Append(" where  DateDiff(dd,createDate,getdate())=0  and  shopid='" + shopid + "'");
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


        //昨天

        public int khzuotian(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*)  FROM wx_diancai_member  ");
            if (shopid != 0)
            {
                strSql.Append(" where   DateDiff(day,-1,createDate)=0   and  shopid='" + shopid + "'");
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
        //本月
        public int khbenyue(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*)  FROM wx_diancai_member  ");
            if (shopid != 0)
            {
                strSql.Append(" where   datediff(month,[createDate],getdate())=0      and  shopid='" + shopid + "'");
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
        
        //上月

        public int khshangyue(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*)  FROM wx_diancai_member  ");
            if (shopid != 0)
            {
                strSql.Append(" where   datediff(month,[createDate],getdate())=-1    and  shopid='" + shopid + "'");
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


        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,shopid,Name,openid,createDate,weixinName,memberName,menberTel,memberAddress,successDingdan,failDingdan,cancelDingdan,status,zongjifen,zongcje ");
            strSql.Append(" FROM wx_diancai_member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
		}
        
		#endregion  ExtensionMethod
	}
}

