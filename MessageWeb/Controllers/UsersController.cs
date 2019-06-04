using Possible.MessageWeb.Models.Identity;
using System.Web.Mvc;
using System.Linq;

namespace Possible.MessageWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public UsersController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        // GET: Users
        public ActionResult Index()
        {
            // get all users except my user
            var model = _dbContext.Users.Where(u => u.UserName != User.Identity.Name).ToList();

            return View(model);
        }
    }
}
