using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Pong.Graphics;

namespace Pong.Collision
{
    public class CollisionManager
    {
        private List<CollisionObject> CollisionObjects { get; set; }

        public CollisionManager()
        {
            CollisionObjects = new List<CollisionObject>();
        }

        public CollisionObject AddSprite(ISprite sprite)
        {
            var collisionObject = new CollisionObject(sprite);
            CollisionObjects.Add(collisionObject);
            return collisionObject;
        }

        public void RemoveSprite(ISprite sprite)
        {
            var collisionObject = new CollisionObject(sprite);
            CollisionObjects.Remove(collisionObject);
        }

        public CollisionObject AddGameWindow(GameWindow gameWindow)
        {
            var collisionObject = new CollisionObject(gameWindow);
            CollisionObjects.Add(collisionObject);
            return collisionObject;
        }

        public void CheckForCollisions()
        {
            var paddles = CollisionObjects.Where(s => s.Sprite is Paddle).ToList();
            var balls = CollisionObjects.Where(s => s.Sprite is Ball).ToList();
            var walls = CollisionObjects.Where(s => s.Sprite is Wall).ToList();

            // Paddle, ball collsion
            foreach (var wall in walls)
            {
                foreach (var paddle in paddles)
                {
                    foreach (var ball in balls)
                    {
                        if (paddle.Sprite.GetBounds.Intersects(ball.Sprite.GetBounds))
                        {
                            paddle.RaiseCollisionEvent(ball.Sprite);
                            ball.RaiseCollisionEvent(paddle.Sprite);
                        }
                        if (wall.Sprite.GetBounds.Intersects(ball.Sprite.GetBounds))
                        {
                            wall.RaiseCollisionEvent(ball.Sprite);
                            ball.RaiseCollisionEvent(wall.Sprite);
                        }
                    }
                    if (paddle.Sprite.GetBounds.Intersects(wall.Sprite.GetBounds))
                    {
                        paddle.RaiseCollisionEvent(wall.Sprite);
                        wall.RaiseCollisionEvent(paddle.Sprite);
                    }
                }
            }

            for (int i = 0; i < balls.Count(); i++)
            {
                var mainBall = balls[i];
                for (int j = 0; j < balls.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var otherBall = balls[j];

                    if (mainBall.Sprite.GetBounds.Intersects(otherBall.Sprite.GetBounds))
                    {
                        mainBall.RaiseCollisionEvent(otherBall.Sprite);
                        otherBall.RaiseCollisionEvent(mainBall.Sprite);
                    }
                }
            }
        }

        public void CheckForScreenCollision()
        {
            var balls = CollisionObjects.Where(s => s.Sprite is Ball).ToList();

            foreach (var ball in balls)
            {
                var ballHeight = ball.Sprite.Position.Y + ball.Sprite.Height;
                var ballWidth = ball.Sprite.Position.X + ball.Sprite.Width;

                if (ballHeight >= ball.Sprite.Structure.Window.ClientBounds.Height)
                {
                    ball.RaiseCollisionEvent(ball.Sprite.Structure.Window);
                }
                else if (ballWidth >= ball.Sprite.Structure.Window.ClientBounds.Width)
                {
                    ball.RaiseCollisionEvent(ball.Sprite.Structure.Window);
                }
                else if (ball.Sprite.Position.Y <= 0)
                {
                    ball.RaiseCollisionEvent(ball.Sprite.Structure.Window);
                }
                else if (ball.Sprite.Position.X <= 0)
                {
                    ball.RaiseCollisionEvent(ball.Sprite.Structure.Window);
                }
            }
        }
    }
}
