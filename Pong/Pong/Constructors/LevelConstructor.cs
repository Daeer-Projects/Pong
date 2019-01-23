using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Collision;
using Pong.GameModes;
using Pong.Graphics;
using Pong.Helpers;
using Pong.Players;
using Pong.Screens;
using System.Collections.Generic;

namespace Pong.Constructors
{
    public abstract class LevelConstructor
    {
        public abstract SpriteBatch SpriteBatches { get; protected set; }
        public abstract GameStructure GameStructures { get; protected set; }
        public abstract CollisionManager CollisionManagers { get; protected set; }
        public abstract OptionsSelected GameOptions { get; protected set; }
        public abstract GameplayScreen Game { get; protected set; }
        public abstract Team LeftTeam { get; protected set; }
        public abstract Team RightTeam { get; protected set; }
        //public abstract Human Human { get; protected set; }
        //public abstract Computer Computer { get; protected set; }
        public abstract List<ISprite> Sprites { get; protected set; }
        public abstract GameModeBase GameTypeMode { get; protected set; }

        protected LevelConstructor(GameplayScreen game, OptionsSelected gameOptions)
        {
            Game = game;
            GameOptions = gameOptions;
        }

        public abstract void CreateLevel();
        public abstract void GoalReset();

        public abstract void StartTimer();

        public void SpriteUpdate(GameTime gameTime)
        {
            GameTypeMode.SpriteUpdate(gameTime);
            if (GameTypeMode.GetGameBall().InGoal)
            {
                UpdateScore(GameTypeMode.GetGameBall());
                GameTypeMode.GoalReset();
                GameTypeMode.GetGameBall().InGoal = false;
            }
        }

        public void UpdateScore(Sprite sprite)
        {
            if (sprite.Position.X <= 0)
            {
                RightTeam.RightScore++;
            }
            else
            {
                LeftTeam.LeftScore++;
            }
        }

        public int GetMaxScoreOfPlayers()
        {
            int result = (LeftTeam.LeftScore > RightTeam.RightScore) ? LeftTeam.LeftScore : RightTeam.RightScore;
            return result;
        }

        public abstract void Update();

        public int HeadingToWho()
        {
            return (GameTypeMode.GetGameBall().HeadingToPlayer == (int)Team.Side.Left) ? (int)Team.Side.Left : (int)Team.Side.Right;
        }

        public abstract void HandleInput(KeyboardState keyboardState);
    }
}
