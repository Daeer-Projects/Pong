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
    public class PongConstructor : LevelConstructor
    {
        public override SpriteBatch SpriteBatches { get; protected set; }
        public override GameStructure GameStructures { get; protected set; }
        public override CollisionManager CollisionManagers { get; protected set; }
        public override OptionsSelected GameOptions { get; protected set; }
        public override Team LeftTeam { get; protected set; }
        public override Team RightTeam { get; protected set; }
        //public override Human Human { get; protected set; }
        //public override Computer Computer { get; protected set; }
        public Human HumanOne { get; set; }
        public Human HumanTwo { get; set; }
        public Computer ComputerOne { get; set; }
        public Computer ComputerTwo { get; set; }
        public Paddle HumanPaddle { get; set; }
        public Paddle ComputerPaddle { get; set; }
        public override List<ISprite> Sprites { get; protected set; }
        public override GameModeBase GameTypeMode { get; protected set; }
        public override GameplayScreen Game { get; protected set; }
        private readonly Timer _timer;

        public PongConstructor(GameplayScreen game, OptionsSelected gameOptions)
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

            GameTypeMode = new PongMode(Game, _timer, CollisionManagers, Sprites);
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
                        ComputerTwo.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter);
                        break;
                    }
                case "1":
                    {
                        HumanOne = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey);
                        ComputerOne = new Computer("Computer", 1, 0);

                        LeftTeam.HumanList.Add(HumanOne);
                        RightTeam.ComputerList.Add(ComputerOne);

                        HumanOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftOuter);
                        ComputerOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter);
                        break;
                    }
                case "2":
                    {
                        HumanOne = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey);
                        HumanTwo = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey);

                        LeftTeam.HumanList.Add(HumanOne);
                        RightTeam.HumanList.Add(HumanTwo);

                        HumanOne.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftOuter);
                        HumanTwo.PlayerPaddle = GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter);
                        break;
                    }

            }

            //Human = new Human(GameOptions.PlayerName, 1, 0, GameOptions.UpKey, GameOptions.DownKey);
            //Computer = new Computer("Computer", 1, 0);

            //HumanOne.PlayerPaddle = GameTypeMode.GetPaddle("Left");
            //ComputerOne.PlayerPaddle = GameTypeMode.GetPaddle("Right");
        }

        public override void GoalReset()
        {
            HumanPaddle.Position = new Vector2(70, 200);
            ComputerPaddle.Position = new Vector2(710, 200);

            GameTypeMode.GoalReset();
        }

        public override void StartTimer()
        {
            GameTypeMode.StartTimer(1000);
        }

        public override void Update()
        {
            foreach (Computer player in LeftTeam.ComputerList)
            {
                if (player is Computer)
                {
                    player.Update(GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.LeftOuter), GameTypeMode.GetGameBall());
                }
            }

            foreach (Computer player in RightTeam.ComputerList)
            {
                if (player is Computer)
                {
                    player.Update(GameTypeMode.GetPaddle((int)Pong.GameModes.GameModeBase.PaddlesEnum.RightOuter), GameTypeMode.GetGameBall());
                }
            }
            //ComputerOne.Update(GameTypeMode.GetPaddle("Right"), GameTypeMode.GetGameBall());
        }

        public override void HandleInput(KeyboardState keyboardState)
        {
            foreach (Human player in LeftTeam.HumanList)
            {
                if (player is Human)
                {
                    player.HandleInput(keyboardState, false);
                }
            }

            foreach (Human player in RightTeam.HumanList)
            {
                if (player is Human)
                {
                    player.HandleInput(keyboardState, false);
                }
            }
            //HumanOne.HandleInput(keyboardState, false);
        }
    }
}
