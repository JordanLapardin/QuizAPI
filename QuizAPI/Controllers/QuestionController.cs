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
    public class QuestionController : ControllerBase
    {

        private readonly QuizableDbContext _Context;

        // Dependency Injection via constructor
        public QuestionController(QuizableDbContext context)
        {
            _Context = context;
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Question> GetSingle(int id)
        {
            var question = _Context.Questions.Where(c => c.QuestionId == id).FirstOrDefault();

            if (question == null)
            {
                return NotFound(new { message = "no Note exists for that id", requestedId = id.ToString() });
            }

            return Ok(question);
        }

        #region AllHttpGets

        // An example of setting up an endpoint to return a limited set of results
        // when a pageNumber or recordCount are not specified, the first 100 entries are returned
        [HttpGet]
        public List<Question> GetAll(int pageNumber = 1, int recordCount = 100)
        {
            return _Context.Questions.Skip((pageNumber - 1) * recordCount).Take(recordCount).ToList();
        }

        // a single Question and the Question Quiz
        [HttpGet]
        [Route("SingleQuestionAndItsQuiz")]
        public ActionResult<Question> SingleQuestionAndQuiz(int id)
        {
            // The .Include() is usage of Eager Loading in EF Core
            // This will generate a query that returns a Question and the Question's attached Quiz
            var question = _Context.Questions.Where(c => c.QuestionId == id).Include(c => c.Quiz).FirstOrDefault();

            if (question == null)
            {
                return NotFound(new { message = "no Note exists for that id", requestedId = id.ToString() });
            }

            return Ok(question);
        }

        // return the Quiz when a QuestionID is provided
        [HttpGet]
        [Route("QuizWhenQuestionID")]
        public ActionResult<Quiz> QuizWhenQuestionId(int id)
        {
            // This code will generate a query that returns a Question's attached Quiz
            var quiz = _Context.Questions.Where(c => c.QuestionId == id).Select(c => c.Quiz).FirstOrDefault();
            return Ok(quiz);
        }

        //return the newest Question when an QuizId is provided

        [HttpGet]
        [Route("NewestQuestion")]
        public ActionResult<Question> NewestQuestion(int id, bool descending)
        {
            // Return the last item in an ordered list of notes where the AuthorId (FK) of the note matches the author ID provided
            return _Context.Questions.Where(c => c.QuizId == id)
                                     .OrderByDescending(c => c.QuestionId)
                                     .FirstOrDefault();
        }
        [HttpGet]
        [Route("QuestionsWithOptions")]
        public ActionResult<Question> GetWithQuestions(int id)
        {
            Question question = _Context.Questions
                .Where(c => c.QuestionId == id)
                .Include(c => c.Options)
                .FirstOrDefault();

            if (question != null)
            {
                return question;
            }

            return NotFound();
        }
        #endregion AllHttpGets

        // Add a recieved Question item to our list
        [HttpPost("OldPost")]
        
        public ActionResult<Question> Post(Question Question)
        {
            // fix with a DTO
            Question.QuestionId = 0;

            _Context.Questions.Add(Question);
            _Context.SaveChanges();

            return CreatedAtAction("Post", Question);
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Question> Put([FromRoute] int id, [FromBody] Question question)
        {
            if (id == 0 || question == null)
            {
                return BadRequest();
            }

            question.QuestionId = id;

            _Context.Questions.Update(question);
            _Context.SaveChanges();

            return Ok();
        }
        [Authorize]
        [HttpPost]
        public void BetterPost([FromBody] QuestionCreate question)
        {

            Question newquest = new Question
            {
                QuestionTopic = question.QuestionTopic,
                QuestionText = question.QuestionText,
                QuestionImg = question.QuestionImg,
                QuizId = question.QuizId
            };

            _Context.Questions.Add(newquest);

            _Context.SaveChanges();

        }
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var note = _Context.Questions.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            _Context.Questions.Remove(note);

            _Context.SaveChanges();

            return Ok();
        }
    }
}
