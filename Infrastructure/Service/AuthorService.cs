using Domain.Dto.Author;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Date;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class AuthorService(ApplicationDbContext context) : IAuthorService
{
    public Response<string> CreatedAuthor(CreatedAuthorDto dto)
    {
        var newAuthor = new Author()
        {
            
        }
    }

    public Response<string> UpdateAuthor(int id, UpdateAuthorDto dto)
    {
        throw new NotImplementedException();
    }

    public Response<string> DeleteAuthor(int id)
    {
        throw new NotImplementedException();
    }

    public Response<GetAuthorDto> GetAuthor(int id)
    {
        throw new NotImplementedException();
    }

    public Response<List<GetAuthorDto>> GetAuthors()
    {
        throw new NotImplementedException();
    }

    public Response<List<GetAuthorDto>> GetAuthorsWithBooks()
    {
        throw new NotImplementedException();
    }

    public Response<List<GetAuthorDto>> GetAuthorsByCountry(string search)
    {
        throw new NotImplementedException();
    }

    public Response<List<GetAuthorDto>> GetAuthorsBornAfterYear(int year)
    {
        throw new NotImplementedException();
    }
}