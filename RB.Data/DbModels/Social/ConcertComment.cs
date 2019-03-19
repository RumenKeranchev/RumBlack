using RB.Data.DbModels.Music;

namespace RB.Data.DbModels.Social
{
	public class ConcertComment : CommentsBase
	{
		public int ConcertId { get; set; }

		public Concert Concert { get; set; }
	}
}