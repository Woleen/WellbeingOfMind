using Microsoft.EntityFrameworkCore;
using wellbeing_of_mind.Domain;

namespace wellbeing_of_mind.Infastructure
{
    public class TestDbContext : DbContext
    {
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Choice> Choices => Set<Choice>();

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuestionContent = "How often do you feel nervous or anxious?" 
                }, 
                new Question
                { 
                    Id = 2,
                    QuestionContent = "Do you have trouble relaxing?"
                }, 
                new Question
                { 
                    Id = 3, 
                    QuestionContent = "How often do you worry about things that might go wrong?"
                }, 
                new Question
                {
                    Id = 4, 
                    QuestionContent = "Do you experience physical symptoms such as trembling, sweating, or a racing heart when anxious?"
                }
                ) ;
            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 1, ChoiceContent = "Never", ChoiceWeight = -1 , QuestionId = 1}, 
                new Choice { Id = 2, ChoiceContent = "Sometimes", ChoiceWeight = 0, QuestionId = 1}, 
                new Choice { Id = 3, ChoiceContent = "Often", ChoiceWeight = 1, QuestionId = 1}, 
                new Choice { Id = 4, ChoiceContent = "Always", ChoiceWeight = 2, QuestionId = 1}
                );
        }
    }
}
