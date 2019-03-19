using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Social;

namespace RB.Data.Configurations.Game_Configurations
{
    public class GameCommentConfiguration : IEntityTypeConfiguration<GameComment>
    {
        public void Configure( EntityTypeBuilder< GameComment > builder )
        {
            builder
                .HasOne(gc => gc.User)
                .WithMany(u => u.GameComments)
                .HasForeignKey(gc => gc.UserId);

	        builder
		        .HasOne( g => g.Game )
		        .WithMany( c => c.Comments )
		        .HasForeignKey( c => c.GameId );
        }
    }
}