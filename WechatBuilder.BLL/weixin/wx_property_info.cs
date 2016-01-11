using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
using System.Text;
using System.Data.SqlClient;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 微信属性值存储值 
	/// </summary>
	public partial class wx_property_info
	{
		private readonly WechatBuilder.DAL.wx_property_info dal=new WechatBuilder.DAL.wx_property_info();
		public wx_property_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(WechatBuilder.Model.wx_property_info model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_property_info model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WechatBuilder.Model.wx_property_info GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_property_info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_property_info> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_property_info> modelList = new List<WechatBuilder.Model.wx_property_info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_property_info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 添加access_token值
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public string AddAccess_Token(int wid,string access_token)
        {
            string ret = "";
            try
            {
                WechatBuilder.Model.wx_property_info wxProperty = new WechatBuilder.Model.wx_property_info();
                wxProperty.iName = "access_token";
                wxProperty.typeId = 1;
                wxProperty.typeName = "base";
                wxProperty.iContent = access_token;
                wxProperty.expires_in = 1200;
                wxProperty.createDate = DateTime.Now;
                wxProperty.count = 1;
                wxProperty.wid = wid;
                Add(wxProperty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return "";
        }

        /// <summary>
        /// 该微帐号是否存在记录
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public bool ExistsWid(int wid)
        {
          return    dal.ExistsWid(wid);
        }

		#endregion  ExtensionMethod
	}
}

