using System.Collections.Generic;
using System.Collections;

namespace Paging.UnitTests
{
    public class GetPagedQueryTestsDataRoofAndFloorCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Parameters: Source data. PageNumber. PageSize. ExpectedResult
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, -1, 1, new int[] { 1 } };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 99, 1, new int[] { 5 } };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, -1, 2, new int[] { 1, 2 } };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 99, 2, new int[] { 5 } };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 1, -1, new int[] { 1 } };
            yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 5, 1000, new int[] { 1, 2, 3, 4, 5 } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
