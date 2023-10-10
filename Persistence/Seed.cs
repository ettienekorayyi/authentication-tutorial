using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(this StudentDbContext context)
        {
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