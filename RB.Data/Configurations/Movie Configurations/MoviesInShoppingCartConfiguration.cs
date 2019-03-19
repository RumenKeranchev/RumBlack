using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Movies;

namespace RB.Data.Configurations.Movie_Configurations
{
	public class MoviesInShoppingCartConfiguration : IEntityTypeConfiguration< MovieInShoppingCart >
	{
		public void Configure( EntityTypeBuilder< MovieInShoppingCart > builder )
		{
			builder
				.HasKey( mc => new { mc.MovieId, mc.CartId } );

			builder
				.HasOne( c => c.Movie )
				.WithMany( m => m.Carts )
				.HasForeignKey( c => c.MovieId );

			builder
				.HasOne( m => m.Cart )
				.WithMany( c => c.Movies )
				.HasForeignKey( m => m.CartId );
		}
	}
}