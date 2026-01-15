using Domain.Dto.Book;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService service) : ControllerBase
{
    [HttpPost]
    public IActionResult AddBook(CreatedBookDto book)
    {
        var res = service.AddBook(book);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateBook(int id, UpdateBookDto book)
    {
        var res = service.UpdateBook(id, book);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteBook(int id)
    {
        var res = service.DeleteBook(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetBook(int id)
    {
        var res = service.GetBook(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("with-authors")]
    public IActionResult GetBooksWithAuthors()
    {
        var res = service.GetBooksWithAuthors();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("with-genre")]
    public IActionResult GetBooksWithGenre()
    {
        var res = service.GetBooksWithGenre();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("genre-id")]
    public IActionResult GetBooksWithGenreId(int id)
    {
        var res = service.GetBooksWithGenreId(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("author-id")]
    public IActionResult GetBooksPublishedInYear(int year)
    {
        var res = service.GetBooksPublishedInYear(year);
        return StatusCode(res.StatusCode, res);
    }
}