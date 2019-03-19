using RB.Data.DbModels.Movies;

namespace RB.Data.DbModels.Social
{
	public class MovieComment : CommentsBase
	{
		public int MovieId { get; set; }

		public Movie Movie { get; set; }
	}
}