using System;
using RB.Common.DbCategoriesFlags;

namespace RB.Services.Music.Models
{
	public class Edit_Concert_ServiceModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Location { get; set; }

		public MusicGenres Genre { get; set; }

		public string Country { get; set; }

		public string City { get; set; }
		
		public string PosterUrl { get; set; }

		public string StreamUrl { get; set; }
	}
}