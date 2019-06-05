using System;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Possible.MessageWeb.Models.Messages;
using Possible.MessageWeb.Models.Identity;
using System.Data.Entity.SqlServer;

namespace Possible.MessageWeb.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private const int MaxMessagePerDay = 5;

        public MessagesController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        // GET: Messages
        public async Task<ActionResult> Index()
        {
            var messages = await _dbContext.Messages.Where(m => m.UserNameTo == User.Identity.Name).ToListAsync();

            return View(messages);
        }

        public async Task<ActionResult> New(string u)
        {
            var count = await _dbContext.Messages.CountAsync(m => SqlFunctions.DateDiff("day", DateTime.Now, m.CreationDate) == 0);

            return View(new NewMessageViewModel { UserNameTo = u, CurrentQuota = (double)count / MaxMessagePerDay * 100 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(NewMessageViewModel msg) 
        {
            if (ModelState.IsValid)
            {
                var count = await _dbContext.Messages.CountAsync(m => SqlFunctions.DateDiff("day", DateTime.Now, m.CreationDate) == 0);

                if (count <= MaxMessagePerDay)
                {
                    _dbContext.Messages.Add(new Message
                    {
                        Contents = msg.Contents,
                        CreationDate = DateTime.Now,
                        UsernameFrom = User.Identity.Name,
                        UserNameTo = msg.UserNameTo
                    });

                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Contents", $"You have reached your quota of {MaxMessagePerDay} per day.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(msg);
        }

        public async Task<ActionResult> Read(int id)
        {
            var model = await _dbContext.Messages.FirstOrDefaultAsync(m => m.MessageId == id);

            // mark message read
            model.Read = true;
            
            await _dbContext.SaveChangesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> MarkAsRead(int id, bool read = true)
        {
            var model = await _dbContext.Messages.FirstOrDefaultAsync(m => m.MessageId == id);

            model.Read = read;

            await _dbContext.SaveChangesAsync();

            return Json(new { success = true }, JsonRequestBehavior.DenyGet);
        }
    }
}