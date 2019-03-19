using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Games
{
	public class GameInShoppingCart
	{
		public int GameId { get; set; }

		public Game Game { get; set; }

		public int CartId { get; set; }

		public ShoppingCart Cart { get; set; }

		public int Quantity { get; set; }
	}
}