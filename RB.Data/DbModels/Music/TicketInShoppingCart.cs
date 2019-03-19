using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Music
{
	public class TicketInShoppingCart
	{
		public int TicketId { get; set; }

		public Ticket Ticket { get; set; }

		public int CartId { get; set; }

		public ShoppingCart Cart { get; set; }

		public int Quantity { get; set; }
	}
}