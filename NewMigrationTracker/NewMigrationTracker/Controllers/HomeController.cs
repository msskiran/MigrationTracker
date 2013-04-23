using NewMigrationTracker.Entities;
using NewMigrationTracker_Services.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace NewMigrationTracker.Controllers
{
    public class HomeController : Controller
    {
        private IService<User> userService { get; set; }

        //   [Inject]
        public HomeController(IService<User> userService)
        {
            this.userService = userService;
        }

        //public HomeController()
        //{

        //}

        public ActionResult Index()
        {
            var currentuser = System.Web.HttpContext.Current.User.Identity;

            string userDomain = System.Environment.UserDomainName;
            string userName = System.Environment.UserName;

            User currentUser = userService.GetMany(user => (user.UserName == userName) && (user.UserDomain == userDomain)).Single();

            if (currentUser == null)
            {
                userService.Add(new User { UserName = userName, UserDomain = userDomain });
            }
            else
            {
                ViewBag.Message = "Welcome" + userName;
            }


            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
