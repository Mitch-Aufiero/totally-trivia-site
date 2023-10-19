using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotallyTriviaApi.Models;

using MySql.Data.MySqlClient;

namespace TotallyTriviaApi.Data
{
    public class QuestionData
    {

        public static IList<Question> Questions = new List<Question>
        {
            new Question ( "What color is the sky?",  "blue",new List<string> {"red", "green","yellow"}, 1 ,"Test"),
            new Question ( "What color is grass?",  "green",new List<string> {"red", "blue", "yellow"}, 1 ,"Test"),
            new Question ( "What color is a ruby?",  "red",new List<string> { "blue", "green","yellow"}, 1 ,"Test"),
            new Question ( "What color is the sun?",  "yellow",new List<string> {"red", "green","blue"}, 1 ,"Test")
        };

        public static string GetCategory()
        {
            string myCategories = "";

            string connString = "Server=localhost;Port=3306;Database=TriviaDB;Uid=admin1;password=Kshayne1234;SslMode=none;";





            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "Select distinct category from question;";

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + "\n");
            }
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {

                myCategories += reader["category"] + "\n";
            }
            return myCategories;
        }

        public static Question getAQuestion(string category)
        {
            string connString = "Server=localhost;Port=3306;Database=TriviaDB;Uid=admin1;password=Kshayne1234;SslMode=none;";

            int idQuest = 0;

            string question = "";
            string rightAnswer = "";
            List<string> wrongAnswers = new List<string>();
            int difficulty = 0;
            string myCategory = "";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();

            if (category.ToUpper() == "ALL")
                command.CommandText = "Select * from question order by lastUsed Asc limit 1;";
            else
                command.CommandText = "Select * from question where category = '" + category + "' order by lastUsed Asc limit 1;";

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + "\n");
            }
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {



                while (reader.Read())
                {

                    idQuest = (int)reader["idQuestion"];

                    question = reader["triviaQuestion"].ToString();
                    wrongAnswers.Add(reader["wrongAnswer_0"].ToString());
                    wrongAnswers.Add(reader["wrongAnswer_1"].ToString());
                    wrongAnswers.Add(reader["wrongAnswer_2"].ToString());
                    rightAnswer = reader["rightAnswer"].ToString();
                    difficulty = (int)reader["difficulty"];
                    myCategory = reader["category"].ToString();
                }


                conn.Close();
                command.CommandText = "Update question set lastUsed = now() where idQuestion = " + idQuest + "; ";

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message + "\n");
                }

            }


            conn.Close();
            return new Question(question, rightAnswer, wrongAnswers, difficulty, myCategory);
        }

    }
}
