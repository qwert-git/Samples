using System.Linq;

namespace Core
{
	public class QuickFind : IDynamicConnectivity
	{
		private readonly int[] _multitudes;

		public QuickFind(int n)
		{
			_multitudes = Enumerable.Range(0, n).ToArray();
		}

		public void Union(int x, int y)
		{
			if (Connected(x, y))
				return;

			var xId = _multitudes[x];
			var yId = _multitudes[y];
			for (var i = 0; i < _multitudes.Length; i++)
			{
				if (_multitudes[i] == xId)
					_multitudes[i] = yId;
			}
		}

		public bool Connected(int x, int y) => _multitudes[x] == _multitudes[y];
	}
}