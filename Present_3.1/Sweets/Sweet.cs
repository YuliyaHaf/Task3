namespace Task3_Present
{
	public class Sweet
	{
		public string Category { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public double SweetWeight { get; set; } //gramms

		public Sweet() { }
		public Sweet(string Category, string Name, double Price, double SweetWeight)
		{
			this.Category = Category;
			this.Name = Name;
			this.Price = Price;
			this.SweetWeight = SweetWeight;
		}
	}
}
