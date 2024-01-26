using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSuds.Domain.Entities.UserAccounts;
public class UserAccount
{
    public UserAccountId UserAccountId { get; set; } = null!;

    [Column(TypeName = "nvarchar(60)")]
    public string Email { get; set; } = null!;
    public AccountType AccountType { get; set; }

}
