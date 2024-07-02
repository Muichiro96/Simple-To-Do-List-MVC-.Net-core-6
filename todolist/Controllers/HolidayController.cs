using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using todolist.Class;
using todolist.Migrations;
using System.Diagnostics;
using System.Text.Json;
namespace todolist.Controllers


{
    
    public class Holidays : Controller
    {
        public Feries _feries;
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        // GET: Holidays
        public Holidays()
        {
        
        }
        public async Task< ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri("https://holidayapi.com/v1/holidays?country=MA&year=2023&pretty=true&key=2d1f641f-fff7-417e-b4ba-8f1fae08cb3b"));
           
                var jsonString = await response.Content.ReadAsStringAsync();
                _feries = JsonSerializer.Deserialize<Feries>(jsonString,options);
            Debug.WriteLine(_feries);
                return View(_feries);

         
           
        }

        // GET: Holidays/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Holidays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Holidays/Create
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

        // GET: Holidays/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Holidays/Edit/5
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

        // GET: Holidays/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Holidays/Delete/5
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
