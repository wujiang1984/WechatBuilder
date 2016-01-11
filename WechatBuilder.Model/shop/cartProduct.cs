using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.Model
{
    public class cartProduct
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id{set; get;}
        /// <summary>
        /// 微信用户openid
        /// </summary>
        public string openid{ set; get;}
        /// <summary>
        /// 微用户id
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int productId{set; get;}

        /// <summary>
        /// 商品名称
        /// </summary>
        public string productName { get; set; }

        /// <summary>
        /// 商品图片1张
        /// </summary>
        public string productPic { get; set; }

        /// <summary>
        /// 配件id
        /// </summary>
        public int skuId{ set; get;}
        /// <summary>
        /// 配件信息
        /// </summary>
        public string skuInfo{ set; get; }
        /// <summary>
        /// 商品总价格
        /// </summary>
        public decimal totPrice{ set; get; }
        /// <summary>
        /// 商品总价格*100
        /// </summary>
        public decimal totPrice100 { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal avgPrice { get; set; }

        /// <summary>
        /// 单价*100
        /// </summary>
        public decimal avgPrice100 { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int productNum{set;  get;}
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createDate{ set; get;}

        public string productUrl { get; set; }
        /// <summary>
        /// 商品库存
        /// </summary>
        public int stock { get; set; }

        public int seq { get; set; }
    }
}
