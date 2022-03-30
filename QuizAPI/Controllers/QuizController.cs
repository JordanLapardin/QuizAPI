using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;
using QuizAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizableDbContext _Context;

        public QuizController(QuizableDbContext context)
        {
            _Context = context;
        }

        // GET: api/<QuizController>
        [HttpGet]
        public IEnumerable<Quiz> Get(string title, string topic, string creatorname)
        {

            var authorQuery = _Context.quizzes.AsQueryable();

            if (!String.IsNullOrEmpty(title))
            {
                authorQuery = authorQuery.Where(c => c.QuizTitle.ToLower().Contains(title.ToLower()));
            }
            else if (!String.IsNullOrEmpty(topic))
            {
                authorQuery = authorQuery.Where(c => c.QuizTopic.Contains(topic));
            }
            else if (!String.IsNullOrEmpty(creatorname))
            {
                authorQuery = authorQuery.Where(c => c.CreatorName.Equals(creatorname));
            }

            return authorQuery.ToList();



        }

        // GET api/<QuizController>/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Quiz> Get(int id)
        {
            Quiz quiz = _Context.quizzes.Where(c => c.QuizId == id).FirstOrDefault();

            if (quiz != null)
            {
                return quiz;
            }

            return NotFound();
        }

        // Return Quiz With Questions
        [HttpGet]
        [Route("QuizWithQuestions")]
        public ActionResult<Quiz> GetWithQuestions(int id)
        {
            Quiz quiz = _Context.quizzes
                .Where(c => c.QuizId == id)
                .Include(c => c.Questions)
                .FirstOrDefault();

            if (quiz != null)
            {
                return quiz;
            }

            return NotFound();
        }

        // POST api/<QuizController>
        [HttpPost("OldPost")]
        public ActionResult<Quiz> Post([FromBody] Quiz quiz)
        {
            quiz.QuizId = 0;

            _Context.quizzes.Add(quiz);
            _Context.SaveChanges();

            return CreatedAtAction("Post", quiz);
        }

        // PUT api/<QuizController>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Quiz> Put(int id, [FromBody] Quiz quiz)
        {
            quiz.QuizId = id;

            _Context.quizzes.Update(quiz);
            _Context.SaveChanges();

            // Return a 200 to indicate success
            return Ok();
        }
        [HttpPost]
        public void BetterPost([FromBody] QuizCreate quiz)
        {

            Quiz newquiz = new Quiz
            {
                QuizTitle = quiz.QuizTitle,
                QuizTopic = quiz.QuizTopic,
                CreatorName = quiz.CreatorName,
                PassP = quiz.PassP
            };

            _Context.quizzes.Add(newquiz);

            _Context.SaveChanges();

        }

        // DELETE api/<QuizController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var quiz = _Context.quizzes.Where(c => c.QuizId == id).FirstOrDefault();

            if (quiz == null)
            {
                return BadRequest();
            }

            // Remove this note from the list
            _Context.quizzes.Remove(quiz);
            _Context.SaveChanges();
            // Return 200 to indicate success
            return Ok();
        }
    }
}
