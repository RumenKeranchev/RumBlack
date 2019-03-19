using Microsoft.AspNetCore.Http;
using RB.Common.DbCategoriesFlags;

namespace RB.Services.Music.Models
{
	public class Create_Album_ServiceModel
	{
		public string Name { get; set; }

		public MusicGenres Genre { get; set; }

		public IFormFile Image { get; set; }

		public int BandId { get; set; }
	}
}