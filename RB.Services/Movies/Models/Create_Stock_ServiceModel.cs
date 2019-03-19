namespace RB.Services.Movies.Models
{
	public class Create_Stock_ServiceModel
	{
		public int MovieId { get; set; }

		public int PhysicalCopies { get; set; }

		public int DigitalCopies { get; set; }
	}
}