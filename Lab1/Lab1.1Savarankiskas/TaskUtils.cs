using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1._1Savarankiskas
{
	class TaskUtils
	{
		public static double GetBudget(List<Tourist> tourists)
		{
			double spendingBudget = 0;
			foreach (Tourist tourist in tourists)
			{
				spendingBudget += tourist.Money;
			}
			spendingBudget *= 0.3;
			return spendingBudget;
		}

		public static Tourist GetLargestBudgetContributor(List<Tourist> tourists)
		{
			if (tourists.Count == 0)
			{
				return null;
			}

			Tourist largestContributor = tourists[0];
			foreach (Tourist tourist in tourists)
			{
				if (tourist.Money > largestContributor.Money)
				{
					largestContributor = tourist;
				}
			}
			return largestContributor;
		}

		public static List<Tourist> GetLargestBudgetContributors(List<Tourist> tourists) {
			List<Tourist> largestContributors = new List<Tourist>();
			Tourist largestContributor = GetLargestBudgetContributor(tourists);
			if (largestContributor == null)
			{
				return largestContributors;
			}

			foreach (Tourist tourist in tourists)
			{
				if (tourist.Money == largestContributor.Money)
				{
					largestContributors.Add(tourist);
				}
			}
			return largestContributors;
		}
	}
}
