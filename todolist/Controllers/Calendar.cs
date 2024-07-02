using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using todolist.Data;
using todolist.Models;

namespace todolist.Controllers
{
    public class Calendar : Controller
    {
        // GET: Calendar
        private Random rnd = new Random();
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userCtx;
        public Calendar(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.db = context;
            this.userCtx = userManager;

        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                ViewBag.color = randomColor;
                String ClientId = userCtx.GetUserId(HttpContext.User);
                return View(db.Todos.Where(t => t.ClientId == ClientId).ToList());
            }
            return View();
        }

        // GET: Calendar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calendar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calendar/Create
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

        // GET: Calendar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calendar/Edit/5
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

        // GET: Calendar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calendar/Delete/5
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
