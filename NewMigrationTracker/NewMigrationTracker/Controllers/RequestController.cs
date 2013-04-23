using NewMigrationTracker.DataAccess;
using NewMigrationTracker.DataAccess.Repositories;
using NewMigrationTracker.Entities;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace NewMigrationTracker.Controllers
{
    public class RequestController : SecureMigrationTrackerController<Request>
    {
        public RequestController(IRepository<Request> repository)
            : base(repository)
        {

        }




        //
        // GET: /Request/

        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Status).Include(r => r.User).Include(r => r.Release);
            return View(requests.ToList());
        }

        //
        // GET: /Request/Details/5

        public ActionResult Details(int id = 0)
        {
            Request request = repository.GetById(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // GET: /Request/Create

        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            ViewBag.ReleaseID = new SelectList(db.Releases, "ReleaseID", "ReleaseName");
            return View();
        }

        //
        // POST: /Request/Create

        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", request.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", request.UserID);
            ViewBag.ReleaseID = new SelectList(db.Releases, "ReleaseID", "ReleaseName", request.ReleaseID);
            return View(request);
        }

        //
        // GET: /Request/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Request request = repository.GetById(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", request.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", request.UserID);
            ViewBag.ReleaseID = new SelectList(db.Releases, "ReleaseID", "ReleaseName", request.ReleaseID);
            return View(request);
        }

        //
        // POST: /Request/Edit/5

        [HttpPost]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", request.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", request.UserID);
            ViewBag.ReleaseID = new SelectList(db.Releases, "ReleaseID", "ReleaseName", request.ReleaseID);
            return View(request);
        }

        //
        // GET: /Request/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Request request = repository.GetById(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Request/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = repository.GetById(id);
            repository.Delete(request);
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