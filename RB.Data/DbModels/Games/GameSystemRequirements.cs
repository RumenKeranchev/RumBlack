using System.ComponentModel.DataAnnotations;

namespace RB.Data.DbModels.Games
{
	public class GameSystemRequirements
	{
		public int Id { get; set; }

		//TODO: Expand processor to a separate class with make, series, model n
		[ Required ]
		public string Processor { get; set; }

		//TODO: Expand Ram to a separate class with make, series, model n
		[Required ]
		public int Ram { get; set; }

		//TODO: Expand Os to a separate class with make, version
		[Required ]
		public string Os { get; set; }

		//TODO: Expand VideoCard to a separate class with make, series, model n
		[Required ]
		public string VideoCard { get; set; }

		//TODO: Expand FreeHddSpace to a separate class with make, series, model n
		[Required ]
		public int FreeHddSpace { get; set; }

		/// <summary>
		/// GameId is nullable due to population process. First a game is created and then
		/// system requirements with said game ID
		/// </summary>
		public int? GameId { get; set; }

		public Game Game { get; set; }
	}
}