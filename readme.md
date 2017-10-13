This project is a console app written in C#

---
## Requirements

*   Generate a list of 10,000 numbers in random order each time it is run.

*   Each number in the list must be unique and be between 1 and 10,000 (inclusive)

---
## Notes

*   Just clone / download the repo, open `csharp-solution\NumberGenConsole.sln` in VS.NET 2017 and run it.

*   Running in release mode is obviously advised.

*   4 different methods were explored

---
## The project:

1.	Run a benchmark: every method / algorithm is executed 100 times, then average execution time is outputted.

2.	Execute a simple test to make sure numbers array is as expected.

---
## The 4 methods are as follow:

*   `Method #1`

    We use the Random class to generate random numbers, which are added to a HashSet

*   `Method #2`

    We initialize an int[] array and initialize it to have an ordered array, ie.

        NbrList[0] = 1
        NbrList[1] = 2
        NbrList[2] = 3
        NbrList[99] = 100

        etc...

    Then we use `LINQ` and `Random` to randomize numbers array (not the fastest option, I included it just for fun)

*   `Method #3`

    Exactly the same as method #2, except we use a custom extension / helper method to shuffle our int array using Fisher-Yates algorithm

	The `Fisher-Yates algorithm` time complexity is **O(n)**, which makes it far more efficient than the "classic" naive implementation

*   `Method #4`

    We use the Random class to generate random numbers, which are added to a Dictionary

---

My personal pick is the third one.