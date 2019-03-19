using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Common.Constants;
using RB.Common.DbCategoriesFlags;
using RB.Data.DbModels.Social;
using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Music
{
	public class Song
	{
		[ Required ]
		public int Id { get; set; }

		[ Required ]
		[ MinLength( MusicConstants.SongMinLength ) ]
		[ MaxLength( MusicConstants.SongMaxLength ) ]
		public string Name { get; set; }

		[ Required ]
		public MusicGenres Genre { get; set; }

//		[ Required ]
//		[ StringLength( 11 ) ]
//		public string UrlId { get; set; }

		public byte[] Data { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }

		public SongStock Stock { get; set; }

		public IEnumerable< SongInShoppingCart > Carts { get; set; } = new List< SongInShoppingCart >();

		public IEnumerable< SongComment > Comments { get; set; } = new List< SongComment >();
	}
}