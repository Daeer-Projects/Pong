using Microsoft.Xna.Framework;
using Pong.Graphics;

namespace Pong.Collision
{
    public class CollisionObject
    {
        public ISprite Sprite { get; private set; }
        public GameWindow GameWindows { get; private set; }
        public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);

        public CollisionEventHandler OnCollisionHandler;

        public CollisionObject(ISprite sprite)
        {
            Sprite = sprite;
        }

        public CollisionObject(GameWindow gameWindow)
        {
            GameWindows = gameWindow;
        }

        public void RaiseCollisionEvent(ISprite collidedSprite)
        {
            if (OnCollisionHandler != null)
            {
                OnCollisionHandler(this, new CollisionEventArgs(collidedSprite));
            }
        }

        public void RaiseCollisionEvent(GameWindow collidedWindow)
        {
            if (OnCollisionHandler != null)
            {
                OnCollisionHandler(this, new CollisionEventArgs(collidedWindow));
            }
        }
    }
}
