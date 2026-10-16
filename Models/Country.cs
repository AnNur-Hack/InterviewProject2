namespace InterviewProject2.Models;

public class Country
{
    public int Id { get; set; }

    public string CountryCode { get; set; }

    public string CountryName { get; set; }

    public string CountryIso { get; set; }

    public ICollection<CountryDetail> CountryDetails { get; set; }
        = new List<CountryDetail>();
}