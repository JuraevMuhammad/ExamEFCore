using Domain.Dto.Author;
using Domain.Dto.BorrowRecord;
using Domain.Dto.Genre;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int PublishedYear { get; set; }
    public int Quantity { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
    
    public GetGenreDto? Genre { get; set; }
    public GetAuthorDto? Author { get; set; }
    public List<GetBorrowRecordDto> ? BorrowRecords { get; set; }
}