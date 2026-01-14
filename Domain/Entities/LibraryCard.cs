using Domain.Dto.Student;

namespace Domain.Entities;

public class LibraryCard
{
    public int  Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public int StudentId { get; set; }
    
    public Student? Student { get; set; }
}