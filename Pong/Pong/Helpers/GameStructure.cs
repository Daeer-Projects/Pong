using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Collision;

namespace Pong.Helpers
{
    public class GameStructure
    {
        public ContentManager Contents { get; set; }
        public GraphicsDevice Graphics { get; set; }
        public GameWindow Window { get; set; }
        public CollisionManager Collision { get; set; }

        public GameStructure(ContentManager contentManager, GameWindow window, CollisionManager collisionManager)
        {
            Contents = contentManager;
            Window = window;
            Collision = collisionManager;
        }
    }
}
