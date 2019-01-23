using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pong.Helpers;
using Pong.Screens.Controls;

namespace Pong.Models
{
    public class MainMenuModel
    {
        public OptionsSelected OptionsSelectedByUser { get; set; }
        public List<string> MenuLists { get; set; }
        public List<MenuEntry> MenusDetails { get; set; }

        /// <summary>
        /// Constructor to set up the lists and options for the model.
        /// </summary>
        public MainMenuModel()
        {
            OptionsSelectedByUser = new OptionsSelected();
            MenuLists = new List<string>();
            MenusDetails = new List<MenuEntry>();
        }
    }
}
