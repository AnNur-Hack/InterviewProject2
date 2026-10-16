using InterviewProject2.Models;

namespace InterviewProject2.Repositories.Interfaces;

public interface ICountryRepository
{
    Task<Country?> GetCountryByCodeAsync(string countryCode);
    Task<IEnumerable<Country>> GetAllCountriesAsync();
}