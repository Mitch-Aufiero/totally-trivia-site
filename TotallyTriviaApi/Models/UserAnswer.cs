using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyTriviaApi.Models
{
    public class UserAnswer
    {
        public User User { get; set; }
        public String Answer { get; set; }
        public bool Winner { get; set; }

        public UserAnswer(User user, string answer)
        {
            this.User = user;
            this.Answer = answer;
            Winner = false;
        }

    }
}
