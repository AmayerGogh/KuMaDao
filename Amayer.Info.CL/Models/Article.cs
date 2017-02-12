using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Models
{
    public class Article
    {

      
        public int Id { get; set; }
        //首级分类
        public int Navigation { get; set; }
        //分类
        public int Category { get; set; }
        //封面
        public string Cover { get; set; }
        //标题
        public string Title { get; set; }
        //描述
        public string Descript { get; set; }
        //内容
        public string Content { get; set; }
        //置顶
        public bool IsTop { get; set; }
        //标题样式
        public string Style { get; set; }
        //点击量
        public int Clicks { get; set; }
        //发布时间
        public DateTime CreateTime {get;set;}
        //修改时间
         public Nullable<DateTime> EditTime { get; set; }
        //是否是已完结
        public bool IsClosed { get; set; }

        public bool Status { get; set; }
    }
}
