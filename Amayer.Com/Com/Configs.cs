using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Utility
{
    class Configs
    {
        #region 获取AppSettings配置信息
        /// <summary>
        /// 获取AppSettings配置信息
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetAppSettingsValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        #endregion

        #region 获取链接字符串
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="name">名字</param>
        /// <returns></returns>
        public static string GetConnectionStrings(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        #endregion


        #region API
        public const string Api_LBS_ServerAK = "294f813ba79b12fde0a703c6a067a35f";
        public const string Api_LBS_BrowserAK = "4GWIYg329q5acIjb9KOwhEse";
        #endregion
    }
}
