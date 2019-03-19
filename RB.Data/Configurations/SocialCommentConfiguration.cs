using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Social;

namespace RB.Data.Configurations
{
    public class SocialCommentConfiguration : IEntityTypeConfiguration<SocialComment>
    {
        public void Configure(EntityTypeBuilder<SocialComment> builder)
        {
            builder
                .HasOne(sc => sc.User)
                .WithMany(u => u.SocialComments)
                .HasForeignKey(sc => sc.UserId);
        }
    }
}