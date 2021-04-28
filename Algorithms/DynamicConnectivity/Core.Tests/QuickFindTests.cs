using System;
using Xunit;

namespace Core.Tests
{
	public class QuickFindTests
	{
		[Fact]
		public void Connected_InitCollection_NumbersNotConnected()
		{
			// Arrange
			var qf = new QuickUnion(10);

			// Assert
			Assert.False(qf.Connected(1, 2));
		}
		
		[Fact]
		public void Union_ConnectTwoElements_Should_BeConnected()
		{
			// Arrange
			var qf = new QuickUnion(10);

			// Act
			qf.Union(1, 2);

			// Assert
			Assert.True(qf.Connected(1, 2));
		}
		
		[Fact]
		public void Union_ConnectedSequence_Should_BeConnected()
		{
			// Arrange
			var qf = new QuickUnion(10);

			// Act
			qf.Union(1, 2);
			qf.Union(3, 2);
			qf.Union(4, 3);

			// Assert
			Assert.True(qf.Connected(1, 4));
		}
	}
}