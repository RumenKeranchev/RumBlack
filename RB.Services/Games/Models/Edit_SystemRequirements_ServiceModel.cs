namespace RB.Services.Games.Models
{
	public class Edit_SystemRequirements_ServiceModel
	{
		public string Processor { get; set; }

		public int Ram { get; set; }

		public string Os { get; set; }

		public string VideoCard { get; set; }

		public int FreeHddSpace { get; set; }
	}
}