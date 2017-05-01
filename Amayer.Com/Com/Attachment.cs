using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Amayer.Utility;
using Amayer.Utility.Entity;

namespace Amayer.Utility
{
    public class HcRequest
    {
        #region Get请求
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <returns>返回字符串</returns>
        public static string GetString(string url)
        {
            Stream stream = Get(url);
            string data = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                data = reader.ReadToEnd();
            }
            stream.Dispose();
            stream.Close();
            return data;
        }
        #endregion

        #region Get请求
        public static Stream Get(string url)
        {
            return Request(url, Enums.RequestType.Get);
        }
        #endregion

        #region Get请求
        public static T GetEntity<T>(string url)
        {
            string json = GetString(url);
            T entity;
            try
            {
                entity = JsonHelper.JsonToObject<T>(json);
            }
            catch (Exception)
            {
                entity = default(T);
            }
            return entity;
        }
        #endregion

        #region Post请求
        public static void Post(string url, params KV[] parameters)
        {

        }
        #endregion

        #region 发送请求
        public static Stream Request(string url, Enums.RequestType type, params KV[] parameters)
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ProtocolVersion = HttpVersion.Version10;
            request.Timeout = 6000;
            request.Method = Enum.GetName(typeof(Enums.RequestType), type);
            if (parameters != null && parameters.Length > 0)
            {
                StringBuilder paramBuilder = new StringBuilder();
                foreach (var item in parameters)
                {
                    paramBuilder.AppendFormat("{0}={1}&", item._key, item._value);
                }
                var paramStr = paramBuilder.ToString().TrimEnd('&');
                byte[] paramArray = Encoding.Default.GetBytes(paramStr);
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(paramArray, 0, paramArray.Length);
                requestStream.Dispose();
                requestStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.GetResponseStream();
        }
        #endregion

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

    }
}
