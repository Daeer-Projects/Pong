using Pong.Helpers;
using Pong.Screens.Controls;
using Pong.Screens.Events;
using Pong.ViewModels;

namespace Pong.Screens
{
    /// <summary>
    ///     The options screen is brought up over the top of the main menu
    ///     screen, and gives the user a chance to configure the game
    ///     in various hopefully useful ways.
    /// </summary>
    internal class OptionsMenuScreen : MenuScreen
    {
        private readonly OptionsSelected _theOptions;
        public OptionsMenuViewModel OptionsMenu { get; set; }

        #region Initialization

        /// <summary>
        ///     Constructor.
        /// </summary>
        public OptionsMenuScreen(OptionsSelected myOptions)
        {
            _theOptions = myOptions;
            OptionsMenu = new OptionsMenuViewModel(_theOptions);

            MainMenuEntries.Add(new MainMenuEntry(Constants.Options, true));

            // Create our menu entries.
            OptionsMenu.SetMenuEntryText();

            // Hook up menu event handlers.
            SetupMenuEntries();

            // Add entries to the menu.
            AddMenuEntries();
        }

        private void SetupMenuEntries()
        {
            OptionsMenu.GetGameMode().Selected += GameModeEntrySelected;
            OptionsMenu.GetPlayerEntry().Selected += AmountOfPlayersEntrySelected;
            OptionsMenu.GetFirstToEntry().Selected += FirstToEntrySelected;
            OptionsMenu.GetBackEntry().Selected += OnCancel;
        }

        private void AddMenuEntries()
        {
            MenuEntries.Add(OptionsMenu.GetGameMode());
            MenuEntries.Add(OptionsMenu.GetPlayerEntry());
            MenuEntries.Add(OptionsMenu.GetFirstToEntry());
            MenuEntries.Add(OptionsMenu.GetBackEntry());
        }

        #endregion

        #region Handle Input

        private void GameModeEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            OptionsMenu.CurrentGameMode = (OptionsMenu.CurrentGameMode + 1) % Constants.GameModes.Length;
            _theOptions.GameModeType = Constants.GameModes.GetValue(OptionsMenu.CurrentGameMode).ToString();
            OptionsMenu.SetMenuEntryText();
        }

        private void AmountOfPlayersEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            OptionsMenu.AmountOfPlayers = (OptionsMenu.AmountOfPlayers + 1) % Constants.Players.Length;
            _theOptions.AmountOfPlayers = Constants.Players.GetValue(OptionsMenu.AmountOfPlayers).ToString();
            OptionsMenu.SetMenuEntryText();
        }

        private void FirstToEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            OptionsMenu.CurrentFirstTo = (OptionsMenu.CurrentFirstTo + 1) % Constants.FirstTo.Length;
            _theOptions.FirstTo = Constants.FirstTo.GetValue(OptionsMenu.CurrentFirstTo).ToString();
            OptionsMenu.SetMenuEntryText();
        }

        #endregion
    }
}