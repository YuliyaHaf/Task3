using System;

namespace Task3_Present
{
	public class EmptyPresentException : Exception
	{
		public EmptyPresentException()
		{
			Console.WriteLine("Cannot fulfill the action! The present is empty! \n");
		}
	}
}
