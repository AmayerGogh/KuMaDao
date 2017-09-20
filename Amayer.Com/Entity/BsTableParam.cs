using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Utility.Entity
{
    public class BsTableRequestModel
    {

        public string order { get; set; }
        public int offset { get; set; } //从第几个开始
        public int limit { get; set; } // 多少个
        public string search { get; set; }


    }
    public class BsTableResponseModel<T>
    {
        public List<T> rows { get; set; }
        public int total { get; set; }
    }
}
