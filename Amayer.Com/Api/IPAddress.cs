using Amayer.Utility;
using Amayer.Utility.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Amayer.Com.Api
{
    public class IPAddress
    {
        #region 根据IP地址
        public static BaiduIPInfo GetIPInofFromBaidu(string ip)
        {
            string url = "http://api.map.baidu.com/location/ip?&ak=" + Configs.Api_LBS_ServerAK + "&ip=" + ip + "&coor=bd09ll";
            return HcRequest.GetEntity<BaiduIPInfo>(url);

        }


        public static TaobaoIPInfo GetIPInfoFromTaobao(string ip)
        {

            string url = "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;
            return HcRequest.GetEntity<TaobaoIPInfo>(url);
        }
        #endregion
    }
}
