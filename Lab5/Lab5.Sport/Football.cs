
using System;

namespace Lab5.Sport
{
    class Football : Player
    {
        public uint GottenYellowCardCount { get; set; }

        public Football(string teamName, string name, string surname, DateTime birthDate, uint gamesPlayed, uint pointsScored, uint gottenYellowCardCount) : base(teamName, name, surname, birthDate, gamesPlayed, pointsScored)
        {
            GottenYellowCardCount = gottenYellowCardCount;
        }
    }
}
