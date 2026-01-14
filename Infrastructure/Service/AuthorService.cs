using System.Net;
using Domain.Dto.Author;
using Domain.Dto.Book;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Date;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class AuthorService(ApplicationDbContext context) : IAuthorService
{
    #region CreatedAuthor
    public Response<string> CreatedAuthor(CreatedAuthorDto dto)
    {
        var newAuthor = new Author()
        {
            FullName = dto.FullName,
            BirthDate = dto.BirthDate,
            Country = dto.Country
        };
        context.Authors.Add(newAuthor);
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, "created Author")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }
    #endregion

    #region UpdateAuthor
    public Response<string> UpdateAuthor(int id, UpdateAuthorDto dto)
    {
        var res = context.Authors.FirstOrDefault(x => x.Id == id);
        if(res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Error");
        res.FullName = dto.FullName ?? res.FullName;
        res.BirthDate = dto.BirthDate ?? res.BirthDate;
        res.Country = dto.Country ?? res.Country;
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.OK, "updated Author")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }
    #endregion

    #region DeleteAuthor
    public Response<string> DeleteAuthor(int id)
    {
        var res = context.Authors.FirstOrDefault(x => x.Id == id);
        if(res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Error");
        context.Authors.Remove(res);
        var res2 = context.SaveChanges();
        return res2 > 0
            ? new Response<string>(HttpStatusCode.OK, "deleted Author")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }
    #endregion

    #region GetAuthor
    public Response<GetAuthorDto> GetAuthor(int id)
    {
        var author = context.Authors.FirstOrDefault(x => x.Id == id);
        if(author == null)
            return new Response<GetAuthorDto>(HttpStatusCode.NotFound, "Error");
        var getAuthor = new GetAuthorDto()
        {
            FullName = author.FullName,
            BirthDate = author.BirthDate,
            Country = author.Country,
            Id = author.Id
        };
        return new Response<GetAuthorDto>(getAuthor);
    }
    #endregion

    #region GetAuthors
    public Response<List<GetAuthorDto>> GetAuthors()
    {
        var allAuthors = context.Authors.Select(x => new GetAuthorDto()
            {
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                Country = x.Country,
                Id = x.Id
            }
        ).ToList();
        if (allAuthors.Count == 0)
            return new Response<List<GetAuthorDto>>(HttpStatusCode.NotFound, "0 Author");
        return new Response<List<GetAuthorDto>>(allAuthors);
    }
    #endregion

    #region GetAuthorWithBooks
    public Response<List<GetAuthorDto>> GetAuthorsWithBooks()
    {
        var res = context.Authors.Include(b => b.Books).Select(x => new GetAuthorDto()
            {
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                Country = x.Country,
                Id = x.Id,
                Books = x.Books!.Select(b => new GetBookDto()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Description = b.Description,
                        PublishedYear = b.PublishedYear,
                        Quantity = b.Quantity
                    }
                ).ToList()
            }
        ).ToList();
        return new Response<List<GetAuthorDto>>(res);
        if (res.Count == 0)
            return new Response<List<GetAuthorDto>>(HttpStatusCode.BadRequest, "0 Author");
    }
#endregion

    #region GetAuthorByCountry
    public Response<List<GetAuthorDto>> GetAuthorsByCountry(string search)
    {
        var res = context.Authors.Select(x => new GetAuthorDto()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    BirthDate = x.BirthDate,
                    Country = x.Country
                }
        ).Where(x => 
            x.Country.ToLower().Contains(search.ToLower())).ToList();
        
        return new Response<List<GetAuthorDto>>(res);
    }
    #endregion
}
