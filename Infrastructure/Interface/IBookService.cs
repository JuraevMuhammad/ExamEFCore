using Domain.Dto.Book;
using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interface;

public interface IBookService
{
    public Response<string> AddBook(CreatedBookDto book);
    public Response<string> UpdateBook(int id, UpdateBookDto book);
    public Response<string> DeleteBook(int id);
    public Response<GetBookDto> GetBook(int id);
    public Response<List<GetBookDto>> GetBooksWithAuthors();
    public Response<List<GetBookDto>> GetBooksWithGenre();
    public Response<List<GetBookDto>> GetBooksWithGenreId(int id);
    public Response<List<GetBookDto>> GetBooksPublishedInYear(int year);
}
