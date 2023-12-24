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
    [Route("api/tests")]
    public class TestsController : Controller
    {
        private readonly ITestRepository _testRepository;

        private readonly IMapper _mapper;

        private readonly IMemoryCache _memoryCache;
        public TestsController(ITestRepository testRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _testRepository = testRepository ?? throw new ArgumentNullException(nameof(testRepository));
            _mapper = mapper;
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        // GET api/tests
        // GET api/tests?search=ski
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-60")]
        public ActionResult<IEnumerable<TestDto>> GetTests([FromQuery] string? search)
        {
            try
            {
                var tests = _testRepository.GetTests(search);

                var testDto = _mapper.Map<IEnumerable<TestDto>>(tests);
                return Ok(testDto);
            }
            catch (Exception ex)
            {
                return Problem("Please try againt later...", statusCode: 500);
            }
        }

        // GET api/tests/1
        [HttpGet("{id:int}")]
        public ActionResult<TestQuestionsDto> GetTestById(int id)
        {
            var cacheKey = $"{nameof(TestsController)}-{nameof(GetTestById)}-{id}";

            if (!_memoryCache.TryGetValue<TestQuestionsDto>(cacheKey, out var testQuestionsDto))
            {
                var test = _testRepository.GetTestbyId(id);
                if (test is not null)
                {
                    testQuestionsDto = _mapper.Map<TestQuestionsDto>(test);
                    _memoryCache.Set(cacheKey, testQuestionsDto, TimeSpan.FromSeconds(30));
                }
            }
            if (testQuestionsDto is null)
            {
                return NotFound();
            }
            return Ok(testQuestionsDto);
        }
    }
}
