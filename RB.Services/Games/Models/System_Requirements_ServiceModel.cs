using RB.Common.Mapper;
using RB.Data.DbModels.Games;

namespace RB.Services.Games.Models
{
	public class System_Requirements_ServiceModel : IMapFrom<GameSystemRequirements>
	{
		public int Id { get; set; }

		public string Os { get; set; }

		public string Processor { get; set; }

		public string VideoCard { get; set; }

		public int Ram { get; set; }

		public int FreeHddSpace { get; set; }
	}
}