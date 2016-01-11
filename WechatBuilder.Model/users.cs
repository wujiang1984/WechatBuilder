using System;
namespace WechatBuilder.Model
{
    #region 用户信息实体类
    /// <summary>
    /// users实体类
    /// </summary>
    [Serializable]
    public partial class users
    {
        public users(){ }
        private int _id;
        private int _group_id = 0;
        private string _user_name;
        private string _password;
        private string _salt;
        private string _email = "";
        private string _nick_name = "";
        private string _avatar = "";
        private string _sex = "保密";
        private DateTime? _birthday;
        private string _telphone = "";
        private string _mobile = "";
        private string _qq = "";
        private string _address = "";
        private string _safe_question = "";
        private string _safe_answer = "";
        private decimal _amount = 0M;
        private int _point = 0;
        private int _exp = 0;
        private int _status = 0;
        private DateTime _reg_time = DateTime.Now;
        private string _reg_ip;


        private int? _isweixin;
        private int? _wid;
        private decimal? _wxcard;
        private string _wxopenid;
        private string _wxname;

       
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户组别
        /// </summary>
        public int group_id
        {
            set { _group_id = value; }
            get { return _group_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 用户注册密钥Key
        /// </summary>
        public string salt
        {
            set { _salt = value; }
            get { return _salt; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nick_name
        {
            set { _nick_name = value; }
            get { return _nick_name; }
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string avatar
        {
            set { _avatar = value; }
            get { return _avatar; }
        }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 安全问题
        /// </summary>
        public string safe_question
        {
            set { _safe_question = value; }
            get { return _safe_question; }
        }
        /// <summary>
        /// 问题答案
        /// </summary>
        public string safe_answer
        {
            set { _safe_answer = value; }
            get { return _safe_answer; }
        }
        /// <summary>
        /// 预存款
        /// </summary>
        public decimal amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 用户积分
        /// </summary>
        public int point
        {
            set { _point = value; }
            get { return _point; }
        }
        /// <summary>
        /// 经验值
        /// </summary>
        public int exp
        {
            set { _exp = value; }
            get { return _exp; }
        }
        /// <summary>
        /// 用户状态,0正常,1待验证,2待审核,3锁定
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime reg_time
        {
            set { _reg_time = value; }
            get { return _reg_time; }
        }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string reg_ip
        {
            set { _reg_ip = value; }
            get { return _reg_ip; }
        }



        /// <summary>
        /// 是否是微信号，1、是 0、不是
        /// </summary>
        public int? isweixin
        {
            set { _isweixin = value; }
            get { return _isweixin; }
        }

        /// <summary>
        /// 微信用户表主键Id
        /// </summary>
        public int? wid
        {
            set { _wid = value; }
            get { return _wid; }
        }


        /// <summary>
        ///  微信会员卡号
        /// </summary>
        public decimal? wxCard
        {
            set { _wxcard = value; }
            get { return _wxcard; }
        }
        /// <summary>
        /// 微信唯一编码
        /// </summary>
        public string wxOpenId
        {
            set { _wxopenid = value; }
            get { return _wxopenid; }
        }
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string wxName
        {
            set { _wxname = value; }
            get { return _wxname; }
        }



    }
    
        #endregion Model
}