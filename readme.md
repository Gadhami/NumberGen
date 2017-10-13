This project is basically a console app written in C#.

Just clone / download the project **csharp-solution\NumberGenConsole.sln** and run. Running in release mode is obviously advised.

4 different methods were explored.

The project:

1.	Run a benchmark: every method / algorithm is executed 100 times, then average execution time is outputted.
2.	Execute a simple test to make sure numbers array is as expected.

The 4 methods are as follow:

1.	We use the Random class to generate random numbers, which are added to a HashSet
2.	We initialize an int[] array and initialize it to have an ordered array, ie.

	NbrList[0] = 1
	NbrList[1] = 2
	NbrList[2] = 3
	NbrList[99] = 100

	etc...

	Then we use LINQ & Random to randomize numbers array (not the fastest option, I included it just for fun)

3.	Exactly the same as method #2, except we use a custom extension / helper method to shuffle our int array using Fisher-Yates algorithm

	The Fisher-Yates algorithm time complexity is O(n), which makes it far more efficient than the "classic" naive implementation

4.	We use the Random class to generate random numbers, which are added to a Dictionary

My personal pick is the third one.