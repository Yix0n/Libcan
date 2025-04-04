namespace WebApplication1.Database.Models;

public class Grades
{
    public ulong Id { get; set; }
    public string Title { get; set; }
    public float Grade { get; set; }
    public Student Student { get; set; }
    public ulong StudentId { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}