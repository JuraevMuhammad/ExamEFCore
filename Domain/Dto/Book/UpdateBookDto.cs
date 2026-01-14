namespace Domain.Dto.Book;

public class UpdateBookDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? PublishedYear { get; set; }
    public int? Quantity { get; set; }
    public int? AuthorId { get; set; }
    public int? GenreId { get; set; }
}