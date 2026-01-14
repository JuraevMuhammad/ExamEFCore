using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public T? Data { get; set; }
    public string Massege { get; set; }   
    public int StatusCode { get; set; }

    public Response(T? data)
    {
        Data = data;
        Massege = "Success";
        StatusCode = 200;
    }

    public Response(HttpStatusCode code, string massege)
    {
        Data = default;
        Massege = massege;
        StatusCode = (int)code;
    }
}