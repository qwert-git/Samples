using FluentAssertions;
using Paging.Api.Services.PagingService;
using Xunit;

namespace Paging.UnitTests.PagingParametersTests
{
    public class PagingParametersTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        public void Construct_EdgeCases_Should_InitializeWithCorrectData(int initPageNumber, int expectedPageNumber)
        {
            // Arrange
            var parameters = new PagingParameters(initPageNumber, pageSize: 1);

            // Assert
            parameters.PageNumber.Should().Be(expectedPageNumber);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        [InlineData(1000, 50)]
        public void Construct_PageSizeEdgeCases_Should_InitializeWithCorrectData(int initPageSize, int expectedPageSize)
        {
            // Arrange
            var parameters = new PagingParameters(pageNumber: 1, initPageSize);

            // Assert
            parameters.PageSize.Should().Be(expectedPageSize);
        }
    }
}