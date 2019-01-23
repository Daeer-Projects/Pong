using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Collision;
using Pong.Helpers;
using Pong.Players;

namespace Pong.Graphics
{
    public class Ball : Sprite
    {
        public int HeadingToPlayer { get; protected set; }
        public float XForce { get; set; }
        public float YForce { get; set; }
        private float MinAngleOfDirection { get; set; }
        private float MaxAngleOfDirection { get; set; }
        public Color ballColour { get; set; }

        public Ball(GameStructure gameStructure, GraphicsDevice graphicsDevice, int xPosition, int yPosition, Color colour)
            : base(10, 10, false, gameStructure, graphicsDevice, xPosition, yPosition)
        {
            MinAngleOfDirection = 20.0f; // ToDo: not actually an angle.
            MaxAngleOfDirection = 70.0f; // ToDo: not actually an angle.

            Position = new Vector2(gameStructure.Window.ClientBounds.Width / 2, gameStructure.Window.ClientBounds.Height / 2);
            Speed = new Vector2(XForce, YForce);

            var collisionObject = gameStructure.Collision.AddSprite(this);
            collisionObject.OnCollisionHandler += OnCollision;
            ballColour = colour;
            SetBallColour(ballColour);
        }

        private void SetBallColour(Color colour)
        {
            var data = new Color[Width * Height];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = colour;
            }
            Texture.SetData(data);
        }

        private void OnCollision(object sender, CollisionEventArgs collisionEventArgs)
        {
            if (collisionEventArgs.Sprite is Paddle)
            {
                Speed = new Vector2(-Speed.X, Speed.Y);
                Position = PreviousPosition;
            }
            else if (collisionEventArgs.Sprite is Wall)
            {
                // Experiment to see if I can calculate angles correctly!
                float angle = AngleCalculator.VectorToRadianAngle(Speed);
                float degrees = AngleCalculator.RadianToDegrees(angle);

                float xOriginal = collisionEventArgs.Sprite.Position.X;
                float yOriginal = collisionEventArgs.Sprite.Position.Y;
                float xDirection = Speed.X;
                float yDirection = Speed.Y;

                if ((xOriginal + 10) <= 70)
                {
                    //degrees = degrees - 180;
                    xDirection = -Speed.X;
                }
                else if (xOriginal >= 720)
                {
                    //degrees = degrees + 180;
                    xDirection = -Speed.X;
                }

                if ((yOriginal + 10) <= 70)
                {
                    //degrees = degrees - 180;
                    yDirection = -Speed.Y;
                }
                else if (yOriginal >= 450)
                {
                    //degrees = degrees + 180;
                    yDirection = -Speed.Y;
                }

                degrees = degrees + 180;

                angle = AngleCalculator.DegreesToRadian(degrees);
                Speed = new Vector2(xDirection, yDirection);
                //Speed = AngleCalculator.RadianAngleToVector(angle);
                Position = PreviousPosition;
            }
            else if (collisionEventArgs.Sprite is Ball)
            {
                Speed = new Vector2(-Speed.X, -Speed.Y);
                Position = PreviousPosition;
            }
            else if (collisionEventArgs.GameWindows is GameWindow)
            {
                CheckWhichPartOfScreenWeCollidedWith();
            }
        }

        private void CheckWhichPartOfScreenWeCollidedWith()
        {
            bool setInGoal = false;
            var ballHeight = Position.Y + Height;
            var ballWidth = Position.X + Width;

            if (ballHeight >= Structure.Window.ClientBounds.Height)
            {
                Speed = new Vector2(Speed.X, -Speed.Y);
                Position = PreviousPosition;
            }
            else if (ballWidth >= Structure.Window.ClientBounds.Width)
            {
                setInGoal = true;
                Position = PreviousPosition;
            }
            else if (Position.Y <= 0)
            {
                Speed = new Vector2(Speed.X, -Speed.Y);
                Position = PreviousPosition;
            }
            else if (Position.X <= 0)
            {
                setInGoal = true;
                Position = PreviousPosition;
            }

            InGoal = setInGoal;
        }

        public override void Update(GameTime gameTime)
        {
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            HeadingToPlayer = (Speed.X < 0) ? (int)Team.Side.Left : (int)Team.Side.Right;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void GenerateBallDirection()
        {
            int leftOrRight = Randomiser.GetRandom(1, 3);
            int upOrDown = Randomiser.GetRandom(1, 3);

            float newXAngle = Randomiser.GetRandom(MinAngleOfDirection, MaxAngleOfDirection);
            float newYAngle = Randomiser.GetRandom(MinAngleOfDirection, MaxAngleOfDirection);

            XForce = (leftOrRight == 1) ? -newXAngle : newXAngle;
            YForce = (upOrDown == 1) ? -newYAngle : newYAngle;

            Speed = new Vector2(XForce, YForce);
        }
    }
}
