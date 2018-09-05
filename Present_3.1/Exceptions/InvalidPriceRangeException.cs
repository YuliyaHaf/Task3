using System;

namespace Task3_Present
{
	public class InvalidPriceRangeException : Exception
	{
		public InvalidPriceRangeException()
		{
			Console.WriteLine("This price range is not valid! \n");
		}
	}
}
