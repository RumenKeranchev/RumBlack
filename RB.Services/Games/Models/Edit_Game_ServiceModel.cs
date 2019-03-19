using System;
using RB.Common.DbCategoriesFlags;

namespace RB.Services.Games.Models
{
	public class Edit_Game_ServiceModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public GameGenres Genre { get; set; }

		public GamePlatforms Platform { get; set; }

		public string DeveloperName { get; set; }

		public float Rating { get; set; }

		public decimal Price { get; set; }

		public bool IsForSale { get; set; }

		public DateTime ReleaseDate { get; set; }
	}
}