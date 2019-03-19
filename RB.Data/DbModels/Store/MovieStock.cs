using System.ComponentModel.DataAnnotations;
using RB.Data.DbModels.Movies;

namespace RB.Data.DbModels.Store
{
	public class MovieStock
	{
		public int Id { get; set; }

		//TODO: remove nullable and check consequences
		public int? MovieId { get; set; }

		public Movie Movie { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int PhysicalCopies { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int DigitalCopies { get; set; }
	}
}