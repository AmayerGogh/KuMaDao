using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Com
{
    public class WebHelper
    {
        public static List<SelectListItem> EnumToSelect<T>(int? defaultValue = null)
        {
            var selectList = new List<SelectListItem>();
            var type = typeof(T);
            var valueArray = Enum.GetValues(type);
            foreach (int item in valueArray)
            {
                var option = new SelectListItem
                {
                    Text = Enum.GetName(type, item),
                    Value = item.ToString()
                };
                if (defaultValue.HasValue)
                    option.Selected = item == defaultValue.Value ? true : false;
                selectList.Add(option);
            }
            return selectList;
        }
    }
}