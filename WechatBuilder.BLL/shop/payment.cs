using System;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;

namespace WechatBuilder.BLL
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public partial class payment
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.payment dal;
        public payment()
        {
            dal = new DAL.payment(siteConfig.sysdatabaseprefix);
        }

        #region  基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 返回标题名称
        /// </summary>
        public string GetTitle(int wid,int ptypeId)
        {
            return dal.GetTitle(wid, ptypeId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.payment model)
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
        public bool Update(Model.payment model)
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
        /// 得到一个对象实体
        /// </summary>
        public Model.payment GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.payment GetModelBypTypeId(int pTypeId)
        {
            return dal.GetModelBypTypeId(pTypeId);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        #endregion  Method


    }
}