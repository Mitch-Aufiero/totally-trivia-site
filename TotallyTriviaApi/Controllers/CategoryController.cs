using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TotallyTriviaApi.Data;
using TotallyTriviaApi.Models;
 
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TotallyTriviaApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {

            IList<Category> cats = CategoryData.GetCategories();

            
            if (cats.ToString() == "")
            {
                return NotFound();
            }


            return Ok(cats);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
