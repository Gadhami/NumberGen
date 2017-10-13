using System;
using System.Collections.Generic;
using System.Linq;
using NumberGenConsole.Extensions;

namespace NumberGenConsole
{
    // Each function in this class generates a list of 10,000 unique numbers
    // in random order using a different algorithm
    public static class RandomNumbers
    {
        /// <summary>
        /// 1st Method: HashSet is used to store generated numbers
        /// </summary>
        /// <param name="NbrCount"></param>
        /// <param name="MinValue"></param>
        /// <param name="MaxValue"></param>
        /// <returns>HashSet containing unique / random numbers</returns>
        public static HashSet<int> GenerateNbrs(int NbrCount = 10000, int MinValue = 1, int MaxValue = 10000)
        {
            // First method: we use HashSet to store generated numbers
            var NbrList   = new HashSet<int>();

            // Initialise Random var
            var Rnd       = new Random();

            int NewNumber;
            do
            {
                // Generate a new random number and add it to our HashSet
                NewNumber = Rnd.Next(MinValue, MaxValue + 1);

                // Add the new number to our HashSet (only if it's unique)
                if (!NbrList.Contains(NewNumber))
                {
                    NbrList.Add(NewNumber);
                }
            }
            while (NbrList.Count < NbrCount);

            // We're done, return the numbers
            return NbrList;
        }

        /// <summary>
        /// 2nd Method: An Array is used to store numbers in sequence, then "randomized" at the end (using LINQ)
        /// </summary>
        /// <param name="NbrCount"></param>
        /// <returns>Array of unique & random numbers</returns>
        public static int[] GenerateNbrs2(int NbrCount = 10000, int MinValue = 1, int MaxValue = 10000)
        {
            // Second method: An Array is used to store generated numbers

            // Initialize *unique and sorted* numbers array (1 → NbrCount)
            var NbrList = new int[NbrCount];
            for (int i = 0; i < NbrCount; i++)
            {
                // NbrList[0] = 1  /  NbrList[1] = 2  /  NbrList[99] = 100  /  etc...
                NbrList[i] = i + 1;
            }

            // Initialise Random var
            var Rnd = new Random();

            // Use LINQ to randomize numbers array
            return NbrList.OrderBy(x => Rnd.Next()).ToArray();
        }

        /// <summary>
        /// 3rd Method: An Array is used to store numbers in sequence, then "randomized" at the end
        /// </summary>
        /// <param name="NbrCount"></param>
        /// <returns>An array of unique & random numbers</returns>
        public static int[] GenerateNbrs3(int NbrCount = 10000, int MinValue = 1, int MaxValue = 10000)
        {
            // Third method: An Array is used to store generated numbers
            // (same as the 2nd method, except that we're using a different algorithm to shuffle array @ the end)

            // Initialize *unique and sorted* numbers array (1 → NbrCount)
            var NbrList = new int[NbrCount];
            for (int i = 0; i < NbrCount; i++)
            {
                // NbrList[0] = 1  /  NbrList[1] = 2  /  NbrList[99] = 100  /  etc...
                NbrList[i] = i + 1;
            }

            // Initialise Random var
            var Rnd = new Random();

            // Shuffle array using the O(n) Fisher-Yates algorithm
            Rnd.Shuffle(NbrList);

            // We're done, return numbers
            return NbrList;
        }

        /// <summary>
        /// 4th Method: A Dictionary is used to store generated numbers
        /// </summary>
        /// <param name="NbrCount"></param>
        /// <returns>Dictionary containing unique & random numbers</returns>
        public static Dictionary<int, int> GenerateNbrs4(int NbrCount = 10000, int MinValue = 1, int MaxValue = 10000)
        {
            // Forth method: A Dictionary is used to store generated numbers

            // Initialize unique numbers Dictionary
            var NbrList = new Dictionary<int, int>();

            // Initialise Random var
            var Rnd     = new Random();

            int NewNumber;
            do
            {
                // Generate a new random number and add it to our list (hash set)
                NewNumber = Rnd.Next(MinValue, MaxValue + 1);

                // Add the new number to our Dictionary (only if it's unique)
                if (!NbrList.ContainsKey(NewNumber))
                {
                    NbrList.Add(NewNumber, NewNumber);
                }
            }
            while (NbrList.Count < NbrCount);

            // We're done, return the numbers
            return NbrList;
        }
    }
}
