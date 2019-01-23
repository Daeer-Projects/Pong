using System;
using System.Text.RegularExpressions;

namespace Pong.Players
{
    public class PlayerName
    {
        public string Name { get; set; }
        public int Index { get; set; }

        public PlayerName(string name)
        {
            if (CheckName(name))
            {
                Name = name;
            }
            else
            {
                throw new FormatException("Value entered is not in the correct format.");
            }
        }

        private bool CheckName(string input)
        {
            Regex regex = new Regex(
              "([a-z])",
            RegexOptions.IgnoreCase
            | RegexOptions.IgnorePatternWhitespace
            );

            return regex.IsMatch(input);
        }
    }
}
