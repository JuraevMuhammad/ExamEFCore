using Domain.Dto.Author;
using Domain.Dto.BorrowRecord;
using Domain.Responses;

namespace Infrastructure.Interface;

public interface IAuthorService
{
    public Response<string> CreatedAuthor(CreatedAuthorDto dto);
    public Response<string> UpdateAuthor(int id, UpdateAuthorDto dto);
    public Response<string> DeleteAuthor(int id);
    public Response<GetAuthorDto> GetAuthor(int id);
    public Response<List<GetAuthorDto>> GetAuthors();
    public Response<List<GetAuthorDto>> GetAuthorsWithBooks();
    public Response<List<GetAuthorDto>> GetAuthorsByCountry(string search);
    public Response<List<GetAuthorDto>> GetAuthorsBornAfterYear(int year);
}