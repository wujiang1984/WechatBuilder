using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.Model
{
    /// <summary>
    /// 商品的配件
    /// </summary>
   public  class ShopSKU
    {
       /// <summary>
       /// 商品id
       /// </summary>
       public int productId { get; set; }
       /// <summary>
       /// 属性id
       /// </summary>
       public int attributeId { get; set; }

       /// <summary>
       /// 属性名称
       /// </summary>
       public string attrName { get; set; }

       public IList<SKUSelectItem> selectItem { get; set; }



    }

   public class SKUSelectItem
   {
       /// <summary>
       /// 属性的选择值的名称
       /// </summary>
       public string attributeValue { get; set; }
       /// <summary>
       /// 货号
       /// </summary>
       public string sku { get; set; }

       /// <summary>
       /// 库存
       /// </summary>
       public int stock { get; set; }
       /// <summary>
       /// 配件加价
       /// </summary>
       public decimal price { get; set; }



   }
    
}
