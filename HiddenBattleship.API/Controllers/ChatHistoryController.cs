using HiddenBattleship.BL;
using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more inChatHistoryion on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PB.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHistoryController : ControllerBase
    {
        private readonly ILogger<ChatHistoryController> _logger;
        private readonly DbContextOptions<HiddenBattleshipEntities> options;

        public ChatHistoryController(ILogger<ChatHistoryController> logger,
                               DbContextOptions<HiddenBattleshipEntities> options)
        {
            _logger = logger;
            this.options = options;
        }

        // GET: api/<ChatHistoryController>
        [HttpGet]
        public IEnumerable<ChatHistory> Get()
        {
            return new ChatHistoryManager(options).Load();
        }

        // GET api/<ChatHistoryController>/5
        [HttpGet("{id}")]
        public ChatHistory Get(Guid id)
        {
            return new ChatHistoryManager(options).LoadById(id);
        }

        // POST api/<ChatHistoryController>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] ChatHistory ChatHistory, bool rollback = false)
        {
            return new ChatHistoryManager(options).Insert(ChatHistory, rollback);
        }

        // PUT api/<ChatHistoryController>/5
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] ChatHistory ChatHistory, bool rollback = false)
        {
            return new ChatHistoryManager(options).Update(ChatHistory, rollback);
        }

        // DELETE api/<ChatHistoryController>/5
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            return new ChatHistoryManager(options).Delete(id, rollback);
        }
    }
}
