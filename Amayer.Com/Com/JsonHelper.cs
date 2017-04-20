using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amayer.Com.Com
{
    public class JsonHelper
    {
        #region JSON序列化反序列化

        /// <summary>
        /// 对象序列化为json字符串（Newtonsoft）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 对象序列化为json字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">序列化的对象</param>
        /// <returns>json字符串</returns>
        public static string ToJson<T>(T entity)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, entity);
                    stream.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    StreamReader reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// JSON反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        public static T ToObject<T>(string json)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(json);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)serializer.ReadObject(stream);
                }
            }
            catch (Exception)
            {

                return default(T);
            }
        }

        /// <summary>
        /// JSON反序列化为对象（Newtonsoft）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

        /// <summary>
        /// 将Json序列化的时间由/Date(1294499956278+0800)转为字符串
        /// </summary>
        private static string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dateTime = dateTime.ToLocalTime();
            result = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        /// <summary>
        /// 将时间字符串转为Json时间
        /// </summary>
        private static string ConvertDateStringToJsonDate(Match m)
        {
            string result = string.Empty;
            DateTime dateTime = DateTime.Parse(m.Groups[0].Value);
            dateTime = dateTime.ToUniversalTime();
            TimeSpan ts = dateTime - DateTime.Parse("1970-01-01");
            result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
            return result;
        }
    }
}
