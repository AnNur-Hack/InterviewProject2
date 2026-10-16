using InterviewProject2.DTOs.Responses;
using InterviewProject2.Models;
using InterviewProject2.Repositories.Interfaces;
using InterviewProject2.Services.Interfaces;

namespace InterviewProject2.Services.Implementations;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    private readonly ICountryRepository _countryRepository = countryRepository;
    
    public async Task<ApiResponse> GetCountryByPhoneNumberAsync(string phoneNumber)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return new ApiResponse
                {
                    ResponseCode = "99",
                    ResponseMessage = "Phone number is required."

                };
            }
            
            phoneNumber = phoneNumber.Trim();

            if (phoneNumber.StartsWith("+"))
            {
                phoneNumber = phoneNumber.Remove(0, 1);
            }

            if (phoneNumber.Length == 0 || !phoneNumber.All(char.IsDigit))
            {
                return new ApiResponse
                {
                    ResponseCode = "99",
                    ResponseMessage = "Please enter a valid phone number."
                };
            }

            var countries = await _countryRepository.GetAllCountriesAsync();
            
            var country = countries
                .Where(c => phoneNumber.StartsWith(c.CountryCode))
                .OrderByDescending(c => c.CountryCode.Length)
                .FirstOrDefault();

            if (country == null)
            {
                return new ApiResponse
                {
                    ResponseCode = "99",
                    ResponseMessage = "Country code not found."
                };
            }

            var response = new CountryLookupResponse
            {
                PhoneNumber = phoneNumber,
                Country = new CountryResponse
                {
                    CountryCode = country.CountryCode,
                    CountryName = country.CountryName,
                    CountryIso = country.CountryIso,
                    CountryDetails = country.CountryDetails
                        .Select(d => new CountryDetailResponse
                        {
                            Operator = d.Operator.Trim(),
                            OperatorCode = d.OperatorCode
                        }).ToList()
                }
            };

            return new ApiResponse
            {
                ResponseCode = "00",
                ResponseMessage = "Country details retrieved successfully",
                Data = response
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse
            {
                ResponseCode = "99",
                ResponseMessage = "An unexpected error occured while retrieving the country details."
            };
        }
       
    }
}