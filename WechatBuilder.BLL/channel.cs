using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using WechatBuilder.Common;

namespace WechatBuilder.BLL
{
    /// <summary>
    /// 系统频道表
    /// </summary>
    public partial class channel
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.channel dal;

        public channel()
        {
            dal = new DAL.channel(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法========================================

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 查询频道名称是否存在
        /// </summary>
        public bool Exists(string name)
        {
            //与站点目录下的一级文件夹是否同名
            if (DirPathExists(siteConfig.webpath, name))
            {
                return true;
            }
            //与站点aspx目录下的一级文件夹是否同名
            if (DirPathExists(siteConfig.webpath + "/" + MXKeys.DIRECTORY_REWRITE_ASPX + "/", name))
            {
                return true;
            }
            //与存在的频道名称是否同名
            if (dal.Exists(name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.channel model)
        {
            //取得所属频道分类的生成目录
            string build_path =new BLL.channel_category().GetBuildPath(model.category_id);
            if (string.IsNullOrEmpty(build_path))
            {
                return 0;
            }
            //开始插入频道信息
            int channelId = dal.Add(model);
            if (channelId > 0)
            {
                //添加导航菜单
                int newNavId = new BLL.navigation().Add("channel_" + build_path, "channel_" + model.name, model.title, "", model.sort_id, channelId, "Show");
                if (newNavId < 1)
                {
                    dal.Delete(channelId);
                    return 0;
                }
                //添加子导航菜单
                new BLL.navigation().Add("channel_" + model.name, "channel_" + model.name + "_list", "内容管理", "article/article_list.aspx", 99, channelId, "Show,View,Add,Edit,Delete,Audit");
                new BLL.navigation().Add("channel_" + model.name, "channel_" + model.name + "_category", "栏目类别", "article/category_list.aspx", 100, channelId, "Show,View,Add,Edit,Delete");
                new BLL.navigation().Add("channel_" + model.name, "channel_" + model.name + "_comment", "评论管理", "article/comment_list.aspx", 101, channelId, "Show,View,Delete,Reply");
            }
            return channelId;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        public bool UpdateSort(int id, int sort_id)
        {
            //取得频道的名称
            string channel_name = dal.GetChannelName(id);
            if (channel_name == string.Empty)
            {
                return false;
            }
            if (new BLL.navigation().UpdateField("channel_" + channel_name, "sort_id=" + sort_id))
            {
                dal.UpdateField(id, "sort_id=" + sort_id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.channel model)
        {
            //取得所属频道分类的生成目录
            string build_path =new BLL.channel_category().GetBuildPath(model.category_id);
            if (string.IsNullOrEmpty(build_path))
            {
                return false;
            }
            //取得所属频道分类在导航中的ID
            int parent_id = new BLL.navigation().GetNavId("channel_" + build_path);
            if (parent_id == 0)
            {
                return false;
            }
            //取得旧的数据
            Model.channel oldModel = dal.GetModel(model.id);
            //开始修改数据
            if (dal.Update(model))
            {
                //如果名称和标题发生改变则修改对应的导航
                if (model.name != oldModel.name || model.title != oldModel.title || model.category_id != oldModel.category_id || model.sort_id != oldModel.sort_id)
                {
                    Model.navigation navModel = new BLL.navigation().GetModel("channel_" + oldModel.name);
                    if (navModel != null)
                    {
                        navModel.name = "channel_" + model.name;
                        navModel.title = model.title;
                        navModel.parent_id = parent_id;
                        navModel.sort_id = model.sort_id;
                        new BLL.navigation().Update(navModel);
                    }
                }
                return true;
            }
            return false;
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
        public Model.channel GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion

        #region 扩展方法========================================
        /// <summary>
        /// 根据频道的名称查询ID
        /// </summary>
        public int GetChannelId(string channel_name)
        {
            return dal.GetChannelId(channel_name);
        }

        /// <summary>
        /// 根据频道的ID查询名称
        /// </summary>
        public string GetChannelName(int id)
        {
            return dal.GetChannelName(id);
        }

        /// <summary>
        /// 根据频道的名称获取实体对象
        /// </summary>
        /// <param name="channel_name"></param>
        /// <returns></returns>
        public Model.channel GetModel(string channel_name)
        {
            return dal.GetModel(channel_name);
        }
        /// <summary>
        /// 获取分页大小
        /// </summary>
        public int GetPageSize(string channel_name)
        {
            return dal.GetPageSize(channel_name);
        }
        /// <summary>
        /// 检查生成目录名与指定路径下的一级目录是否同名
        /// </summary>
        /// <param name="dirPath">指定的路径</param>
        /// <param name="build_path">生成目录名</param>
        /// <returns>bool</returns>
        private bool DirPathExists(string dirPath, string build_path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(dirPath));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                if (build_path.ToLower() == dir.Name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}