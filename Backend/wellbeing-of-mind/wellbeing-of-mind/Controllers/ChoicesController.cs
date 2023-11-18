using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wellbeing_of_mind.DTOs;
using wellbeing_of_mind.Infastructure;

namespace wellbeing_of_mind.Controllers
{
    [ApiController]
    [Route("api/questions/{questionId:int}/choices")]
    public class ChoicesController : ControllerBase
    {
        private readonly TestDbContext _dbContext;

        public ChoicesController(TestDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        //GET 
        [HttpGet]
        public ActionResult<IEnumerable<ChoiceDto>> GetChoices(int questionId)
        {
            var question = _dbContext.Questions
                .Include(q => q.Choices)
                .SingleOrDefault(q => q.Id == questionId);

            if(question == null)
            {
                return NotFound();
            }

            var choicesDto = question.Choices.Select(q =>
                new ChoiceDto()
                { 
                    Id = q.Id,
                    ChoiceContent = q.ChoiceContent,
                }
           );
            return Ok(choicesDto);
        }


    }
}
