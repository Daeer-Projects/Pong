using Pong.Helpers;
using Pong.Models;
using Pong.Screens.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.ViewModels
{
    public class OptionsMenuViewModel
    {
        public int CurrentGameMode { get; set; }
        public int AmountOfPlayers { get; set; }
        public int CurrentFirstTo { get; set; }

        public OptionsMenuModel OptionsMenu { get; private set; }
        public OptionsSelected TheOptions { get; private set; }

        public OptionsMenuViewModel(OptionsSelected options)
        {
            TheOptions = options;
            CurrentGameMode = Array.IndexOf(Constants.GameModes, TheOptions.GameModeType);
            AmountOfPlayers = Array.IndexOf(Constants.Players, TheOptions.AmountOfPlayers);
            CurrentFirstTo = Array.IndexOf(Constants.FirstTo, TheOptions.FirstTo);
            OptionsMenu = new OptionsMenuModel(TheOptions);

            CreateMenuEntries();
        }

        public void CreateMenuEntries()
        {
            // Create our menu entries.
            OptionsMenu.GameModeMenuEntry = new MenuEntry(string.Empty, true);
            OptionsMenu.PlayersMenuEntry = new MenuEntry(string.Empty, true);
            OptionsMenu.FirstToMenuEntry = new MenuEntry(string.Empty, true);
            OptionsMenu.Back = new MenuEntry(Constants.Back, true);
        }

        /// <summary>
        ///     Fills in the latest values for the options screen menu text.
        /// </summary>
        public void SetMenuEntryText()
        {
            OptionsMenu.GameModeMenuEntry.Text = Constants.ModeText + Constants.GameModes[CurrentGameMode];
            OptionsMenu.PlayersMenuEntry.Text = Constants.PlayersText + Constants.Players[AmountOfPlayers];
            OptionsMenu.FirstToMenuEntry.Text = Constants.FirstToScoreText + Constants.FirstTo[CurrentFirstTo];
        }

        public MenuEntry GetGameMode()
        {
            return OptionsMenu.GameModeMenuEntry;
        }

        public MenuEntry GetPlayerEntry()
        {
            return OptionsMenu.PlayersMenuEntry;
        }

        public MenuEntry GetFirstToEntry()
        {
            return OptionsMenu.FirstToMenuEntry;
        }

        public MenuEntry GetBackEntry()
        {
            return OptionsMenu.Back;
        }
    }
}
