using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amayer.Info.Areas.Hp.ViewModel
{
    public class BsTableResponseModel
    {

        public string order { get; set; }
        public int offset { get; set; } //从第几个开始
        public int limit { get; set; } // 多少个
        public string search { get; set; }


    }
    public class BsTableResultModel<T>
    {
        public List<T> rows { get; set; }
        public int total { get; set; }
    }
}