using System;
namespace WechatBuilder.Model
{
    /// <summary>
    /// 数据表2
    /// </summary>
    [Serializable]
    public partial class wx_message_list
    {
        public wx_message_list()
        { }

        #region Model
        private int _id;
        private int? _wid;
        private string _username;
        private string _title;
        private int? _parentid;
        private string _openid;
        private DateTime? _createdate;
        private int? _sort_id;
        private bool _hassh;
        /// <summary>
        /// 编号 主键
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关联编号 外键
        /// </summary>
        public int? wid
        {
            set { _wid = value; }
            get { return _wid; }
        }
        /// <summary>
        /// 名称 用户名
        /// </summary>
        public string userName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 内容 留言内容
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 留言主键 留言标识
        /// </summary>
        public int? parentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 用户openid 用户openid
        /// </summary>
        public string openId
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// 创建时间 时间
        /// </summary>
        public DateTime? createDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int? sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 已审核
        /// </summary>
        public bool hasSH
        {
            set { _hassh = value; }
            get { return _hassh; }
        }
        #endregion Model

    }
}

