using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;
using WechatBuilder.Common;//Please add references
namespace WechatBuilder.DAL
{
    /// <summary>
    /// 数据访问类:wx_xt_base
    /// </summary>
    public partial class wx_xt_base
    {
        public wx_xt_base()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_xt_base");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_xt_base");
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
        public int Add(WechatBuilder.Model.wx_xt_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_xt_base(");
            strSql.Append("wid,wxTitle,keywords,fengmian,donghua,donghuaSlt,manName,felmanName,nameSeq,tel,statedate,addr,lngX,latY,video,video2,music,word,sqrurl,copyrite,createDate,templateId,templateName,pwd,extStr,extStr2,extInt)");
            strSql.Append(" values (");
            strSql.Append("@wid,@wxTitle,@keywords,@fengmian,@donghua,@donghuaSlt,@manName,@felmanName,@nameSeq,@tel,@statedate,@addr,@lngX,@latY,@video,@video2,@music,@word,@sqrurl,@copyrite,@createDate,@templateId,@templateName,@pwd,@extStr,@extStr2,@extInt)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@wxTitle", SqlDbType.VarChar,40),
					new SqlParameter("@keywords", SqlDbType.VarChar,100),
					new SqlParameter("@fengmian", SqlDbType.VarChar,1000),
					new SqlParameter("@donghua", SqlDbType.VarChar,1000),
					new SqlParameter("@donghuaSlt", SqlDbType.VarChar,1000),
					new SqlParameter("@manName", SqlDbType.VarChar,50),
					new SqlParameter("@felmanName", SqlDbType.VarChar,50),
					new SqlParameter("@nameSeq", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,40),
					new SqlParameter("@statedate", SqlDbType.DateTime),
					new SqlParameter("@addr", SqlDbType.VarChar,500),
					new SqlParameter("@lngX", SqlDbType.Float,8),
					new SqlParameter("@latY", SqlDbType.Float,8),
					new SqlParameter("@video", SqlDbType.VarChar,1000),
					new SqlParameter("@video2", SqlDbType.VarChar,1000),
					new SqlParameter("@music", SqlDbType.VarChar,1000),
					new SqlParameter("@word", SqlDbType.VarChar,500),
					new SqlParameter("@sqrurl", SqlDbType.VarChar,1000),
					new SqlParameter("@copyrite", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@templateId", SqlDbType.Int,4),
					new SqlParameter("@templateName", SqlDbType.VarChar,300),
					new SqlParameter("@pwd", SqlDbType.VarChar,100),
					new SqlParameter("@extStr", SqlDbType.VarChar,1000),
					new SqlParameter("@extStr2", SqlDbType.VarChar,4000),
					new SqlParameter("@extInt", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.wxTitle;
            parameters[2].Value = model.keywords;
            parameters[3].Value = model.fengmian;
            parameters[4].Value = model.donghua;
            parameters[5].Value = model.donghuaSlt;
            parameters[6].Value = model.manName;
            parameters[7].Value = model.felmanName;
            parameters[8].Value = model.nameSeq;
            parameters[9].Value = model.tel;
            parameters[10].Value = model.statedate;
            parameters[11].Value = model.addr;
            parameters[12].Value = model.lngX;
            parameters[13].Value = model.latY;
            parameters[14].Value = model.video;
            parameters[15].Value = model.video2;
            parameters[16].Value = model.music;
            parameters[17].Value = model.word;
            parameters[18].Value = model.sqrurl;
            parameters[19].Value = model.copyrite;
            parameters[20].Value = model.createDate;
            parameters[21].Value = model.templateId;
            parameters[22].Value = model.templateName;
            parameters[23].Value = model.pwd;
            parameters[24].Value = model.extStr;
            parameters[25].Value = model.extStr2;
            parameters[26].Value = model.extInt;

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
        public bool Update(WechatBuilder.Model.wx_xt_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_xt_base set ");
            strSql.Append("wid=@wid,");
            strSql.Append("wxTitle=@wxTitle,");
            strSql.Append("keywords=@keywords,");
            strSql.Append("fengmian=@fengmian,");
            strSql.Append("donghua=@donghua,");
            strSql.Append("donghuaSlt=@donghuaSlt,");
            strSql.Append("manName=@manName,");
            strSql.Append("felmanName=@felmanName,");
            strSql.Append("nameSeq=@nameSeq,");
            strSql.Append("tel=@tel,");
            strSql.Append("statedate=@statedate,");
            strSql.Append("addr=@addr,");
            strSql.Append("lngX=@lngX,");
            strSql.Append("latY=@latY,");
            strSql.Append("video=@video,");
            strSql.Append("video2=@video2,");
            strSql.Append("music=@music,");
            strSql.Append("word=@word,");
            strSql.Append("sqrurl=@sqrurl,");
            strSql.Append("copyrite=@copyrite,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("templateId=@templateId,");
            strSql.Append("templateName=@templateName,");
            strSql.Append("pwd=@pwd,");
            strSql.Append("extStr=@extStr,");
            strSql.Append("extStr2=@extStr2,");
            strSql.Append("extInt=@extInt");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@wxTitle", SqlDbType.VarChar,40),
					new SqlParameter("@keywords", SqlDbType.VarChar,100),
					new SqlParameter("@fengmian", SqlDbType.VarChar,1000),
					new SqlParameter("@donghua", SqlDbType.VarChar,1000),
					new SqlParameter("@donghuaSlt", SqlDbType.VarChar,1000),
					new SqlParameter("@manName", SqlDbType.VarChar,50),
					new SqlParameter("@felmanName", SqlDbType.VarChar,50),
					new SqlParameter("@nameSeq", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.VarChar,40),
					new SqlParameter("@statedate", SqlDbType.DateTime),
					new SqlParameter("@addr", SqlDbType.VarChar,500),
					new SqlParameter("@lngX", SqlDbType.Float,8),
					new SqlParameter("@latY", SqlDbType.Float,8),
					new SqlParameter("@video", SqlDbType.VarChar,1000),
					new SqlParameter("@video2", SqlDbType.VarChar,1000),
					new SqlParameter("@music", SqlDbType.VarChar,1000),
					new SqlParameter("@word", SqlDbType.VarChar,500),
					new SqlParameter("@sqrurl", SqlDbType.VarChar,1000),
					new SqlParameter("@copyrite", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@templateId", SqlDbType.Int,4),
					new SqlParameter("@templateName", SqlDbType.VarChar,300),
					new SqlParameter("@pwd", SqlDbType.VarChar,100),
					new SqlParameter("@extStr", SqlDbType.VarChar,1000),
					new SqlParameter("@extStr2", SqlDbType.VarChar,4000),
					new SqlParameter("@extInt", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.wxTitle;
            parameters[2].Value = model.keywords;
            parameters[3].Value = model.fengmian;
            parameters[4].Value = model.donghua;
            parameters[5].Value = model.donghuaSlt;
            parameters[6].Value = model.manName;
            parameters[7].Value = model.felmanName;
            parameters[8].Value = model.nameSeq;
            parameters[9].Value = model.tel;
            parameters[10].Value = model.statedate;
            parameters[11].Value = model.addr;
            parameters[12].Value = model.lngX;
            parameters[13].Value = model.latY;
            parameters[14].Value = model.video;
            parameters[15].Value = model.video2;
            parameters[16].Value = model.music;
            parameters[17].Value = model.word;
            parameters[18].Value = model.sqrurl;
            parameters[19].Value = model.copyrite;
            parameters[20].Value = model.createDate;
            parameters[21].Value = model.templateId;
            parameters[22].Value = model.templateName;
            parameters[23].Value = model.pwd;
            parameters[24].Value = model.extStr;
            parameters[25].Value = model.extStr2;
            parameters[26].Value = model.extInt;
            parameters[27].Value = model.id;

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
            strSql.Append("delete from wx_xt_base ");
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
            strSql.Append("delete from wx_xt_base ");
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
        public WechatBuilder.Model.wx_xt_base GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,wxTitle,keywords,fengmian,donghua,donghuaSlt,manName,felmanName,nameSeq,tel,statedate,addr,lngX,latY,video,video2,music,word,sqrurl,copyrite,createDate,templateId,templateName,pwd,extStr,extStr2,extInt from wx_xt_base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            WechatBuilder.Model.wx_xt_base model = new WechatBuilder.Model.wx_xt_base();
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
        public WechatBuilder.Model.wx_xt_base DataRowToModel(DataRow row)
        {
            WechatBuilder.Model.wx_xt_base model = new WechatBuilder.Model.wx_xt_base();
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
                if (row["wxTitle"] != null)
                {
                    model.wxTitle = row["wxTitle"].ToString();
                }
                if (row["keywords"] != null)
                {
                    model.keywords = row["keywords"].ToString();
                }
                if (row["fengmian"] != null)
                {
                    model.fengmian = row["fengmian"].ToString();
                }
                if (row["donghua"] != null)
                {
                    model.donghua = row["donghua"].ToString();
                }
                if (row["donghuaSlt"] != null)
                {
                    model.donghuaSlt = row["donghuaSlt"].ToString();
                }
                if (row["manName"] != null)
                {
                    model.manName = row["manName"].ToString();
                }
                if (row["felmanName"] != null)
                {
                    model.felmanName = row["felmanName"].ToString();
                }
                if (row["nameSeq"] != null && row["nameSeq"].ToString() != "")
                {
                    model.nameSeq = int.Parse(row["nameSeq"].ToString());
                }
                if (row["tel"] != null)
                {
                    model.tel = row["tel"].ToString();
                }
                if (row["statedate"] != null && row["statedate"].ToString() != "")
                {
                    model.statedate = DateTime.Parse(row["statedate"].ToString());
                }
                if (row["addr"] != null)
                {
                    model.addr = row["addr"].ToString();
                }
                if (row["lngX"] != null && row["lngX"].ToString() != "")
                {
                    model.lngX = decimal.Parse(row["lngX"].ToString());
                }
                if (row["latY"] != null && row["latY"].ToString() != "")
                {
                    model.latY = decimal.Parse(row["latY"].ToString());
                }
                if (row["video"] != null)
                {
                    model.video = row["video"].ToString();
                }
                if (row["video2"] != null)
                {
                    model.video2 = row["video2"].ToString();
                }
                if (row["music"] != null)
                {
                    model.music = row["music"].ToString();
                }
                if (row["word"] != null)
                {
                    model.word = row["word"].ToString();
                }
                if (row["sqrurl"] != null)
                {
                    model.sqrurl = row["sqrurl"].ToString();
                }
                if (row["copyrite"] != null)
                {
                    model.copyrite = row["copyrite"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["templateId"] != null && row["templateId"].ToString() != "")
                {
                    model.templateId = int.Parse(row["templateId"].ToString());
                }
                if (row["templateName"] != null)
                {
                    model.templateName = row["templateName"].ToString();
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
                }
                if (row["extStr"] != null)
                {
                    model.extStr = row["extStr"].ToString();
                }
                if (row["extStr2"] != null)
                {
                    model.extStr2 = row["extStr2"].ToString();
                }
                if (row["extInt"] != null && row["extInt"].ToString() != "")
                {
                    model.extInt = int.Parse(row["extInt"].ToString());
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
            strSql.Append("select id,wid,wxTitle,keywords,fengmian,donghua,donghuaSlt,manName,felmanName,nameSeq,tel,statedate,addr,lngX,latY,video,video2,music,word,sqrurl,copyrite,createDate,templateId,templateName,pwd,extStr,extStr2,extInt ");
            strSql.Append(" FROM wx_xt_base ");
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
            strSql.Append(" id,wid,wxTitle,keywords,fengmian,donghua,donghuaSlt,manName,felmanName,nameSeq,tel,statedate,addr,lngX,latY,video,video2,music,word,sqrurl,copyrite,createDate,templateId,templateName,pwd,extStr,extStr2,extInt ");
            strSql.Append(" FROM wx_xt_base ");
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
            strSql.Append("select count(1) FROM wx_xt_base ");
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
            strSql.Append(")AS Row, T.*  from wx_xt_base T ");
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
            parameters[0].Value = "wx_xt_base";
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
            strSql.Append(" select  * from wx_xt_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        ///  删除一条喜帖信息，连带删除关联的其他信息【微信回复表的数据，喜帖相册，喜帖报名人信息，喜帖祝福信息】
        /// </summary>
        /// <param name="id">喜帖基本表的主键</param>
        /// <returns></returns>
        public bool DeleteXitie(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_requestRule where modelFunctionName='喜帖' and modelFunctionId=@id ; ");
            strSql.Append("delete from wx_xt_base  where id=@id ; ");
            strSql.Append("delete from wx_xt_photo  where bId=@id ; ");
            strSql.Append("delete from wx_xt_user  where bId=@id ; ");
            strSql.Append("delete from wx_xt_zhufu  where bId=@id ; ");
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


        #endregion  ExtensionMethod
    }
}

