using Domain.Dto.Book;

namespace Domain.Dto.Genre;

public class GetGenreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<GetBookDto>? Books { get; set; }
}