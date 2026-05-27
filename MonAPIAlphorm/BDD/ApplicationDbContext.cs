using Microsoft.EntityFrameworkCore;
using MonAPIAlphorm.Entities;

namespace MonAPIAlphorm.BDD
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<ProspectEntity> Propects { get; set; }
        public DbSet<EmailTemplateEntity> EmailTemplates { get; set; }
    }
}
