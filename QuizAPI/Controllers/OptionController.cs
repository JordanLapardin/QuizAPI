using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;
using QuizAPI.Models.DTO;
using System.Collections.Generic;
using System.Linq;


namespace QuizAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptionController : ControllerBase
    {
        private readonly QuizableDbContext _Context;

        // Dependency Injection via constructor
        public OptionController(QuizableDbContext context)
        {
            _Context = context;
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Option> GetSingle(int id)
        {
            var option = _Context.Options.Where(c => c.OptionID == id).FirstOrDefault();

            if (option == null)
            {
                return NotFound(new { message = "no Note exists for that id", requestedId = id.ToString() });
            }

            return Ok(option);
        }

        #region AllHttpGets

        // An example of setting up an endpoint to return a limited set of results
        // when a pageNumber or recordCount are not specified, the first 100 entries are returned
        [HttpGet]
        public List<Option> GetAll(int pageNumber = 1, int recordCount = 100)
        {
            return _Context.Options.Skip((pageNumber - 1) * recordCount).Take(recordCount).ToList();
        }

        // a single Option and the Question 
        [HttpGet]
        [Route("SingleOptionAndItsQuestion")]
        public ActionResult<Option> SingleOptionAndQuestion(int id)
        {
            // The .Include() is usage of Eager Loading in EF Core
            // This will generate a query that returns a Question and the Question's attached Quiz
            var option = _Context.Options.Where(c => c.OptionID == id).Include(c => c.Question).FirstOrDefault();

            if (option == null)
            {
                return NotFound(new { message = "no Note exists for that id", requestedId = id.ToString() });
            }

            return Ok(option);
        }

        // return the Question when a OptionID is provided
        [HttpGet]
        [Route("QuestionWhenOptionID")]
        public ActionResult<Question> QuestionWhenOptionId(int id)
        {
            // This code will generate a query that returns a Option's attached Question
            var question = _Context.Options.Where(c => c.OptionID == id).Select(c => c.Question).FirstOrDefault();
            return Ok(question);
        }

        //return the newest Option when an QuestionID is provided

        [HttpGet]
        [Route("NewestOption")]
        public ActionResult<Option> NewestOption(int id, bool descending)
        {
            return _Context.Options.Where(c => c.QuestionId == id)
                                     .OrderByDescending(c => c.OptionID)
                                     .FirstOrDefault();
        }

        #endregion AllHttpGets
        [Authorize]
        // Add a recieved Question item to our list
        [HttpPost]
        public ActionResult<Option> Post(Option option)
        {
            // fix with a DTO
            option.OptionID = 0;

            _Context.Options.Add(option);
            _Context.SaveChanges();

            return CreatedAtAction("Post", option);
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Option> Put([FromRoute] int id, [FromBody] Option option)
        {
            if (id == 0 || option == null)
            {
                return BadRequest();
            }

            option.OptionID = id;

            _Context.Options.Update(option);
            _Context.SaveChanges();

            return Ok();
        }
        [Authorize]
        [HttpPost("OldPost")]
        public void BetterPost([FromBody] OptionCreate option)
        {

            Option newoption = new Option
            {
                OptionText = option.OptionText,
                OptionLetter = option.OptionLetter,
                IsCorrect = option.IsCorrect,
                QuestionId = option.QuestionId
            };

            _Context.Options.Add(newoption);

            _Context.SaveChanges();

        }
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Option = _Context.Options.Find(id);

            if (Option == null)
            {
                return NotFound();
            }

            _Context.Options.Remove(Option);

            _Context.SaveChanges();

            return Ok();
        }
    }
}
