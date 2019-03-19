using RB.Data.DbModels.Music;

namespace RB.Data.DbModels.Social
{
	public class SongComment : CommentsBase
	{
		public int SongId { get; set; }

		public Song Song { get; set; }
	}
}