using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using wellbeing_of_mind.DTOs;
using wellbeing_of_mind.Domain;
using wellbeing_of_mind.Infastructure;


namespace WellbeingOfMindAPI.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly TestDbContext _dbContext;


        public ArticleController(TestDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var articles = _dbContext.Articles.ToList();
            return Ok(articles);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Post([FromBody] Article newArticle)
        {
            try
            {
                if (newArticle == null)
                {
                    return BadRequest("Invalid input data");
                }

                newArticle.CreatedAt = DateTime.Now;
                newArticle.UpdatedAt = DateTime.Now;

                _dbContext.Articles.Add(newArticle);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = newArticle.Id }, newArticle);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
    