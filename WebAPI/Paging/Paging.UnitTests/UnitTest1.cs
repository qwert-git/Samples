using Xunit;
using FluentAssertions;

namespace Paging.UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(2, 2, 4)]
        public void Test1(int a, int b, int expected)
        {
            // Act
            int c = a + b;

            // Assert
            c.Should().Be(expected);
        }
    }
}
