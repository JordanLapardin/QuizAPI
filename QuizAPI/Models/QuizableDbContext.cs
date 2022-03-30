using Microsoft.EntityFrameworkCore;

namespace QuizAPI.Models
{
    public class QuizableDbContext : DbContext
    {
        public QuizableDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> quizzes { get; set; }
        public DbSet<Option> Options { get; set; }

        public DbSet<UserStuff> Users { get; set; } 


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserStuff>().HasData(
                new UserStuff
                {
                    UserStuffID = 1,
                    UserName = "Admin",
                    UserPassword = "Nah"
                },
                new UserStuff
                {
                    UserStuffID = 2,
                    UserName = "Teacher",
                    UserPassword = "teach"
                }) ;
            builder.Entity<Question>().HasData(
                new Question { QuestionId = 1, QuizId = 1, QuestionTopic = "Math",QuestionText = "What's 1+1"},
                new Question { QuestionId = 2, QuizId = 1, QuestionTopic = "Math", QuestionText = "What's 2+2" },
                new Question { QuestionId = 3, QuizId = 1, QuestionTopic = "Math", QuestionText = "What's 3+3" },
                new Question { QuestionId = 4, QuizId = 2, QuestionTopic = "English", QuestionText = "WHaat does monkey mean" },
                new Question { QuestionId = 5, QuizId = 2, QuestionTopic = "English", QuestionText = "What does Word mean" }
                );
            builder.Entity<Option>().HasData(
                new Option { QuestionId = 1,OptionID = 1,OptionText = "999",OptionLetter = "A", IsCorrect = false },
                new Option { QuestionId = 1, OptionID = 2, OptionText = "69", OptionLetter = "B", IsCorrect = false },
                new Option { QuestionId = 1, OptionID = 3, OptionText = "777", OptionLetter = "C", IsCorrect = false },
                new Option { QuestionId = 1, OptionID = 4, OptionText = "2", OptionLetter = "D", IsCorrect = true },
                new Option { QuestionId = 2, OptionID = 5, OptionText = "Banna", OptionLetter = "A", IsCorrect = false },
                new Option { QuestionId = 2, OptionID = 6, OptionText = "4", OptionLetter = "B", IsCorrect = true },
                new Option { QuestionId = 2, OptionID = 7, OptionText = "876543245678", OptionLetter = "C", IsCorrect = false },
                new Option { QuestionId = 2, OptionID = 8, OptionText = "42", OptionLetter = "D", IsCorrect = false },
                new Option { QuestionId = 3, OptionID = 9, OptionText = "Banna", OptionLetter = "A", IsCorrect = false },
                new Option { QuestionId = 3, OptionID = 10, OptionText = "6", OptionLetter = "B", IsCorrect = true },
                new Option { QuestionId = 3, OptionID = 11, OptionText = "876543245678", OptionLetter = "C", IsCorrect = false },
                new Option { QuestionId = 3, OptionID = 12, OptionText = "42", OptionLetter = "D", IsCorrect = false },
                new Option { QuestionId = 4, OptionID = 13, OptionText = "Banna", OptionLetter = "A", IsCorrect = false },
                new Option { QuestionId = 4, OptionID = 14, OptionText = "Monkey", OptionLetter = "B", IsCorrect = true },
                new Option { QuestionId = 4, OptionID = 15, OptionText = "876543245678", OptionLetter = "C", IsCorrect = false },
                new Option { QuestionId = 4, OptionID = 16, OptionText = "42", OptionLetter = "D", IsCorrect = false }, 
                new Option { QuestionId = 5, OptionID = 17, OptionText = "Banna", OptionLetter = "A", IsCorrect = false },
                new Option { QuestionId = 5, OptionID = 18, OptionText = "word", OptionLetter = "B", IsCorrect = true },
                new Option { QuestionId = 5, OptionID = 19, OptionText = "876543245678", OptionLetter = "C", IsCorrect = false },
                new Option { QuestionId = 5, OptionID = 20, OptionText = "42", OptionLetter = "D", IsCorrect = false }
                );
            builder.Entity<Quiz>().HasData(
                new Quiz
                {
                    QuizId = 1,
                    QuizTitle = "Maths",
                    QuizTopic = "Maths",
                    CreatorName = "Brom",
                    PassP = 60
                },
                new Quiz
                {
                    QuizId = 2,
                    QuizTitle = "English",
                    QuizTopic = "English",
                    CreatorName = "Mr Mokey",
                    PassP = 20
                });
                
        }
    }
}
