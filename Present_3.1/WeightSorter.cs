using System.Collections.Generic;

namespace Task3_Present
{
	public class WeightSorter : IComparer<Sweet>
	{
		public int Compare(Sweet x, Sweet y)
		{
			if (x.SweetWeight > y.SweetWeight)
			{
				return 1;
			}
			else if (x.SweetWeight < y.SweetWeight)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}
	}
}
