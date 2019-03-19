using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Movies;
using RB.Data.DbModels.Store;

namespace RB.Data.Configurations.Movie_Configurations
{
	public class MovieConfiguration : IEntityTypeConfiguration< Movie >
	{
		public void Configure( EntityTypeBuilder< Movie > builder )
		{
			builder
				.HasOne( m => m.BoxOffice )
				.WithOne( b => b.Movie )
				.HasForeignKey< BoxOffice >( m => m.MovieId );

			builder
				.HasOne( m => m.Stock )
				.WithOne( s => s.Movie )
				.HasForeignKey< MovieStock >( m => m.MovieId );
		}
	}
}