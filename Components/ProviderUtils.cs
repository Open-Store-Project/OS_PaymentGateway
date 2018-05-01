using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using NBrightCore.common;
using NBrightDNN;
using Nevoweb.DNN.NBrightBuy.Components;
using DotNetNuke.Common.Utilities;

namespace OS_PaymentGateway
{
    public class ProviderUtils
    {
        public static NBrightInfo GetProviderSettings()
        {
            var objCtrl = new NBrightBuyController();
            var info = objCtrl.GetPluginSinglePageData("OS_PaymentGatewaypayment", "OS_PaymentGatewayPAYMENT", Utils.GetCurrentCulture());
            return info;
        }


        public static String GetBankRemotePost(OrderData orderData)
        {
            var rPost = new RemotePost();

            var objCtrl = new NBrightBuyController();
            var info = objCtrl.GetPluginSinglePageData("OS_PaymentGatewaypayment", "OS_PaymentGatewayPAYMENT", orderData.Lang);

            var param = new string[3];
            param[0] = "orderid=" + orderData.PurchaseInfo.ItemID.ToString("");
            param[1] = "status=1";
            var pbxeffectue = Globals.NavigateURL(StoreSettings.Current.PaymentTabId, "", param);
            param[0] = "orderid=" + orderData.PurchaseInfo.ItemID.ToString("");
            param[1] = "status=0";
            var pbxrefuse = Globals.NavigateURL(StoreSettings.Current.PaymentTabId, "", param);
            var appliedtotal = orderData.PurchaseInfo.GetXmlPropertyDouble("genxml/appliedtotal").ToString("0.00").Replace(",", "").Replace(".", ""); ;
            var postUrl = info.GetXmlProperty("genxml/textbox/mainurl");
            if (info.GetXmlPropertyBool("genxml/checkbox/preproduction"))
            {
                postUrl = info.GetXmlProperty("genxml/textbox/preprodurl");
            }

            rPost.Url = postUrl;

            rPost.Add("SITE", info.GetXmlProperty("genxml/textbox/site"));
            rPost.Add("KEY", info.GetXmlProperty("genxml/textbox/key"));


            //Build the re-direct html 
            var rtnStr = "";
            rtnStr = rPost.GetPostHtml();

            if (info.GetXmlPropertyBool("genxml/checkbox/debugmode"))
            {
                File.WriteAllText(PortalSettings.Current.HomeDirectoryMapPath + "\\debug_OS_PaymentGatewaypost.html", rtnStr);
            }
            return rtnStr;
        }

    }
}
