using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyTriviaApi.Models
{ 
    public class Category
    {
        public string TriviaCategory { get; set; }
        public Category(string triviaCategory)
        {
            this.TriviaCategory = triviaCategory;
        }
    }
}
