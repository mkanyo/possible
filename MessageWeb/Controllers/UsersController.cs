using Possible.MessageWeb.Models.Identity;
using System.Web.Mvc;
using System.Linq;

namespace Possible.MessageWeb.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            // get all users except my user
            var model = ApplicationDbContext.Create().Users.Where(u => u.UserName != User.Identity.Name).ToList();

            return View(model);
        }
    }
}
