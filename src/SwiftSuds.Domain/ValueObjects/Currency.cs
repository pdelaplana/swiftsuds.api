namespace SwiftSuds.Domain.ValueObjects;
public record Currency(string Symbol)
{
    public static Currency Php => new("PHP");
    public static Currency Usd => new("USD");
    public static Currency Aud => new("AUD");

}
