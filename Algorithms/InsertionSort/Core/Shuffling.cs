using System;

namespace Core
{
	public class Shuffling
	{
		public void Shuffle(int[] array)
		{
			for (var i = 0; i < array.Length; i++)
			{
				var r = new Random().Next(i);
				if (i == r) continue;
                
				var temp = array[i];
				array[i] = array[r];
				array[r] = temp;
			}
		}
	}
}