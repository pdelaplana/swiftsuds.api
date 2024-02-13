using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.ValueObjects;

public record Money
{
    public Money() { }
    public Money(decimal amount, Currency currency) { 
        Amount = amount;
        Currency = currency;
    }
    
    [Column(TypeName="decimal(10,2)")] 
    public decimal Amount { get; set; } = default!;
    public Currency Currency { get; set; } = default!;
};

