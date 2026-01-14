namespace Domain.Dto.LibraryCard;

public class UpdateLibraryCardDto
{
    public string? CardNumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public int? StudentId { get; set; }
}