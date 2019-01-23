using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Helpers
{
    public static class Constants
    {
        public const string GameTitle = "David's Magic Games!";
        public const string PlayTitle = "Play";
        public const string OptionsTitle = "Options";
        public const string PlayerTitles = "Player Details";
        public const string ExitTitles = "Exit";

        public const string LoadingMessage = "Loading...";
        public const string CancelMessage = "Are you sure you want to exit?";

        public static readonly string[] GameModes = { "Pong", "Hockey", "MultiBall", "MadWorld", "Squash" };
        public static readonly string[] Players = { "0", "1", "2", "4" };
        public static readonly string[] FirstTo = { "3", "5", "10" };

        public const string Options = "Options";
        public const string Back = "Back";
        public const string ModeText = "Mode: ";
        public const string PlayersText = "Players: ";
        public const string FirstToScoreText = "First to score: ";

    }
}
