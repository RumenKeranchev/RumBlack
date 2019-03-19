using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Social;

namespace RB.Data.Configurations.Music_Configurations
{
	public class AlbumCommentConfiguration : IEntityTypeConfiguration< AlbumComment >
	{
		public void Configure( EntityTypeBuilder< AlbumComment > builder )
		{
			builder
				.HasOne( mc => mc.User )
				.WithMany( u => u.AlbumComments )
				.HasForeignKey( mc => mc.UserId );

			builder
				.HasOne( c => c.Album )
				.WithMany( a => a.Comments )
				.HasForeignKey( c => c.AlbumId );
		}
	}
}