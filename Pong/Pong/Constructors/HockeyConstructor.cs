using System.Timers;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Collision;
using Pong.GameModes;
using Pong.Graphics;
using Pong.Players;
using Pong.Screens;
using Pong.Helpers;

namespace Pong.Constructors
{
    public class HockeyConstructor : LevelConstructor
    {
        public override SpriteBatch SpriteBatches { get; protected set; }
        public override GameStructure GameStructures { get; protected set; }
        public override CollisionManager CollisionManagers { get; protected set; }
        public override OptionsSelected GameOptions { get; protected set; }
        public override Team LeftTeam { get; protected set; }
        public override Team RightTeam { get; protected set; }
        public Human HumanOne { get; protected set; }
        public Human HumanTwo { get; protected set; }
        public Human HumanThree { get; protected set; }
        public Human HumanFour { get; protected set; }
        public Computer ComputerOne { get; protected set; }
        public Computer ComputerTwo { get; protected set; }
        public Computer ComputerThree { get; protected set; }
        public Computer ComputerFour { get; protected set; }
        public Paddle HumanPaddle { get; private set; }
        public Paddle ComputerPaddle { get; private set; }
        public override List<ISprite> Sprites { get; protected set; }

        public override GameModeBase GameTypeMode { get; protected set; }

        public override GameplayScreen Game { get; protected set; }
        private readonly Timer _timer;

        //public LevelConstructor(PongMode game)
        public HockeyConstructor(GameplayScreen game, OptionsSelected gameOptions)
            : base(game, gameOptions)
        {
            Game = game;
            GameOptions = gameOptions;

            CollisionManagers = new CollisionManager();
            SpriteBatches = new SpriteBatch(Game.ScreenManager.GraphicsDevice);
            GameStructures = new GameStructure(Game.ScreenManager.Game.Content, Game.ScreenManager.Game.Window, CollisionManagers);
            Sprites = new List<ISprite>();
            CollisionManagers.AddGameWindow(Game.ScreenManager.Game.Window);
            LeftTeam = new Team(Team.Side.Left, "Goodies");
            RightTeam = new Team(Team.Side.Right, "Baddies");

            _timer = new Timer(1000);

            GameTypeMode = new HockeyMode(Game, _timer, CollisionManagers, Sprites);
        }

        public override void CreateLevel()
        {
            GameTypeMode.CreateLevel();
            switch (GameOptions.AmountOfPlayers)
            {
                case "0":
                    {
                        ComputerOne = new Computer("Left Player", 1, 0);
                        ComputerTwo = new Computer("Right Player", 1, 0);

                        LeftTeam.ComputerList.Add(ComputerOne);
                        RightTeam.ComputerList.Add(ComputerTwo);

                        ComputerOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftOuter);
                        ComputerOne.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftInner);
                        ComputerTwo.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter);
                        ComputerTwo.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightInner);
                        break;
                    }
                case "1":
                    {
                        HumanOne = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey, GameOptions.LeftKey, GameOptions.RightKey);
                        ComputerOne = new Computer("Computer", 1, 0);

                        LeftTeam.HumanList.Add(HumanOne);
                        RightTeam.ComputerList.Add(ComputerOne);

                        HumanOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftOuter);
                        HumanOne.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftInner);
                        ComputerOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter);
                        ComputerOne.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightInner);
                        break;
                    }
                case "2":
                    {
                        HumanOne = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey, GameOptions.LeftKey, GameOptions.RightKey);
                        HumanTwo = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey, GameOptions.LeftKey, GameOptions.RightKey);

                        LeftTeam.HumanList.Add(HumanOne);
                        RightTeam.HumanList.Add(HumanTwo);

                        HumanOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftOuter);
                        HumanOne.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftInner);
                        HumanTwo.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter);
                        HumanTwo.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightInner);
                        break;
                    }
                case "4":
                    {
                        HumanOne = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey, GameOptions.LeftKey, GameOptions.RightKey);
                        HumanTwo = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey, GameOptions.LeftKey, GameOptions.RightKey);
                        HumanThree = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey, GameOptions.LeftKey, GameOptions.RightKey);
                        HumanFour = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey, GameOptions.LeftKey, GameOptions.RightKey);

                        LeftTeam.HumanList.Add(HumanOne);
                        LeftTeam.HumanList.Add(HumanTwo);
                        RightTeam.HumanList.Add(HumanThree);
                        RightTeam.HumanList.Add(HumanFour);

                        HumanOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftOuter);
                        HumanTwo.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftInner);
                        HumanThree.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter);
                        HumanFour.PlayerSecondPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightInner);
                        break;
                    }
            }


            //HumanOne = new Human("Player 1", 1, 0, 'Q', 'A', 'Z', 'X');
            //ComputerOne = new Computer("Computer", 1, 0);

            //HumanOne.PlayerPaddle = GameTypeMode.GetPaddle("LeftOuter");
            //HumanOne.PlayerSecondPaddle = GameTypeMode.GetPaddle("LeftInner");
            //ComputerOne.PlayerPaddle = GameTypeMode.GetPaddle("RightOuter");
            //ComputerOne.PlayerSecondPaddle = GameTypeMode.GetPaddle("RightInner");
        }

        public override void GoalReset()
        {
            HumanPaddle.Position = new Vector2(70, 150);
            ComputerPaddle.Position = new Vector2(710, 150);

            GameTypeMode.GoalReset();
        }

        public override void StartTimer()
        {
            GameTypeMode.StartTimer(1000);
        }

        public override void Update()
        {
            int leftTeamCount = LeftTeam.ComputerList.Count;
            int rightTeamCount = RightTeam.ComputerList.Count;
            int TeamPaddleCount = 2;

            for (int i = 0; i < leftTeamCount; i++)
            {
                Computer player = LeftTeam.ComputerList[i];
                for (int j = 0; j < TeamPaddleCount; j++)
                {
                    player.Update(GameTypeMode.GetPaddle(j), GameTypeMode.GetPaddle(j + 2), GameTypeMode.GetGameBall());
                }
            }

            for (int k = 0; k < rightTeamCount; k++)
            {
                Computer player = RightTeam.ComputerList[k];
                for (int l = 1; l < TeamPaddleCount; l++)
                {
                    player.Update(GameTypeMode.GetPaddle(l), GameTypeMode.GetPaddle(l + 2), GameTypeMode.GetGameBall());
                }
            }
            //ComputerOne.Update(GameTypeMode.GetPaddle("RightInner"), GameTypeMode.GetPaddle("RightOuter"), GameTypeMode.GetGameBall());
        }

        public override void HandleInput(KeyboardState keyboardState)
        {
            //int leftTeamCount = LeftTeam.HumanList.Count;
            //int rightTeamCount = RightTeam.HumanList.Count;

            //for (int i = 0; i < leftTeamCount; i++ )
            //{
            //    Human player = LeftTeam.HumanList[i];
            //    player.HandleInput(keyboardState, false);
            //}

            //for (int j = 0; j < rightTeamCount; j++)
            //{
            //    Human player = RightTeam.HumanList[j];
            //    player.HandleInput(keyboardState, false);
            //}

            foreach (Human player in LeftTeam.HumanList)
            {
                player.HandleInput(keyboardState, true);
            }

            foreach (Human player in RightTeam.HumanList)
            {
                player.HandleInput(keyboardState, true);
            }
            //HumanOne.HandleInput(keyboardState, true);
        }
    }
}
