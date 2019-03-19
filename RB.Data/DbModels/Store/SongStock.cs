using System.ComponentModel.DataAnnotations;
using RB.Data.DbModels.Music;

namespace RB.Data.DbModels.Store
{
	public class SongStock
	{
		public int Id { get; set; }

		[ Required ]
		public int SongId { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public Song Song { get; set; }

		[ Required ]
		[ Range( 1, int.MaxValue ) ]
		public int DigitalCopies { get; set; }

		//TODO: Save actual song to DB instead of YT URLs
	}
}