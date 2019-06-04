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
            // get all users except my user
            var model = await _dbContext.Users.Where(u => u.UserName != User.Identity.Name).ToListAsync();

            return View(model);
        }
    }
}
