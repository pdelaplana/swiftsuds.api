using SwiftSuds.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.Entities.Users;
public class User
{

    [Column(TypeName = "nvarchar(60)")]
    public string Name { get; set; } = null!;

    public Address Address { get; set; } = null!;

    [Column(TypeName = "nvarchar(60)")]
    public string Email { get; set; } = null!;

    [Column(TypeName = "nvarchar(20)")]
    public string Phone { get; set; } = null!;

}
