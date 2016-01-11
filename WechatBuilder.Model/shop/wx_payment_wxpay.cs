using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微支付接口表
	/// </summary>
	[Serializable]
	public partial class wx_payment_wxpay
	{
		public wx_payment_wxpay()
		{}
        #region Model
        private int _id;
        private int? _wid;
        private string _partnerid;
        private string _appid;
        private string _partnerkey;
        private string _paysignkey;
        private DateTime? _createdate;
        private string _certinfopath;
        private string _partnerpwd;
        private string _shname;
        private string _bankname;
        private string _bankcode;
        private string _remark;
        private bool _quicklyfh;
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
        /// 财付通身份标志
        /// </summary>
        public string partnerId
        {
            set { _partnerid = value; }
            get { return _partnerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appId
        {
            set { _appid = value; }
            get { return _appid; }
        }
        /// <summary>
        /// 财付通密匙
        /// </summary>
        public string partnerKey
        {
            set { _partnerkey = value; }
            get { return _partnerkey; }
        }
        /// <summary>
        /// 秘钥
        /// </summary>
        public string paySignKey
        {
            set { _paysignkey = value; }
            get { return _paysignkey; }
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
        /// 证书地址
        /// </summary>
        public string CertInfoPath
        {
            set { _certinfopath = value; }
            get { return _certinfopath; }
        }
        /// <summary>
        /// 财付通登录密码
        /// </summary>
        public string partnerPwd
        {
            set { _partnerpwd = value; }
            get { return _partnerpwd; }
        }
        /// <summary>
        /// 商户名称
        /// </summary>
        public string shName
        {
            set { _shname = value; }
            get { return _shname; }
        }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string bankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 银行帐号
        /// </summary>
        public string bankCode
        {
            set { _bankcode = value; }
            get { return _bankcode; }
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
        /// 立即发货
        /// </summary>
        public bool quicklyFH
        {
            set { _quicklyfh = value; }
            get { return _quicklyfh; }
        }

        #endregion Model

    
    }
}

