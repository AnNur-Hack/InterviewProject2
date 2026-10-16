using InterviewProject2.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject2.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Country>  Countries { get; set; }
    public DbSet<CountryDetail>   CountriesDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(country => country.Id);

            entity.Property(country => country.CountryCode)
                .IsRequired()
                .HasMaxLength(4);

            entity.Property(country => country.CountryName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(country => country.CountryIso)
                .IsRequired()
                .HasMaxLength(4);

            entity.HasIndex(country => country.CountryCode)
                .IsUnique();

            entity.HasMany(country => country.CountryDetails)
                .WithOne(countryDetail => countryDetail.Country)
                .HasForeignKey(countryDetail => countryDetail.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(
                new Country
                {
                    Id = 1,
                    CountryCode = "234",
                    CountryName = "Nigeria",
                    CountryIso = "NG",
                },

                new Country
                {
                    Id = 2,
                    CountryCode = "233",
                    CountryName = "Ghana",
                    CountryIso = "GH",
                },
                new Country
                {
                    Id = 3,
                    CountryCode = "229",
                    CountryName = "Benin Republic",
                    CountryIso = "BN",
                },
                new Country
                {
                    Id = 4,
                    CountryCode = "225",
                    CountryName = "Côte d'Ivoire",
                    CountryIso = "CIV",
                });


        });

        modelBuilder.Entity<CountryDetail>(entity =>
            {
                entity.HasKey(countryDetail => countryDetail.Id);

                entity.Property(countryDetail => countryDetail.Operator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(countryDetail => countryDetail.OperatorCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasData(
                    new CountryDetail
                    {
                        Id = 1,
                        CountryId = 1,
                        Operator = "MTN Nigeria",
                        OperatorCode = "MTN NG",
                    },
                    new CountryDetail
                    {
                        Id = 2,
                        CountryId = 1,
                        Operator = "Airtel Nigeria",
                        OperatorCode = "ANG",
                    },
                    new CountryDetail
                    {
                        Id = 3,
                        CountryId = 1,
                        Operator = "9Mobile Nigeria",
                        OperatorCode = "ETN",
                    },
                    new CountryDetail
                    {
                        Id = 4,
                        CountryId = 1,
                        Operator = "Globacom Nigeria",
                        OperatorCode = "GLO NG",
                    },
                    new CountryDetail
                    {
                        Id = 5,
                        CountryId = 2,
                        Operator = "Vodafone Ghana",
                        OperatorCode = "Vodafone GH",
                    },
                    new CountryDetail
                    {
                        Id = 6,
                        CountryId = 2,
                        Operator = "MTN Ghana",
                        OperatorCode = "MTN Ghana",
                    },
                    new CountryDetail
                    {
                        Id = 7,
                        CountryId = 2,
                        Operator = "Tigo Ghana",
                        OperatorCode = "Tigo Ghana",
                    },
                    new CountryDetail
                    {
                        Id = 8,
                        CountryId = 3,
                        Operator = "MTN Benin",
                        OperatorCode = "MTN Benin",
                    },
                    new CountryDetail
                    {
                        Id = 9,
                        CountryId = 3,
                        Operator = "Moov Benin",
                        OperatorCode = "Moov Benin",
                    },
                    new CountryDetail
                    {
                        Id = 10,
                        CountryId = 4,
                        Operator = "MTN Côte d'Ivoire",
                        OperatorCode = "MTN CIV",
                    });
            }

        );
    }
}