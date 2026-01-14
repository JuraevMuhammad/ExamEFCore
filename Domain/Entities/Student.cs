using Domain.Dto.BorrowRecord;

namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Course { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    
    public List<BorrowRecord>? BorrowRecords { get; set; }
}