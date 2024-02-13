using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.ValueObjects;

public record Address
{
    public Address() { }

    public Address(string streetAddress1, string city) {
        StreetAddress1 = streetAddress1;
        City = city;
    }

    [Column(TypeName = "nvarchar(120)")] 
    public string StreetAddress1 = null!;

    [Column(TypeName = "nvarchar(120)")]
    public string? StreetAddress2;

    [Column(TypeName = "nvarchar(120)")]
    public string? StreetAddress3;

    [Column(TypeName = "nvarchar(60)")]
    public string? City;

    [Column(TypeName = "nvarchar(10)")]
    public string? PostCode;
}

