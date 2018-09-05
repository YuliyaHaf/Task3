using System;

namespace Task3_Present
{
	public class NoItemsToSortException : Exception
	{
		public NoItemsToSortException()
		{
			Console.WriteLine("No items to sort! The present is empty! \n");
		}
	}
}
