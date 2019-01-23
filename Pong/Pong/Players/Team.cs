using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Players
{
    public class Team
    {
        public enum Side
        {
            Left,
            Right
        };

        public List<Human> HumanList;
        public List<Computer> ComputerList;
        public List<PlayerBase> LeftSide;
        public List<PlayerBase> RightSide;

        public int LeftScore { get; set; }
        public int RightScore { get; set; }

        public string TeamName { get; set; }

        public Team(Side side, string teamName)
        {
            TeamName = teamName;

            HumanList = new List<Human>();
            ComputerList = new List<Computer>();
        }

    }
}
