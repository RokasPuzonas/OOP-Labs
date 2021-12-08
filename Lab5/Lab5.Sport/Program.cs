using System;
using System.Collections.Generic;

namespace Lab5.Sport
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = InOut.ReadTeams("Teams.csv", "Players.csv");
            TeamsRegister register = new TeamsRegister(teams);

            /* Console.WriteLine("Number of teams: {0}\n", register.Count()); */

            string targetCity = "Kaunas";
            List<Player> foundPlayers = register
                .FilterByCity(targetCity)
                .FindPlayerActiveAndWithHighPoints();

            InOut.PrintPlayers(foundPlayers);
        }
    }
}
