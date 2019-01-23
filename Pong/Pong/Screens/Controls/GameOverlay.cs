using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Constructors;
using Pong.Players;
using Pong.StateManager;

namespace Pong.Screens.Controls
{
    public class GameOverlay
    {
        private SpriteFont _font;
        private SpriteFont _scoreFont;
        private Team _leftTeam;
        private Team _rightTeam;

        public void LoadContent(ContentManager contentManager, LevelConstructor levelConstruction)
        {
            _font = contentManager.Load<SpriteFont>("PlayerFont");
            _scoreFont = contentManager.Load<SpriteFont>("ScoreFont");

            _leftTeam = levelConstruction.LeftTeam;
            _rightTeam = levelConstruction.RightTeam;
        }

        public void Draw(SpriteBatch spriteBatch, ScreenManager screenManager)
        {
            spriteBatch.DrawString(_font, _leftTeam.TeamName, new Vector2(30, 10), Color.Yellow);
            spriteBatch.DrawString(_font, _rightTeam.TeamName, new Vector2(695, 10), Color.Purple);
            spriteBatch.DrawString(_scoreFont, _leftTeam.LeftScore.ToString(), new Vector2(30, 30), Color.Yellow);
            spriteBatch.DrawString(_scoreFont, _rightTeam.RightScore.ToString(), new Vector2(755, 30), Color.Purple);
        }

    }
}