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
    /// 数据访问类:wx_wsite_setting
    /// </summary>
    public partial class templatesDal
    {
        public templatesDal()
        { }

        #region 微网站模版

        /// <summary>
        /// 通过wid获得该微帐号的站点信息,(换成存储过程获得数据)
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="templateskin">模版的虚拟路劲</param>
        /// <returns></returns>
        public WechatBuilder.Model.wxcodeconfig GetModelByWid(int wid, string templateskin)
        {

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  top 1 ws.id,wId,wName,companyName,bgMusic,bgPic,bgDongHuaId,wCopyright,wBrief,ws.remark,phone,addr,addrUrl,email,seo_title,seo_keywords,seo_desc");
            //strSql.Append(",wxName,wxId,weixinCode,headerpic,wxprovince,wxcity,w.enddate ");
            //strSql.Append(" from wx_wsite_setting  ws,wx_userweixin  w ");
            //strSql.Append(" where ws.wId=w.id and  w.id=@wId  and w.isDelete=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;


            WechatBuilder.Model.wxcodeconfig config = new WechatBuilder.Model.wxcodeconfig();
            SqlDataReader sr = DbHelperSQL.RunProcedure("p_wcode_wsiteinfo", parameters);
            while (sr.Read())
            {
                config.wid = wid;
                #region 微信帐号的基本信息
                config.wxcode = MyCommFun.ObjToStr(sr["weixinCode"]);
                config.wxname = MyCommFun.ObjToStr(sr["wxName"]);
                config.wxphoto = MyCommFun.ObjToStr(sr["headerpic"]);
                config.wxprovince = MyCommFun.ObjToStr(sr["wxprovince"]);
                config.wxcity = MyCommFun.ObjToStr(sr["wxcity"]);
                if (DateTime.Parse(sr["enddate"].ToString()) < DateTime.Now)
                { //过期
                    config.wxstatus = 0;
                }
                else
                {
                    config.wxstatus = 1;
                }

                #endregion

                #region 微网站的基本信息
                config.templateskin = templateskin;
                config.sitename = MyCommFun.ObjToStr(sr["wName"]);
                config.companyname = MyCommFun.ObjToStr(sr["companyName"]);
                config.bgmusic = MyCommFun.ObjToStr(sr["bgMusic"]);
                config.bgpic = MyCommFun.ObjToStr(sr["bgPic"]);
                config.bgdonghuaid = MyCommFun.Obj2Int(sr["bgDongHuaId"]);
                config.wcopyright = MyCommFun.ObjToStr(sr["wCopyright"]);
                config.wbrief = MyCommFun.ObjToStr(sr["wBrief"]);
                config.remark = MyCommFun.ObjToStr(sr["remark"]);
                config.phone = MyCommFun.ObjToStr(sr["phone"]);
                config.addr = MyCommFun.ObjToStr(sr["addr"]);
                config.addrurl = MyCommFun.ObjToStr(sr["addrUrl"]);

                config.email = MyCommFun.ObjToStr(sr["email"]);
                config.seotitle = MyCommFun.ObjToStr(sr["seo_title"]);
                config.seokeywords = MyCommFun.ObjToStr(sr["seo_keywords"]);
                config.seodesc = MyCommFun.ObjToStr(sr["seo_desc"]);
                config.topht = MyCommFun.ObjToStr(sr["topcolorHtml"]);

                #endregion



            }
            sr.Close();

            return config;
        }



        /// <summary>
        /// 取幻灯片信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="topNum">取前几条数据，若为-1，则取全部的数据</param>
        public IList<Model.article> GetHDPByWid(int wid, int topNum)
        {
            IList<Model.article> hdpList = new List<Model.article>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (topNum >= 0)
            {
                strSql.Append(" top " + topNum + " ");
            }
            strSql.Append("id,title,link_url,img_url,content,sort_id from dt_article where channel_id=3 and category_id=1  ");
            strSql.Append(" and wId=@wId order by sort_id asc");
            SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            Model.article hdp = new Model.article();
            while (sr.Read())
            {
                hdp = new Model.article();
                hdp.id = MyCommFun.Obj2Int(sr["id"]);
                hdp.title = MyCommFun.ObjToStr(sr["title"]);
                hdp.link_url = MyCommFun.ObjToStr(sr["link_url"]);
                hdp.img_url = MyCommFun.ObjToStr(sr["img_url"]);
                hdp.content = MyCommFun.ObjToStr(sr["content"]);
                hdp.sort_id = MyCommFun.Obj2Int(sr["sort_id"]);
                hdpList.Add(hdp);
            }
            sr.Close();
            return hdpList;

        }


        /// <summary>
        /// 获得微帐号的分类信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="topNum">取前几条数据；若为-1，则不作筛选条件</param>
        /// <param name="parentId">若为-1，则不作筛选条件</param>
        /// <returns></returns>
        public IList<Model.article_category> GetCategoryListByWid(int wid, int topNum, int parentId, int class_layer)
        {
            IList<Model.article_category> categoryList = new List<Model.article_category>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (topNum >= 0)
            {
                strSql.Append(" top " + topNum + " ");
            }
            strSql.Append(" (select count(1) from dt_article_category sc where c.id=sc.parent_id) hasSun,id,title,call_index,parent_id,class_layer,link_url,img_url,[content],ico_url,seo_title,seo_keywords,seo_description from dt_article_category c where channel_id=1 ");
            if (parentId != -1)
            {
                strSql.Append(" and parent_id=" + parentId);
            }
            if (class_layer != -1)
            {
                strSql.Append(" and class_layer=" + class_layer);
            }

            strSql.Append(" and wId=@wId order by sort_id asc");
            SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            Model.article_category category = new Model.article_category();
            while (sr.Read())
            {
                category = new Model.article_category();
                category.id = MyCommFun.Obj2Int(sr["id"]);
                category.title = MyCommFun.ObjToStr(sr["title"]);
                category.call_index = MyCommFun.ObjToStr(sr["call_index"]);
                category.parent_id = MyCommFun.Obj2Int(sr["parent_id"]);
                category.class_layer = MyCommFun.Obj2Int(sr["class_layer"]);
                category.link_url = MyCommFun.ObjToStr(sr["link_url"]);
                category.img_url = MyCommFun.ObjToStr(sr["img_url"]);
                category.content = MyCommFun.ObjToStr(sr["content"]);
                category.ico_url = MyCommFun.ObjToStr(sr["ico_url"]);
                category.seo_title = MyCommFun.ObjToStr(sr["seo_title"]);
                category.seo_keywords = MyCommFun.ObjToStr(sr["seo_keywords"]);
                category.seo_description = MyCommFun.ObjToStr(sr["seo_description"]);
                if (sr["hasSun"].ToString() == "0")
                {//无子分类
                    category.hasSun = false;
                }
                else
                {  //有子类
                    category.hasSun = true;
                }
                categoryList.Add(category);
            }
            sr.Close();



            return categoryList;
        }

        /// <summary>
        /// 获得微帐号的底部菜单信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="topNum">取前几条数据；若为-1，则不作筛选条件</param>
        /// <param name="parentId">若为-1，则不作筛选条件</param>
        /// <returns></returns>
        public IList<Model.article_category> GetBottomMenuByWid(int wid, int topNum, int parentId, int class_layer)
        {
            IList<Model.article_category> bottomList = new List<Model.article_category>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (topNum >= 0)
            {
                strSql.Append(" top " + topNum + " ");
            }
            strSql.Append(" id,title,call_index,parent_id,class_layer,link_url,img_url,[content],ico_url,seo_title,seo_keywords,seo_description from dt_article_category where channel_id=7 ");
            if (parentId != -1)
            {
                strSql.Append(" and parent_id=" + parentId);
            }
            if (class_layer != -1)
            {
                strSql.Append(" and class_layer=" + class_layer);
            }
            strSql.Append(" and wId=@wId order by sort_id asc");
            SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);

            Model.article_category category = new Model.article_category();
            while (sr.Read())
            {
                category = new Model.article_category();
                category.id = MyCommFun.Obj2Int(sr["id"]);
                category.title = MyCommFun.ObjToStr(sr["title"]);
                category.call_index = MyCommFun.ObjToStr(sr["call_index"]);
                category.parent_id = MyCommFun.Obj2Int(sr["parent_id"]);
                category.class_layer = MyCommFun.Obj2Int(sr["class_layer"]);
                category.link_url = MyCommFun.ObjToStr(sr["link_url"]);
                category.img_url = MyCommFun.ObjToStr(sr["img_url"]);
                category.content = MyCommFun.ObjToStr(sr["content"]);
                category.ico_url = MyCommFun.ObjToStr(sr["ico_url"]);
                category.seo_title = MyCommFun.ObjToStr(sr["seo_title"]);
                category.seo_keywords = MyCommFun.ObjToStr(sr["seo_keywords"]);
                category.seo_description = MyCommFun.ObjToStr(sr["seo_description"]);
                bottomList.Add(category);
            }
            sr.Close();


            return bottomList;
        }


        /// <summary>
        /// 获得该分类信息，使用wid仅仅作为限制条件
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.article_category GetCategoryByWid(int wid, int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1");
            strSql.Append(" id,title,call_index,parent_id,class_layer,link_url,img_url,[content],ico_url,seo_title,seo_keywords,seo_description  ");
            strSql.Append(" from dt_article_category  where   id=@id  and wId=@wId");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@wId", SqlDbType.Int,4)
			};
            parameters[0].Value = id;
            parameters[1].Value = wid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            Model.article_category category = new Model.article_category();
            while (sr.Read())
            {
                category = new Model.article_category();
                category.id = MyCommFun.Obj2Int(sr["id"]);
                category.title = MyCommFun.ObjToStr(sr["title"]);
                category.call_index = MyCommFun.ObjToStr(sr["call_index"]);
                category.parent_id = MyCommFun.Obj2Int(sr["parent_id"]);
                category.class_layer = MyCommFun.Obj2Int(sr["class_layer"]);
                category.link_url = MyCommFun.ObjToStr(sr["link_url"]);
                category.img_url = MyCommFun.ObjToStr(sr["img_url"]);
                category.content = MyCommFun.ObjToStr(sr["content"]);
                category.ico_url = MyCommFun.ObjToStr(sr["ico_url"]);
                category.seo_title = MyCommFun.ObjToStr(sr["seo_title"]);
                category.seo_keywords = MyCommFun.ObjToStr(sr["seo_keywords"]);
                category.seo_description = MyCommFun.ObjToStr(sr["seo_description"]);
            }
            sr.Close();
            return category;
        }


        #endregion

        #region 官网pc

        public DataSet GetPc_Article(int article_category_Id, string whereStr, int topNum, string orderStr)
        {
            DAL.article artDal = new article();
            string where = "category_id=" + article_category_Id;
            if (whereStr != null && whereStr.Trim().Length > 0)
            {
                where += " and " + whereStr;
            }
            return artDal.GetList(topNum, where, orderStr);

        }

        #endregion




    }
}

