using RB.Data.DbModels.Music;

namespace RB.Data.DbModels.Social
{
	public class AlbumComment : CommentsBase
	{
		public int AlbumId { get; set; }

		public Album Album { get; set; }
	}
}