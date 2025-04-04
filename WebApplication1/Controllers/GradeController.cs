using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Frorm;
using WebApplication1.Database;
using WebApplication1.Database.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    [HttpPost("create")]
    public ActionResult<Grades> CreateGrade([FromBody] Grade_Create grade)
    {
        using (var context = new Context())
        {
            var newGrade = new Grades
            {
                Title = grade.Title,
                Grade = grade.Grade,
                StudentId = grade.StudentId
            };
            context.grades.Add(newGrade);
            context.SaveChanges();
            return CreatedAtAction(nameof(CreateGrade), newGrade);
        }
    }
}