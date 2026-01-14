using Domain.Dto.Book;

namespace Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    
    public List<Book>? Books { get; set; }
}