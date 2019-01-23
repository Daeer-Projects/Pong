using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Collision;
using Pong.Helpers;

namespace Pong.Graphics
{
    public class Paddle : Sprite
    {
        public Paddle(GameStructure structure, GraphicsDevice graphicsDevice, int xPosition, int yPosition)
            : base(10, 80, false, structure, graphicsDevice, xPosition, yPosition)
        {
            Position = new Vector2(xPosition, yPosition);

            Color[] data = new Color[Width * Height];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = Color.Chocolate;
            }
            Texture.SetData(data);

            var collisionObject = structure.Collision.AddSprite(this);
            collisionObject.OnCollisionHandler += OnCollision;
        }

        public override void Update(GameTime gameTime)
        {
            CheckForScreenCollision();
        }

        public bool CheckCollisionWithBall(GameTime gameTime, Ball ball)
        {
            return GetBounds.Intersects(ball.GetBounds);
        }

        public bool CheckCollisionWithWall(GameTime gameTime, Ball ball)
        {
            return GetBounds.Intersects(ball.GetBounds);
        }

        private void CheckForScreenCollision()
        {
            var paddleBottom = Position.Y + Height;
            var paddleTop = Position.Y;

            if (paddleTop <= 0)
            {
                Position = new Vector2(Position.X, 0);
            }
            else if (paddleBottom >= Structure.Window.ClientBounds.Height)
            {
                Position = new Vector2(Position.X, Structure.Window.ClientBounds.Height - Height);
            }
        }

        private void OnCollision(object sender, CollisionEventArgs collisionEventArgs)
        {
            if (collisionEventArgs.Sprite is Wall)
            {
                Position = PreviousPosition;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public Vector2 MovePaddleUp(Paddle paddle)
        {
            return new Vector2(paddle.Position.X, paddle.Position.Y - 5);
        }

        public Vector2 MovePaddleDown(Paddle paddle)
        {
            return new Vector2(paddle.Position.X, paddle.Position.Y + 5);
        }

        public Vector2 MovePaddleLeft(Paddle paddle)
        {
            float newXPosition = paddle.Position.X;
            float newYPosition = paddle.Position.Y;

            return CheckForLeftBounds(paddle) ? new Vector2(newXPosition, newYPosition) : new Vector2(newXPosition - 5, newYPosition);
        }

        public Vector2 MovePaddleRight(Paddle paddle)
        {
            float newXPosition = paddle.Position.X;
            float newYPosition = paddle.Position.Y;

            return CheckForRightBounds(paddle) ? new Vector2(newXPosition, newYPosition) : new Vector2(newXPosition + 5, newYPosition);
        }

        private bool CheckForLeftBounds(Paddle paddle)
        {
            return (paddle.Position.X < 90);
        }

        private bool CheckForRightBounds(Paddle paddle)
        {
            return (paddle.Position.X > 300);
        }
    }
}
