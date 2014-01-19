using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Attribute;
using Presentation.UIView;

namespace Presentation
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(System.Enum enumType)
        {
            var customerAttributes =
                enumType.GetType()
                        .GetField(enumType.ToString())
                        .GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];
            if (customerAttributes == null || customerAttributes.Length == 0)
            {
                return enumType.ToString();
            }
            else
            {
                return customerAttributes.FirstOrDefault().Description;
            }
        }

        public static IList<DataItemPresentation> GetEnumDescriptionList<T>()
        {
            IList<DataItemPresentation> list = new List<DataItemPresentation>();
            var tInstance = typeof(T);
            var fields = tInstance.GetFields();
            foreach (var fieldInfo in fields)
            {
                var customerAttributes =
                    fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as
                    DescriptionAttribute;
                if (customerAttributes != null && !customerAttributes.Exclude)
                {
                    list.Add(new DataItemPresentation()
                    {
                        Text = customerAttributes.Description,
                        Value = ((int)fieldInfo.GetValue(tInstance)).ToString()
                    });
                }
            }
            return list;
        }

        public static bool Contain(this int source, int eEnum)
        {
            return (source & eEnum) == eEnum;
        }
    }
}
