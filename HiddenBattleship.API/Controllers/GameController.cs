using HiddenBattleship.BL;
using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more inGameion on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PB.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly DbContextOptions<HiddenBattleshipEntities> options;

        public GameController(ILogger<GameController> logger,
                               DbContextOptions<HiddenBattleshipEntities> options)
        {
            _logger = logger;
            this.options = options;
        }

        // GET: api/<GameController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return new GameManager(options).Load();
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public Game Get(Guid id)
        {
            return new GameManager(options).LoadById(id);
        }

        // POST api/<GameController>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Game Game, bool rollback = false)
        {
            return new GameManager(options).Insert(Game, rollback);
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Game Game, bool rollback = false)
        {
            return new GameManager(options).Update(Game, rollback);
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new GameManager(options).Delete(id, rollback);
        }
    }
}
