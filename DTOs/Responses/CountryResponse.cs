namespace InterviewProject2.DTOs.Responses;

public class CountryResponse
{
    public string CountryCode { get; set; }
    
    public string CountryName { get; set; }
    
    public string CountryIso { get; set; }
    
    public List<CountryDetailResponse> CountryDetails { get; set; } = new();
}