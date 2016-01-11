using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.Model
{
    public class wxcodeconfig
    {

        /// <summary>
        /// 微帐号的网站基本信息，每个字段/属性作为前台模版标签{$:config.属性}
        /// </summary>
        public wxcodeconfig() { }
        /// <summary>
        /// 微帐号主键
        /// </summary>
        public int wid { get; set; }

        #region 微信帐号基本信息
        /// <summary>
        /// 微信公众帐号
        /// </summary>
        public string wxcode { get; set; }

        /// <summary>
        /// 微信名称
        /// </summary>
        public string wxname { get; set; }

        /// <summary>
        /// 微信头像uri
        /// </summary>
        public string wxphoto { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string wxprovince { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string wxcity { get; set; }
        /// <summary>
        /// 微信公众帐号的状态:1为正常使用；0：帐号已过期；
        /// </summary>
        public int wxstatus { get; set; }
        #endregion

        #region 微网站基本信息

        /// <summary>
        /// 模版的虚拟路径
        /// </summary>
        public string templateskin { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string sitename { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string companyname { get; set; }
        /// <summary>
        /// 背景音乐
        /// </summary>
        public string bgmusic { get; set; }
        /// <summary>
        /// 背景图片
        /// </summary>
        public string bgpic { get; set; }
        /// <summary>
        /// 动画
        /// </summary>
        public int bgdonghuaid { get; set; }

        /// <summary>
        /// 版权
        /// </summary>
        public string wcopyright { get; set; }

        /// <summary>
        /// 网站简介
        /// </summary>
        public string wbrief { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string addr { get; set; }

        /// <summary>
        /// 百度地图网址
        /// </summary>
        public string addrurl { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// seo标题
        /// </summary>
        public string seotitle { get; set; }

        /// <summary>
        /// seo关键词
        /// </summary>
        public string seokeywords { get; set; }

        /// <summary>
        /// seo描述
        /// </summary>
        public string seodesc { get; set; }

        /// <summary>
        /// 顶部横条的css
        /// </summary>
        public string topht { get; set; }
        #endregion

    }
}
