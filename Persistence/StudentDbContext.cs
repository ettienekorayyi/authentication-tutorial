using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
                : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }

}