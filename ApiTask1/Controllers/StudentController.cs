using ApiTask1.Contexts;
using ApiTask1.DTOs.StudentDTOs;
using ApiTask1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        TaskOneDbContext _context;

        public StudentController (TaskOneDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create (StudentCreateDTO student) 
        {
            Student studentToCreate = new Student
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
            };
            await _context.Students.AddAsync(studentToCreate);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _context.Students.FindAsync(id);
            if (data == null) return NotFound();
            _context.Students.Remove(data);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(int? id, StudentCreateDTO student)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _context.Students.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = student.Name;
            data.Surname = student.Surname;
            data.Age = student.Age;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
