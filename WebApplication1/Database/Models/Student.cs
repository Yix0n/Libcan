namespace WebApplication1.Database.Models;

public class Student
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Grades>? grades { get; set; }
}