using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Helpers;
using Pong.Screens.Controls;
using Pong.Screens.Events;
using Pong.ViewModels;
using System.Linq;

namespace Pong.Screens
{
    /// <summary>
    ///     The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    public class MainMenuScreen : MenuScreen
    {
        #region Initialization
        public OptionsSelected MyOptions { get; set; }
        public MainMenuViewModel MainMenu { get; set; }

        /// <summary>
        ///     Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
        {
            MainMenu = new MainMenuViewModel();
            MainMenuEntries.Add(new MainMenuEntry(MainMenu.GetGameTitle(), true));

            // Create our menu entries.
            MainMenu.CreateListOfEntries();

            // Hook up menu event handlers.
            SetUpMenusToFunctions();

            // Add entries to the menu.
            foreach (var entry in MainMenu.GetGameMenuEntries())
            {
                MenuEntries.Add(entry);
            }
        }

        /// <summary>
        ///     Sets up the methods declared below to the Game menu entries in the VM.
        /// </summary>
        private void SetUpMenusToFunctions()
        {
            foreach (var entry in MainMenu.GetGameMenuEntries())
            {
                switch (entry.Text)
                {
                    case Constants.PlayTitle:
                        {
                            entry.Selected += PlayPongMenuEntrySelected;
                            break;
                        }
                    case Constants.OptionsTitle:
                        {
                            entry.Selected += OptionsMenuEntrySelected;
                            break;
                        }
                    case Constants.PlayerTitles:
                        {
                            entry.Selected += PlayerDetailsMenuEntrySelected;
                            break;
                        }
                    case Constants.ExitTitles:
                        {
                            entry.Selected += OnCancel;
                            break;
                        }
                }
            }
        }

        #endregion

        #region Handle Input

        /// <summary>
        ///     Event handler for when the Play Game menu entry is selected.
        /// </summary>
        private void PlayPongMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, Constants.LoadingMessage, e.PlayerIndex, new GameplayScreen(MainMenu.GetOptions()));
        }


        /// <summary>
        ///     Event handler for when the Options menu entry is selected.
        /// </summary>
        private void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(MainMenu.GetOptions()), e.PlayerIndex);
        }

        private void PlayerDetailsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new PlayerDetailsMenuScreen(MainMenu.GetOptions()), e.PlayerIndex);
        }

        /// <summary>
        ///     When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            var confirmExitMessageBox = new MessageBoxScreen(Constants.CancelMessage);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }

        /// <summary>
        ///     Event handler for when the user selects ok on the "are you sure
        ///     you want to exit" message box.
        /// </summary>
        private void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }

        #endregion
    }
}