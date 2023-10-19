using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyTriviaApi.Models
{
    public class User
    {

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Environment { get; set; }
        public int Score { get; set; }

        public string Team { get; set; }

        public User(string userId, string userName, string environment, int score, string team)
        {
            this.UserID = userId;
            this.UserName = userName;
            this.Environment = environment;
            this.Score = score;
            this.Team = team;
        }

        public override string ToString()
        {
            return String.Concat($"{UserName}");
        }

    }
}
