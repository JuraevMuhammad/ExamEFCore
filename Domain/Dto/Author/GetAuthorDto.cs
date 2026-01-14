using Domain.Dto.Book;

namespace Domain.Dto.Author;

public class GetAuthorDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    
    public List<GetBookDto>? Books { get; set; }
}