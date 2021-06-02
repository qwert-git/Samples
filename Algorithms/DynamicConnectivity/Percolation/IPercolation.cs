namespace Percolation
{
	public interface IPercolation
	{
		/// <summary>
		/// opens the site (row, col) if it is not open already
		/// </summary>
		void Open(int row, int col);

		/// <summary>
		/// is the site (row, col) open?
		/// </summary>
		bool IsOpen(int row, int col);

		/// <summary>
		/// is the site (row, col) full?
		/// </summary>
		bool IsFull(int row, int col);

		/// <summary>returns the number of open sites</summary>
		int NumberOfOpenSites();

		///<summary>does the system percolate?</summary>
		bool Percolates();

		/// <summary>
		/// Print the percolation field.
		/// </summary>
		void Print();
	}
}