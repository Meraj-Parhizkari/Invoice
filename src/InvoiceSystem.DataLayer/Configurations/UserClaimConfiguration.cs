using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceSystem.Entities.Identity;

namespace InvoiceSystem.DataLayer.Mappings
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasOne(userClaim => userClaim.User)
                   .WithMany(user => user.Claims)
                   .HasForeignKey(userClaim => userClaim.UserId);

            builder.ToTable("AppUserClaims");
        }
    }
}