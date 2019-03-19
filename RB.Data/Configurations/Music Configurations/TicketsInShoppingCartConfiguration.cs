using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Music;

namespace RB.Data.Configurations.Music_Configurations
{
	public class TicketsInShoppingCartConfiguration : IEntityTypeConfiguration< TicketInShoppingCart >
	{
		public void Configure( EntityTypeBuilder< TicketInShoppingCart > builder )
		{
			builder
				.HasKey( tc => new { tc.TicketId, tc.CartId } );

			builder
				.HasOne( t => t.Cart )
				.WithMany( c => c.Tickets )
				.HasForeignKey( t => t.TicketId );

			builder
				.HasOne( c => c.Ticket )
				.WithMany( t => t.Carts )
				.HasForeignKey( c => c.CartId );
		}
	}
}