using RB.Common.DbCategoriesFlags;

namespace RB.Services.Music.Models
{
	public class Create_Band_ServiceModel
	{
		public string Name { get; set; }

		public MusicGenres Genre { get; set; }
	}
}