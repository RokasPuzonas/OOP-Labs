using System;
using System.Collections.Generic;

namespace Lab1._1Savarankiskas
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Tourist>	tourists = InOutUtils.ReadTourists("Tourists.csv");
			InOutUtils.PrintTourists(tourists);

			double spendingBudget = TaskUtils.GetBudget(tourists);
			Console.WriteLine("Grupės išlaidų biudžetas: {0:c2}", spendingBudget);
			Console.WriteLine();

			List<Tourist> largestContributors = TaskUtils.GetLargestBudgetContributors(tourists);
			if (largestContributors.Count > 0)
			{
				if (largestContributors.Count == 1)
				{
					Console.WriteLine("Turistas kuris daugiausiai prisidėjo prie išlaidų biudžeto:");
				}
				else
				{
					Console.WriteLine("Turistai kurie daugiausiai prisidėjo prie išlaidų biudžeto:");
				}
				foreach (Tourist tourist in largestContributors)
				{
					Console.WriteLine("{0} {1}", tourist.Name, tourist.Surname);
				}
			}
		}
	}
}
