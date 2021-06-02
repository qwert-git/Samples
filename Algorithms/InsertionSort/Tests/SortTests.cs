using System.Linq;
using Core;
using Xunit;

namespace Tests
{
    public class SortTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        public void InsertionTest(int n)
        {
            var insertionSort = new InsertionSort();

            var array = GetTestData(n);

            insertionSort.Sort(array);

            var expectedList = array.OrderBy(x => x);
            Assert.True(expectedList.SequenceEqual(array));
        }
        
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        public void ShellSortTest(int n)
        {
            var insertionSort = new InsertionSort();

            var array = GetTestData(n);

            insertionSort.Sort(array);

            var expectedList = array.OrderBy(x => x);
            Assert.True(expectedList.SequenceEqual(array));
        }

        private static int[] GetTestData(int n)
        {
            var array = Enumerable.Range(0, n).ToArray();
            new Shuffling().Shuffle(array);

            return array;
        }
    }
}
