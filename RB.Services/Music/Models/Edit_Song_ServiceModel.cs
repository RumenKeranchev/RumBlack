using RB.Common.DbCategoriesFlags;

namespace RB.Services.Music.Models
{
	public class Edit_Song_ServiceModel
	{
		public int Id { get; set; }

		public string Name { get; set; }
		
		public int AlbumId { get; set; }

		public MusicGenres Genres { get; set; }
	}
}