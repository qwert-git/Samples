using System.Diagnostics;
using System.Linq;

namespace Core
{
	public class QuickUnion : IDynamicConnectivity
	{
		private readonly int[] _multitudes;

		private readonly int[] _treeSize;

		public QuickUnion(int n)
		{
			_multitudes = Enumerable.Range(0, n).ToArray();
			_treeSize = Enumerable.Repeat(1, n).ToArray();
		}

		/// <inheritdoc />
		public void Union(int x, int y)
		{
			var xRoot = GetRoot(x);
			var yRoot = GetRoot(y);

			if (xRoot == yRoot)
				return;

			var (rootJoinTo, rootJoinFrom) = GetUnionWeights(yRoot, xRoot);

			_multitudes[rootJoinTo] = _multitudes[rootJoinFrom];
			_treeSize[rootJoinTo] += _treeSize[rootJoinFrom];
		}

		/// <inheritdoc />
		public bool Connected(int x, int y) =>
			GetRoot(x) == GetRoot(y);

		private int GetRoot(int item)
		{
			while (_multitudes[item] != item)
			{
				_multitudes[item] = _multitudes[_multitudes[item]];
				item = _multitudes[item];
			}

			return item;
		}

		private (int rootJoinTo, int rootJoinFrom) GetUnionWeights(int yRoot, int xRoot)
		{
			var rootJoinTo = yRoot;
			var rootJoinFrom = xRoot;

			if (_treeSize[xRoot] > _treeSize[yRoot])
			{
				rootJoinTo = xRoot;
				rootJoinFrom = yRoot;
			}

			return (rootJoinTo, rootJoinFrom);
		}
	}
}