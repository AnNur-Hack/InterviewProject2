namespace InterviewProject2.DTOs.Responses;

public class ApiResponse
{
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public object? Data { get; set; }
}