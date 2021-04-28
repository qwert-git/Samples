using System.Linq;

namespace Core
{
	public class QuickUnion : IDynamicConnectivity
	{
		private readonly int[] _multitudes;

		public QuickUnion(int n)
		{
			_multitudes = Enumerable.Range(0, n).ToArray();
		}

		/// <inheritdoc />
		public void Union(int x, int y) => _multitudes[x] = GetRoot(y);

		/// <inheritdoc />
		public bool Connected(int x, int y) =>
			GetRoot(x) == GetRoot(y);

		private int GetRoot(int item) =>
			_multitudes[item] == item ? item : GetRoot(_multitudes[item]);
	}
}