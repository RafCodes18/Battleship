using HiddenBattleship.BL.Models;
using HiddenBattleship.MVC.UI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HiddenBattleship.MVC.UI.Controllers
{
    public class GameController : Controller
    {
        private readonly IHubContext<GameHub> _hubContext;

        public GameController(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }

        //TODO: Live action - Raf still WIP
        //GET: Game/Live/gameid
        public ActionResult Live(string gameId, Player player)
        {


            //get user from session

            Player _player = HttpContext.Session.GetObject<Player>("player");
            if (_player == null)
            {
                return RedirectToAction("CreateAccount", "Profile");
            }


            string hub = "../Hub/GameHub";

            var signalRConnection = new SignalRConnection(hub);

            //connect to the server
            // signalRConnection.Start();

            //run game logic 

            //send update to GameHub when moves and game state have been validated       
            return View(gameId);
        }

        //GET: Game/Computer
        public ActionResult Computer(string gameId)
        {
            return View(gameId);
        }

        // GET: GameController 
        public ActionResult Index()
        {
            return View();
        }

        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

}
