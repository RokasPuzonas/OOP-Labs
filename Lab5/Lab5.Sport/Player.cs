using System;

namespace Lab5.Sport
{
    abstract class Player
    {
        public string TeamName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public uint GamesPlayed { get; set; }
        public uint PointsScored { get; set; }

        public Player(string teamName, string name, string surname, DateTime birthDate, uint gamesPlayed, uint pointsScored)
        {
            TeamName = teamName;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            GamesPlayed = gamesPlayed;
            PointsScored = pointsScored;
        }
    }
}
