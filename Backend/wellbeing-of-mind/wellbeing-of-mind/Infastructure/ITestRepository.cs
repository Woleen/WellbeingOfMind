using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wellbeing_of_mind.Domain;
using wellbeing_of_mind.DTOs;

namespace wellbeing_of_mind.Infastructure
{
    public interface ITestRepository
    {
        IEnumerable<Question> GetQuestions(string? search);
        Question? GetQuestion(int id);
        
        }
}