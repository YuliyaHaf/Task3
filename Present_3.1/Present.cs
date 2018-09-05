using System;
using System.Collections.Generic;

namespace Task3_Present
{
	public class Present
	{
		public static List<Sweet> sweets = new List<Sweet>();
		public static double presentWeight { get; set; }


		// Adds sweets according to the user's input
		public static void AddItem()
		{
			int menu_choice = -1;
			string noCategory = "No such category!\n";
			string noSweet = "No sweets in the chosen category!\n";

			while (menu_choice != 0)
			{
				Console.WriteLine("Select a sweet category, please:");
				Console.WriteLine("1. Caramel");
				Console.WriteLine("2. Chocolate");
				Console.WriteLine("0. Show the main menu\n");
				try
				{
					menu_choice = Convert.ToInt32(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine(noCategory);
					Console.ReadLine();
					menu_choice = -1;
				}

				switch (menu_choice)
				{
					case 1:
						Console.WriteLine("Select a sweet: 1. Dyushes, 2. Barbaris\n");
						try
						{
							int option = Convert.ToInt32(Console.ReadLine());
							switch (option)
							{
								case 1:
									{
										Dyushes sweet = new Dyushes();
										AddSweet(sweet);
										presentWeight += sweet.SweetWeight;
										break;
									}
								case 2:
									{
										Barbaris sweet = new Barbaris();
										AddSweet(sweet);
										presentWeight += sweet.SweetWeight;
										break;
									}
								default:
									{
										Console.WriteLine(noSweet);
										Console.ReadLine();
										menu_choice = -1;
										break;
									}
							}
						}
						catch (FormatException)
						{
							Console.WriteLine(noCategory);
							Console.ReadLine();
							menu_choice = -1;
						}
						break;
					case 2:
						Console.WriteLine("Select a sweet: 1. Alyonka, 2. Minchanka\n");
						try
						{
							int option2 = Convert.ToInt32(Console.ReadLine());
							switch (option2)
							{
								case 1:
									{
										Alyonka sweet = new Alyonka();
										AddSweet(sweet);
										presentWeight += sweet.SweetWeight;
										break;
									}
								case 2:
									{
										Minchanka sweet = new Minchanka();
										AddSweet(sweet);
										presentWeight += sweet.SweetWeight;
										break;
									}
								default:
									{
										Console.WriteLine(noSweet);
										Console.ReadLine();
										menu_choice = -1;
										break;
									}
							}

						}
						catch (FormatException)
						{
							Console.WriteLine(noCategory);
							Console.ReadLine();
							menu_choice = -1;
						}
						break;
					case 0:
						menu_choice = 0;
						break;

					default:
						Console.WriteLine(noCategory);
						break;
				}
			}
		}

		//Adds a sweet to the present
		public static void AddSweet(Sweet sweet)
		{
			sweets.Add(sweet);
			Console.WriteLine("The sweet was added to the present!\n");
		}

		//Removes a sweet from the present
		public void RemoveSweets(string name)
		{
			List<Sweet> itemsToRemove = new List<Sweet>();
			foreach (Sweet sweet in sweets)
			{
				if (sweet.Name == name)
				{
					itemsToRemove.Add(sweet);
				}
			}
			try
			{
				if (itemsToRemove.Count == 0)
				{ throw new NoItemsToRemoveException(); }
				else
				{
					foreach (Sweet sweet in itemsToRemove)
					{
						sweets.Remove(sweet);
						Console.WriteLine("The sweets were removed!\n");
					}
				}
			}
			catch (NoItemsToRemoveException) { }
		}

		//Shows what sweets are contained in the present, removes sweets from present
		public void DisplayPresentContent()
		{
			if (sweets.Count == 0)
			{
				Console.WriteLine("There are no sweets in the present!\n");
			}
			else
			{
				UserInput input = new UserInput();
				Console.WriteLine("Your present contains the following items: ");
				foreach (Sweet sweet in sweets)
				{
					Console.WriteLine(sweet.Name + " " + Convert.ToString(sweet.SweetWeight) + "g.");
				}
				Console.WriteLine("Total weight: " + PresentWeight() + "g.\n");
			}

			Console.WriteLine("Do you want to remove any sweets? (yes/no): ");
			string removeOption = Console.ReadLine();
			switch (removeOption)
			{
				case "yes":
					try
					{
						if (sweets.Count == 0)
						{
							throw new EmptyPresentException();
						}
						else
						{
							Console.WriteLine("Enter the sweet name please: ");
							string sweetsToRemove = Console.ReadLine();
							RemoveSweets(sweetsToRemove);
						}
					}
					catch (EmptyPresentException) { };
					break;

				case "no":
					break;
				default:
					Console.WriteLine("No such option!\n");
					break;
			}
		}

		//Calculates the total weight of the present
		public double PresentWeight()
		{
			double presentWeight = 0.0;
			foreach (Sweet sweet in sweets)
			{
				presentWeight += sweet.SweetWeight;
			}
			return presentWeight;
		}

		//Sorts the sweets in the present by price
		public void SortByPrice()
		{
			PriceSorter price = new PriceSorter();
			sweets.Sort(price);
			try
			{
				if (sweets.Count == 0)
					throw new NoItemsToSortException();
				else
				{
					foreach (Sweet sweet in sweets)
					{
						Console.WriteLine(sweet.Name + " " + sweet.Price);
					}
				}
			}
			catch (NoItemsToSortException) { }
		}

		//Allows to find a sweet/sweets by specifying the price range
		public void FindByPrice()
		{
			try
			{
				if (sweets.Count == 0)
				{
					throw new EmptyPresentException();
				}
				else
				{
					try
					{
						double price;
						Console.WriteLine("Enter min price: ");
						double minPrice = Convert.ToDouble(Console.ReadLine());
						Console.WriteLine("Enter max price: ");
						double maxPrice = Convert.ToDouble(Console.ReadLine());

						try
						{
							if (minPrice > maxPrice || maxPrice == 0)
							{
								throw new InvalidPriceRangeException();
							}
							else
							{
								Console.WriteLine("The following sweets fit into the specified price range (" + minPrice + " - " + maxPrice + "): \n");
								foreach (Sweet sweet in sweets)
								{
									price = sweet.Price;
									if (price >= minPrice && price <= maxPrice)
									{
										Console.WriteLine(sweet.Name + ", " + sweet.Price + ". ");
									}
									else
									{
										Console.WriteLine("No sweets in this range!\n");
									}
								}
							}
						}
						catch (InvalidPriceRangeException) { }
					}
					catch (FormatException)
					{
						Console.WriteLine("Invalid input!");
					}
				}
			}
			catch (EmptyPresentException) { }
		}
	}
}
