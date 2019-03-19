using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Common.Constants;
using RB.Common.DbCategoriesFlags;
using RB.Data.DbModels.Social;
using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Games
{
	public class Game
	{
		[ Required ]
		public int Id { get; set; }

		[ Required ]
		[ MinLength( GameConstants.MinNameLength ) ]
		[ MaxLength( GameConstants.MaxNameLength ) ]
		public string Name { get; set; }

		[ Required ]
		[ MinLength( GameConstants.MinDescriptionLength ) ]
		[ MaxLength( GameConstants.MaxDescriptionLength ) ]
		public string Description { get; set; }

		[ Required ]
		public GameGenres Genre { get; set; }

		[ Required ]
		public GamePlatforms Platform { get; set; }

		[ Required ]
		public int DeveloperId { get; set; }

		[ Required ]
		public Developer Developer { get; set; }

		[ Range( GameConstants.MinRating, GameConstants.MaxRating ) ]
		public float Rating { get; set; }

		[ Range( GameConstants.MinPrice, double.MaxValue ) ]
		public decimal Price { get; set; }

		[ Required ]
		public bool IsForSale { get; set; }

		[ Required ]
		public DateTime ReleaseDate { get; set; }

		public IEnumerable< GameInShoppingCart > Carts { get; set; } = new List< GameInShoppingCart >();

		public GameStock Stock { get; set; }

		public GameSystemRequirements SystemRequirements { get; set; }

		public byte[] CoverImage { get; set; }

		public IEnumerable< GameComment > Comments { get; set; } = new List< GameComment >();

		/*TODO: Add cover image, as well as gallery
			The Gallery and cover image should be actual pictures and not links,
			however for DB size concerns in production env it might be links for now
		 */
	}
}