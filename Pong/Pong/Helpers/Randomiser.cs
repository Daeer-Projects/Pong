using System;

namespace Pong.Helpers
{
    public static class Randomiser
    {
        private static readonly Random GetBaseRandom = new Random();
        private static readonly object SyncLock = new object();

        public static int GetRandom(int startValue, int endValue)
        {
            lock (SyncLock)
            {
                return GetBaseRandom.Next(startValue, endValue);
            }
        }

        public static float GetRandom(float startValue, float endValue)
        {
            string newStartValue = startValue.ToString();
            string newEndValue = endValue.ToString();

            int intStartValue;
            int intEndValue;

            Int32.TryParse(newStartValue, out intStartValue);
            Int32.TryParse(newEndValue, out intEndValue);

            float result;
            lock (SyncLock)
            {
                result = GetBaseRandom.Next(intStartValue, intEndValue);
            }
            return result;
        }
    }
}
