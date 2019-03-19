using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RB.Data;
using RB.Services.Games.Interfaces;
using RB.Services.Games.Models;

namespace RB.Services.Games.Implementations
{
	public class GameService : IGameService
	{
		private readonly RumBlackDbContext db;

		public GameService( RumBlackDbContext db )
		{
			this.db = db;
		}

		

		public async Task<Details_ServiceModel> DetailsAsync( int id )
		{
			if ( id <= 0 )
			{
				throw new Exception( "Invalid Id" );
			}

			var result = await this.db.Games
				.Where( g => g.Id == id )
				.ProjectTo< Details_ServiceModel >()
				.FirstOrDefaultAsync();

			return result;
		}

		public async Task< IEnumerable< List_ServiceModel > > ListAsync()
		{
			var result = await this.db
				.Games
				.ProjectTo< List_ServiceModel >()
				.ToListAsync();

			return result;
		}
	}
}