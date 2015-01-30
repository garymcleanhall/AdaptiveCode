using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ReadingController
    {
        private readonly IUserSettings settings;

        public ReadingController(IUserSettings settings)
        {
            this.settings = settings;
        }

        public string GetTheme()
        {
            return settings.Theme;
        }
    }
}
