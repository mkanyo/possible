using Possible.MessageWeb.Models.Identity;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index()
        {
            // get all users except current user and those marked themselves hidden.
            var model = await _dbContext.Users.Where(u => u.UserName != User.Identity.Name && !u.HideMeFromList).ToListAsync();

            return View(model);
        }
    }
}
