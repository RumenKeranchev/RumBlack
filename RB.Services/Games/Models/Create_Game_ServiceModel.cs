using System;
using Microsoft.AspNetCore.Http;
using RB.Common.DbCategoriesFlags;

namespace RB.Services.Games.Models
{
	public class Create_Game_ServiceModel
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

		public IFormFile CoverImage { get; set; }

		//System Requirements

		public string Processor { get; set; }

		public int Ram { get; set; }

		public string Os { get; set; }

		public string VideoCard { get; set; }

		public int FreeHddSpace { get; set; }
	}
}