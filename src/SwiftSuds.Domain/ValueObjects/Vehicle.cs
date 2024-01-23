using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.ValueObjects;

public record Vehicle
{
    public required VehicleType VehicleType = null!;
    [Column(TypeName = "nvarchar(20)")]
    public required string RegistrationNumber = null!;
    public DateTime? RegistrationExpiryDate = null!;
};