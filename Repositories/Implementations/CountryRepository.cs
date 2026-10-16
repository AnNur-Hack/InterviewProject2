using InterviewProject2.Data;
using InterviewProject2.Models;
using InterviewProject2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject2.Repositories.Implementations;

public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    private readonly ApplicationDbContext _context = context;
    
    public async Task<Country?> GetCountryByCodeAsync(string countryCode)
    {
        return await _context.Countries
            .Include(c=> c.CountryDetails)
            .FirstOrDefaultAsync(c => c.CountryCode == countryCode);
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        return await _context.Countries
            .Include(c => c.CountryDetails)
            .ToListAsync();
    }
}