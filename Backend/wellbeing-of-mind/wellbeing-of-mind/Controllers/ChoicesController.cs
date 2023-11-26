using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wellbeing_of_mind.Domain;
using wellbeing_of_mind.DTOs;
using wellbeing_of_mind.Infastructure;

namespace wellbeing_of_mind.Controllers
{
    [ApiController]
    [Route("api/questions/{questionId:int}/choices")]
    public class ChoicesController : ControllerBase
    {
        private readonly TestDbContext _dbContext;

        private readonly IMapper _mapper;
        public ChoicesController(TestDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

            var choicesDto = _mapper.Map<IEnumerable<ChoiceDto>>(question.Choices.Select(q => q));
            return Ok(choicesDto);
        }


    }
}
