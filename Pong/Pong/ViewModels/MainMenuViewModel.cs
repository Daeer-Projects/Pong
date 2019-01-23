using System;
using System.Collections.Generic;
using System.Linq;
using Pong.Models;
using Pong.Screens.Controls;
using Pong.Helpers;

namespace Pong.ViewModels
{
    public class MainMenuViewModel
    {
        public MainMenuModel MainGameMenu { get; private set; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        public MainMenuViewModel()
        {
            MainGameMenu = new MainMenuModel();
        }

        /// <summary>
        /// Get the title of the game.
        /// </summary>
        /// <returns>The tile contained in the constants (at the moment).</returns>
        public string GetGameTitle()
        {
            return Constants.GameTitle;
        }

        /// <summary>
        /// Gets a list of the menu entries for this VM.
        /// </summary>
        /// <returns>The MenuDetails list.</returns>
        public List<MenuEntry> GetGameMenuEntries()
        {
            return MainGameMenu.MenusDetails;
        }

        /// <summary>
        /// Gets the list of menu entries, but in a string list for reading.
        /// </summary>
        /// <returns>A list of strings.</returns>
        public List<string> ListOfMenuEntries()
        {
            var list = new List<string>();

            list = (from item in MainGameMenu.MenusDetails
                    select item.Text).ToList();

            return list;
        }

        /// <summary>
        /// Connects up the Menu lists to the MenuDetails list.
        /// </summary>
        public void CreateListOfEntries()
        {
            MainGameMenu.MenuLists.Add(Constants.PlayTitle);
            MainGameMenu.MenuLists.Add(Constants.OptionsTitle);
            MainGameMenu.MenuLists.Add(Constants.PlayerTitles);
            MainGameMenu.MenuLists.Add(Constants.ExitTitles);

            foreach (var item in MainGameMenu.MenuLists)
            {
                MainGameMenu.MenusDetails.Add(new MenuEntry(item, true));
            }

            MainGameMenu.OptionsSelectedByUser.LoadDefaults();
        }

        /// <summary>
        /// Gets the options class instantiated by this VM.
        /// </summary>
        /// <returns>The options class.</returns>
        public OptionsSelected GetOptions()
        {
            return MainGameMenu.OptionsSelectedByUser;
        }

    }
}
