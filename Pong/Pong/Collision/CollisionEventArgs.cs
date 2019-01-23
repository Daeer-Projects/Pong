using System;
using Microsoft.Xna.Framework;
using Pong.Graphics;

namespace Pong.Collision
{
    public class CollisionEventArgs : EventArgs
    {
        public ISprite Sprite { get; private set; }
        public GameWindow GameWindows { get; private set; }

        public CollisionEventArgs(ISprite sprite)
        {
            Sprite = sprite;
        }

        public CollisionEventArgs(GameWindow gameWindow)
        {
            GameWindows = gameWindow;
        }
    }
}
