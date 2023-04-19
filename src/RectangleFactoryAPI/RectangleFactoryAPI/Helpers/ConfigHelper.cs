using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RectangleFactoryAPI.Helpers
{
    public static class ConfigHelper<T>
    {
        public static T getValue(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrEmpty(value))
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }

            return default(T);
        }
    }
}