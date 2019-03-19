namespace RB.Services.Games.Models
{
	public class Create_Stock_ServiceModel
	{
		public int GameId { get; set; }

		public int PcPhysicalCopies { get; set; }

		public int PcDigitalCopies { get; set; }

		public int MacPhysicalCopies { get; set; }

		public int MacDigitalCopies { get; set; }

		public int PlaystationPhysicalCopies { get; set; }

		public int PlaystationDigitalCopies { get; set; }

		public int XboxPhysicalCopies { get; set; }

		public int XboxDigitalCopies { get; set; }

		public int NintentoSwitchPhysicalCopies { get; set; }

		public int NintentoSwitchDigitalCopies { get; set; }

		public int LinuxPhysicalCopies { get; set; }

		public int LinuxDigitalCopies { get; set; }

		public int AndroidDigitalCopies { get; set; }
	}
}