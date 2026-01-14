namespace Domain.Dto.Author;

public class CreatedAuthor
{
    public string FullName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}