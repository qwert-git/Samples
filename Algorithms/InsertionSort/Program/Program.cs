using System;
using System.Diagnostics;
using Core;

namespace Program
{
	class Program
	{
		static void Main(string[] args)
		{
			var nArray = new[] { 1000, 10000, 50000, 100000 };
			
			var insertionSort = new InsertionSort();
			var shellSort = new ShellSort();

			foreach (var n in nArray)
			{
				var data = GetTestData(n);
				
				var data2 = new int[n];
				data.CopyTo(data2, 0);
				
				Test(data, shellSort, nameof(ShellSort));
				Test(data2, insertionSort, nameof(InsertionSort));
				Console.WriteLine("===========================");
			}

			Console.ReadKey();
		}

		private static int[] GetTestData(int n)
		{
			var array = new int[n];
			for (var i = 0; i < n; i++)
				array[i] = new Random().Next(100);

			return array;
		}

		private static void Test(int[] array, ISortAlgorithm sortAlgorithm, string testName)
		{
			var sw = Stopwatch.StartNew();
			sortAlgorithm.Sort(array);
			sw.Stop();

			Console.WriteLine($"{testName} for {array.Length} elements: {sw.Elapsed.TotalSeconds}");
		}
	}
}