using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.Common;
using WechatBuilder.DBUtility;
using System.Data;

namespace WechatBuilder.DAL
{
    public class article_images_size
    {

         private string databaseprefix; //数据库表名前缀
         public article_images_size(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;

        }
        /// <summary>
        /// 查找不存在的图片并删除已删除的图片及数据
        /// </summary>
         public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.article_images_size> models, int category_id)
         {
             StringBuilder idList = new StringBuilder();
             if (models != null)
             {
                 foreach (Model.article_images_size modelt in models)
                 {
                     if (modelt.id > 0)
                     {
                         idList.Append(modelt.id + ",");
                     }
                 }
             }
             string id_list = Utils.DelLastChar(idList.ToString(), ",");
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select id,height,width,category_id from " + databaseprefix + "article_images_size where category_id=" + category_id);
             if (!string.IsNullOrEmpty(id_list))
             {
                 strSql.Append(" and id not in(" + id_list + ")");
             }
             DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
             foreach (DataRow dr in ds.Tables[0].Rows)
             {
                 DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "article_images_size where id=" + dr["id"].ToString()); //删除数据库           
             }
         }

         /// <summary>
         /// 获得数据列表
         /// </summary>
         public List<Model.article_images_size> GetCategoryImageSizeById(int category_id)
         {
             List<Model.article_images_size> modelList = new List<Model.article_images_size>();

             StringBuilder strSql = new StringBuilder();
             strSql.Append("select  id,category_id,height,width from " + databaseprefix + "article_images_size ");
             strSql.Append(" where category_id=@category_id");
             SqlParameter[] parameters = {
					new SqlParameter("@category_id", SqlDbType.Int,4)
			};
             parameters[0].Value = category_id;

             DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
             int rowsCount = ds.Tables[0].Rows.Count;
             if (rowsCount > 0)
             {
                 for (int n = 0; n < rowsCount; n++)
                 {
                     modelList.Add(DataRowToModel(ds.Tables[0].Rows[n]));
                 }
             }
             return modelList;
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public Model.article_images_size DataRowToModel(DataRow row)
         {
             Model.article_images_size model = new Model.article_images_size();
             if (row != null)
             {
                 if (row["id"] != null && row["id"].ToString() != "")
                 {
                     model.id = int.Parse(row["id"].ToString());
                 }
                 if (row["category_id"] != null && row["category_id"].ToString() != "")
                 {
                     model.category_id = int.Parse(row["category_id"].ToString());
                 }
                 if (row["height"] != null)
                 {
                     model.height = row["height"].ToString();
                 }
                 if (row["width"] != null)
                 {
                     model.width = row["width"].ToString();
                 }
             }
             return model;
         }

    }
}
