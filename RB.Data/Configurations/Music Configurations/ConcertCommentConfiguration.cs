using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Social;

namespace RB.Data.Configurations.Music_Configurations
{
	public class ConcertCommentConfiguration : IEntityTypeConfiguration< ConcertComment >
	{
		public void Configure( EntityTypeBuilder< ConcertComment > builder )
		{
			builder
				.HasOne( cc => cc.User )
				.WithMany( u => u.ConcertComments )
				.HasForeignKey( cc => cc.UserId );

			builder
				.HasOne( cc => cc.Concert )
				.WithMany( c => c.Comments )
				.HasForeignKey( cc => cc.ConcertId );
		}
	}
}