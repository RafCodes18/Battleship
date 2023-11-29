using HiddenBattleship.BL;
using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more inPlayerion on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PB.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly DbContextOptions<HiddenBattleshipEntities> options;

        public PlayerController(ILogger<PlayerController> logger,
                               DbContextOptions<HiddenBattleshipEntities> options)
        {
            _logger = logger;
            this.options = options;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return new PlayerManager(options).Load();
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public Player Get(Guid id)
        {
            return new PlayerManager(options).LoadById(id);
        }

        // POST api/<PlayerController>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Player Player, bool rollback = false)
        {
            return new PlayerManager(options).Insert(Player, rollback);
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Player Player, bool rollback = false)
        {
            return new PlayerManager(options).Update(Player, rollback);
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new PlayerManager(options).Delete(id, rollback);
        }
    }
}
