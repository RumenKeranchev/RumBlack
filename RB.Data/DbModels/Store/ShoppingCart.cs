using System.Collections.Generic;
using RB.Data.DbModels.Games;
using RB.Data.DbModels.Movies;
using RB.Data.DbModels.Music;
using RB.Data.DbModels.Social;

namespace RB.Data.DbModels.Store
{
	public class ShoppingCart
	{
		public int Id { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public IEnumerable< GameInShoppingCart > Games { get; set; } = new List< GameInShoppingCart >();

		public IEnumerable< MovieInShoppingCart > Movies { get; set; } = new List< MovieInShoppingCart >();

		public IEnumerable< AlbumInShoppingCart > Albums { get; set; } = new List< AlbumInShoppingCart >();

		public IEnumerable< SongInShoppingCart > Songs { get; set; } = new List< SongInShoppingCart >();

		public IEnumerable< TicketInShoppingCart > Tickets { get; set; } = new List< TicketInShoppingCart >();
	}
}