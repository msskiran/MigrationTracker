using NewMigrationTracker.Entities;
using NewMigrationTracker_Services.Interfaces;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NewMigrationTracker.Controllers
{
    public class UsersController : SecureMigrationTrackerController<User>
    {
        private readonly IService<User> userService;

        public UsersController(IService<User> userService)
            : base(userService)
        {
            this.userService = userService;
        }

        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View(userService.GetAll().ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(string id = null)
        {
            User user = userService.GetById(Convert.ToInt32(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userService.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(string id = null)
        {
            User user = userService.GetById(Convert.ToInt32(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(user).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            userService.Update(user);
            return RedirectToAction("Index");
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(string id = null)
        {
            User user = userService.GetById(Convert.ToInt32(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = userService.GetById(Convert.ToInt32(id));
            userService.Delete(user);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    // userService.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}