using Microsoft.EntityFrameworkCore;
using wellbeing_of_mind.Domain;
using wellbeing_of_mind.DTOs;

namespace wellbeing_of_mind.Infastructure
{
    public class TestRepository : ITestRepository
    {
        private readonly TestDbContext _dbcontext;

        public TestRepository(TestDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Question? GetQuestion(int id)
        {
            return _dbcontext.Questions.Include(q => q.Choices)
                 .SingleOrDefault(q => q.Id == id);
        }

        public IEnumerable<Question> GetQuestions(string? search)
        {
            var questions = _dbcontext.Questions.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                questions = questions.Where(q => q.QuestionContent.Contains(search));
            }

            return questions.ToList();
        }
    }
}
