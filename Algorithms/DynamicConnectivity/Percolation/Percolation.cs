using System;
using Core;

namespace Percolation
{
	// TODO: Write tests
	// TODO: Add QuickUnion using
	public class Percolation : IPercolation
	{
		private readonly bool[,] _field;
		private readonly QuickUnion _quickUnion; // weighted
		private int _openedSites;

		public Percolation(int n)
		{
			if (n <= 0)
				throw new ArgumentException($"{nameof(n)} cannot be less 1");

			_field = new bool[n, n];
			_quickUnion = new QuickUnion(n);
		}

		/// <inheritdoc />
		public void Open(int row, int col)
		{
			ValidateRange(row, col);

			_field[row, col] = true;
			_openedSites++;
		}

		/// <inheritdoc />
		public bool IsOpen(int row, int col)
		{
			ValidateRange(row, col);
			return _field[row, col];
		}

		/// <inheritdoc />
		public bool IsFull(int row, int col)
		{
			ValidateRange(row, col);
			return _quickUnion.Connected(0, row + col);
		}

		/// <inheritdoc />
		public int NumberOfOpenSites()
		{
			return _openedSites;
		}

		/// <inheritdoc />
		public bool Percolates()
		{
			// TODO: what is index of bottom virtual node.
			return _quickUnion.Connected(0, 1);
		}

		/// <inheritdoc />
		public void Print()
		{
			Console.WriteLine();
			for (var i = 0; i < _field.GetLength(1); i++)
			{
				for (var j = 0; j < _field.GetLength(2); j++)
				{
					var site = _field[i, j];
					Console.Write(site ? "# " : "O ");
				}

				Console.WriteLine();
			}
		}

		private void ValidateRange(int row, int col)
		{
			if (_field.GetLength(1) < row)
				throw new ArgumentOutOfRangeException(nameof(row), "Index out of range");
			if (_field.GetLength(2) < col)
				throw new ArgumentOutOfRangeException(nameof(row), "Index out of range");
		}
	}
}