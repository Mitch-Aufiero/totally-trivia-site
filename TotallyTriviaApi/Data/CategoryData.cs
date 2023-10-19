using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotallyTriviaApi.Models;

using MySql.Data.MySqlClient;
 
namespace TotallyTriviaApi.Data
{
    public class CategoryData
    {
        public static IList<Category> Category = new List<Category>
        {
            new Category ( "Category 1"),
            new Category ( "Category 2"),
            new Category ( "Category 3"),
            new Category ( "Category 4"),
        };

        public static IList<Category> GetCategories()
        {
            IList<Category> myCategories = new List<Category>();
            string cat = "";

            string connString = "";


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

                cat = reader["category"].ToString();
                myCategories.Add(new Models.Category(cat));
            }
            return myCategories;
        }
    }
}
