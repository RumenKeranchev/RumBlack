using System.ComponentModel.DataAnnotations;
using RB.Data.DbModels.Music;

namespace RB.Data.DbModels.Store
{
	public class AlbumStock
	{
		public int Id { get; set; }

		[ Required ]
		public int AlbumId { get; set; }

		[ Required ]
		public Album Album { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int PhysicalCopies { get; set; }

		[ Required ]
		[ Range( 1, int.MaxValue ) ]
		public int DigitalCopies { get; set; }
	}
}