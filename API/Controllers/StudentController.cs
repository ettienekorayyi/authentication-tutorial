using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            if (!students.Any()) return NotFound();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var students = await _context.Students.FindAsync(id);
            if (students == null) return NotFound();

            return Ok(students);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException();

            _context.Add(student);
            _context.SaveChanges();
            
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var students = await _context.Students.FindAsync(student.StudentId);
            if (students == null) return NotFound();

            
            return Ok(students);
        }

    }
}