using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
    /// <summary>
    /// 数据访问类:wx_diancai_dingdan_caiping
    /// </summary>
    public partial class wx_diancai_dingdan_caiping
    {
        public wx_diancai_dingdan_caiping()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_diancai_dingdan_caiping");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_diancai_dingdan_caiping");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WechatBuilder.Model.wx_diancai_dingdan_caiping model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_diancai_dingdan_caiping(");
            strSql.Append("dingId,caiId,num,price,totpric)");
            strSql.Append(" values (");
            strSql.Append("@dingId,@caiId,@num,@price,@totpric)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@dingId", SqlDbType.Int,4),
					new SqlParameter("@caiId", SqlDbType.Int,4),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@totpric", SqlDbType.Float,8)};
            parameters[0].Value = model.dingId;
            parameters[1].Value = model.caiId;
            parameters[2].Value = model.num;
            parameters[3].Value = model.price;
            parameters[4].Value = model.totpric;

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
        public bool Update(WechatBuilder.Model.wx_diancai_dingdan_caiping model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_diancai_dingdan_caiping set ");
            strSql.Append("dingId=@dingId,");
            strSql.Append("caiId=@caiId,");
            strSql.Append("num=@num,");
            strSql.Append("price=@price,");
            strSql.Append("totpric=@totpric");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@dingId", SqlDbType.Int,4),
					new SqlParameter("@caiId", SqlDbType.Int,4),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@totpric", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.dingId;
            parameters[1].Value = model.caiId;
            parameters[2].Value = model.num;
            parameters[3].Value = model.price;
            parameters[4].Value = model.totpric;
            parameters[5].Value = model.id;

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_diancai_dingdan_caiping ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_diancai_dingdan_caiping ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public WechatBuilder.Model.wx_diancai_dingdan_caiping GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,dingId,caiId,num,price,totpric from wx_diancai_dingdan_caiping ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_diancai_dingdan_caiping model = new WechatBuilder.Model.wx_diancai_dingdan_caiping();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WechatBuilder.Model.wx_diancai_dingdan_caiping DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_diancai_dingdan_caiping model = new WechatBuilder.Model.wx_diancai_dingdan_caiping();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["dingId"] != null && row["dingId"].ToString() != "")
                {
                    model.dingId = int.Parse(row["dingId"].ToString());
                }
                if (row["caiId"] != null && row["caiId"].ToString() != "")
                {
                    model.caiId = int.Parse(row["caiId"].ToString());
                }
                if (row["num"] != null && row["num"].ToString() != "")
                {
                    model.num = int.Parse(row["num"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["totpric"] != null && row["totpric"].ToString() != "")
                {
                    model.totpric = decimal.Parse(row["totpric"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,dingId,caiId,num,price,totpric ");
            strSql.Append(" FROM wx_diancai_dingdan_caiping ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,dingId,caiId,num,price,totpric ");
            strSql.Append(" FROM wx_diancai_dingdan_caiping ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wx_diancai_dingdan_caiping ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_diancai_dingdan_caiping T ");
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
            parameters[0].Value = "wx_diancai_dingdan_caiping";
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
        public DataSet GetTongjiByDate(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select cpName,sum(jintian) jintian,sum(zuotian) zuotian,sum(benyue) benyue,sum(shangyue) shangyue from ");
            strSql.Append(" (");
            strSql.Append(" select  cpName,");
            strSql.Append(" case when years=datepart(yyyy,getdate()) and  months=month(getdate()) and days=day(getdate()) then counts else 0 end 'jintian',");
            strSql.Append(" case when years=datepart(yyyy,getdate()) and months=month(getdate()) and days=day(getdate())-1 then counts else 0 end 'zuotian',");
            strSql.Append(" case when years=datepart(yyyy,getdate()) and months=month(getdate())  then counts else 0 end 'benyue',");
            strSql.Append(" case when years=datepart(yyyy,getdate())  and months=month(getdate())-1  then counts else 0 end 'shangyue'");
            strSql.Append("  from");
            strSql.Append(" (");
            strSql.Append(" select cpName,datepart(yyyy,createDate) as years, datepart(mm,createDate) months,datepart(dd,createDate) days ,sum(num)as counts ");
            strSql.Append("  from ");
            strSql.Append(" (");
            strSql.Append(" select dc.*,d.createDate  from");
            strSql.Append("  (select dc.*,c.cpName from wx_diancai_dingdan_caiping dc,wx_diancai_caipin_manage c where dc.caiId=c.id ) dc ");
            strSql.Append(" left join wx_diancai_dingdan_manage d on dc.dingId=d.id  where d.shopinfoid=" + shopid);
            strSql.Append(" ) as dv  group by cpName, year(createDate),month(createDate) ,day(createDate)");
            strSql.Append(" ) as resultdv");

            strSql.Append(" ) as resultdt group by cpName");
            return DbHelperSQL.Query(strSql.ToString());
        }




        #endregion  ExtensionMethod
    }
}

