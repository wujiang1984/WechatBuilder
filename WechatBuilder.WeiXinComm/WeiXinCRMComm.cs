using WechatBuilder.BLL;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.WeiXinComm
{
    public class WeiXinCRMComm
    {
        public WeiXinCRMComm() { }
        wx_property_info pBll = new wx_property_info();
        BLL.wx_userweixin wBll = new wx_userweixin();
        #region Base Function: access_token和所有关注用户的openid字符串
        /// <summary>
        /// 及时获得access_token值
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，
        /// 重复获取将导致上次获取的access_token失效。
        /// 每日限额获取access_token.我们将access_token保存到数据库里，间隔时间为20分钟，从微信公众平台获得一次。
        /// </summary>
        /// <returns></returns>
        public string getAccessToken(int wid,out string error)
        {
            string token = "";
            error="";
            try
            {
              
                Model.wx_userweixin weixininfo = wBll.GetModel(wid);
                if (weixininfo.AppId == null || weixininfo.AppSecret == null || weixininfo.AppId.Trim().Length <= 0 || weixininfo.AppSecret.Trim().Length <= 0)
                {
                    error = "appId或者AppSecret未填写完全,请在[我的公众帐号]里补全信息！";
                    return "";
                }
                WechatBuilder.Model.wx_property_info wxProperty = new WechatBuilder.Model.wx_property_info();
                //第一次插入微信属性表
                if (!pBll.ExistsWid(wid))
                {
                    var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(weixininfo.AppId, weixininfo.AppSecret);
                    token = result.access_token;
                    pBll.AddAccess_Token(wid, token);
                    return token;
                }
              
                wxProperty = pBll.GetModelList("iName='access_token' and wid="+wid)[0];
                TimeSpan chajun = DateTime.Now - wxProperty.createDate.Value;
                double chajunSecond = chajun.TotalSeconds;

                if (wxProperty.iContent == null || wxProperty.iContent.Trim() == "" || chajunSecond >= wxProperty.expires_in)
                {  //从微信平台重新获得access_token

                    var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(weixininfo.AppId, weixininfo.AppSecret);
                    token = result.access_token;
                    //更新到数据库里
                    wxProperty.iContent = token;
                    wxProperty.createDate = DateTime.Now;
                    pBll.Update(wxProperty);

                }
                else
                {
                    token = wxProperty.iContent;
                }


            }
            catch (Exception ex)
            {
                error = "获得access_token出错:" + ex.Message;
            }
            return token;
        }

        /// <summary>
        ///【强制刷新】access_token值
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，
        /// 重复获取将导致上次获取的access_token失效。
        /// 每日限额获取access_token.我们将access_token保存到数据库里，间隔时间为20分钟，从微信公众平台获得一次。
        /// </summary>
        /// <returns></returns>
        public string FlushAccessToken(int wid,out string error)
        {
            string token = "";
            error = "";
            try
            {

                Model.wx_userweixin weixininfo = wBll.GetModel(wid);
                if (weixininfo.AppId == null || weixininfo.AppSecret == null || weixininfo.AppId.Trim().Length <= 0 || weixininfo.AppSecret.Trim().Length <= 0)
                {
                    error = "appId或者AppSecret未填写完全,请在[我的公众帐号]里补全信息！";
                    return "";
                }

                var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.GetToken(weixininfo.AppId, weixininfo.AppSecret);
                token = result.access_token;


                //第一次插入微信属性表
                if (!pBll.ExistsWid(wid))
                {
                    //插入
                    pBll.AddAccess_Token(wid, token);

                }
                else
                {
                    WechatBuilder.Model.wx_property_info wxProperty = new WechatBuilder.Model.wx_property_info();
                    wxProperty = pBll.GetModelList("iName='access_token' and wid=" + wid)[0];
                    //更新到数据库里
                    wxProperty.iContent = token;
                    wxProperty.createDate = DateTime.Now;
                    pBll.Update(wxProperty);

                }

            }
            catch (Exception ex)
            {
                error = "获得access_token出错:" + ex.Message;
            }

            return token;
        }



        /// <summary>
        /// 获得所有关注用户的openid字符串（别的方法调用此方法）
        /// </summary>
        /// <returns></returns>
        private IList<string> baseUserOpenid(int wid,out string error)
        {
            IList<string> ret = new List<string>();
          
            string access_token = getAccessToken(wid, out error);
            if (error != "")
            {
                return null ;
            }
            OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.User.Get(access_token, "");
            if (openidJson.count == openidJson.total)
            {
                ret = openidJson.data.openid;
            }
            else
            {
                getNextUserOpenid(wid,openidJson.next_openid, ret);
            }

            return ret;
        }
        /// <summary>
        /// （基础方法）获得所有关注用户的openid字符串
        /// 递归算法
        /// </summary>
        /// <param name="nexOpenid"></param>
        /// <param name="openidList"></param>
        private void getNextUserOpenid(int wid,string nexOpenid, IList<string> openidList)
        {
            string err = "";
            string access_token = getAccessToken(wid,out err);
            OpenIdResultJson openidJson = Senparc.Weixin.MP.AdvancedAPIs.User.Get(access_token, nexOpenid);

            if (openidJson == null || openidJson.count <= 0)
            {
                //return openidJson.data.openid;
                return;
            }
            else
            {
                for (int i = 0; i < openidJson.data.openid.Count; i++)
                {
                    openidList.Add(openidJson.data.openid[i]);
                }
                getNextUserOpenid(wid,openidJson.next_openid, openidList);
            }


        }

        /// <summary>
        /// 【从本地数据库里】获得关注用户的openid字符串
        ///与微信服务器上的数据有最大20分钟的出入
        /// </summary>
        /// <returns></returns>
        //public IList<string> getUserOpenidFromDataStroe()
        //{
        //    IList<string> ret = new List<string>();

        //    MxWeiXin.Model.wx_interface_info interfaceEntity = new MxWeiXin.Model.wx_interface_info();
        //    interfaceEntity = pBll.GetModelList("iName='useropenid'")[0];
        //    TimeSpan chajun = DateTime.Now - interfaceEntity.createDate.Value;
        //    double chajunSecond = chajun.TotalSeconds;
        //    if (interfaceEntity.iContent == null || interfaceEntity.iContent.Trim() == "" || chajunSecond >= interfaceEntity.expires_in)
        //    {

        //        //更新到本地数据库里
        //        IList<string> openidList = baseUserOpenid();
        //        string tmpOpenidStr = "";
        //        foreach (string tmpStr in openidList)
        //        {
        //            tmpOpenidStr += tmpStr.ToString() + ";";
        //        }
        //        interfaceEntity.iContent = tmpOpenidStr;
        //        interfaceEntity.createDate = DateTime.Now;
        //        pBll.Update(interfaceEntity);


        //    }
        //    else
        //    {
        //        string[] openidArr = interfaceEntity.iContent.Split(';');
        //        for (int i = 0; i < openidArr.Length; i++)
        //        {
        //            if (openidArr[i] != "")
        //            {
        //                ret.Add(openidArr[i]);
        //            }
        //        }
        //    }
        //    return ret;
        //}


        /// <summary>
        /// 【强制刷新】【从本地数据库里】获得关注用户的openid字符串
        ///与微信服务器上的数据有最大20分钟的出入
        /// </summary>
        /// <returns></returns>
        //public IList<string> FlushUserOpenidFromDataStroe()
        //{
        //    IList<string> ret = new List<string>();

        //    MxWeiXin.Model.wx_interface_info interfaceEntity = new MxWeiXin.Model.wx_interface_info();
        //    interfaceEntity = pBll.GetModelList("iName='useropenid'")[0];
        //    TimeSpan chajun = DateTime.Now - interfaceEntity.createDate.Value;
        //    double chajunSecond = chajun.TotalSeconds;
        //    //更新到本地数据库里
        //    IList<string> openidList = baseUserOpenid();
        //    string tmpOpenidStr = "";
        //    foreach (string tmpStr in openidList)
        //    {
        //        tmpOpenidStr += tmpStr.ToString() + ";";
        //    }
        //    interfaceEntity.iContent = tmpOpenidStr;
        //    interfaceEntity.createDate = DateTime.Now;
        //    pBll.Update(interfaceEntity);
        //    return ret;
        //}


        #endregion


        /// <summary>
        /// 获得所有关注用户信息
        /// </summary>
        /// <returns></returns>
        //public IList<UserInfoJson> getAllUserInfoList()
        //{
        //    IList<string> openidStr = getUserOpenidFromDataStroe();
        //    List<UserInfoJson> userlist = new List<UserInfoJson>();
        //    string access_token = getAccessToken();
        //    foreach (string openidValue in openidStr)
        //    {
        //        userlist.Add(Senparc.Weixin.MP.AdvancedAPIs.User.Info(access_token, openidValue));
        //    }

        //    return userlist;
        //}


        //public IList<UserInfoJson> getUserInfoListPage(string whereStr, int PageSize, int CurrentPageIndex, out int RecordCount, string orderStr)
        //{
        //    IList<UserInfoJson> alluserlist = getAllUserInfoList();
        //    RecordCount = alluserlist.Count();


        //    return alluserlist;
        //}


    }
}
