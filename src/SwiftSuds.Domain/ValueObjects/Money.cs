namespace SwiftSuds.Domain.ValueObjects;

public record Money
{
    public Currency Currency = null!;
    public decimal Amount = 0;
}