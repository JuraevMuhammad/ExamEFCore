namespace Domain.Dto.BorrowRecord;

public class CreatedBorrowRecordDto
{
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}