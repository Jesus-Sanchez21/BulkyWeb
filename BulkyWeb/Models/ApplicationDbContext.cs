using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Models
{
    public class ApplicationDbContext : DbContext //Root class of entity framework
    {
        public ApplicationDbContext (DbContextOptions <ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet <Category> Categories { get; set; }
    }
}
