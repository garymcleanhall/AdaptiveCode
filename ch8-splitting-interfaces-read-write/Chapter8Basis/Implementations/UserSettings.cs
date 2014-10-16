using Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public class UserSettingsConfig : IUserSettingsReader, IUserSettingsWriter
    {
        private const string ThemeSetting = "Theme";

        private readonly Configuration config;

        public UserSettingsConfig()
        { 
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string Theme
        {
            get
            {
                return config.AppSettings.Settings[ThemeSetting].Value;
            }
            set
            {
                config.AppSettings.Settings[ThemeSetting].Value = value;
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}
