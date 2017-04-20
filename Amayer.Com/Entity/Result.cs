using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Com.Entity
{
    public class Result
    {
        /// <summary>
        /// 状态 -1=错误, 0=失败, 1=成功
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
    public class PushResult
    {
        /// <summary>
        /// 状态 -1=错误, 0=失败, 1=成功
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 返回信息
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 状态，成功=200，失败=500
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        public ApiResult(HttpStatusCode status = HttpStatusCode.OK, string message = "执行成功！")
        {
            this.status = (int)status;
            this.message = message;
        }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> : ApiResult
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        /// <param name="data">返回数据</param>
        public ApiResult(HttpStatusCode status = HttpStatusCode.OK, string message = "执行成功！", T data = default(T))
        {
            this.status = (int)status;
            this.message = message;
            this.data = data;
        }

        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }
    }

    public class KV
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
