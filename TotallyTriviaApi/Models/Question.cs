using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyTriviaApi.Models
{
    public class Question
    {


        public string TriviaQuestion { get; set; }

        public string RightAnswer { get; set; }
        public string RightIndex { get; set; }
        public IList<string> WrongAnswers { get; set; }

        public int Difficulty { get; set; }

        public string Category { get; set; }

        public Question(string triviaQuestion, string rightAnswer, IList<string> wrongAnswers, int difficulty, string category)
        {
            this.TriviaQuestion = triviaQuestion;
            this.RightAnswer = rightAnswer;
            this.WrongAnswers = wrongAnswers;
            this.Difficulty = difficulty;
            this.Category = category;

            WrongAnswers.Add(RightAnswer);

            Shuffle();
            AddIndex();
            RightIndex = IdentifyRightAnswer();
        }

        private string IdentifyRightAnswer()
        {
            string index = "Z";
            foreach (string ans in WrongAnswers)
            {
                if (String.Equals(ans.Substring(3).ToUpper(), RightAnswer.ToUpper()))
                {
                    try
                    {
                        Console.WriteLine("found a match" + ans.Substring(3).ToUpper() + " = " + RightAnswer.Substring(3).ToUpper());
                        index = ans.Substring(0, 1);
                    }
                    catch(Exception er)
                    {
                        Console.WriteLine("ERROR: " + er);
                        index = null;
                    }
                }
            }

            return index;
        }

        private void Shuffle()
        {

            Random rand = new Random();

            int n = WrongAnswers.Count;


            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);

                String value = WrongAnswers[k];
                WrongAnswers[k] = WrongAnswers[n];
                WrongAnswers[n] = value;
            }


        }

        private void AddIndex()
        {
            int n = WrongAnswers.Count;


            while (n > 0)
            {
                n--;
                WrongAnswers[n] = Number2String(n + 1, true) + ") " + WrongAnswers[n].ToString();

            }
        }

        public String Ask()
        {
            string askUsers = TriviaQuestion + "\n";

            foreach (var p in WrongAnswers)
            {
                askUsers += p + "\n";
            }


            return askUsers;
        }

        public bool Guess(string userAnswer)
        {
            bool rightAnswer = false;

            if (String.Equals(userAnswer.ToUpper(), RightIndex.ToUpper()))
            {
                rightAnswer = true;
            }

            return rightAnswer;

        }

        public string GetRightAnswer()
        {
            return RightAnswer;
        }


        private String Number2String(int number, bool isCaps)
        {

            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));

            return c.ToString();

        }

        

    }
}
