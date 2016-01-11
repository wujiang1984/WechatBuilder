using System;
namespace WechatBuilder.Model
{
    /// <summary>
    /// 会员组商品格价
    /// </summary>
    [Serializable]
    public partial class user_group_price
    {
        public user_group_price()
        { }
        #region Model
        private int _id;
        private int _article_id = 0;
        private int _group_id = 0;
        private decimal _price = 0M;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 主表ID
        /// </summary>
        public int article_id
        {
            set { _article_id = value; }
            get { return _article_id; }
        }
        /// <summary>
        /// 用户组ID
        /// </summary>
        public int group_id
        {
            set { _group_id = value; }
            get { return _group_id; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal price
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}