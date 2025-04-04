using WebApplication1.Database.Models;

namespace WebApplication1.Controllers.Frorm;

public class GetUser_Response
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<GetGrade_Response> Grades { get; set; } = new List<GetGrade_Response>();
}