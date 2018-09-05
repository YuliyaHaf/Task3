using System;

namespace Task3_Present
{
	class UserInput
	{
		Present present = new Present();

		//Main menu that provides user with the possibility to create a present, see its contents, sort and search the sweets  
		public void MainMenu()
		{
			int choice = -1;
			Console.WriteLine("Create your own present!\n");

			while (choice != 0)
			{
				Console.WriteLine("Select one of the options below: ");
				Console.WriteLine("1. Add an item");
				Console.WriteLine("2. Display the present content");
				Console.WriteLine("3. Find a sweet by price");
				Console.WriteLine("4. Sort sweets by price");
				Console.WriteLine("0. Exit\n");

				try
				{
					choice = Convert.ToInt32(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("No such option! Please, try again or press 0 to exit!\n");
					Console.ReadLine();
					choice = -1;
				}

				switch (choice)
				{
					case 1:
						Present.AddItem();
						break;

					case 2:
						present.DisplayPresentContent();
						break;

					case 3:
						present.FindByPrice();
						break;

					case 4:
						present.SortByPrice();
						break;

					case 0:
						Environment.Exit(0);
						break;
				}

			}
			Console.ReadLine();
		}
	}
}
