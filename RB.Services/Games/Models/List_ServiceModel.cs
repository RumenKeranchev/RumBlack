using AutoMapper;
using RB.Common.Mapper;
using RB.Data.DbModels.Games;

namespace RB.Services.Games.Models
{
	public class List_ServiceModel : IMapFrom< Game >, IHaveCustomMapping
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Developer { get; set; }

		public float Rating { get; set; }

		public decimal Price { get; set; }

		public bool IsForSale { get; set; }

		public void ConfigureMapping( Profile mapper )
		{
			mapper
				.CreateMap< Game, List_ServiceModel >()
				.ForMember( g => g.Developer, cfg => cfg.MapFrom( g => g.Developer.Name ) );
		}
	}
}