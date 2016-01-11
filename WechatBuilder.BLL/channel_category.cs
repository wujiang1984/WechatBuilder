using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using WechatBuilder.Common;

namespace WechatBuilder.BLL
{
	/// <summary>
	/// 频道分类表
	/// </summary>
	public partial class channel_category
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.channel_category dal;

		public channel_category()
		{
            dal = new DAL.channel_category(siteConfig.sysdatabaseprefix);
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
        /// 查询生成目录名是否存在
        /// </summary>
        public bool Exists(string build_path)
        {
            //与站点目录下的一级文件夹是否同名
            if (DirPathExists(siteConfig.webpath, build_path))
            {
                return true;
            }
            //与站点aspx目录下的一级文件夹是否同名
            if (DirPathExists(siteConfig.webpath + "/" + MXKeys.DIRECTORY_REWRITE_ASPX + "/", build_path))
            {
                return true;
            }
            //与频道名称是否同名
            if (new DAL.channel(siteConfig.sysdatabaseprefix).Exists(build_path))
            {
                return true;
            }
            //与频道分类生成目录是否同名
            if (dal.Exists(build_path))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// 返回频道分类的生成目录名
        /// </summary>
        public string GetBuildPath(int id)
        {
            return dal.GetBuildPath(id);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.channel_category model)
		{
            int newCategoryId = dal.Add(model);
            if (newCategoryId > 0)
            {
                //添加导航菜单
                int newNavId = new BLL.navigation().Add("sys_contents", "channel_" + model.build_path, model.title, "", model.sort_id, 0, "Show");
                if (newNavId < 1)
                {
                    dal.Delete(newCategoryId);
                    return 0;
                }
            }
            return newCategoryId;
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string build_path, string strValue)
        {
            return dal.UpdateField(build_path, strValue);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.channel_category model)
		{
            Model.channel_category oldModel = dal.GetModel(model.id);
            if (dal.Update(model))
            {
                if (oldModel.build_path.ToLower() != model.build_path.ToLower())
                {
                    //更改频道分类对应的目录名称
                    Utils.MoveDirectory(siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_ASPX + "/" + oldModel.build_path,
                        siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_ASPX + "/" + model.build_path);
                    Utils.MoveDirectory(siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_HTML + "/" + oldModel.build_path,
                        siteConfig.webpath + MXKeys.DIRECTORY_REWRITE_HTML + "/" + model.build_path);
                }
                //修改对应的导航
                new BLL.navigation().Update("channel_" + oldModel.build_path, "channel_" + model.build_path, model.title);
                
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
		public Model.channel_category GetModel(int id)
		{
			return dal.GetModel(id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.channel_category GetModel(string build_path)
        {
            return dal.GetModel(build_path);
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
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
        /// 返回默认的生成目录
        /// </summary>
        public string GetDefaultPath()
        {
            DataTable dt = GetList(1, "is_default=1", "sort_id asc,id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["build_path"].ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 返回频道分类绑定域名及目录
        /// </summary>
        public Dictionary<string, string> GetCategoryDirs()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (siteConfig.mobilestatus == 1)
            {
                dic.Add("mobile", siteConfig.mobiledomain);
            }

            List<Model.channel_category> modelList = DataTableToList(GetList(0, "", "sort_id asc,id desc").Tables[0]);
            foreach (Model.channel_category model in modelList)
            {
                dic.Add(model.build_path.ToLower(), model.domain.ToLower());
            }
            return dic;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.channel_category> DataTableToList(DataTable dt)
        {
            List<Model.channel_category> modelList = new List<WechatBuilder.Model.channel_category>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.channel_category model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new WechatBuilder.Model.channel_category();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.build_path = dt.Rows[n]["build_path"].ToString();
                    model.domain = dt.Rows[n]["domain"].ToString();
                    if (dt.Rows[n]["is_default"].ToString() != "")
                    {
                        model.is_default = int.Parse(dt.Rows[n]["is_default"].ToString());
                    }
                    if (dt.Rows[n]["sort_id"].ToString() != "")
                    {
                        model.sort_id = int.Parse(dt.Rows[n]["sort_id"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
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

