using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amayer.Com.Entity;

namespace Amayer.Utility
{
   public partial class Enums
    {
        public enum Week
        {

            星期一 = 0,
            星期二 = 1,
            星期三 = 2,
            星期四 = 3,
            星期五 = 4,
            星期六 = 5,
            星期天 = 6,
        }
        /// <summary>
        /// 状态
        /// </summary>
        public enum Status
        {
            无效 = 0,
            正常 = 1,
            待审核 = 2
        }

        public enum RequestType
        {
            Get = 1,
            Post = 2
        }
        public static List<SelectItem> GetList<T>()
        {
            var type = typeof(T);
            var valueList = Enum.GetValues(type);
            return (from int item in valueList
                select new SelectItem
                {
                    Text = Enum.GetName(type, item), Value = item.ToString()
                }).ToList();
        }

       
    }
}
