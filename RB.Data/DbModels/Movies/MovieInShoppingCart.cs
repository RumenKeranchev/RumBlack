using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Movies
{
	public class MovieInShoppingCart
	{
		public int MovieId { get; set; }

		public Movie Movie { get; set; }

		public int CartId { get; set; }

		public ShoppingCart Cart { get; set; }

		public int Quantity { get; set; }
	}
}