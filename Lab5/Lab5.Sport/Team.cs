using System.Collections.Generic;

namespace Lab5.Sport
{
    class Team
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }
        public uint GamesPlayed { get; set; }
        public List<Player> Players { get; set; }

        public Team(string name, string city, string coach, uint gamesPlayed, List<Player> players) {
            Name = name;
            City = city;
            Coach = coach;
            GamesPlayed = gamesPlayed;
            Players = players;
        }

        public uint GetTotalPointsScored()
        {
            uint total = 0;
            foreach (Player player in Players)
            {
                total += player.PointsScored;
            }
            return total;
        }

        public float GetAveragePointsScored()
        {
            return (float)GetTotalPointsScored() / Players.Count;
        }
    }
}

