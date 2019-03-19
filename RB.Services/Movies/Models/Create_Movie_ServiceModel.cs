using System;
using RB.Common.DbCategoriesFlags;

namespace RB.Services.Movies.Models
{
	public class Create_Movie_ServiceModel
	{
		public string Title { get; set; }

		public string Plot { get; set; }

		public MoviesGenres Genre { get; set; }

		public int Length { get; set; }

		public string ProductionCompany { get; set; }

		public string DirectorName { get; set; }

		public string WriterName { get; set; }

		public DateTime ReleaseDate { get; set; }

		//Boxoffice  data:

		public int Budget { get; set; }

		public int OpeningWeekend { get; set; }

		public int GrossUsa { get; set; }

		public int WorldwideGross { get; set; }
	}
}