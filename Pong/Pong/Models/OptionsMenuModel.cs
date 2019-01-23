using Pong.Helpers;
using Pong.Screens.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Models
{
    public class OptionsMenuModel
    {
        public MenuEntry GameModeMenuEntry { get; set; }
        public MenuEntry PlayersMenuEntry { get; set; }
        public MenuEntry FirstToMenuEntry { get; set; }
        public MenuEntry Back { get; set; }

        public OptionsSelected TheOptions { get; private set; }

        public OptionsMenuModel(OptionsSelected options)
        {
            TheOptions = options;
        }

    }
}
