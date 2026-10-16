using InterviewProject2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewProject2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(ICountryService countryService) : ControllerBase
{
    private readonly ICountryService _countryService = countryService;

    [HttpGet("api/{phoneNumber}")]
    public async Task<IActionResult> GetCountryByPhoneNumber(string phoneNumber)
    {
        var response = await _countryService.GetCountryByPhoneNumberAsync(phoneNumber);

        if (response.ResponseCode != "00")
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }
}