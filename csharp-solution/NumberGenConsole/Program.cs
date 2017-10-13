using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NumberGenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Number generation code → [ RandomNumbers.cs ]

            // Run each algorithm 100 times, then output average execution time (in ticks)
            RunTests();

            // Convert integer lists & Save output for further inspection
            TestAndExport();
        }

        /// <summary>
        /// Simple benchmark: Execute available algorithms and output execution speed result
        /// </summary>
        /// <param name="RepeatTests">How many times we should execute each method</param>
        static void RunTests(int RepeatTests = 100)
        {
            // Stop watch used to measure execution speed of each method
            var Watch     = new Stopwatch();

            // Array used to track time measures for every method / algorithm
            var AlgoSpeed = new long[4];

            // ========
            // First method
            // ========
            for (int i = 1; i <= RepeatTests; i++)
            {
                Watch.Start();
                RandomNumbers.GenerateNbrs();
                Watch.Stop();
            }
            AlgoSpeed[0] = Watch.ElapsedTicks;

            // ========
            // Second method
            // ========
            Watch.Reset();
            for (int i = 1; i <= RepeatTests; i++)
            {
                Watch.Start();
                RandomNumbers.GenerateNbrs2();
                Watch.Stop();
            }
            AlgoSpeed[1] = Watch.ElapsedTicks;

            // ========
            // Third method
            // ========
            Watch.Reset();
            for (int i = 1; i <= RepeatTests; i++)
            {
                Watch.Start();
                RandomNumbers.GenerateNbrs3();
                Watch.Stop();
            }
            AlgoSpeed[2] = Watch.ElapsedTicks;

            // ========
            // Forth method
            // ========
            Watch.Reset();
            for (int i = 1; i <= RepeatTests; i++)
            {
                Watch.Start();
                RandomNumbers.GenerateNbrs4();
                Watch.Stop();
            }
            AlgoSpeed[3] = Watch.ElapsedTicks;

            // ========
            // Output speed results
            // ========
            Console.WriteLine("========================================\n" +
                              $"Average Speed / algorithm / execution (each method were executed {RepeatTests} times):\n" +
                              "========================================\n" +
                              $"Method 1: {(AlgoSpeed[0] / RepeatTests).ToString()} ticks\n" +
                              $"Method 2: {(AlgoSpeed[1] / RepeatTests).ToString()} ticks\n" +
                              $"Method 3: {(AlgoSpeed[2] / RepeatTests).ToString()} ticks (should be the fastest algorithm)\n" +
                              $"Method 4: {(AlgoSpeed[3] / RepeatTests).ToString()} ticks\n"
            );
        }

        /// <summary>
        /// Convert integer lists & Save output for further inspection (just for debugging purposes)
        /// </summary>
        static void TestAndExport()
        {
            // ========
            // Output speed results
            // ========
            Console.WriteLine("========================================\n" +
                              $"Running Tests (+ array export)\n" +
                              "========================================\n");

            var DebugFolder = Directory.GetCurrentDirectory() + @"\";


            // ===============
            // Run the 1st algorithm and save array to a file
            // ===============
            var list1 = RandomNumbers.GenerateNbrs();
            var sList = list1.Select(nbr => nbr.ToString());
            File.WriteAllLines($"{DebugFolder}algorithm-1.txt", sList);

            // Test array (we use LINQ to convert HashSet to int[])
            if (TestUniqueNumbers(list1.Select(nbr => nbr).ToArray(), 1, 10000))
                Console.WriteLine(" > Tests for the first Method passed");
            else
                Console.WriteLine(" > Tests for the first Method failed :(");


            // ===============
            // Run the 2nd algorithm and save array to a file
            // ===============
            var list2 = RandomNumbers.GenerateNbrs2();
            sList     = list2.Select(nbr => nbr.ToString());
            File.WriteAllLines($"{DebugFolder}algorithm-2.txt", sList);

            // Test array
            if (TestUniqueNumbers(list2, 1, 10000))
                Console.WriteLine(" > Tests for the second Method passed");
            else
                Console.WriteLine(" > Tests for the second Method failed :(");


            // ===============
            // Run the 3rd algorithm and save array to a file
            // ===============
            var list3 = RandomNumbers.GenerateNbrs3();
            sList     = list3.Select(nbr => nbr.ToString());
            File.WriteAllLines($"{DebugFolder}algorithm-3.txt", sList);

            // Test array
            if (TestUniqueNumbers(list3, 1, 10000))
                Console.WriteLine(" > Tests for the third Method passed");
            else
                Console.WriteLine(" > Tests for the third Method failed :(");


            // ===============
            // Run the 4th algorithm and save array to a file
            // ===============
            var list4 = RandomNumbers.GenerateNbrs4();
            sList     = list4.Select(nbr => nbr.Value.ToString());
            File.WriteAllLines($"{DebugFolder}algorithm-4.txt", sList);

            // Test array (we use LINQ to convert Dictionary to int[])
            if (TestUniqueNumbers(list4.Select(nbr => nbr.Value).ToArray(), 1, 10000))
                Console.WriteLine(" > Tests for the forth Method passed");
            else
                Console.WriteLine(" > Tests for the forth Method failed :(");


            // ==========

            Console.WriteLine($"\nDone! Random numbers were exported to: \n\t{DebugFolder}\n");
            Console.WriteLine("========================================\n");
        }

        /// <summary>
        /// Really simple function to test that passed array contains unique numbers (& within the specified range).
        /// Given the simplicity of the task, I didn't bother making a separate / more elaborate test project
        /// </summary>
        /// <param name="NbrArray">Integer Array to be tested</param>
        /// <param name="MinValue">Min. valid value</param>
        /// <param name="MaxValue">Max. valid value</param>
        /// <returns>True if array passed the test, false otherwise</returns>
        public static bool TestUniqueNumbers(int[] NbrArray, int MinValue = 1, int MaxValue = 10000)
        {
            // Wrap inside a try-catch to handle unexpected issue & gracefully mark test as failed

            // In this test, we use a temporary int array (called TempIntArray) and "fill it" with the passed array values
            // At the end of this test, if the passed array doesn't "cover" all random numbers (ie. number X weren't
            // generated), TempIntArray[X - 1] value will be zero (ie. the default value for an integer)

            // In this test, we also check for duplicated values, as well as their validity (ie. wether value is within
            // or outside the specified range)

            // NB. This "trick" only works if MinValue is > 0
            try
            {
                if (NbrArray == null || NbrArray.Length == 0)
                {
                    return false;
                }

                var ArrayLength  = NbrArray.Length;
                var TempIntArray = new int[ArrayLength];

                for (int i = 0; i < ArrayLength; i++)
                {
                    // Check that passed array is within allowed range
                    if (NbrArray[i] <= MaxValue && NbrArray[i] >= MinValue)
                    {
                        if (TempIntArray[NbrArray[i] - 1] != 0)
                        {
                            // Passed array has a duplicate value
                            // Test failed → No need to proceed any further

                            return false;
                        }
                        else
                        {
                            TempIntArray[NbrArray[i] - 1] = NbrArray[i];
                        }
                    }
                    else
                    {
                        // Passed array has a value outside the allowed range
                        // Test failed → No need to proceed any further

                        return false;
                    }
                }

                for (int i = 0; i < ArrayLength; i++)
                {
                    if (TempIntArray[i] == 0)
                    {
                        // If LocalIntArray[i] value is zero, it means that passed array didn't "fill" all numbers

                        // Test failed → No need to proceed any further
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            // Since we're here, we can safely assume test passed sucessfully
            return true;
        }
    }
}
