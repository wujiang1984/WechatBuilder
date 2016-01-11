using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_purchase_base
	/// </summary>
	public partial class wx_purchase_base
	{
		public wx_purchase_base()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "wx_purchase_base");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_purchase_base");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WechatBuilder.Model.wx_purchase_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_purchase_base(");
            strSql.Append("activityName,activitySummary,activityTimebegin,email,emailPwd,smtp,shopsPwd,activeDescription,specialRemind,activityEndtitle,endExplanation,shopstel,address,introduction,goodName,costPrice,limitCount,groupPrice,totalCount,groupPerson,virtualPerson,copyrightSetup,activityTimeend,createtime,wid,imageUrl,imageUrlend,txtLatXPoint,txtLngYPoint)");
            strSql.Append(" values (");
            strSql.Append("@activityName,@activitySummary,@activityTimebegin,@email,@emailPwd,@smtp,@shopsPwd,@activeDescription,@specialRemind,@activityEndtitle,@endExplanation,@shopstel,@address,@introduction,@goodName,@costPrice,@limitCount,@groupPrice,@totalCount,@groupPerson,@virtualPerson,@copyrightSetup,@activityTimeend,@createtime,@wid,@imageUrl,@imageUrlend,@txtLatXPoint,@txtLngYPoint)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@activityName", SqlDbType.VarChar,100),
					new SqlParameter("@activitySummary", SqlDbType.VarChar,500),
					new SqlParameter("@activityTimebegin", SqlDbType.DateTime),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@emailPwd", SqlDbType.VarChar,100),
					new SqlParameter("@smtp", SqlDbType.VarChar,100),
					new SqlParameter("@shopsPwd", SqlDbType.VarChar,100),
					new SqlParameter("@activeDescription", SqlDbType.VarChar,2000),
					new SqlParameter("@specialRemind", SqlDbType.VarChar,1000),
					new SqlParameter("@activityEndtitle", SqlDbType.VarChar,100),
					new SqlParameter("@endExplanation", SqlDbType.VarChar,2000),
					new SqlParameter("@shopstel", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.VarChar,500),
					new SqlParameter("@introduction", SqlDbType.VarChar,2000),
					new SqlParameter("@goodName", SqlDbType.VarChar,100),
					new SqlParameter("@costPrice", SqlDbType.Float,8),
					new SqlParameter("@limitCount", SqlDbType.Int,4),
					new SqlParameter("@groupPrice", SqlDbType.Float,8),
					new SqlParameter("@totalCount", SqlDbType.Int,4),
					new SqlParameter("@groupPerson", SqlDbType.Int,4),
					new SqlParameter("@virtualPerson", SqlDbType.Int,4),
					new SqlParameter("@copyrightSetup", SqlDbType.VarChar,200),
					new SqlParameter("@activityTimeend", SqlDbType.DateTime),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@imageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@imageUrlend", SqlDbType.NVarChar,200),
					new SqlParameter("@txtLatXPoint", SqlDbType.Float,8),
					new SqlParameter("@txtLngYPoint", SqlDbType.Float,8)};
            parameters[0].Value = model.activityName;
            parameters[1].Value = model.activitySummary;
            parameters[2].Value = model.activityTimebegin;
            parameters[3].Value = model.email;
            parameters[4].Value = model.emailPwd;
            parameters[5].Value = model.smtp;
            parameters[6].Value = model.shopsPwd;
            parameters[7].Value = model.activeDescription;
            parameters[8].Value = model.specialRemind;
            parameters[9].Value = model.activityEndtitle;
            parameters[10].Value = model.endExplanation;
            parameters[11].Value = model.shopstel;
            parameters[12].Value = model.address;
            parameters[13].Value = model.introduction;
            parameters[14].Value = model.goodName;
            parameters[15].Value = model.costPrice;
            parameters[16].Value = model.limitCount;
            parameters[17].Value = model.groupPrice;
            parameters[18].Value = model.totalCount;
            parameters[19].Value = model.groupPerson;
            parameters[20].Value = model.virtualPerson;
            parameters[21].Value = model.copyrightSetup;
            parameters[22].Value = model.activityTimeend;
            parameters[23].Value = model.createtime;
            parameters[24].Value = model.wid;
            parameters[25].Value = model.imageUrl;
            parameters[26].Value = model.imageUrlend;
            parameters[27].Value = model.txtLatXPoint;
            parameters[28].Value = model.txtLngYPoint;

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
        public bool Update(WechatBuilder.Model.wx_purchase_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_purchase_base set ");
            strSql.Append("activityName=@activityName,");
            strSql.Append("activitySummary=@activitySummary,");
            strSql.Append("activityTimebegin=@activityTimebegin,");
            strSql.Append("email=@email,");
            strSql.Append("emailPwd=@emailPwd,");
            strSql.Append("smtp=@smtp,");
            strSql.Append("shopsPwd=@shopsPwd,");
            strSql.Append("activeDescription=@activeDescription,");
            strSql.Append("specialRemind=@specialRemind,");
            strSql.Append("activityEndtitle=@activityEndtitle,");
            strSql.Append("endExplanation=@endExplanation,");
            strSql.Append("shopstel=@shopstel,");
            strSql.Append("address=@address,");
            strSql.Append("introduction=@introduction,");
            strSql.Append("goodName=@goodName,");
            strSql.Append("costPrice=@costPrice,");
            strSql.Append("limitCount=@limitCount,");
            strSql.Append("groupPrice=@groupPrice,");
            strSql.Append("totalCount=@totalCount,");
            strSql.Append("groupPerson=@groupPerson,");
            strSql.Append("virtualPerson=@virtualPerson,");
            strSql.Append("copyrightSetup=@copyrightSetup,");
            strSql.Append("activityTimeend=@activityTimeend,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("wid=@wid,");
            strSql.Append("imageUrl=@imageUrl,");
            strSql.Append("imageUrlend=@imageUrlend,");
            strSql.Append("txtLatXPoint=@txtLatXPoint,");
            strSql.Append("txtLngYPoint=@txtLngYPoint");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@activityName", SqlDbType.VarChar,100),
					new SqlParameter("@activitySummary", SqlDbType.VarChar,500),
					new SqlParameter("@activityTimebegin", SqlDbType.DateTime),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@emailPwd", SqlDbType.VarChar,100),
					new SqlParameter("@smtp", SqlDbType.VarChar,100),
					new SqlParameter("@shopsPwd", SqlDbType.VarChar,100),
					new SqlParameter("@activeDescription", SqlDbType.VarChar,2000),
					new SqlParameter("@specialRemind", SqlDbType.VarChar,1000),
					new SqlParameter("@activityEndtitle", SqlDbType.VarChar,100),
					new SqlParameter("@endExplanation", SqlDbType.VarChar,2000),
					new SqlParameter("@shopstel", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.VarChar,500),
					new SqlParameter("@introduction", SqlDbType.VarChar,2000),
					new SqlParameter("@goodName", SqlDbType.VarChar,100),
					new SqlParameter("@costPrice", SqlDbType.Float,8),
					new SqlParameter("@limitCount", SqlDbType.Int,4),
					new SqlParameter("@groupPrice", SqlDbType.Float,8),
					new SqlParameter("@totalCount", SqlDbType.Int,4),
					new SqlParameter("@groupPerson", SqlDbType.Int,4),
					new SqlParameter("@virtualPerson", SqlDbType.Int,4),
					new SqlParameter("@copyrightSetup", SqlDbType.VarChar,200),
					new SqlParameter("@activityTimeend", SqlDbType.DateTime),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@imageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@imageUrlend", SqlDbType.NVarChar,200),
					new SqlParameter("@txtLatXPoint", SqlDbType.Float,8),
					new SqlParameter("@txtLngYPoint", SqlDbType.Float,8),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.activityName;
            parameters[1].Value = model.activitySummary;
            parameters[2].Value = model.activityTimebegin;
            parameters[3].Value = model.email;
            parameters[4].Value = model.emailPwd;
            parameters[5].Value = model.smtp;
            parameters[6].Value = model.shopsPwd;
            parameters[7].Value = model.activeDescription;
            parameters[8].Value = model.specialRemind;
            parameters[9].Value = model.activityEndtitle;
            parameters[10].Value = model.endExplanation;
            parameters[11].Value = model.shopstel;
            parameters[12].Value = model.address;
            parameters[13].Value = model.introduction;
            parameters[14].Value = model.goodName;
            parameters[15].Value = model.costPrice;
            parameters[16].Value = model.limitCount;
            parameters[17].Value = model.groupPrice;
            parameters[18].Value = model.totalCount;
            parameters[19].Value = model.groupPerson;
            parameters[20].Value = model.virtualPerson;
            parameters[21].Value = model.copyrightSetup;
            parameters[22].Value = model.activityTimeend;
            parameters[23].Value = model.createtime;
            parameters[24].Value = model.wid;
            parameters[25].Value = model.imageUrl;
            parameters[26].Value = model.imageUrlend;
            parameters[27].Value = model.txtLatXPoint;
            parameters[28].Value = model.txtLngYPoint;
            parameters[29].Value = model.Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_purchase_base ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_purchase_base ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public WechatBuilder.Model.wx_purchase_base GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,activityName,activitySummary,activityTimebegin,email,emailPwd,smtp,shopsPwd,activeDescription,specialRemind,activityEndtitle,endExplanation,shopstel,address,introduction,goodName,costPrice,limitCount,groupPrice,totalCount,groupPerson,virtualPerson,copyrightSetup,activityTimeend,createtime,wid,imageUrl,imageUrlend,txtLatXPoint,txtLngYPoint from wx_purchase_base ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            WechatBuilder.Model.wx_purchase_base model = new WechatBuilder.Model.wx_purchase_base();
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
        public WechatBuilder.Model.wx_purchase_base DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_purchase_base model = new WechatBuilder.Model.wx_purchase_base();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["activityName"] != null)
                {
                    model.activityName = row["activityName"].ToString();
                }
                if (row["activitySummary"] != null)
                {
                    model.activitySummary = row["activitySummary"].ToString();
                }
                if (row["activityTimebegin"] != null && row["activityTimebegin"].ToString() != "")
                {
                    model.activityTimebegin = DateTime.Parse(row["activityTimebegin"].ToString());
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["emailPwd"] != null)
                {
                    model.emailPwd = row["emailPwd"].ToString();
                }
                if (row["smtp"] != null)
                {
                    model.smtp = row["smtp"].ToString();
                }
                if (row["shopsPwd"] != null)
                {
                    model.shopsPwd = row["shopsPwd"].ToString();
                }
                if (row["activeDescription"] != null)
                {
                    model.activeDescription = row["activeDescription"].ToString();
                }
                if (row["specialRemind"] != null)
                {
                    model.specialRemind = row["specialRemind"].ToString();
                }
                if (row["activityEndtitle"] != null)
                {
                    model.activityEndtitle = row["activityEndtitle"].ToString();
                }
                if (row["endExplanation"] != null)
                {
                    model.endExplanation = row["endExplanation"].ToString();
                }
                if (row["shopstel"] != null)
                {
                    model.shopstel = row["shopstel"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["introduction"] != null)
                {
                    model.introduction = row["introduction"].ToString();
                }
                if (row["goodName"] != null)
                {
                    model.goodName = row["goodName"].ToString();
                }
                if (row["costPrice"] != null && row["costPrice"].ToString() != "")
                {
                    model.costPrice = decimal.Parse(row["costPrice"].ToString());
                }
                if (row["limitCount"] != null && row["limitCount"].ToString() != "")
                {
                    model.limitCount = int.Parse(row["limitCount"].ToString());
                }
                if (row["groupPrice"] != null && row["groupPrice"].ToString() != "")
                {
                    model.groupPrice = decimal.Parse(row["groupPrice"].ToString());
                }
                if (row["totalCount"] != null && row["totalCount"].ToString() != "")
                {
                    model.totalCount = int.Parse(row["totalCount"].ToString());
                }
                if (row["groupPerson"] != null && row["groupPerson"].ToString() != "")
                {
                    model.groupPerson = int.Parse(row["groupPerson"].ToString());
                }
                if (row["virtualPerson"] != null && row["virtualPerson"].ToString() != "")
                {
                    model.virtualPerson = int.Parse(row["virtualPerson"].ToString());
                }
                if (row["copyrightSetup"] != null)
                {
                    model.copyrightSetup = row["copyrightSetup"].ToString();
                }
                if (row["activityTimeend"] != null && row["activityTimeend"].ToString() != "")
                {
                    model.activityTimeend = DateTime.Parse(row["activityTimeend"].ToString());
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["imageUrl"] != null)
                {
                    model.imageUrl = row["imageUrl"].ToString();
                }
                if (row["imageUrlend"] != null)
                {
                    model.imageUrlend = row["imageUrlend"].ToString();
                }
                if (row["txtLatXPoint"] != null && row["txtLatXPoint"].ToString() != "")
                {
                    model.txtLatXPoint = decimal.Parse(row["txtLatXPoint"].ToString());
                }
                if (row["txtLngYPoint"] != null && row["txtLngYPoint"].ToString() != "")
                {
                    model.txtLngYPoint = decimal.Parse(row["txtLngYPoint"].ToString());
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
            strSql.Append("select Id,activityName,activitySummary,activityTimebegin,email,emailPwd,smtp,shopsPwd,activeDescription,specialRemind,activityEndtitle,endExplanation,shopstel,address,introduction,goodName,costPrice,limitCount,groupPrice,totalCount,groupPerson,virtualPerson,copyrightSetup,activityTimeend,createtime,wid,imageUrl,imageUrlend,txtLatXPoint,txtLngYPoint ");
            strSql.Append(" FROM wx_purchase_base ");
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
            strSql.Append(" Id,activityName,activitySummary,activityTimebegin,email,emailPwd,smtp,shopsPwd,activeDescription,specialRemind,activityEndtitle,endExplanation,shopstel,address,introduction,goodName,costPrice,limitCount,groupPrice,totalCount,groupPerson,virtualPerson,copyrightSetup,activityTimeend,createtime,wid,imageUrl,imageUrlend,txtLatXPoint,txtLngYPoint ");
            strSql.Append(" FROM wx_purchase_base ");
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
            strSql.Append("select count(1) FROM wx_purchase_base ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_purchase_base T ");
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
            parameters[0].Value = "wx_purchase_base";
            parameters[1].Value = "Id";
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
            strSql.Append("select Id,activityName,activitySummary,activityTimebegin,email,emailPwd,smtp,shopsPwd,activeDescription,specialRemind,activityEndtitle,endExplanation,shopstel,address,introduction,goodName,costPrice,limitCount,groupPrice,totalCount,groupPerson,virtualPerson,copyrightSetup,activityTimeend,createtime ");
            strSql.Append(",txtLatXPoint,txtLngYPoint  FROM wx_purchase_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        public DataSet GetListByid(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,activityName,activitySummary,activityTimebegin,email,emailPwd,smtp,shopsPwd,activeDescription,specialRemind,activityEndtitle,endExplanation,shopstel,address,introduction,goodName,costPrice,limitCount,groupPrice,totalCount,groupPerson,virtualPerson,copyrightSetup,activityTimeend,createtime  ");
            strSql.Append(" ,txtLatXPoint,txtLngYPoint  FROM wx_purchase_base ");
            if (id != 0)
            {
                strSql.Append(" where  id='" + id + "' ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        public DataSet GetList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,activityName,activitySummary,activityTimebegin,email,emailPwd,smtp,shopsPwd,activeDescription,specialRemind,activityEndtitle,endExplanation,shopstel,address,introduction,goodName,costPrice,limitCount,groupPrice,totalCount,groupPerson,virtualPerson,copyrightSetup,activityTimeend,createtime,wid ");
            strSql.Append(",txtLatXPoint,txtLngYPoint  FROM wx_purchase_base ");
            if (id != 0)
            {
                strSql.Append(" where  Id='"+id+"' ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


		#endregion  ExtensionMethod
	}
}

