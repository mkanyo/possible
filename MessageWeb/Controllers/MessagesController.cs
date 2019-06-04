using Possible.MessageWeb.Models.Identity;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using Possible.MessageWeb.Models.Messages;
using System.Threading.Tasks;
using System;

namespace Possible.MessageWeb.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
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

        public ActionResult New(string u)
        {
            return View(new NewMessageViewModel { UserNameTo = u });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(NewMessageViewModel msg) 
        {
            if (ModelState.IsValid)
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

        public async Task<JsonResult> MarkAsRead(int id, bool read = true)
        {
            var model = await _dbContext.Messages.FirstOrDefaultAsync(m => m.MessageId == id);

            model.Read = read;

            await _dbContext.SaveChangesAsync();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}