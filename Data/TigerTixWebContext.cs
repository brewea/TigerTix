using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TigerTix.Web.Areas.Account.Models;
using TigerTix.Web.Areas.Event.Models;
using TigerTix.Web.Areas.Ticket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TigerTix.Web.Data
{
    public class TigerTixWebContext : IdentityDbContext
    {
        public DbSet<UserModel> User { get; set; }

        public DbSet<EventModel> Event { get; set; }

        public DbSet<TicketModel> Ticket { get; set; }

        private readonly IConfiguration _config;

        public TigerTixWebContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }

        

    }
}
