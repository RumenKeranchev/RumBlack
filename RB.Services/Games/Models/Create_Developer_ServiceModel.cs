using RB.Common.Mapper;
using RB.Data.DbModels.Games;

namespace RB.Services.Games.Models
{
	public class Create_Developer_ServiceModel : IMapFrom<Developer>
	{
		public string Name { get; set; }

		public string OriginCity { get; set; }

		public string OriginCountry { get; set; }
	}
}