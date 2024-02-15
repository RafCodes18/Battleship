using HiddenBattleship.BL;
using HiddenBattleship.BL.Models;
using HiddenBattleship.MVC.UI.ViewModels;
using HiddenBattleship.PL;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HiddenBattleship.MVC.UI.Controllers
{

    public class ProfileController : Controller
    {

        public void SetUser(Player player)
        {
            if (player != null)
            {
                HttpContext.Session.SetObject("player", player);
                HttpContext.Session.SetString("username", player.UserName);
            }
            else
            {
                HttpContext.Session.SetObject("username", string.Empty);

            }
        }

        // GET: ProfileController
        public ActionResult Index()
        {
            ProfileVM profileVM = new ProfileVM();
            profileVM.player = HttpContext.Session.GetObject<Player>("player");

            if (profileVM.player == null)
            {
                return RedirectToAction("CreateAccount", "Profile", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

            return View(profileVM);
        }

        //GET
        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Login(Player player)
        {
            try
            {
                bool result = PlayerManager.Login(player);
                if (HttpContext != null && result == true) SetUser(player);

                if (TempData?["returnUrl"] != null)
                    return Redirect(TempData["returnUrl"]?.ToString());
                else

                    return RedirectToAction("Live", "Game");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(player);
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.SetObject("player", null);
            HttpContext.Session.SetObject("username", null);
            return RedirectToAction(nameof(Index), "Home");
        }

        //GET: Profile/CreateAccount
        public ActionResult CreateAccount(string returnURL)
        {
            TempData["returnUrl"] = returnURL;
            return View();
        }

        [HttpPost]
        //POST: Profile/CreateAccount
        public ActionResult CreateAccount(Player player)
        {
            try
            {
                //TODO: Turbo jank that works for inserting - Update w/ API 
                DbContextOptions<HiddenBattleshipEntities> options = new DbContextOptions<HiddenBattleshipEntities>();
                PlayerManager playerManager = new PlayerManager(options);
                int result = playerManager.Insert(player, false);

                //int result = PlayerManager.Insert(player, false);
                if (result > 0)
                {
                    Login(player);
                    return Redirect(TempData["returnUrl"].ToString());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
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

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
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

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
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
