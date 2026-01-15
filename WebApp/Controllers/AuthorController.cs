using Domain.Dto.Author;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateAuthor(CreatedAuthorDto dto)
    {
        var res = service.CreatedAuthor(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateAuthor(int id, UpdateAuthorDto dto)
    {
        var res = service.UpdateAuthor(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteAuthor(int id)
    {
        var res = service.DeleteAuthor(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetAuthor(int id)
    {
        var res = service.GetAuthor(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        var res = service.GetAuthors();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("with-books")]
    public IActionResult GetAuthorsWithBooks()
    {
        var res = service.GetAuthorsWithBooks();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("by-country")]
    public IActionResult GetAuthorsByCountry(string country)
    {
        var res = service.GetAuthorsByCountry(country);
        return StatusCode(res.StatusCode, res);
    }
}