
using System.Collections.Generic;

namespace Lab5.Sport
{
    class TeamsRegister
    {
        private List<Team> allTeams;

        public TeamsRegister()
        {
            allTeams = new List<Team>();
        }

        public TeamsRegister(List<Team> initialTeams)
        {
            allTeams = new List<Team>();
            foreach (Team team in initialTeams)
            {
                Add(team);
            }
        }

        public void Add(Team team)
        {
            allTeams.Add(team);
        }

        public Team Get(int index)
        {
            return allTeams[index];
        }

        public int Count()
        {
            return allTeams.Count;
        }

        public TeamsRegister FilterByCity(string city)
        {
            List<Team> filtered = new List<Team>();
            foreach (Team team in allTeams)
            {
                if (team.City == city)
                {
                    filtered.Add(team);
                }
            }
            return new TeamsRegister(filtered);
        }

        public List<Player> FindPlayerActiveAndWithHighPoints()
        {
            List<Player> players = new List<Player>();
            foreach (Team team in allTeams)
            {
                float averagePoints = team.GetAveragePointsScored();
                foreach (Player player in team.Players)
                {
                    if (team.GamesPlayed <= player.GamesPlayed && player.PointsScored > averagePoints)
                    {
                        players.Add(player);
                    }
                }
            }
            return players;
        }
    }
}
