using System;

namespace NumberGenConsole.Extensions
{
    public static class ShuffleArray
    {
        /// <summary>
        /// Shuffle array using Fisher-Yates algorithm (O(n))
        /// </summary>

        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n        = array.Length;
            while (n > 1)
            {
                int k    = rng.Next(n--);
                T temp   = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
