namespace Domain.Dto.Author;

public class CreatedAuthorDto
{
    public string FullName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}