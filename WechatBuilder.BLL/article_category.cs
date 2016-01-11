using System;
using System.Data;
using System.Collections.Generic;

namespace WechatBuilder.BLL
{
    /// <summary>
    /// 类别业务类
    /// </summary>
    public partial class article_category
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.article_category dal;
        public article_category()
        {
            dal = new DAL.article_category(siteConfig.sysdatabaseprefix);
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.article_category model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.article_category model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.article_category GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetChildList(int parent_id, int channel_id)
        {
            return dal.GetChildList(parent_id, channel_id);
        }

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_name">频道名称</param>
        /// <returns></returns>
        public DataTable GetChildList(int parent_id, string channel_name)
        {
            int channel_id = new channel().GetChannelId(channel_name);
            return dal.GetChildList(parent_id, channel_id);
        }

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetList(int parent_id, int channel_id)
        {
            return dal.GetList(parent_id, channel_id);
        }

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_name">频道名称</param>
        /// <returns></returns>
        public DataTable GetList(int parent_id, string channel_name)
        {
            int channel_id = new channel().GetChannelId(channel_name);
            return dal.GetList(parent_id, channel_id);
        }

        #region 扩展方法================================
        /// <summary>
        /// 取得父节点的ID
        /// </summary>
        public int GetParentId(int id)
        {
            return dal.GetParentId(id);
        }

        /// <summary>
        /// 取得该微帐号的所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetWCodeList(int wid,int parent_id, int channel_id)
        {
            return dal.GetWCodeList(wid,parent_id, channel_id);
        }

        #endregion

        #endregion
    }
}