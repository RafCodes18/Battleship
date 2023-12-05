using DocumentFormat.OpenXml.Spreadsheet;
using HiddenBattleship.BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HiddenBattleship.BL;

namespace HiddenBattleship.MVC.UI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public void SetUser(Player player)
        {
            if (player != null)
            {
                HttpContext.Session.SetObject("player", player);              
            }
            else
            {
                HttpContext.Session.SetObject("username", string.Empty);

            }
        }

        // GET: ProfileController
        public ActionResult Index()
        {
            if(HttpContext.Session.GetObject<Player>("player") != null)
            {
                return View();
            }
            return View();
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
                if (HttpContext != null) SetUser(player);

                if (TempData?["returnUrl"] != null)
                    return Redirect(TempData["returnUrl"]?.ToString());
                else
                    return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(player);
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
