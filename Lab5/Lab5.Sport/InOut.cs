using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab5.Sport
{
    static class InOut
    {

        public static IEnumerable<string> ReadByLines(string filename)
        {
            using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        private static List<Player> FindPlayersByTeam(List<Player> players, string team)
        {
            List<Player> filtered = new List<Player>();
            foreach (Player player in players)
            {
                if (player.TeamName == team)
                {
                    filtered.Add(player);
                }
            }
            return filtered;
        }

        public static List<Team> ReadTeams(string teamsFilename, string playersFilename)
        {
            List<Player> allPlayers = ReadPlayers(playersFilename);
            List<Team> teams = new List<Team>();
            foreach (string line in ReadByLines(teamsFilename))
            {
                string[] parts = line.Split(";");
                string name = parts[0];
                string city = parts[1];
                string coach = parts[2];
                uint gamesPlayed = uint.Parse(parts[3]);
                List<Player> players = FindPlayersByTeam(allPlayers, name);
                Team team = new Team(name, city, coach, gamesPlayed, players);
                teams.Add(team);
            }
            return teams;
        }

        public static List<Player> ReadPlayers(string filename)
        {
            List<Player> players = new List<Player>();
            foreach (string line in ReadByLines(filename))
            {
                string[] parts = line.Split(";");
                string teamName = parts[0];
                string name = parts[1];
                string surname = parts[2];
                DateTime birthDate = DateTime.Parse(parts[3]);
                uint gamesPlayed = uint.Parse(parts[4]);
                uint pointsScored = uint.Parse(parts[5]);
                Player player;
                if (parts.Length == 8) // Basketball
                {
                    uint gainedBallsCount = uint.Parse(parts[6]);
                    uint greatPassessCount = uint.Parse(parts[7]);
                    player = new Basketball(teamName, name, surname, birthDate, gamesPlayed, pointsScored, gainedBallsCount, greatPassessCount);
                }
                else if (parts.Length == 7) // Football
                {
                    uint gottenYellowCardCount = uint.Parse(parts[6]);
                    player = new Football(teamName, name, surname, birthDate, gamesPlayed, pointsScored, gottenYellowCardCount);
                }
                else // Who knows what this is
                {
                    throw new Exception($"Expected basketball or football player: {line}");
                }

                players.Add(player);
            }
            return players;
        }

        public static void PrintPlayers(List<Player> players)
        {
            Console.WriteLine(new string('-', 93));
            Console.WriteLine("| {0,-15} | {1,-12} | {2,-12} | {3} | {4} | {5} |", "Team name", "Name", "Surname", "Birth date", "Games played", "Points scored");
            Console.WriteLine(new string('-', 93));
            foreach (Player p in players)
            {
                Console.WriteLine("| {0,-15} | {1,-12} | {2,-12} | {3:yyyy-MM-dd} | {4,12} | {5,13} |", p.TeamName, p.Name, p.Surname, p.BirthDate, p.GamesPlayed, p.PointsScored);
            }
            Console.WriteLine(new string('-', 93));
        }
    }
}
