using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure;
using Project.Infrastructure.Sprockets;

namespace Project.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("sprocket")]
    public class SprocketController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SprocketController(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets my sprocket
        /// </summary>
        /// <returns>A <see cref="IActionResult"/>.</returns>
        [HttpGet]
        [ProducesResponseType<string>( StatusCodes.Status200OK)]
        public IActionResult Get()
        {

            _context.Sprockets.Add(new Sprocket());
            _context.SaveChanges();

            return Ok("hello!");
        }
    }
}
