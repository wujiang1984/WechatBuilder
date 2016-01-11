using System;
namespace WechatBuilder.Model
{
    /// <summary>
    /// 预存款记录日志
    /// </summary>
    [Serializable]
    public partial class user_amount_log
    {
        public user_amount_log()
        { }
        #region Model
        private int _id;
        private int _user_id;
        private string _user_name;
        private string _type;
        private string _order_no = "";
        private string _trade_no = "";
        private int _payment_id = 0;
        private decimal _value = 0;
        private string _remark;
        private int _status = 0;
        private DateTime _add_time = DateTime.Now;
        private DateTime? _complete_time;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
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
        /// 类型
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
       
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; }
        }
        /// <summary>
        /// 交易号担保支付用到
        /// </summary>
        public string trade_no
        {
            get { return _trade_no; }
            set { _trade_no = value; }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int payment_id
        {
            get { return _payment_id; }
            set { _payment_id = value; }
        }
        /// <summary>
        /// 增减值
        /// </summary>
        public decimal value
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 状态0
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? complete_time
        {
            set { _complete_time = value; }
            get { return _complete_time; }
        }
        #endregion Model

    }
}