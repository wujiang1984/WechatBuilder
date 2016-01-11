using System;
using System.Collections.Generic;
using System.Text;

namespace WechatBuilder.Model
{
    /// <summary>
    /// 订单配置信息
    /// </summary>
    [Serializable]
    public class orderconfig
    {
        public orderconfig()
        { }
        private int _anonymous = 0;
        private int _confirmmsg = 0;
        private string _confirmcallindex = "";
        private int _expressmsg = 0;
        private string _expresscallindex = "";
        private int _completemsg = 0;
        private string _completecallindex = "";

        private string _kuaidiapi = "";
        private string _kuaidikey = "";
        private int _kuaidishow = 3;
        private int _kuaidimuti = 1;
        private string _kuaidiorder = "desc";

        

        /// <summary>
        /// 开启匿名购物0否1是
        /// </summary>
        public int anonymous
        {
            get { return _anonymous; }
            set { _anonymous = value; }
        }
        /// <summary>
        /// 订单确认通知0关闭1短信2邮件
        /// </summary>
        public int confirmmsg
        {
            get { return _confirmmsg; }
            set { _confirmmsg = value; }
        }
        /// <summary>
        /// 通知模板别名
        /// </summary>
        public string confirmcallindex
        {
            get { return _confirmcallindex; }
            set { _confirmcallindex = value; }
        }
        /// <summary>
        /// 订单发货通知0关闭1短信2邮件
        /// </summary>
        public int expressmsg
        {
            get { return _expressmsg; }
            set { _expressmsg = value; }
        }
        /// <summary>
        /// 通知模板别名
        /// </summary>
        public string expresscallindex
        {
            get { return _expresscallindex; }
            set { _expresscallindex = value; }
        }
        /// <summary>
        /// 订单完成通知0关闭1短信2邮件
        /// </summary>
        public int completemsg
        {
            get { return _completemsg; }
            set { _completemsg = value; }
        }
        /// <summary>
        /// 通知模板别名
        /// </summary>
        public string completecallindex
        {
            get { return _completecallindex; }
            set { _completecallindex = value; }
        }

        /// <summary>
        /// 快递100API地址
        /// </summary>
        public string kuaidiapi
        {
            get { return _kuaidiapi; }
            set { _kuaidiapi = value; }
        }
        /// <summary>
        /// 快递100Key
        /// </summary>
        public string kuaidikey
        {
            get { return _kuaidikey; }
            set { _kuaidikey = value; }
        }
        /// <summary>
        /// 物流跟踪返回0json字符串1xml对象2html表格3文本
        /// </summary>
        public int kuaidishow
        {
            get { return _kuaidishow; }
            set { _kuaidishow = value; }
        }
        /// <summary>
        /// 跟踪信息数量0只返回一行信息1返回完整信息
        /// </summary>
        public int kuaidimuti
        {
            get { return _kuaidimuti; }
            set { _kuaidimuti = value; }
        }
        /// <summary>
        /// 跟踪信息排序asc：按时间由旧到新,desc：按时间由新到旧
        /// </summary>
        public string kuaidiorder
        {
            get { return _kuaidiorder; }
            set { _kuaidiorder = value; }
        }
    }
}
