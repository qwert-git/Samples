using System.Collections.Generic;

namespace Core
{
	public class ShellSort : ISortAlgorithm
	{
		public void Sort(int[] array)
		{
			var length = array.Length;

			var h = 1;
			while (h < length / 3) h = h * 3 + 1;

			while (h >= 1)
			{
				for (var i = h; i < length; i++)
				{
					for (var j = i; j >= h && BiggerThanPrevious(array, j); j -= h)
						Swap(array, j, j - 1);
				}

				h /= 3;
			}
		}

		private static bool BiggerThanPrevious(IReadOnlyList<int> array, int j) => 
			array[j - 1] > array[j];

		private static void Swap(IList<int> arr, int i, int j)
		{
			var t = arr[i];
			arr[i] = arr[j];
			arr[j] = t;
		}
	}
}