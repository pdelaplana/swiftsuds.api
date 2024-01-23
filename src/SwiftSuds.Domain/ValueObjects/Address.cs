using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.ValueObjects;

public record Address
{
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

