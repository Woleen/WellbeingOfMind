using Microsoft.EntityFrameworkCore;
using System;
using wellbeing_of_mind.Domain;

namespace wellbeing_of_mind.Infastructure
{
    public class TestDbContext : DbContext
    {
        public DbSet<Test> Tests => Set<Test>();
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Choice> Choices => Set<Choice>();

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().HasData(
                new Test { 
                    Id = 1, 
                    Title = "Anxiety level",
                    Description = "The Anxiety Level Test is a quick assessment designed to measure the intensity of anxiety symptoms. " +
                    "It includes questions about worry, restlessness, and physical tension, with respondents rating their experiences on a scale.",
                });
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuestionContent = "How often have you been bothered by becoming easily annoyed or irritable over the last two weeks ?", 
                    TestId = 1
                }, 
                new Question
                { 
                    Id = 2,
                    QuestionContent = "Do you have trouble relaxing ?", 
                    TestId = 1
                }, 
                new Question
                { 
                    Id = 3, 
                    QuestionContent = "How often do you worry about things that might go wrong?", 
                    TestId = 1
                }, 
                new Question
                {
                    Id = 4, 
                    QuestionContent = "Do you experience physical symptoms such as trembling, sweating, or a racing heart when anxious?",
                    TestId = 1
                },
                new Question
                {
                    Id = 5,
                    QuestionContent = "How often have you been bothered by not being able to stop or control worrying over the last two weeks?",
                    TestId = 1
                },
                new Question
                {
                    Id = 6,
                    QuestionContent = "How often do you find it difficult to make a decision?",
                    TestId = 1
                }
                ) ;

            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 1, ChoiceContent = "One-two time", ChoiceType = "No Anxiety", QuestionId = 1 },
                new Choice { Id = 2, ChoiceContent = "Few times", ChoiceType = "Mild Anxiety", QuestionId = 1 },
                new Choice { Id = 3, ChoiceContent = "Almost every day", ChoiceType = "Severe Anxiety", QuestionId = 1 }
                );
            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 4, ChoiceContent = "No, I do not", ChoiceType = "No Anxiety", QuestionId = 2 },
                new Choice { Id = 5, ChoiceContent = "Sometimes", ChoiceType = "Mild Anxiety", QuestionId = 2 },
                new Choice { Id = 6, ChoiceContent = "Almost every day", ChoiceType = "Severe Anxiety", QuestionId = 2 }
                );
            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 7, ChoiceContent = "I do not worry", ChoiceType = "No Anxiety", QuestionId = 3 },
                new Choice { Id = 8, ChoiceContent = "Sometimes", ChoiceType = "Mild Anxiety", QuestionId = 3 },
                new Choice { Id = 9, ChoiceContent = "Almost every day", ChoiceType = "Severe Anxiety", QuestionId = 3 }
                );
            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 13, ChoiceContent = "No, I do not",  ChoiceType = "No Anxiety", QuestionId = 4 },
                new Choice { Id = 14, ChoiceContent = "Sometimes", ChoiceType = "Mild Anxiety", QuestionId = 4 },
                new Choice { Id = 15, ChoiceContent = "Almost every day", ChoiceType = "Severe Anxiety", QuestionId = 4 }
                );
            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 16, ChoiceContent = "I do not worry", ChoiceType = "No Anxiety", QuestionId = 5 },
                new Choice { Id = 17, ChoiceContent = "Sometimes", ChoiceType = "Mild Anxiety", QuestionId = 5 },
                new Choice { Id = 18, ChoiceContent = "Almost every day", ChoiceType = "Severe Anxiety", QuestionId = 5 }
                );
            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 19, ChoiceContent = "I do not", ChoiceType = "No Anxiety", QuestionId = 6 },
                new Choice { Id = 20, ChoiceContent = "Sometimes", ChoiceType = "Mild Anxiety", QuestionId = 6 },
                new Choice { Id = 21, ChoiceContent = "Almost every day", ChoiceType = "Severe Anxiety", QuestionId = 6 }
                );
        }
    }
}
