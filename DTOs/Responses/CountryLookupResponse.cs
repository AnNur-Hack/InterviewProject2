namespace InterviewProject2.DTOs.Responses;

public class CountryLookupResponse
{
    public string PhoneNumber { get; set; }

    public CountryResponse Country { get; set; } = new();
}