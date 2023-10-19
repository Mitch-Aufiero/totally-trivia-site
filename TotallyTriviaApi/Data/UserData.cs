using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using TotallyTriviaApi.Models;
using MySql.Data.MySqlClient;

namespace TotallyTriviaApi.Data
{
    public class UserData
    {
        public static User GetUser(string id, string env)
        {

            int score = 0;
            string userID = "", userName = "", team = "";

            string connString = "";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "Select userID, userName, team, score from user where userID = '" + id + "' and environment = '" + env + "'; ";

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
                userID = reader["userID"].ToString();
                userName = reader["userName"].ToString();
                team = reader["team"].ToString();
                score = (int)reader["score"];
            }


            conn.Close();

            return new User(userID, userName, env, score, team);
        }


        public static int getUserScore(string id, string env)
        {

            int score = 0;

            string connString = "Server=localhost;Port=3306;Database=TriviaDB;Uid=admin1;password=Kshayne1234;SslMode=none;";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "Select * from user where userID = '" + id + "' and environment = '" + env + "'; ";

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
                    score = (int)reader["score"];
                }
            }
            else
            {
                score = -5;
            }
            conn.Close();

            return score;
        }


        public static void AddToScore(string id, string env, int scoreToAdd)
        {

            int myScore = UserData.getUserScore(id, env) + scoreToAdd;

            string connString = "Server=localhost;Port=3306;Database=TriviaDB;Uid=admin1;password=Kshayne1234;SslMode=none;";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "Update user set score = " + myScore + "   where userID = '" + id + "' and environment = '" + env + "'; ";

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + "\n");
            }
            command.ExecuteNonQuery(); ;


            conn.Close();

        }


        public static void CreateUser(string userID, string userName, string env, string team)
        {
            string connString = "Server=localhost;Port=3306;Database=TriviaDB;Uid=admin1;password=Kshayne1234;SslMode=none;";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "insert into user (userID,userName,environment,score,team) values ('" + userID + "','" + userName + "','" + env + "',0,'" + team + "');";

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + "\n");
            }
            command.ExecuteNonQuery();

        }


        public static string getHighScore()
        {

            string scores = "Highscores:\n";

            int score = 0;
            string username = "";

            string connString = "Server=localhost;Port=3306;Database=TriviaDB;Uid=admin1;password=Kshayne1234;SslMode=none;";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "select username, score from user order by score desc limit 5; ";

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
                    score = (int)reader["score"];
                    username = reader["userName"].ToString();

                    scores += username + ": " + score + " \n";
                }
            }
            else
            {

            }
            conn.Close();

            return scores;
        }
    }

}

