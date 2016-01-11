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
	/// 数据访问类:wx_ucard_store
	/// </summary>
	public partial class wx_ucard_store
	{
		public wx_ucard_store()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_ucard_store");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_ucard_store");
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
        public int Add(WechatBuilder.Model.wx_ucard_store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_ucard_store(");
            strSql.Append("wid,storeName,logo,storeCatagory,cardBrief,consumePwd,tel,addr,xPoint,yPoint,createDate,sort_id,isRecommend,hfPic)");
            strSql.Append(" values (");
            strSql.Append("@wid,@storeName,@logo,@storeCatagory,@cardBrief,@consumePwd,@tel,@addr,@xPoint,@yPoint,@createDate,@sort_id,@isRecommend,@hfPic)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@storeName", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,800),
					new SqlParameter("@storeCatagory", SqlDbType.VarChar,50),
					new SqlParameter("@cardBrief", SqlDbType.VarChar,48),
					new SqlParameter("@consumePwd", SqlDbType.VarChar,30),
					new SqlParameter("@tel", SqlDbType.VarChar,40),
					new SqlParameter("@addr", SqlDbType.VarChar,200),
					new SqlParameter("@xPoint", SqlDbType.Float,8),
					new SqlParameter("@yPoint", SqlDbType.Float,8),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@isRecommend", SqlDbType.Bit,1),
					new SqlParameter("@hfPic", SqlDbType.VarChar,700)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.storeName;
            parameters[2].Value = model.logo;
            parameters[3].Value = model.storeCatagory;
            parameters[4].Value = model.cardBrief;
            parameters[5].Value = model.consumePwd;
            parameters[6].Value = model.tel;
            parameters[7].Value = model.addr;
            parameters[8].Value = model.xPoint;
            parameters[9].Value = model.yPoint;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.sort_id;
            parameters[12].Value = model.isRecommend;
            parameters[13].Value = model.hfPic;

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
        public bool Update(WechatBuilder.Model.wx_ucard_store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_ucard_store set ");
            strSql.Append("wid=@wid,");
            strSql.Append("storeName=@storeName,");
            strSql.Append("logo=@logo,");
            strSql.Append("storeCatagory=@storeCatagory,");
            strSql.Append("cardBrief=@cardBrief,");
            strSql.Append("consumePwd=@consumePwd,");
            strSql.Append("tel=@tel,");
            strSql.Append("addr=@addr,");
            strSql.Append("xPoint=@xPoint,");
            strSql.Append("yPoint=@yPoint,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("isRecommend=@isRecommend,");
            strSql.Append("hfPic=@hfPic");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@storeName", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,800),
					new SqlParameter("@storeCatagory", SqlDbType.VarChar,50),
					new SqlParameter("@cardBrief", SqlDbType.VarChar,48),
					new SqlParameter("@consumePwd", SqlDbType.VarChar,30),
					new SqlParameter("@tel", SqlDbType.VarChar,40),
					new SqlParameter("@addr", SqlDbType.VarChar,200),
					new SqlParameter("@xPoint", SqlDbType.Float,8),
					new SqlParameter("@yPoint", SqlDbType.Float,8),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@isRecommend", SqlDbType.Bit,1),
					new SqlParameter("@hfPic", SqlDbType.VarChar,700),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.storeName;
            parameters[2].Value = model.logo;
            parameters[3].Value = model.storeCatagory;
            parameters[4].Value = model.cardBrief;
            parameters[5].Value = model.consumePwd;
            parameters[6].Value = model.tel;
            parameters[7].Value = model.addr;
            parameters[8].Value = model.xPoint;
            parameters[9].Value = model.yPoint;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.sort_id;
            parameters[12].Value = model.isRecommend;
            parameters[13].Value = model.hfPic;
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_ucard_store ");
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
        public WechatBuilder.Model.wx_ucard_store GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,storeName,logo,storeCatagory,cardBrief,consumePwd,tel,addr,xPoint,yPoint,createDate,sort_id,isRecommend,hfPic from wx_ucard_store ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_ucard_store model = new WechatBuilder.Model.wx_ucard_store();
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
        public WechatBuilder.Model.wx_ucard_store DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_ucard_store model = new WechatBuilder.Model.wx_ucard_store();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["storeName"] != null)
                {
                    model.storeName = row["storeName"].ToString();
                }
                if (row["logo"] != null)
                {
                    model.logo = row["logo"].ToString();
                }
                if (row["storeCatagory"] != null)
                {
                    model.storeCatagory = row["storeCatagory"].ToString();
                }
                if (row["cardBrief"] != null)
                {
                    model.cardBrief = row["cardBrief"].ToString();
                }
                if (row["consumePwd"] != null)
                {
                    model.consumePwd = row["consumePwd"].ToString();
                }
                if (row["tel"] != null)
                {
                    model.tel = row["tel"].ToString();
                }
                if (row["addr"] != null)
                {
                    model.addr = row["addr"].ToString();
                }
                if (row["xPoint"] != null && row["xPoint"].ToString() != "")
                {
                    model.xPoint = decimal.Parse(row["xPoint"].ToString());
                }
                if (row["yPoint"] != null && row["yPoint"].ToString() != "")
                {
                    model.yPoint = decimal.Parse(row["yPoint"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["isRecommend"] != null && row["isRecommend"].ToString() != "")
                {
                    if ((row["isRecommend"].ToString() == "1") || (row["isRecommend"].ToString().ToLower() == "true"))
                    {
                        model.isRecommend = true;
                    }
                    else
                    {
                        model.isRecommend = false;
                    }
                }
                if (row["hfPic"] != null)
                {
                    model.hfPic = row["hfPic"].ToString();
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
            strSql.Append("select id,wid,storeName,logo,storeCatagory,cardBrief,consumePwd,tel,addr,xPoint,yPoint,createDate,sort_id,isRecommend,hfPic ");
            strSql.Append(" FROM wx_ucard_store ");
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
            strSql.Append(" id,wid,storeName,logo,storeCatagory,cardBrief,consumePwd,tel,addr,xPoint,yPoint,createDate,sort_id,isRecommend,hfPic ");
            strSql.Append(" FROM wx_ucard_store ");
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
            strSql.Append("select count(1) FROM wx_ucard_store ");
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
            strSql.Append(")AS Row, T.*  from wx_ucard_store T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

       

        #endregion  BasicMethod

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_ucard_store set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		#region  ExtensionMethod
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  *  from wx_ucard_store  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


       /// <summary>
        /// 获得微帐号下的所有店铺列表，并且判断该用户是否已经领取了
       /// </summary>
       /// <param name="wid">微帐号id</param>
       /// <param name="openid">用户openid</param>
       /// <returns></returns>
        public DataSet GetStorelist(int wid,string openid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s.*,u.id as uid,u.openid from wx_ucard_store s left join  wx_ucard_users u  on s.id=u.sid  and openid=@openid where s.wid=@wid");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100),
                    new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = openid;
            parameters[1].Value = wid;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            
            List<CommandInfo> sqllist = new List<CommandInfo>();
          
            //分店
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from wx_ucard_store_fendian ");
            strSql2.Append(" where sId=@sId ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);


            //删除等级
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from wx_ucard_udegree ");
            strSql3.Append(" where sid=@sid ");
            SqlParameter[] parameters3 = {
                    new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters3[0].Value = id;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //卡面设置
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete from wx_ucard_cardinfo ");
            strSql4.Append(" where sId=@sId ");
            SqlParameter[] parameters4 = {
                    new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters4[0].Value = id;
            cmd = new CommandInfo(strSql4.ToString(), parameters4);
            sqllist.Add(cmd);


            //通知
            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("delete from wx_ucard_notice ");
            strSql5.Append(" where sId=@sId ");
            SqlParameter[] parameters5 = {
                    new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters5[0].Value = id;
            cmd = new CommandInfo(strSql5.ToString(), parameters5);
            sqllist.Add(cmd);

            //特权
            StringBuilder strSql6 = new StringBuilder();
            strSql6.Append("delete from wx_ucard_privileges ");
            strSql6.Append(" where sId=@sId ");
            SqlParameter[] parameters6 = {
                    new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters6[0].Value = id;
            cmd = new CommandInfo(strSql6.ToString(), parameters6);
            sqllist.Add(cmd);


            //优惠券
            StringBuilder strSql7 = new StringBuilder();
            strSql7.Append("delete from wx_ucard_ticket ");
            strSql7.Append(" where sId=@sId ");
            SqlParameter[] parameters7 = {
                    new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters7[0].Value = id;
            cmd = new CommandInfo(strSql7.ToString(), parameters7);
            sqllist.Add(cmd);

            //礼品券
            StringBuilder strSql8 = new StringBuilder();
            strSql8.Append("delete from wx_ucard_gift ");
            strSql8.Append(" where sId=@sId ");
            SqlParameter[] parameters8 = {
                    new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters8[0].Value = id;
            cmd = new CommandInfo(strSql8.ToString(), parameters8);
            sqllist.Add(cmd);


            //会员
            StringBuilder strSql9 = new StringBuilder();
            strSql9.Append("delete from wx_ucard_users ");
            strSql9.Append(" where sId=@sId ");
            SqlParameter[] parameters9 = {
                    new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters9[0].Value = id;
            cmd = new CommandInfo(strSql9.ToString(), parameters9);
            sqllist.Add(cmd);

            ////会员领卡信息
            //StringBuilder strSql10 = new StringBuilder();
            //strSql10.Append("delete from wx_ucard_usercard ");
            //strSql10.Append(" where sid=@sid ");
            //SqlParameter[] parameters10 = {
            //        new SqlParameter("@sId", SqlDbType.Int,4)};
            //parameters10[0].Value = id;
            //cmd = new CommandInfo(strSql10.ToString(), parameters10);
            //sqllist.Add(cmd);


            //主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_ucard_store ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

		#endregion  ExtensionMethod
	}
}

