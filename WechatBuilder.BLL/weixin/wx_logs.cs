using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;
using WechatBuilder.Model;
namespace WechatBuilder.BLL
{
	/// <summary>
	/// 微信相关日志表
	/// </summary>
	public partial class wx_logs
	{
		private readonly WechatBuilder.DAL.wx_logs dal=new WechatBuilder.DAL.wx_logs();
		public wx_logs()
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
		public int  Add(WechatBuilder.Model.wx_logs model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_logs model)
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
		public WechatBuilder.Model.wx_logs GetModel(int id)
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
		public List<WechatBuilder.Model.wx_logs> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WechatBuilder.Model.wx_logs> DataTableToList(DataTable dt)
		{
			List<WechatBuilder.Model.wx_logs> modelList = new List<WechatBuilder.Model.wx_logs>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WechatBuilder.Model.wx_logs model;
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

        #region  不带wid的日志记录
        public void AddLog(string content)
        {
            AddLog("", "", content);
        }
        public void AddErrLog(string content)
        {
            AddLog("", "", content, 0);
        }
        public void AddLog(string modelName, string funName, string content)
        {
            AddLog(modelName, funName, content, 1);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志内容</param>
        /// <param name="logsType">日志类型（0错误，1正常）</param>
        public void AddLog(string modelName, string funName, string content, int logsType)
        {

            this.AddLog(modelName, funName, content, logsType, "");
        }

        /// <summary>
        /// 添加flg标志
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="funName"></param>
        /// <param name="flg"></param>
        public void AddFlg(string modelName, string funName, string flg)
        {
            this.AddLog(modelName, funName, "", 1, flg, "");
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志名称</param>
        /// <param name="logsType">日志类型（0错误，1正常）</param>
        /// <param name="flg">标志</param>
        public void AddLog(string modelName, string funName, string content, int logsType, string flg)
        {
            this.AddLog(modelName, funName, content, logsType, flg, "");
        }


        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志名称</param>
        /// <param name="logsType">日志类型（0错误，1正常）</param>
        /// <param name="flg">标志</param>
        /// <param name="flg2">标志2</param>
        public void AddLog(string modelName, string funName, string content, int logsType, string flg, string flg2)
        {
            Model.wx_logs log = new Model.wx_logs();
            log.modelName = modelName;
            log.funName = funName;
            log.logsContent = content;
            log.logsType = logsType;
            log.flg = flg;
            log.flg2 = flg2;
            log.createDate = DateTime.Now;
            this.Add(log);
        }

        /// <summary>
        /// 是否存在标志flg
        /// </summary>
        /// <param name="flg"></param>
        /// <returns></returns>
        public bool ExistsFlg(string flg)
        {
            return dal.ExistsFlg(flg);
        }

        #endregion  ExtensionMethod

        #region  带wid的日志记录

        public void AddFlg(int wid,string modelName, string funName, string flg)
        {
            this.AddLog(wid,modelName, funName, "", 1, flg, "");
        }


        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="content"></param>
        public void AddLog(int wid, string content)
        {
            AddLog(wid, "", "", content);
        }

        /// <summary>
        /// 添加日志：错误的
        /// </summary>
        /// <param name="wid">微帐号</param>
        /// <param name="content">日志内容</param>
        public void AddErrLog(int wid, string content)
        {
            AddErrLog(wid, "", "", content);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="wid">微帐号</param>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志内容</param>
        public void AddLog(int wid, string modelName, string funName, string content)
        {
            AddLog(wid, modelName, funName, content, 1);
        }

        /// <summary>
        /// 添加日志：错误的
        /// </summary>
        /// <param name="wid">微帐号</param>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志内容</param>
        public void AddErrLog(int wid, string modelName, string funName, string content)
        {
            AddLog(wid, modelName, funName, content, 0);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="wid">微帐号</param>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志内容</param>
        /// <param name="logsType">日志类型（0错误，1正常）</param>
        public void AddLog(int wid, string modelName, string funName, string content, int logsType)
        {
            this.AddLog(wid, modelName, funName, content, logsType, "");
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志名称</param>
        /// <param name="logsType">日志类型（0错误，1正常）</param>
        /// <param name="flg">标志</param>
        public void AddLog(int wid, string modelName, string funName, string content, int logsType, string flg)
        {
            this.AddLog(wid, modelName, funName, content, logsType, flg, "");
        }


        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <param name="funName">方法名称</param>
        /// <param name="content">日志名称</param>
        /// <param name="logsType">日志类型（0错误，1正常）</param>
        /// <param name="flg">标志</param>
        /// <param name="flg2">标志2</param>
        public void AddLog(int wid, string modelName, string funName, string content, int logsType, string flg, string flg2)
        {
            Model.wx_logs log = new Model.wx_logs();
            log.wid = wid;
            log.modelName = modelName;
            log.funName = funName;
            log.logsContent = content;
            log.logsType = logsType;
            log.flg = flg;
            log.flg2 = flg2;
            log.createDate = DateTime.Now;
            this.Add(log);
        }

        #endregion  ExtensionMethod
        
	}
}

