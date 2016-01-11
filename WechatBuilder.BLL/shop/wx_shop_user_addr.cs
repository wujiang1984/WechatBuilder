using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 用户地址表
	/// </summary>
	public partial class wx_shop_user_addr
	{
		private readonly WechatBuilder.DAL.wx_shop_user_addr dal=new WechatBuilder.DAL.wx_shop_user_addr();
		public wx_shop_user_addr()
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
		public int  Add(WechatBuilder.Model.wx_shop_user_addr model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_shop_user_addr model)
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
		public WechatBuilder.Model.wx_shop_user_addr GetModel(int id)
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
		public List<WechatBuilder.Model.wx_shop_user_addr> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_shop_user_addr> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_shop_user_addr> modelList = new List<WechatBuilder.Model.wx_shop_user_addr>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_shop_user_addr model;
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
		 

		#endregion  BasicMethod
		#region  ExtensionMethod


      /// <summary>
     /// 获得微信用户的地址
      /// </summary>
      /// <param name="openid"></param>
      /// <param name="wid"></param>
      /// <returns></returns>
        public List<WechatBuilder.Model.wx_shop_user_addr> GetOpenidAddr(string openid, int wid)
        {
            DataSet ds = dal.GetOpenidAddr(openid,wid);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 获得微信用户的地址(把省份，城市，区域的名字展示出来)
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public List<WechatBuilder.Model.wx_shop_user_addr> GetOpenidAddrName(string openid, int wid)
        {
            DataSet ds = dal.GetOpenidAddrName(openid, wid);
            return DataTableToList(ds.Tables[0]);
        }

       

		#endregion  ExtensionMethod
	}
}

