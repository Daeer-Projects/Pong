using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Helpers;

namespace Pong.Graphics
{
    public class Wall : Sprite
    {
        public Wall(GameStructure gameStructure, GraphicsDevice graphics, int xPosition, int yPosition, int height, int width)
            : base(height, width, false, gameStructure, graphics, xPosition, yPosition)
        {
            Position = new Vector2(xPosition, yPosition);

            Color[] data = new Color[Width * Height];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.White;
            }
            Texture.SetData(data);

            gameStructure.Collision.AddSprite(this);
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        public bool CheckCollisionWithBall(GameTime gameTime, Ball ball)
        {
            return GetBounds.Intersects(ball.GetBounds);
        }

        public bool CheckCollisionWithPaddle(GameTime gameTime, Paddle paddle)
        {
            return GetBounds.Intersects(paddle.GetBounds);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
}
