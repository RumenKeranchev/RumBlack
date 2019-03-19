using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Music;

namespace RB.Data.Configurations.Music_Configurations
{
	public class SongsInShoppingCartConfiguration : IEntityTypeConfiguration< SongInShoppingCart >
	{
		public void Configure( EntityTypeBuilder< SongInShoppingCart > builder )
		{
			builder
				.HasKey( sc => new { sc.SongId, sc.CartId } );

			builder
				.HasOne( s => s.Cart )
				.WithMany( c => c.Songs )
				.HasForeignKey( s => s.CartId );

			builder
				.HasOne( c => c.Song )
				.WithMany( s => s.Carts )
				.HasForeignKey( c => c.SongId );
		}
	}
}