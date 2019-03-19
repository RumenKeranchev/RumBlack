using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Music
{
	public class SongInShoppingCart
	{
		public int SongId { get; set; }

		public Song Song { get; set; }

		public int CartId { get; set; }

		public ShoppingCart Cart { get; set; }
	}
}