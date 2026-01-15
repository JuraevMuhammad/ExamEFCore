using Domain.Dto.Student;
using Domain.Responses;

namespace Infrastructure.Interface;

public interface IStudentService
{
    public Response<string> RegisterStudent(CreatedStudentDto dto);
    public Response<string> UpdateStudent(int id, UpdateStudentDto dto);
    public Response<string> DeleteStudent(int id);
    public Response<GetStudentDto> GetStudentById(int id);
    public Response<List<GetStudentDto>> GetAllStudentWithCard(int cardId);
    public Response<List<GetStudentDto>> GetAllStudentsWithCards();
    public Response<List<GetStudentDto>> GetStudentsByCourse(int courseId);
    public Response<GetStudentDto> GetStudentByCardNumber(string cardNumber);
}