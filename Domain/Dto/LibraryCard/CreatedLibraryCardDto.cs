namespace Domain.Dto.LibraryCard;

public class CreatedLibraryCardDto
{
    public string CardNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public int StudentId { get; set; }
}