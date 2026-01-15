using Domain.Dto.Book;
using Domain.Dto.Student;

namespace Domain.Entities;

public class BorrowRecord
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public Book? Book { get; set; }
    public Student? Student { get; set; }
}