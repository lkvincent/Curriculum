using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkHelper
{
    public static class DatetimeHelper
    {
        public static string ToCustomerShortDateString(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd");
        }

        public static string ToCustomerDateString(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
