using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceSystem.Entities.Identity;

namespace InvoiceSystem.DataLayer.Mappings
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasOne(userLogin => userLogin.User)
                   .WithMany(user => user.Logins)
                   .HasForeignKey(userLogin => userLogin.UserId);

            builder.ToTable("AppUserLogins");
        }
    }
}