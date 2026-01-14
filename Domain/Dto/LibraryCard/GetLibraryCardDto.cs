using Domain.Dto.Student;

namespace Domain.Dto.LibraryCard;

public class GetLibraryCardDto
{
    public int  Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    
    public GetStudentDto? Student { get; set; }
}