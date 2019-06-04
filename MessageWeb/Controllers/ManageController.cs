using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using Possible.MessageWeb.Models.Identity;
using Possible.MessageWeb.Models.Manage;

namespace Possible.MessageWeb.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ManageController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index()
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            var model = new IndexViewModel
            {
                HideMeFromList = user?.HideMeFromList ?? false,
            };

            return View(model);
        }

        //
        // POST: /Manage/Index
        [HttpPost]
        public async Task<ActionResult> Index(IndexViewModel model)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            user.HideMeFromList = model.HideMeFromList;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}