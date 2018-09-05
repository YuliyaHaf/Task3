namespace Task3_Present
{
	public class Chocolate : Sweet
	{
		public Chocolate()
		{
			Category = "Chocolate";
			Name = base.Name;
			Price = base.Price;
			SweetWeight = base.SweetWeight;
		}
	}
}
