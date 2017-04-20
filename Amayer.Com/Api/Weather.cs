using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amayer.Com.Com;
using Amayer.Com.Entity;

namespace Amayer.Com.Api
{
    public class Weather
    {
        #region 获取天气
        public static BaiduWeather GetWeatherFromBaidu(string city)
        {
            string url = "http://api.map.baidu.com/telematics/v3/weather?location=" + city + "&output=json&ak=" + Configs.Api_LBS_ServerAK;
            return HcRequest.GetEntity<BaiduWeather>(url);
        }
        #endregion
    }
}
