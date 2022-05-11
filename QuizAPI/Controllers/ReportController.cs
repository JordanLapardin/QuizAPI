using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;
using QuizAPI.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly QuizableDbContext _context;
        public ReportController(QuizableDbContext context)
        {
            _context = context;
        }
        [HttpGet("QuestionsPerQuizReport")]
        public IActionResult QuetionsPerQuizReport()
        {
            var questionsperquiz = _context.quizzes.Include(c => c.Questions).ToList();

            List<ReportVeiwModel> reportdata = questionsperquiz.Select(c => new ReportVeiwModel
            {
                QuizName = c.QuizTitle,
                QuestionCount = c.Questions.Count
            }).ToList();
            return Ok(reportdata);
        }
        
    }
}
