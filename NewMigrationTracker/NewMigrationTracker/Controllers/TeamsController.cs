using NewMigrationTracker.DataAccess.Repositories;
using NewMigrationTracker.Entities;
using System.Linq;
using System.Web.Mvc;

namespace NewMigrationTracker.Controllers
{
    public class TeamsController : SecureMigrationTrackerController<Team>
    {
        public TeamsController(IRepository<Team> repository)
            : base(repository)
        {

        }

        //
        // GET: /Teams/

        public ActionResult Index()
        {
            return View(repository.GetAll().ToList());
        }

        //
        // GET: /Teams/Details/5

        public ActionResult Details(int id = 0)
        {
            Team team = repository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        //
        // GET: /Teams/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teams/Create

        [HttpPost]
        public ActionResult Create(Team team)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Teams.Add(team);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                repository.Add(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }

        //
        // GET: /Teams/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Team team = repository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        //
        // POST: /Teams/Edit/5

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(team).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(team);
            repository.Update(team);
            return RedirectToAction("Index");
            return View(team);
        }

        //
        // GET: /Teams/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Team team = repository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        //
        // POST: /Teams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = repository.GetById(id);
            repository.Delete(team);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}