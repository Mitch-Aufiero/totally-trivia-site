using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TotallyTriviaApi.Data;
using TotallyTriviaApi.Models;

namespace TotallyTriviaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        // GET: api/Questions
        [HttpGet(Name = "QuestionCategory")]
        public IActionResult Get(string QuestionCategory = "All")
        {
            
            Question currQuestion = QuestionData.getAQuestion(QuestionCategory);

            if (currQuestion.TriviaQuestion == "")
            {
                return NotFound();
            }

           
            return Ok(currQuestion);
        }

        // GET: api/Questions/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Questions
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
