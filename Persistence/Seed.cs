using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(this StudentDbContext context,
           UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

            }

            if (context.Students.Any()) return;

            var students = new List<Student>
            {
                new Student { 
                    StudentId = Guid.NewGuid(), 
                    FirstName = "Lazarus", 
                    MiddleName = "Migos", 
                    LastName = "Katada"
                },
                new Student { 
                    StudentId = Guid.NewGuid(), 
                    FirstName = "Argus", 
                    MiddleName = "", 
                    LastName = "Tenafrancia"
                },
                new Student { 
                    StudentId = Guid.NewGuid(), 
                    FirstName = "Wa", 
                    MiddleName = "Pei", 
                    LastName = "Ya"
                },
                new Student { 
                    StudentId = Guid.NewGuid(), 
                    FirstName = "Mhuka", 
                    MiddleName = "ng", 
                    LastName = "Tae-Yan"
                },
                new Student { 
                    StudentId = Guid.NewGuid(), 
                    FirstName = "Lala", 
                    MiddleName = "Mukang", 
                    LastName = "Bato"
                },
            };

            await context.AddRangeAsync(students);
            context.SaveChanges();
        }
    }
}