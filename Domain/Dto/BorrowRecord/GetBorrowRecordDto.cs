using Domain.Dto.Book;
using Domain.Dto.Student;

namespace Domain.Dto.BorrowRecord;

public class GetBorrowRecordDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public GetBookDto? Book { get; set; }
    public GetStudentDto? Student { get; set; }
}