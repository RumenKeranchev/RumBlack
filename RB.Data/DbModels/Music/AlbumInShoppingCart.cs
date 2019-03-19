using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Music
{
	public class AlbumInShoppingCart
	{
		public int AblumId { get; set; }

		public Album Album { get; set; }

		public int CartId { get; set; }

		public ShoppingCart Cart { get; set; }

		public int Quantity { get; set; }
	}
}