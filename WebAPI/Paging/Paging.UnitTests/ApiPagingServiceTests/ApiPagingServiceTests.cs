using Xunit;
using FluentAssertions;
using Paging.Api.Services.PagingService;
using System.Linq;

namespace Paging.UnitTests
{
    public class ApiPagingServiceTests
    {
        private readonly IPagingService _pagingService;

        public ApiPagingServiceTests()
        {
            _pagingService = new ApiPagingService();
        }

        [Fact]
        public void GetPagedQuery_EmptySource_Should_ReturnEmptyResult()
        {
            // Arrange
            var emptySource = Enumerable.Empty<int>().AsQueryable();

            // Act
            var result = _pagingService.GetPagedQuery<int>(emptySource, new PagingParameters(pageNumber: 1, pageSize: 1));

            // Assert
            result.Should().BeEmpty();
        }

        [Theory]
        [ClassData(typeof(GetPagedQueryTestsDataCommonCases))]
        [ClassData(typeof(GetPagedQueryTestsDataRoofAndFloorCases))]
        public void GetPagedQuery_PageSizeIsOne_Should_ReturnSingleItem(int[] data, int pageNumber, int pageSize, int[] expectedResult)
        {
            // Arrange
            var source = data.AsQueryable();

            // Act
            var result = _pagingService.GetPagedQuery<int>(source, new PagingParameters(pageNumber, pageSize));

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
