using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.ValueObjects;
public record Currency
{
    public Currency() { }
    public Currency(string currencyCode) { Symbol = currencyCode; }

    [Column(TypeName = "nvarchar(5)")]
    public string Symbol { get; set; } = string.Empty;
    public static Currency Php => new("PHP");
    public static Currency Usd => new("USD");
    public static Currency Aud => new("AUD");

}
