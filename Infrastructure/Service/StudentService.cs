using System.Net;
using Domain.Dto.LibraryCard;
using Domain.Dto.Student;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Date;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class StudentService(ApplicationDbContext context) : IStudentService
{
    #region CreatedStudent
    public Response<string> RegisterStudent(CreatedStudentDto dto)
    {
        var res = new Student()
        {
            FullName = dto.FullName,
            Course = dto.Course,
            PhoneNumber = dto.PhoneNumber
        };
        context.Students.Add(res);
        var result = context.SaveChanges();
        return result > 0
                ? new Response<string>(HttpStatusCode.Created, "Created Student")
                : new Response<string>(HttpStatusCode.InternalServerError, "Error");
    }
    #endregion

    #region UpdateStudent
    public Response<string> UpdateStudent(int id, UpdateStudentDto dto)
    {
        var res = context.Students.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Student not found");
        res.FullName = dto.FullName ?? res.FullName;
        res.Course = dto.Course ?? res.Course;
        res.PhoneNumber = dto.PhoneNumber ?? res.PhoneNumber;
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.NoContent, "Student Updated")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }
    #endregion

    #region DeleteStudent
    public Response<string> DeleteStudent(int id)
    {
        var res = context.Students.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Student not found");
        context.Students.Remove(res);
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.NoContent, "Student Deleted")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }
    #endregion

    #region GetStudentById
    public Response<GetStudentDto> GetStudentById(int id)
    {
        var res = context.Students.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<GetStudentDto>(HttpStatusCode.NotFound, "Student not found");
        var getStudent = new GetStudentDto()
        {
            Id = res.Id,
            FullName = res.FullName,
            Course = res.Course,
            PhoneNumber = res.PhoneNumber
        };
        return new Response<GetStudentDto>(getStudent);
    }
    #endregion

    #region GetAllStudentWithCard
    public Response<List<GetStudentDto>> GetAllStudentWithCard(int cardId)
    {
        var res = context.Students.Include(x => x.LibraryCard).Select(x => new GetStudentDto()
            {
                FullName = x.FullName,
                Course = x.Course,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                LibraryCard = x.LibraryCard == null
                ? null
                : new GetLibraryCardDto()
                {
                    Id = x.LibraryCard.Id,
                    CardNumber = x.LibraryCard.CardNumber,
                    IssueDate = x.LibraryCard.IssueDate,
                }
            }
        ).Where(x => x.LibraryCard!.Id == cardId).ToList();
        return new Response<List<GetStudentDto>>(res);
    }
    #endregion

    #region GetAllStudentsWithCards
    public Response<List<GetStudentDto>> GetAllStudentsWithCards()
    {
        var res = context.Students.Include(x => x.LibraryCard).Select(x => new GetStudentDto()
            {
                FullName = x.FullName,
                Course = x.Course,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                LibraryCard = x.LibraryCard == null
                    ? null
                    : new GetLibraryCardDto()
                    {
                        Id = x.LibraryCard.Id,
                        CardNumber = x.LibraryCard.CardNumber,
                        IssueDate = x.LibraryCard.IssueDate,
                    }
            }
        ).ToList();
        return new Response<List<GetStudentDto>>(res);
    }
    #endregion

    #region GetStudentsByCourse
    public Response<List<GetStudentDto>> GetStudentsByCourse(int courseId)
    {
        var res = context.Students.Select(x => new GetStudentDto()
        {
            Id = x.Id,
            FullName = x.FullName,
            Course = x.Course,
            PhoneNumber = x.PhoneNumber,
        }).Where(x => x.Course == courseId).ToList();
        return new Response<List<GetStudentDto>>(res);
    }
    #endregion

    #region GetStudentByCardNumber
    public Response<GetStudentDto> GetStudentByCardNumber(string cardNumber)
    {
        var res = context.Students.Include(x => x.LibraryCard)
            .Select(x => new GetStudentDto()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Course = x.Course,
                    PhoneNumber = x.PhoneNumber,
                    LibraryCard = x.LibraryCard == null
                        ? null
                        : new GetLibraryCardDto()
                        {
                            Id = x.LibraryCard.Id,
                            CardNumber = x.LibraryCard.CardNumber,
                            IssueDate = x.LibraryCard.IssueDate,
                        }
                }
            ).FirstOrDefault(x => x.LibraryCard!.CardNumber == cardNumber);
        return new Response<GetStudentDto>(res);
    }
    #endregion
}