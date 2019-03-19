using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Movies;

namespace RB.Data.Configurations.Movie_Configurations
{
	public class MovieActorConfiguration : IEntityTypeConfiguration< MovieActor >
	{
		public void Configure( EntityTypeBuilder< MovieActor > builder )
		{
			builder
				.HasKey( ma => new { ma.MovieId, ma.ActorId } );

			builder
				.HasOne( m => m.Actor )
				.WithMany( a => a.Movies )
				.HasForeignKey( m => m.ActorId );

			builder
				.HasOne( a => a.Movie )
				.WithMany( m => m.Cast )
				.HasForeignKey( a => a.MovieId );
		}
	}
}