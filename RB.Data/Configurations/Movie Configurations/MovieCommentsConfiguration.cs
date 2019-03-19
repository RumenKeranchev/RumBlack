using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Social;

namespace RB.Data.Configurations.Movie_Configurations
{
	class MovieCommentsConfiguration : IEntityTypeConfiguration< MovieComment >
	{
		public void Configure( EntityTypeBuilder< MovieComment > builder )
		{
			builder
				.HasOne( mc => mc.User )
				.WithMany( u => u.MovieComments )
				.HasForeignKey( mc => mc.UserId );

			builder
				.HasOne( c => c.Movie )
				.WithMany( m => m.Comments )
				.HasForeignKey( c => c.MovieId );
		}
	}
}