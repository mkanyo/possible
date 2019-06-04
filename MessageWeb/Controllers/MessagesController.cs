﻿using Possible.MessageWeb.Models.Identity;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            var messages = _dbContext.Messages.Where(m => m.UserNameTo == User.Identity.Name).ToList();

            return View(messages);
        }

        public ActionResult New()
        {
            return View();
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


    }
}