using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Caching.Memory;
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

        private readonly IMemoryCache _memoryCache;
        public QuestionsController(ITestRepository questionsRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _questionsRepository = questionsRepository ?? throw new ArgumentNullException(nameof(questionsRepository));
            _mapper = mapper;
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        // GET api/questions
        // GET api/questions?search=ski
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-60")]
        public ActionResult<IEnumerable<QuestionDto>> GetQuestions([FromQuery] string? search)
        {
            try
            {
                var questions = _questionsRepository.GetQuestions(search);

                var questionsDto = _mapper.Map<IEnumerable<QuestionDto>>(questions);
                return Ok(questionsDto);
            }
            catch (Exception ex) {
                return Problem("Please try againt later...", statusCode: 500);
            }
        }

        // GET api/questions/1
        [HttpGet("{id:int}")]
        public ActionResult<QuestionAnswersDto> GetQuestionById(int id)
        {
            var cacheKey = $"{nameof(QuestionsController)}-{nameof(GetQuestionById)}-{id}";

            if(!_memoryCache.TryGetValue<QuestionAnswersDto>(cacheKey, out var questionAnswersDto))
                {
                var question = _questionsRepository.Get(id);
                if (question is not null)
                {
                    questionAnswersDto = _mapper.Map<QuestionAnswersDto>(question);
                    _memoryCache.Set(cacheKey, questionAnswersDto, TimeSpan.FromSeconds(5));
                }
            }
            if (questionAnswersDto is null)
            {
                return NotFound();
            }
            return Ok(questionAnswersDto);
        }
    }
}
