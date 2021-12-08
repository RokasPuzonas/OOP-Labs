
using System;

namespace Lab5.Sport
{
    class Basketball : Player
    {
        public uint GainedBallsCount { get; set; }
        public uint GreatPassessCount { get; set; }

        public Basketball(string teamName, string name, string surname, DateTime birthDate, uint gamesPlayed, uint pointsScored, uint gainedBallsCount, uint greatPassessCount) : base(teamName, name, surname, birthDate, gamesPlayed, pointsScored)
        {
            GainedBallsCount = gainedBallsCount;
            GreatPassessCount = greatPassessCount;
        }
    }
}
