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

        public string GetTheme()
        {
            return config.AppSettings.Settings[ThemeSetting].Value;
        }

        public void SetTheme(string theme)
        {
            config.AppSettings.Settings[ThemeSetting].Value = theme;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
