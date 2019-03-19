using System.ComponentModel.DataAnnotations;

namespace RB.Data.DbModels.Movies
{
	public class BoxOffice
	{
		public int Id { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int Budget { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int OpeningWeekend { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int GrossUsa { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int WorldwideGross { get; set; }

		public int MovieId { get; set; }

		public Movie Movie { get; set; }
	}
}