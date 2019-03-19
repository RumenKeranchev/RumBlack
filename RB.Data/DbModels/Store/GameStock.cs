using System.ComponentModel.DataAnnotations;
using RB.Data.DbModels.Games;

namespace RB.Data.DbModels.Store
{
	public class GameStock
	{
		public int Id { get; set; }

		[ Required ]
		public int GameId { get; set; }

		[ Required ]
		public Game Game { get; set; }

		//TODO Expand the copies props to separate classes

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int PcPhysicalCopies { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int PcDigitalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int MacPhysicalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int MacDigitalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int PlaystationPhysicalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int PlaystationDigitalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int XboxPhysicalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int XboxDigitalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int NintentoSwitchPhysicalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int NintentoSwitchDigitalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int LinuxPhysicalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int LinuxDigitalCopies { get; set; }

		[Required]
		[Range( 0, int.MaxValue )]
		public int AndroidDigitalCopies { get; set; }
	}
}