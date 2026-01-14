namespace Domain.Dto.Student;

public class CreatedStudentDto
{
    public string FullName { get; set; } = string.Empty;
    public int Course { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
}