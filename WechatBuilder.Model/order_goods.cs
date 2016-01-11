using System;

namespace WechatBuilder.Model
{
    /// <summary>
    /// 订单商品表
    /// </summary>
    [Serializable]
    public partial class order_goods
    {
        public order_goods()
        { }
        #region Model
        private int _id;
        private int _order_id = 0;
        private int _goods_id = 0;
        private string _goods_title = "";
        private decimal _goods_price = 0M;
        private decimal _real_price = 0M;
        private int _quantity = 0;
        private int _point = 0;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string goods_title
        {
            set { _goods_title = value; }
            get { return _goods_title; }
        }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal goods_price
        {
            set { _goods_price = value; }
            get { return _goods_price; }
        }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal real_price
        {
            set { _real_price = value; }
            get { return _real_price; }
        }
        /// <summary>
        /// 订购数量
        /// </summary>
        public int quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 积分,正数赠送|负数消费
        /// </summary>
        public int point
        {
            set { _point = value; }
            get { return _point; }
        }
        #endregion Model

    }
}