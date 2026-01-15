using Domain.Dto.BorrowRecord;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BorrowController(IBorrowService service) : ControllerBase
{
    [HttpPost]
    public IActionResult IssueBookToStudent(IssueBorrow dto)
    {
        var res = service.IssueBookToStudent(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPost]
    public IActionResult ReturnBookFromStudent(ReturnBorrow dto)
    {
        var res = service.ReturnBookFromStudent(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateBorrowRecord(int id, UpdateBorrowRecordDto dto)
    {
        var res = service.UpdateBorrowRecord(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteBorrowRecord(int id)
    {
        var res = service.DeleteBorrowRecord(id);
        return  StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetBorrowRecord(int id)
    {
        var res = service.GetBorrowRecord(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("with-books")]
    public IActionResult GetAllBorrowsWithBooks()
    {
        var res = service.GetAllBorrowsWithBooks();
        return StatusCode(res.StatusCode, res);
    }
    
    [HttpGet("with-students")]
    public IActionResult GetAllBorrowsWithStudents()
    {
        var res = service.GetAllBorrowsWithStudents();
        return StatusCode(res.StatusCode, res);
    }
}