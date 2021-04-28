namespace Core
{
	public interface IDynamicConnectivity
	{
		void Union(int x, int y);

		bool Connected(int x, int y);
	}
}