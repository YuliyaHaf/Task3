using System;

namespace Task3_Present
{
	public class NoItemsToRemoveException : Exception
	{
		public NoItemsToRemoveException()
		{
			Console.WriteLine("No items to remove! \n");
		}
	}
}
