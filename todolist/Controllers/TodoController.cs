using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todolist.Class;
using todolist.Data;
using todolist.Models;

namespace todolist.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext db ;
        private readonly UserManager<ApplicationUser> userCtx;
        
        public TodoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.db = context;
            this.userCtx = userManager;
            

        }
        // GET: TodoController
        public ActionResult Index()
        {
           
            String ClientId = userCtx.GetUserId(HttpContext.User);
            return View(db.Todos.Where(t => t.ClientId == ClientId).ToList());
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int? id)
        {
            String ClientId = userCtx.GetUserId(HttpContext.User);
            Todos tache;
            if (id == null)
            {
                return NotFound();
            }
            tache = db.Todos.Find(id);
            if (tache == null)
            {
                return NotFound();
            }
            
            if (tache.ClientId == ClientId)
            {
                return View(tache);
            }
            else { return NotFound(); }
        }

        // GET: TodoController/Create
        public ActionResult Create()

        {
            var model = new Todos();
            return View(model);
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Task,Description,Status,Priority,Assignee,Comments,Created,CompleteBy")] Todos todo)
        {
            String ClientId = userCtx.GetUserId(HttpContext.User);
            if (ClientId == null)
            {
                return NotFound("L'utilisateur n'es pas authentifie .");
            }
            todo.ClientId = ClientId;
            if (ModelState.IsValid)
            {
                
                
               
                db.Add(todo);
                db.SaveChanges();
                TempData["Success"] = "La tâche a été bien crée.";
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
            
        }

        // GET: TodoController/Edit/5
        public ActionResult Edit(int? id)
        {
            String ClientId = userCtx.GetUserId(HttpContext.User);
            if (ClientId == null)
            {
                return NotFound(); }
            
            Todos tache;
            if (id == null)
            {
                return NotFound();
            }
            tache = db.Todos.Find(id);
            if (tache == null)
            {
                return NotFound();
            }
            if (tache.ClientId == ClientId)
            {
                return View(tache);
            }
            else { return NotFound(""); }
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Task,Description,Status,Priority,Assignee,Comments,Created,CompleteBy")] Todos todo)
        {
            String ClientId = userCtx.GetUserId(HttpContext.User);
            todo.ClientId = ClientId;
            if (ModelState.IsValid)
            {
                 
                if (ClientId == null)
                {
                    return NotFound();
                }
               
                db.Update(todo);
                db.SaveChanges();
                TempData["Success"] = "La tâche a été bien modifiée.";
                return RedirectToAction(nameof(Index));
            }
          
                return View(todo);
            
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int? id)
        {
            String ClientId = userCtx.GetUserId(HttpContext.User);
            Todos tache;
            if (id == null)
            {
                return NotFound();
            }
            tache = db.Todos.Find(id);
            if (tache == null)
            {
                return NotFound();
            }
            if (tache.ClientId == ClientId)
            {
                return View(tache);
            }
            else { return NotFound(); }
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var todo =  db.Todos.Find(id);
            if(todo == null)
            {
                return View(todo);
            }
            db.Todos.Remove(todo);
                db.SaveChanges();
                TempData["Success"] = "La tâche a été bien supprimée.";
                return RedirectToAction(nameof(Index));
         
            
        }
        [HttpPost]
        public JsonResult check([FromBody] tache a)
        {
            Dictionary<String, Boolean> response = new Dictionary<String, Boolean>();
           
                var todo = db.Todos.Find(a.Id);
                

               
                    todo.Status = "Done";
                    db.Todos.Update(todo);
                    db.SaveChanges();
                    response.Add("success", true);
                    response.Add("Done", false);
                


                return Json(response);
            }


        } 
        
       
    }

