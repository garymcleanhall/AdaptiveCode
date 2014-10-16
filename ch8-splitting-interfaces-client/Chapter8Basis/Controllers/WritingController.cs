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
        private readonly IUserSettings settings;

        public WritingController(IUserSettings settings)
        {
            this.settings = settings;
        }

        public void SetTheme(string theme)
        {
            settings.Theme = theme;
        }
    }
}
