using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using Sermo.Data.Contracts;

namespace Sermo.UI
{
    public class ConfigAppSettings : IApplicationSettings
    {
        public string GetValue(string setting)
        {
            return ConfigurationManager.AppSettings[setting];
        }
    }
}