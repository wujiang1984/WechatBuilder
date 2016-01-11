using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.Templates
{
    public class TemplateEnity
    {

    }

    /// <summary>
    /// 模版类型 
    /// </summary>
    public enum TemplateType
    {
        /// <summary>
        /// 首页
        /// </summary>
        Index,
        /// <summary>
        /// 列表
        /// </summary>
        Class,
        /// <summary>
        /// 详情
        /// </summary>
        News,
        /// <summary>
        /// 频道,二级页面
        /// </summary>
        Channel,
        /// <summary>
        /// 购物车页面
        /// </summary>
        Cart,
        /// <summary>
        /// 确定订单页面
        /// </summary>
        confirmOrder,
        /// <summary>
        /// 编辑地址
        /// </summary>
        editaddr,
        /// <summary>
        /// 用户中心
        /// </summary>
        userinfo,
        /// <summary>
        /// 下单成功页面
        /// </summary>
        orderSuccess,
        /// <summary>
        /// 订单详情
        /// </summary>
        orderDetail
    }

    


}
