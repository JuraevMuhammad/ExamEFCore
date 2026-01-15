using Domain.Dto.Book;
using Domain.Dto.BorrowRecord;
using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interface;

public interface IBorrowService
{
    public Response<string> IssueBookToStudent(IssueBorrow dto);
    public Response<string> ReturnBookFromStudent(ReturnBorrow dto);
    public Response<string> UpdateBorrowRecord(int id, UpdateBorrowRecordDto dto);
    public Response<string> DeleteBorrowRecord(int id);
    public Response<GetBorrowRecordDto> GetBorrowRecord(int id);
    public Response<List<GetBorrowRecordDto>> GetAllBorrowsWithBooks();
    public Response<List<GetBorrowRecordDto>> GetAllBorrowsWithStudents();
}