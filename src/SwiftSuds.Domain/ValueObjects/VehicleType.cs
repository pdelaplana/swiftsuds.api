namespace SwiftSuds.Domain.ValueObjects;
public record VehicleType (string Type)
{
    public static VehicleType Motorcycle => new("Motorcycle");
    public static VehicleType Car = new("Car");
    public static VehicleType Van = new("Van");

}
