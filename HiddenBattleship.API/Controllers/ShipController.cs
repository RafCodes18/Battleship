using HiddenBattleship.BL;
using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more inShipion on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PB.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly ILogger<ShipController> _logger;
        private readonly DbContextOptions<HiddenBattleshipEntities> options;

        public ShipController(ILogger<ShipController> logger,
                               DbContextOptions<HiddenBattleshipEntities> options)
        {
            _logger = logger;
            this.options = options;
        }

        // GET: api/<ShipController>
        [HttpGet]
        public IEnumerable<Ship> Get()
        {
            return new ShipManager(options).Load();
        }

        // GET api/<ShipController>/5
        [HttpGet("{id}")]
        public Ship Get(Guid id)
        {
            return new ShipManager(options).LoadById(id);
        }

        // POST api/<ShipController>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Ship Ship, bool rollback = false)
        {
            return new ShipManager(options).Insert(Ship, rollback);
        }

        // PUT api/<ShipController>/5
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Ship Ship, bool rollback = false)
        {
            return new ShipManager(options).Update(Ship, rollback);
        }

        // DELETE api/<ShipController>/5
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new ShipManager(options).Delete(id, rollback);
        }
    }
}
