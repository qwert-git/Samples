using System.Collections.Generic;

namespace Core
{
    public class InsertionSort : ISortAlgorithm
    {
        public void Sort(int[] array) 
        {
            var length = array.Length;
            for (var i = 0; i < length; i++)
            {
                for (var j = i; j > 0 && BiggerThanPrevious(array, j); j--)
                { 
                    Swap(array, j, j-1);
                }
            }
        }

        private static bool BiggerThanPrevious(IReadOnlyList<int> array, int j) 
            => array[j - 1] > array[j];

        private static void Swap(IList<int> arr, int i, int j)
        {
            var t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
