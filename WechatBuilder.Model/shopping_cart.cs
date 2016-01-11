using System;
using System.Collections.Generic;
using System.Text;

namespace WechatBuilder.Model
{
    /// <summary>
    /// 购物车实体类
    /// </summary>
    [Serializable]
    public partial class cart_items
    {
        public cart_items()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _img_url;
        private decimal _price = 0M;
        private decimal _user_price = 0M;
        private int _point = 0;
        private int _quantity = 1;
        private int _stock_quantity = 0;

        /// <summary>
        /// 商品ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 会员单价
        /// </summary>
        public decimal user_price
        {
            set { _user_price = value; }
            get { return _user_price; }
        }
        /// <summary>
        /// 所需/获得积分
        /// </summary>
        public int point
        {
            set { _point = value; }
            get { return _point; }
        }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int stock_quantity
        {
            set { _stock_quantity = value; }
            get { return _stock_quantity; }
        }
        #endregion
    }

    /// <summary>
    /// 购物车属性类
    /// </summary>
    [Serializable]
    public partial class cart_total
    {
        public cart_total()
        { }
        #region Model
        private int _total_num = 0;
        private int _total_quantity = 0;
        private decimal _payable_amount = 0M;
        private decimal _real_amount = 0M;
        private int _total_point = 0;

        /// <summary>
        /// 商品种数
        /// </summary>
        public int total_num
        {
            set { _total_num = value; }
            get { return _total_num; }
        }
        /// <summary>
        /// 商品总数量
        /// </summary>
        public int total_quantity
        {
            set { _total_quantity = value; }
            get { return _total_quantity; }
        }
        /// <summary>
        /// 应付商品总金额
        /// </summary>
        public decimal payable_amount
        {
            set { _payable_amount = value; }
            get { return _payable_amount; }
        }
        /// <summary>
        /// 实付商品总金额
        /// </summary>
        public decimal real_amount
        {
            set { _real_amount = value; }
            get { return _real_amount; }
        }
        /// <summary>
        /// 总积分
        /// </summary>
        public int total_point
        {
            set { _total_point = value; }
            get { return _total_point; }
        }
        #endregion
    }
}
