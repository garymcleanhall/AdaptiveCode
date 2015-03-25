using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class WritingController
    {
        private readonly IUserSettingsWriter settings;

        public WritingController(IUserSettingsWriter settings)
        {
            this.settings = settings;
        }

        public void SetTheme(string theme)
        {
            if (settings.GetTheme() != theme)
            {
                settings.SetTheme(theme);
            }
        }
    }
}
