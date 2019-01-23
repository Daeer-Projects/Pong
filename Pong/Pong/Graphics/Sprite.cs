using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Helpers;

namespace Pong.Graphics
{
    public abstract class Sprite : ISprite
    {
        private Vector2 _position;
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public bool InGoal { get; set; }
        public Texture2D Texture { get; protected set; }
        public GameStructure Structure { get; protected set; }
        public GraphicsDevice GraphicsDevice { get; set; }
        public Vector2 PreviousPosition { get; protected set; }
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                PreviousPosition = _position;
                _position = value;
            }
        }

        public Vector2 Speed { get; set; }

        public Rectangle GetBounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }

        protected Sprite(int width, int height, bool inGoal, GameStructure structure, GraphicsDevice graphicsDevice, int xPosition, int yPosition)
        {
            Width = width;
            Height = height;
            InGoal = inGoal;
            GraphicsDevice = graphicsDevice;
            Structure = structure;

            Texture = new Texture2D(GraphicsDevice, Width, Height);
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}