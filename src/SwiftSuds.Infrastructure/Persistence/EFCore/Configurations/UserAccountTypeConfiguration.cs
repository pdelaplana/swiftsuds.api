using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftSuds.Domain.Entities.UserAccounts;

namespace SwiftSuds.Infrastructure.Persistence.EFCore.Configurations;
internal class UserAccountTypeConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasKey(userAccount => userAccount.UserAccountId);
        builder.Property(userAccount => userAccount.UserAccountId)
            .HasConversion(id => id.Value,
                value => new UserAccountId(value));
    }
}
