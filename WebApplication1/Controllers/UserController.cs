using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers.Frorm;
using WebApplication1.Database;
using WebApplication1.Database.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("create")]
    public ActionResult<StudentResponse> CreateUser([FromBody] Create_Student student)
    {
        using (var context = new Context())
        {
            var newStudent = new Student
            {
                Name = student.Name
            };
            context.students.Add(newStudent);
            context.SaveChanges();
            return CreatedAtAction(nameof(CreateUser), new StudentResponse{ Id = newStudent.Id, Name = newStudent.Name });
        }
    }
    [HttpGet("get")]
    public ActionResult<GetUser_Response> GetUser([FromQuery] ulong id)
    {
        using (var context = new Context())
        {
            var stds = context.students.Include(a => a.grades).ToList();
            var student = stds.FirstOrDefault(i => i.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            GetUser_Response response = new GetUser_Response
            {
                Id = student.Id,
                Name = student.Name,
                Grades = student.grades.Select(g => new GetGrade_Response
                {
                    Id = g.Id,
                    Title = g.Title,
                    Grade = g.Grade
                }).ToList()
            };
            
            return response;
        }
    }
}