using System;
namespace WechatBuilder.Model
{
    /// <summary>
    /// 频道分类表
    /// </summary>
    [Serializable]
    public partial class channel_category
    {
        public channel_category()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private string _build_path = "";
        private string _templet_path = "";
        private string _domain = "";
        private int _is_default = 0;
        private int _sort_id = 99;
        private int? _wid;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 生成文件夹名称
        /// </summary>
        public string build_path
        {
            set { _build_path = value; }
            get { return _build_path; }
        }

        /// <summary>
        /// 模板文件夹名称
        /// </summary>
        public string templet_path
        {
            set { _templet_path = value; }
            get { return _templet_path; }
        }
        /// <summary>
        /// 绑定域名
        /// </summary>
        public string domain
        {
            set { _domain = value; }
            get { return _domain; }
        }
        /// <summary>
        /// 是否默认
        /// </summary>
        public int is_default
        {
            set { _is_default = value; }
            get { return _is_default; }
        }
        /// <summary>
        /// 排序数字
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 微帐号主键Id
        /// </summary>
        public int? wid
        {
            set { _wid = value; }
            get { return _wid; }
        }

        #endregion Model

    }
}