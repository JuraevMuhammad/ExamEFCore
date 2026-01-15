namespace Domain.Dto.BorrowRecord;

public class IssueBorrow
{
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
}