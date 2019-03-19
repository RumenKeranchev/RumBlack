using RB.Data.DbModels.Games;

namespace RB.Data.DbModels.Social
{
	public class GameComment : CommentsBase
	{
		public int GameId { get; set; }

		public Game Game { get; set; }
	}
}