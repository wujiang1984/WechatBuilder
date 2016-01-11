using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 产品系统设置
	/// </summary>
	[Serializable]
	public partial class wx_product_sys
	{
		public wx_product_sys()
		{}
        #region Model
        private int _id;
        private int? _wid;
        private string _title;
        private string _banner;
        private string _extstr;
        private string _extstr2;
        private string _extstr3;
        private string _remark;
        private DateTime? _createdate;
        private int? _sort_id;
        private string _link_url;
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 微帐号id
        /// </summary>
        public int? wid
        {
            set { _wid = value; }
            get { return _wid; }
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
        /// 微活动banner
        /// </summary>
        public string banner
        {
            set { _banner = value; }
            get { return _banner; }
        }
        /// <summary>
        /// 扩展1
        /// </summary>
        public string extStr
        {
            set { _extstr = value; }
            get { return _extstr; }
        }
        /// <summary>
        /// 扩展2
        /// </summary>
        public string extStr2
        {
            set { _extstr2 = value; }
            get { return _extstr2; }
        }
        /// <summary>
        /// 扩展3
        /// </summary>
        public string extStr3
        {
            set { _extstr3 = value; }
            get { return _extstr3; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string link_url
        {
            set { _link_url = value; }
            get { return _link_url; }
        }
        #endregion Model

	}
}

