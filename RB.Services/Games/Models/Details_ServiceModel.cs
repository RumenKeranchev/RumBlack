using System;
using AutoMapper;
using RB.Common.DbCategoriesFlags;
using RB.Common.Mapper;
using RB.Data.DbModels.Games;

namespace RB.Services.Games.Models
{
	public class Details_ServiceModel : IMapFrom< Game >, IHaveCustomMapping
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public GameGenres Genre { get; set; }

		public GamePlatforms Platform { get; set; }

		public string DeveloperName { get; set; }

		public float Rating { get; set; }

		public decimal Price { get; set; }

		public bool IsForSale { get; set; }

		public DateTime ReleaseDate { get; set; }

		public bool InStock { get; set; }

		public System_Requirements_ServiceModel SystemRequirements { get; set; }

		public void ConfigureMapping( Profile mapper )
		{
			mapper
				.CreateMap< Game, Details_ServiceModel >()
				.ForMember( g => g.DeveloperName, cfg => cfg.MapFrom( g => g.Developer.Name ) );
			
			mapper
				.CreateMap< Game, Details_ServiceModel >()
				.ForMember( g => g.InStock, cfg => cfg.MapFrom( g => g.Stock != null ) );
		}
	}
}