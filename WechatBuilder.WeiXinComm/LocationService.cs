using System.Collections.Generic;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.GoogleMap;
using Senparc.Weixin.MP.Helpers;
using WechatBuilder.Common;

namespace WechatBuilder.WeiXinComm
{
    public class LocationService
    {
        public IResponseMessageBase GetResponseMessage(RequestMessageLocation requestMessage)
        {
            #region 注释掉的
            //var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);

            //var markersList = new List<Markers>();
            //markersList.Add(new Markers()
            //{
            //    X = requestMessage.Location_X,
            //    Y = requestMessage.Location_Y,
            //    Color = "red",
            //    Label = "S",
            //    Size = MarkerSize.Default,
            //});
            //var mapSize = "480x600";
            //var mapUrl = GoogleMapHelper.GetGoogleStaticMap(19 /*requestMessage.Scale*//*微信和GoogleMap的Scale不一致，这里建议使用固定值*/,
            //                                                markersList, mapSize);
            //responseMessage.Articles.Add(new Article()
            //{
            //    Description = string.Format("您刚才发送了地理位置信息。Location_X：{0}，Location_Y：{1}，Scale：{2}，标签：{3}",
            //                  requestMessage.Location_X, requestMessage.Location_Y,
            //                  requestMessage.Scale, requestMessage.Label),
            //    PicUrl = mapUrl,
            //    Title = "定位地点周边地图",
            //    Url = mapUrl
            //});
            //responseMessage.Articles.Add(new Article()
            //{
            //    Title = "微信公众平台SDK 官网链接",
            //    Description = "Senparc.Weixin.MK SDK地址",
            //    PicUrl = "http://weixin.senparc.com/images/logo1.jpg",
            //    Url = "http://www.yubom.net"
            //});

            //return responseMessage;

            #endregion

               WeiXCommFun wxcomm = new WeiXCommFun();
           
            string yuming = MyCommFun.getWebSite();
            int apiid = wxcomm.getApiid();

            //1 查询店面，如果查询到店面，则返回图文列表信息，如果未查询到，则返回纯文本“找不到你查询的内容”
            BLL.wx_lbs_setting setBll = new BLL.wx_lbs_setting();
            Model.wx_lbs_setting setting = setBll.GetSettingByWid(apiid);


            BLL.wx_lbs_shopInfo sBll = new BLL.wx_lbs_shopInfo();
            //SELECT * FROM wx_lbs_shopInfo WHERE dbo.[ufn_GetMapDistance](121.4624,31.220933,yPoint, xPoint) < 5
            IList<Model.wx_lbs_shopInfo> shopList = sBll.GetDetailList(apiid,"dbo.[ufn_GetMapDistance](" + requestMessage.Location_Y + "," + requestMessage.Location_X + ",yPoint, xPoint) < " + setting.searchRadius);

            if (shopList == null || shopList.Count <= 0)
            {  //未查询到
                var responseTextMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);

                responseTextMessage.Content = "找不到你查询的内容";
                return responseTextMessage;
            }
            else
            {  //查询到了数据 
                var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
                ////第一条信息
                //responseMessage.Articles.Add(new Article()
                //{
                //    Description = string.Format("您刚才发送了地理位置信息。Location_X：{0}，Location_Y：{1}，Scale：{2}，标签：{3}",
                //                  requestMessage.Location_X, requestMessage.Location_Y,
                //                  requestMessage.Scale, requestMessage.Label),
                //    PicUrl = yuming + "/lbsInfo/images/ditu.jpg",
                //    Title = "周边门店信息",
                //    Url = yuming + "/weixin/lbs/index.aspx?x=" + requestMessage.Location_X + "&y=" + requestMessage.Location_Y + "&wid=" + apiid + "&openid=" + requestMessage.FromUserName
                //});

                //中间n条信息 ，图文消息个数，限制为10条以内，所以中间控制最多8条信息
                for (int i = 0; i < shopList.Count; i++)
                {
                    if (i == 8)
                    {
                        break;
                    }
                    Model.wx_lbs_shopInfo shop = shopList[i];
                    string pUrl = "";
                    if (shop.shopLogo == null || shop.shopLogo.Trim() == "")
                    {
                        // pUrl = yuming + "/lbsinfo/images/logo.jpg";
                    }
                    else
                    {
                        pUrl = yuming + shop.shopLogo;
                    }
                    responseMessage.Articles.Add(new Article()
                    {
                        Title = shop.shopName + "\n 地址：" + shop.detailAddr + "\n电话：" + shop.telphone,
                        Description = shop.shopName + "分店信息",
                        PicUrl = pUrl,
                        Url = yuming + "/weixin/lbs/detailAddr.aspx?shopid=" + shop.id + "&x=" + requestMessage.Location_X + "&y=" + requestMessage.Location_Y + "&wid=" + apiid + "&openid=" + requestMessage.FromUserName
                    });
                }

                //最后一条信息
                responseMessage.Articles.Add(new Article()
                {
                    Title = "更多门店>>",
                    Url = yuming + "/weixin/lbs/index.aspx?x=" + requestMessage.Location_X + "&y=" + requestMessage.Location_Y + "&wid=" + apiid + "&openid=" + requestMessage.FromUserName
                });

                return responseMessage;

            }


        }
    }
}