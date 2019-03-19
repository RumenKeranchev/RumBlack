using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Music;

namespace RB.Data.Configurations.Music_Configurations
{
	public class AlbumsInShoppingCartConfiguration : IEntityTypeConfiguration< AlbumInShoppingCart >
	{
		public void Configure( EntityTypeBuilder< AlbumInShoppingCart > builder )
		{
			builder
				.HasKey( ac => new { ac.AblumId, ac.CartId } );

			builder
				.HasOne( a => a.Cart )
				.WithMany( c => c.Albums )
				.HasForeignKey( a => a.CartId );

			builder
				.HasOne( c => c.Album )
				.WithMany( a => a.Carts )
				.HasForeignKey( c => c.AblumId );
		}
	}
}