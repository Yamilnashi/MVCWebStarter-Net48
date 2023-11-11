using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace WebMvc.Data
{
    public class Utils
    {
        public static string GetAppSetting(EAppSettings appSetting)
        {
            var description = GetDescription(appSetting);
            var res = ConfigurationManager.AppSettings[description];

            if (res == null)
            {
                throw new InvalidEnumArgumentException($"The App Setting [{appSetting}] is not in the Web Config");
            }

            return res;
        }

        public static string GetDescription(object enumValue, string defaultDescriptionIfNotFound = "")
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            if (field != null)
            {
                object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    DescriptionAttribute foundAttribute = (DescriptionAttribute)attributes[0];
                    return foundAttribute.Description;
                }
            }
            return defaultDescriptionIfNotFound;
        }

    }
}