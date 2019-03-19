using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Social;

namespace RB.Data.Configurations.Music_Configurations
{
	public class SongCommentConfiguration : IEntityTypeConfiguration< SongComment >
	{
		public void Configure( EntityTypeBuilder< SongComment > builder )
		{
			builder
				.HasOne( sc => sc.User )
				.WithMany( u => u.SongComments )
				.HasForeignKey( sc => sc.UserId );

			builder
				.HasOne( sc => sc.Song )
				.WithMany( s => s.Comments )
				.HasForeignKey( sc => sc.SongId );
		}
	}
}