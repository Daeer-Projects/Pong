
namespace Pong.Helpers
{
    public class OptionsSelected
    {
        public string GameModeType { get; set; }
        public string AmountOfPlayers { get; set; }
        public string FirstTo { get; set; }
        public string PlayerName { get; set; }
        public char UpKey { get; set; }
        public char DownKey { get; set; }
        public char LeftKey { get; set; }
        public char RightKey { get; set; }

        public OptionsSelected()
        {

        }

        public void LoadDefaults()
        {
            GameModeType = "Pong";
            AmountOfPlayers = "1";
            FirstTo = "3";
            PlayerName = "Fred";
            UpKey = 'q';
            DownKey = 'a';
            LeftKey = 'z';
            RightKey = 'x';
        }

        public bool IfNull()
        {
            if (GameModeType == null || AmountOfPlayers == null || FirstTo == null)
            {
                return true;
            }
            
            return false;
        }
    }
}
