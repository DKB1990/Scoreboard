using System;

namespace Scoreboard.Models
{
    public class Consoleboard
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public int Scores { get; set; }
        public string Status { get; set; }
        public string PlayerName { get; set; }
        public DateTime LastUpdated { get; set; }
        public override string ToString()
        {
            return PlayerName ?? Id;
        }
    }
}
