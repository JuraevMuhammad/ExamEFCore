using Domain.Dto.BorrowRecord;
using Domain.Dto.LibraryCard;

namespace Domain.Dto.Student;

public class GetStudentDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Course { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    
    public GetLibraryCardDto? LibraryCard { get; set; }
    public List<GetBorrowRecordDto>? BorrowRecords { get; set; }
}