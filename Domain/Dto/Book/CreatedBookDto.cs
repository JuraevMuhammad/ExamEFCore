namespace Domain.Dto.Book;

public class CreatedBookDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int PublishedYear { get; set; }
    public int Quantity { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
}