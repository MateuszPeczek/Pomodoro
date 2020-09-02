using System;
using System.ComponentModel;
using System.Linq;

namespace Pomodoro.Core.Helpers
{
    public static class EnumHelpers
    {
        public static string GetEnumDescription(this Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());
            var descriptionAttribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).Select(a => (DescriptionAttribute)a).SingleOrDefault();

            return descriptionAttribute.Description;
        }
    }
}
