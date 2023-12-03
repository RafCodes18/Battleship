using HiddenBattleship.BL;
using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more inGameMovesion on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PB.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameMovesController : ControllerBase
    {
        private readonly ILogger<GameMovesController> _logger;
        private readonly DbContextOptions<HiddenBattleshipEntities> options;

        public GameMovesController(ILogger<GameMovesController> logger,
                               DbContextOptions<HiddenBattleshipEntities> options)
        {
            _logger = logger;
            this.options = options;
        }

        // GET: api/<GameMovesController>
        [HttpGet]
        public IEnumerable<GameMoves> Get()
        {
            return new GameMovesManager(options).Load();
        }

        // GET api/<GameMovesController>/5
        [HttpGet("{id}")]
        public GameMoves Get(Guid id)
        {
            return new GameMovesManager(options).LoadById(id);
        }

        // POST api/<GameMovesController>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] GameMoves GameMoves, bool rollback = false)
        {
            return new GameMovesManager(options).Insert(GameMoves, rollback);
        }

        // PUT api/<GameMovesController>/5
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] GameMoves GameMoves, bool rollback = false)
        {
            return new GameMovesManager(options).Update(GameMoves, rollback);
        }

        // DELETE api/<GameMovesController>/5
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new GameMovesManager(options).Delete(id, rollback);
        }
    }
}
