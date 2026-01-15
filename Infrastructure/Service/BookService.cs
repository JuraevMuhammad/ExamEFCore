using System.Net;
using Domain.Dto.Author;
using Domain.Dto.Book;
using Domain.Dto.Genre;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Date;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class BookService(ApplicationDbContext context) : IBookService
{
    #region AddBook
    public Response<string> AddBook(CreatedBookDto book)
    {
        var newBook = new Book()
        {
            AuthorId = book.AuthorId,
            Title = book.Title,
            Description = book.Description,
            GenreId = book.GenreId,
            Quantity = book.Quantity,
            PublishedYear = book.PublishedYear
        };
        context.Books.Add(newBook);
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, "CreatedBook")
            : new  Response<string>(HttpStatusCode.InternalServerError, "Error");
    }
    
    #endregion

    #region UpdateBook
    public Response<string> UpdateBook(int id, UpdateBookDto book)
    {
        var res = context.Books.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Book not found");
        res.Title = book.Title ?? res.Title;
        res.Description = book.Description;
        res.GenreId = book.GenreId ??  res.GenreId;
        res.Quantity = book.Quantity ?? res.Quantity;
        res.AuthorId = book.AuthorId ?? res.AuthorId;
        res.PublishedYear = book.PublishedYear ?? res.PublishedYear;
        var result = context.SaveChanges();
        return result > 0 
            ? new Response<string>(HttpStatusCode.OK, "UpdatedBook")
            : new  Response<string>(HttpStatusCode.InternalServerError, "Error");
    }
    #endregion
    
    #region DeleteBook
    public Response<string> DeleteBook(int id)
    {
        var res = context.Books.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Book not found");
        context.Books.Remove(res);
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.OK, "DeletedBook")
            : new  Response<string>(HttpStatusCode.InternalServerError, "Error");
    }
    #endregion

    #region GetBook
    public Response<GetBookDto> GetBook(int id)
    {
        var res = context.Books.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<GetBookDto>(HttpStatusCode.NotFound, "Book not found");
        var getBook = new GetBookDto()
        {
            Id = res.Id,
            Title = res.Title,
            Description = res.Description,
            PublishedYear = res.PublishedYear,
            Quantity = res.Quantity
        };
        return new Response<GetBookDto>(getBook);
    }
    #endregion

    #region GetBooksWithAuthors
    public Response<List<GetBookDto>> GetBooksWithAuthors()
    {
        var res = context.Books.Include(x => x.Author).Select(x => new GetBookDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PublishedYear = x.PublishedYear,
                Quantity = x.Quantity,
                Author = x.Author == null
                ? null
                : new GetAuthorDto()
                {
                    Id = x.Author.Id,
                    FullName = x.Author.FullName,
                    BirthDate = x.Author.BirthDate,
                    Country = x.Author.Country,
                }
            }
        ).ToList();
        return new Response<List<GetBookDto>>(res);
    }
    #endregion

    #region GetBooksWithGenre
    public Response<List<GetBookDto>> GetBooksWithGenre()
    {
        var res = context.Books.Include(x => x.Genre).Select(x => new GetBookDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PublishedYear = x.PublishedYear,
                Quantity = x.Quantity,
                Genre = x.Genre == null 
                    ? null
                    : new GetGenreDto()
                    {
                        Id = x.Genre.Id,
                        Name = x.Genre.Name,
                    }
            }
        ).ToList();
        return new Response<List<GetBookDto>>(res);
    }
    #endregion
    
    #region GetBooksWithGenreId
    public Response<List<GetBookDto>> GetBooksWithGenreId(int id)
    {
        var res = context.Books.Include(x => x.Genre).Select(x => new GetBookDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PublishedYear = x.PublishedYear,
                Quantity = x.Quantity,
                Genre = x.Genre == null
                    ? null
                    : new GetGenreDto()
                    {
                        Id = x.Genre.Id,
                        Name = x.Genre.Name,
                    }
            }
        ).Where(x => x.Genre!.Id == id).ToList();
        return new Response<List<GetBookDto>>(res);
    }
    #endregion
    
    #region GetBooksPublishedInYear
    public Response<List<GetBookDto>> GetBooksPublishedInYear(int year)
    {
        var res = context.Books.Select(x => new GetBookDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PublishedYear = x.PublishedYear,
                Quantity = x.Quantity,
            }
        ).Where(x => x.PublishedYear == year).ToList();
        return new Response<List<GetBookDto>>(res);
    }
    #endregion
}