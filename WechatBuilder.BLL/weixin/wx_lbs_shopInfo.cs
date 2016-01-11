using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 微信lbs商店地理位
	/// </summary>
	public partial class wx_lbs_shopInfo
	{
		private readonly WechatBuilder.DAL.wx_lbs_shopInfo dal=new WechatBuilder.DAL.wx_lbs_shopInfo();
		public wx_lbs_shopInfo()
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
		public int  Add(WechatBuilder.Model.wx_lbs_shopInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_lbs_shopInfo model)
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
		public WechatBuilder.Model.wx_lbs_shopInfo GetModel(int id)
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
		public List<WechatBuilder.Model.wx_lbs_shopInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_lbs_shopInfo> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_lbs_shopInfo> modelList = new List<WechatBuilder.Model.wx_lbs_shopInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_lbs_shopInfo model;
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public List<Model.wx_lbs_shopInfo> GetDetailList(int wid,string strWhere)
        {
            return dal.GetDetailList(wid,strWhere);
        }

        ///<summary>返回两个经纬度坐标点的距离（单位：米） by Alex.Y</summary>
        ///<param name="Longtiude">来源坐标经度Y</param>
        ///<param name="Latitude">来源坐标纬度X</param>
        ///<param name="Longtiude2">目标坐标经度Y</param>
        ///<param name="Latitude2">目标坐标纬度X</param>
        ///<returns>返回距离（米）</returns>
        public double getMapDistance(double Longtiude, double Latitude, double Longtiude2, double Latitude2)
        {

            var lat1 = Latitude;
            var lon1 = Longtiude;
            var lat2 = Latitude2;
            var lon2 = Longtiude2;
            var earthRadius = 6371; //appxoximate radius in miles  6378.137

            var factor = Math.PI / 180.0;
            var dLat = (lat2 - lat1) * factor;
            var dLon = (lon2 - lon1) * factor;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1 * factor)
              * Math.Cos(lat2 * factor) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double d = earthRadius * c * 1000;

            return d;

        }


		#endregion  ExtensionMethod
	}
}

