using Domain.Dto.Student;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService service) : ControllerBase 
{
    [HttpPost]
    public IActionResult CreatedStudent(CreatedStudentDto dto)
    {
        var res = service.RegisterStudent(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateStudent(int id, UpdateStudentDto dto)
    {
        var res = service.UpdateStudent(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteStudent(int id)
    {
        var res = service.DeleteStudent(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetStudent(int id)
    {
        var res = service.GetStudentById(id);
        return  StatusCode(res.StatusCode, res);
    }

    [HttpGet("with-card-id")]
    public IActionResult GetWithCardId(int id)
    {
        var res = service.GetAllStudentWithCard(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("without-cards")]
    public IActionResult GetWithoutCards()
    {
        var res = service.GetAllStudentsWithCards();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("With-course-id")]
    public IActionResult GetWithCourseId(int id)
    {
        var res = service.GetStudentsByCourse(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("with-card-number")]
    public IActionResult GetWithCardNumber(string cardNumber)
    {
        var res = service.GetStudentByCardNumber(cardNumber);
        return StatusCode(res.StatusCode, res);
    }
}