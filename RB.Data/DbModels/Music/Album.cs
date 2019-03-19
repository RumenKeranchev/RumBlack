using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Common.Constants;
using RB.Common.DbCategoriesFlags;
using RB.Data.DbModels.Social;
using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Music
{
	public class Album
	{
		[ Required ]
		public int Id { get; set; }

		[ Required ]
		[ MinLength( MusicConstants.AlbumNameMinLength ) ]
		[ MaxLength( MusicConstants.AlbumNameMaxLength ) ]
		public string Name { get; set; }

		public MusicGenres Genre { get; set; }

		[ Required ]
		public byte[] Image { get; set; }

		[ Required ]
		public int BandId { get; set; }

		[ Required ]
		public Band Band { get; set; }

		public IEnumerable< Song > Songs { get; set; } = new List< Song >();

		[ Required ]
		public AlbumStock Stock { get; set; }

		public IEnumerable< AlbumInShoppingCart > Carts { get; set; } = new List< AlbumInShoppingCart >();

		public IEnumerable< AlbumComment > Comments { get; set; } = new List< AlbumComment >();
	}
}