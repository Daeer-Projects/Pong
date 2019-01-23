using Pong.Helpers;
using Pong.Screens.Controls;
using Pong.Screens.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    internal class PlayerDetailsMenuScreen : MenuScreen
    {
        private static readonly string[] PlayersNamesList = { "Fred", "David", "Amber", "Pingu", "Harry" };
        private static readonly char[] UpKeyList = { 'q', 'p', '7' };
        private static readonly char[] DownKeyList = { 'a', 'l', '4' };
        private static readonly char[] LeftKeyList = { 'z', 'n', '1' };
        private static readonly char[] RightKeyList = { 'x', 'm', '2' };

        private static int _currentPlayerName;
        private static int _currentUpKey;
        private static int _currentDownKey;
        private static int _currentLeftKey;
        private static int _currentRightKey;
        
        private readonly MenuEntry _playerNameMenuEntry;
        private readonly MenuEntry _upKeyMenuEntry;
        private readonly MenuEntry _downKeyMenuEntry;
        private readonly MenuEntry _leftKeyMenuEntry;
        private readonly MenuEntry _rightKeyMenuEntry;

        private readonly OptionsSelected _theOptions;

        #region Initialization

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlayerDetailsMenuScreen(OptionsSelected myOptions)
        {
            _theOptions = myOptions;
            MainMenuEntries.Add(new MainMenuEntry("Player Details", true));

            // Create our menu entries.
            _playerNameMenuEntry = new MenuEntry(string.Empty, true);
            _upKeyMenuEntry = new MenuEntry(string.Empty, true);
            _downKeyMenuEntry = new MenuEntry(string.Empty, true);
            _leftKeyMenuEntry = new MenuEntry(string.Empty, true);
            _rightKeyMenuEntry = new MenuEntry(string.Empty, true);

            SetMenuEntryText();

            var back = new MenuEntry("Back", true);

            // Hook up menu event handlers.
            _playerNameMenuEntry.Selected += PlayerNameEntrySelected;
            _upKeyMenuEntry.Selected += UpKeyMenuEntrySelected;
            _downKeyMenuEntry.Selected += DownKeyMenuEntrySelected;
            _leftKeyMenuEntry.Selected += LeftKeyMenuEntrySelected;
            _rightKeyMenuEntry.Selected += RightKeyMenuEntrySelected;
            back.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(_playerNameMenuEntry);
            MenuEntries.Add(_upKeyMenuEntry);
            MenuEntries.Add(_downKeyMenuEntry);
            MenuEntries.Add(_leftKeyMenuEntry);
            MenuEntries.Add(_rightKeyMenuEntry);
            MenuEntries.Add(back);

        }


        /// <summary>
        ///     Fills in the latest values for the options screen menu text.
        /// </summary>
        private void SetMenuEntryText()
        {
            _playerNameMenuEntry.Text = "Name: " + PlayersNamesList[_currentPlayerName];
            _upKeyMenuEntry.Text = "Up Key: " + UpKeyList[_currentUpKey];
            _downKeyMenuEntry.Text = "Down Key: " + DownKeyList[_currentDownKey];
            _leftKeyMenuEntry.Text = "Left Key: " + LeftKeyList[_currentLeftKey];
            _rightKeyMenuEntry.Text = "Right Key: " + RightKeyList[_currentRightKey];
        }

        #endregion

        #region Handle Input

        private void PlayerNameEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            _currentPlayerName = (_currentPlayerName + 1) % PlayersNamesList.Length;
            _theOptions.PlayerName = PlayersNamesList.GetValue(_currentPlayerName).ToString();// GameModes.GetValue(_currentGameMode).ToString();
            //_currentGameMode = (_currentGameMode + 1) % GameModes.Length;
            //_theOptions.GameModeType = GameModes.GetValue(_currentGameMode).ToString();
            SetMenuEntryText();
        }

        private void UpKeyMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            _currentUpKey = (_currentUpKey + 1) % UpKeyList.Length;
            _currentDownKey = (_currentDownKey + 1) % DownKeyList.Length;
            _theOptions.UpKey = (char)UpKeyList.GetValue(_currentUpKey);
            _theOptions.DownKey = (char)DownKeyList.GetValue(_currentDownKey);
            SetMenuEntryText();
        }

        private void DownKeyMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            _currentDownKey = (_currentDownKey + 1) % DownKeyList.Length;
            _currentUpKey = (_currentUpKey + 1) % UpKeyList.Length;
            _theOptions.UpKey = (char)UpKeyList.GetValue(_currentUpKey);
            _theOptions.DownKey = (char)DownKeyList.GetValue(_currentDownKey);
            SetMenuEntryText();
        }

        private void LeftKeyMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            _currentLeftKey = (_currentLeftKey + 1) % LeftKeyList.Length;
            _currentRightKey = (_currentRightKey + 1) % RightKeyList.Length;
            _theOptions.LeftKey = (char)LeftKeyList.GetValue(_currentLeftKey);
            _theOptions.RightKey = (char)RightKeyList.GetValue(_currentRightKey);
            SetMenuEntryText();
        }

        private void RightKeyMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            _currentRightKey = (_currentRightKey + 1) % RightKeyList.Length;
            _currentLeftKey = (_currentLeftKey + 1) % LeftKeyList.Length;
            _theOptions.LeftKey = (char)LeftKeyList.GetValue(_currentLeftKey);
            _theOptions.RightKey = (char)RightKeyList.GetValue(_currentRightKey);
            SetMenuEntryText();
        }


        #endregion
    }
}
