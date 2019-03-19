using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Games;

namespace RB.Data.Configurations.Game_Configurations
{
	public class GamesInShoppingCartConfiguration : IEntityTypeConfiguration< GameInShoppingCart >
	{
		public void Configure( EntityTypeBuilder< GameInShoppingCart > builder )
		{
			builder
				.HasKey( gc => new { gc.GameId, gc.CartId } );

			builder
				.HasOne( g => g.Game )
				.WithMany( c => c.Carts )
				.HasForeignKey( g => g.GameId );

			builder
				.HasOne( c => c.Cart )
				.WithMany( g => g.Games )
				.HasForeignKey( c => c.CartId );
		}
	}
}