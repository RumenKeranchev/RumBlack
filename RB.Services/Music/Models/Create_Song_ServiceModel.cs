using RB.Common.DbCategoriesFlags;

namespace RB.Services.Music.Models
{
	public class Create_Song_ServiceModel
	{
		public string Name { get; set; }

		public byte[] Data { get; set; }

		public int AlbumId { get; set; }

		public MusicGenres Genres { get; set; }
	}
}