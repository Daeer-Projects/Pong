using Microsoft.Xna.Framework;
using System;

namespace Pong.Helpers
{
    public static class AngleCalculator
    {
        public static Vector2 RadianAngleToVector(float angle)
        {
            return new Vector2((float)Math.Sin(angle), -(float)Math.Cos(angle));
        }

        public static float VectorToRadianAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.X, -vector.Y);
        }

        public static float RadianToDegrees(float angle)
        {
            return (float)(angle * 180 / Math.PI);
        }

        public static float DegreesToRadian(float angle)
        {
            return (float)(angle / Math.PI * 180);
        }
    }
}
