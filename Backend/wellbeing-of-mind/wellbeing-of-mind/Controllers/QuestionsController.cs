using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using wellbeing_of_mind.DTOs;
using wellbeing_of_mind.Infastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wellbeing_of_mind.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : Controller
    {
        private readonly ITestRepository _questionsRepository;

        private readonly IMapper _mapper;
        public QuestionsController(ITestRepository questionsRepository, IMapper mapper)
        {
            _questionsRepository = questionsRepository ?? throw new ArgumentNullException(nameof(questionsRepository));
            _mapper = mapper;
        }

        // GET api/questions
        // GET api/questions?search=ski
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<QuestionDto>> GetQuestions([FromQuery] string? search)
        {
            var questions = _questionsRepository.GetQuestions(search);

            var questionsDto = _mapper.Map<IEnumerable<QuestionDto>>(questions);
            return Ok(questionsDto);

            
        }

        // GET api/questions/1
        [HttpGet("{id:int}")]
        public ActionResult<QuestionDto> GetQuestionById(int id)
        {
            var question = _questionsRepository.GetQuestion(id);
            var questionDto = _mapper.Map<QuestionAnswersDto>(question);
            if (questionDto == null)
            {
                return NotFound();
            }
            return Ok(questionDto);
        }
    }
}
