using RB.Common.Constants;
using RB.Common.DbCategoriesFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Data.DbModels.Social;
using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Movies
{
	public class Movie
	{
		public int Id { get; set; }

		[ Required ]
		public MoviesGenres Genre { get; set; }

		[ Required ]
		public string Title { get; set; }

		[ Required ]
		[ MinLength( MovieConstants.MinPlotLength ) ]
		[ MaxLength( MovieConstants.MaxPlotLength ) ]
		public string Plot { get; set; }

		[ Required ]
		[ Range( MovieConstants.MinLength, MovieConstants.MaxLength ) ]
		public int Length { get; set; }

		[ Required ]
		[ MinLength( MovieConstants.MinProductionCompanyLength ) ]
		public string ProductionCompany { get; set; }

		[ Required ]
		public string DirectorName { get; set; }

		[ Required ]
		public string WriterName { get; set; }

		public IEnumerable< MovieActor > Cast { get; set; } = new List< MovieActor >();

		public BoxOffice BoxOffice { get; set; }

		[ Required ]
		public DateTime ReleaseDate { get; set; }

		public IEnumerable< MovieInShoppingCart > Carts { get; set; } = new List< MovieInShoppingCart >();

		public MovieStock Stock { get; set; }

		public byte[] CoverImage { get; set; }

		public IEnumerable< MovieComment > Comments { get; set; } = new List< MovieComment >();
	}
}