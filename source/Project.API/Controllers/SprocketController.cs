using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Project.Infrastructure.Sprockets;

namespace Project.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("sprocket")]
    public class SprocketController : ControllerBase
    {
        private readonly MongoClient _context;

        public SprocketController(MongoClient context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add()
        {

            _context.GetDatabase("MyDatabase").GetCollection<Sprocket>(nameof(Sprocket)).InsertOne(new Sprocket(), new InsertOneOptions());

            return Created();
        }

        /// <summary>
        /// Gets my sprocket
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet]
        [ProducesResponseType<List<Sprocket>>(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var result = _context.GetDatabase("MyDatabase").GetCollection<Sprocket>(nameof(Sprocket)).Find(FilterDefinition<Sprocket>.Empty).ToList();

            return Ok(result);
        }
    }
}