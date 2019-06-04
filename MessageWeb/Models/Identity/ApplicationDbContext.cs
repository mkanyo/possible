using Microsoft.AspNet.Identity.EntityFramework;
using Possible.MessageWeb.Models.Messages;
using System.Data.Entity;

namespace Possible.MessageWeb.Models.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Gets the db set to query / update the messages in the DB.
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}