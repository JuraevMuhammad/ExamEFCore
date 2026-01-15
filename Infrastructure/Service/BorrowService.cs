using System.Net;
using Domain.Dto.Book;
using Domain.Dto.BorrowRecord;
using Domain.Dto.Student;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Date;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class BorrowService(ApplicationDbContext context) : IBorrowService
{
    public Response<string> IssueBookToStudent(IssueBorrow dto)
    {
        var book = context.Books.FirstOrDefault(x => x.Id == dto.BookId);
        if (book!.Quantity != 0)
        {
            book.Quantity -= 1;
        }
        else
        {
            return new Response<string>(HttpStatusCode.NotFound, $"0 Book-{dto.BookId}");
        }
        
        var res = new BorrowRecord()
        {
            StudentId = dto.StudentId,
            BookId = dto.BookId,
            BorrowDate = dto.BorrowDate
        };
        
        context.BorrowRecords.Add(res);
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.Created, "Issue Borrow")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<string> ReturnBookFromStudent(ReturnBorrow dto)
    {
        var res = context.BorrowRecords.FirstOrDefault(x => x.StudentId == dto.StudentId &&
                                                            x.BookId == dto.BookId && x.ReturnDate == null);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Error");
        
        var book = context.Books.FirstOrDefault(x => x.Id == dto.BookId);
        book!.Quantity = book.Quantity + 1;
        
        res.ReturnDate = dto.ReturnDate;
        
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.Created, "Return Borrow")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<string> UpdateBorrowRecord(int id, UpdateBorrowRecordDto dto)
    {
        var res = context.BorrowRecords.FirstOrDefault(x => x.Id == id && x.ReturnDate == null);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Error");
        res.BorrowDate = dto.BorrowDate ?? res.BorrowDate;
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.Created, "Return Borrow")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<string> DeleteBorrowRecord(int id)
    {
        var res = context.BorrowRecords.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Error");
        context.BorrowRecords.Remove(res);
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.OK, "Return Borrow")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<GetBorrowRecordDto> GetBorrowRecord(int id)
    {
        var res = context.BorrowRecords.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<GetBorrowRecordDto>(HttpStatusCode.NotFound, "Error");
        var get = new GetBorrowRecordDto()
        {
            Id = res.Id,
            StudentId = res.StudentId,
            BookId = res.BookId,
            BorrowDate = res.BorrowDate,
            ReturnDate = res.ReturnDate,
        };
        return new Response<GetBorrowRecordDto>(get);
    }

    public Response<List<GetBorrowRecordDto>> GetAllBorrowsWithBooks()
    {
        var res = context.BorrowRecords.Include(x => x.Book).Select(x => new GetBorrowRecordDto()
            {
                Id = x.Id,
                StudentId = x.StudentId,
                BookId = x.BookId,
                BorrowDate = x.BorrowDate,
                ReturnDate = x.ReturnDate,
                Book = x.Book == null
                ? null
                : new GetBookDto()
                {
                    Id = x.Book.Id,
                    Title = x.Book.Title,
                    Description = x.Book.Description,
                    Quantity = x.Book.Quantity,
                    PublishedYear = x.Book.PublishedYear,
                }
            }
        ).ToList();
        return new Response<List<GetBorrowRecordDto>>(res);
    }

    public Response<List<GetBorrowRecordDto>> GetAllBorrowsWithStudents()
    {
        var res = context.BorrowRecords.Include(x => x.Student).Select(x => new GetBorrowRecordDto()
            {
                Id = x.Id,
                StudentId = x.StudentId,
                BookId = x.BookId,
                BorrowDate = x.BorrowDate,
                ReturnDate = x.ReturnDate,
                Student = x.Student == null
                    ? null
                    : new GetStudentDto()
                    {
                        Id = x.Student.Id,
                        FullName = x.Student.FullName,
                        Course = x.Student.Course,
                        PhoneNumber = x.Student.PhoneNumber,
                    }
            }
        ).ToList();
        return new Response<List<GetBorrowRecordDto>>(res);
    }
}