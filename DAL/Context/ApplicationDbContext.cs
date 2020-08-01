using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using loppinja.Models.Domains;
using loppinja.Common.Models.Domains;

namespace loppinja.Models.Context
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } 
        public virtual DbSet<Comment> Comments { get; set; } 
        
    }
}