using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Helpers;

namespace Pong.Graphics
{
    public interface ISprite
    {
        int Width { get; }
        int Height { get; }
        bool InGoal { get; set; }
        Vector2 Position { get; }
        GameStructure Structure { get; }
        Rectangle GetBounds { get; }
        Texture2D Texture { get; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}