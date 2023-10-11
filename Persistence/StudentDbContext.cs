using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class StudentDbContext : IdentityDbContext<AppUser>
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
                : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }

}