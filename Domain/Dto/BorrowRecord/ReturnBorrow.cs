namespace Domain.Dto.BorrowRecord;

public class ReturnBorrow
{
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;
}