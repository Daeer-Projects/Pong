using Microsoft.Xna.Framework.Graphics;
using Pong.Collision;
using Pong.Graphics;
using Pong.Helpers;
using Pong.Screens;
using System.Collections.Generic;
using System.Timers;

namespace Pong.GameModes
{
    public interface IGameModeBase
    {
        Timer ModeTimer { get; }
        GameplayScreen Screen { get; }
        SpriteBatch SpriteBatches { get; }
        GameStructure Structures { get; }
        CollisionManager Collisions { get; }
        List<ISprite> GameSprites { get; }
    }
}
