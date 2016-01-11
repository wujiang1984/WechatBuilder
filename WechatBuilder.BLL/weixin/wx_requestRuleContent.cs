using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 微信请求回复的内容
	/// </summary>
	public partial class wx_requestRuleContent
	{
		private readonly WechatBuilder.DAL.wx_requestRuleContent dal=new WechatBuilder.DAL.wx_requestRuleContent();
		public wx_requestRuleContent()
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
		public int  Add(WechatBuilder.Model.wx_requestRuleContent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_requestRuleContent model)
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
		public WechatBuilder.Model.wx_requestRuleContent GetModel(int id)
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
		public List<WechatBuilder.Model.wx_requestRuleContent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_requestRuleContent> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_requestRuleContent> modelList = new List<WechatBuilder.Model.wx_requestRuleContent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_requestRuleContent model;
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

        #region 微信端获取数据，需要提升效率

        /// <summary>
        /// 得到回复规则的纯文本信息
        /// </summary>
        ///<param name="rid">规则主键Id</param>
        /// <returns></returns>
        public string GetTxtContent(int rid)
        {
            return dal.GetTxtContent(rid);
        }
        /// <summary>
        /// 2014-9-18新增抽奖功能
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public string GetTxtContent(string  openid)
        {
            return dal.GetTxtContent(openid);
        }

        /// <summary>
        /// 得到回复规则的语音信息
        /// </summary>
        /// <param name="rid">规则主键Id</param>
        /// <returns></returns>
        public WechatBuilder.Model.wx_requestRuleContent GetMusicContent(int rid)
        {
            return dal.GetMusicContent(rid);
        }

        /// <summary>
        /// 得到回复规则的【图文】信息
        /// </summary>
        /// <param name="rid">规则主键Id</param>
        /// <returns></returns>
        public IList<WechatBuilder.Model.wx_requestRuleContent> GetTuWenContent(int rid)
        {

            IList<Model.wx_requestRuleContent> twList = new List<Model.wx_requestRuleContent>();
            twList = dal.GetTuWenContent(rid);

            return twList;
        }


        #endregion

		#region  ExtensionMethod

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<WechatBuilder.Model.wx_requestRuleContent> GetModelList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds= dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 如果有该openid已经注册过会员卡信息，则拼接cardno=卡号
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public string cardnoStr(int wid,string openid)
        {
            string ret = "";
            if (openid == null || openid.Trim() == "")
            {
                return "";
            }
            BLL.users ubll = new BLL.users();
            string cardno = ubll.getCardnoByOpenId(wid,openid);
            if (cardno == "")
            {
                ret = "";
            }
            else
            {
                ret = "&cardno=" + cardno;
            }
            return ret;

        }

		#endregion  ExtensionMethod
	}
}

