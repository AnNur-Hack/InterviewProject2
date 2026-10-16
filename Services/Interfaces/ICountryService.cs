using InterviewProject2.DTOs.Responses;

namespace InterviewProject2.Services.Interfaces;

public interface ICountryService
{
    Task<ApiResponse> GetCountryByPhoneNumberAsync(string phoneNumber);                                                                  
}