using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MedicineSecurityReport.Common
{
    /// <summary>
    /// 配置信息读取
    /// </summary>
    public static class SiteConfig
    {
        private static IConfigurationSection _appSection = null;

        /// <summary>
        /// API域名地址
        /// </summary>
        public static string AppSetting(string key)
        {
            string str = string.Empty;
            if (_appSection.GetSection(key) != null)
            {
                str = _appSection.GetSection(key).Value;
            }
            return str;
        }

        public static void SetAppSetting(IConfigurationSection section)
        {
            _appSection = section;
        }

        public static string GetSite(string apiName)
        {
            return AppSetting(apiName);
        }
    }
}
