using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Com.Entity
{
    #region 百度IP
    public class BaiduIPInfo
    {
        public int status { get; set; }
        public string address { get; set; }
        public content content { get; set; }
    }

    public class content
    {
        public string address { get; set; }
        public address_detail address_detail { get; set; }
        public point point { get; set; }
    }

    public class address_detail
    {
        public string province { get; set; }
        public string city { get; set; }
        public string city_code { get; set; }
        public string district { get; set; }
        public string street { get; set; }
        public string street_number { get; set; }
    }
    public class point
    {
        public decimal x { get; set; }
        public decimal y { get; set; }
    }
    #endregion

    #region  淘宝IP
    public class TaobaoIPInfo
    {
        public int code { get; set; }
        public data data { get; set; }
    }

    public class data
    {
        public string country { get; set; }
        public string country_id { get; set; }
        public string area { get; set; }
        public string region { get; set; }
        public string region_id { get; set; }
        public string city { get; set; }
        public string city_id { get; set; }
        public string county { get; set; }
        public string county_id { get; set; }
        public string isp { get; set; }
        public string isp_id { get; set; }
        public string ip { get; set; }
    }
    #endregion

    #region 百度天气
    public class BaiduWeather
    {
        public int error { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public List<result> results { get; set; }
    }

    public class result
    {
        public string currentCity { get; set; }
        public int pm25 { get; set; }
        public List<index> index { get; set; }
        public List<weather_data> weather_data { get; set; }
    }

    public class index
    {
        public string title { get; set; }
        public string zs { get; set; }
        public string tipt { get; set; }
        public string des { get; set; }
    }

    public class weather_data
    {
        public string date { get; set; }
        public string dayPictureUrl { get; set; }
        public string nightPictureUrl { get; set; }
        public string weather { get; set; }
        public string wind { get; set; }
        public string temperature { get; set; }
    }
    #endregion
}
