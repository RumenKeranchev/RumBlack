using System;
using System.Linq;
using System.Threading.Tasks;
using RB.Common.DbCategoriesFlags;
using RB.Data;
using RB.Data.DbModels.Games;
using RB.Services.Games.Interfaces;
using RB.Services.Games.Interfaces.Admin;
using RB.Services.Games.Models;

namespace RB.Services.Games.Implementations.Admin
{
	public class AdminGameService : IAdminGameService
	{
		private readonly RumBlackDbContext db;

		public AdminGameService( RumBlackDbContext db )
		{
			this.db = db;
		}

		// CREATE ENTRIES:
		public async Task< bool > CreateAsync( Create_Game_ServiceModel model )
		{
			DateTime tmp;

			if ( string.IsNullOrWhiteSpace( model.Name ) ||
			     string.IsNullOrWhiteSpace( model.Description ) ||
			     string.IsNullOrWhiteSpace( model.DeveloperName ) ||
			     model.Price <= 0 ||
			     model.Rating <= 0 ||
			     model.Genre <= 0 ||
			     model.Platform <= 0 ||
			     !DateTime.TryParse( model.ReleaseDate.ToString(), out tmp ) ||
			     model.CoverImage == null)
			{
				return false;
			}

			var developer = this.GetDeveloperByName( this.db, model.DeveloperName );

			var game = new Game()
			{
				Description = model.Description,
				Developer = developer,
				Genre = model.Genre,
				IsForSale = model.IsForSale,
				Name = model.Name,
				Platform = model.Platform,
				Price = model.Price,
				Rating = model.Rating,
				ReleaseDate = model.ReleaseDate,
				CoverImage = HelperMethods.FileToBytes( model.CoverImage )
			};

			if ( model.Genre.HasFlag( GamePlatforms.MicrosoftWindows ) ||
			     model.Genre.HasFlag( GamePlatforms.Linux ) ||
			     model.Genre.HasFlag( GamePlatforms.MacOs ) )
			{
				if ( string.IsNullOrWhiteSpace( model.Os ) ||
				     string.IsNullOrWhiteSpace( model.Processor ) ||
				     string.IsNullOrWhiteSpace( model.VideoCard ) ||
				     model.FreeHddSpace <= 0 ||
				     model.Ram <= 0 )
				{
					return false;
				}

				var sysRequirements = new GameSystemRequirements()
				{
					FreeHddSpace = model.FreeHddSpace,
					Os = model.Os,
					Processor = model.Processor,
					Ram = model.Ram,
					VideoCard = model.VideoCard
				};

				game.SystemRequirements = sysRequirements;
			}

			await this.UpdateDeveloperRatingAsync( this.db, developer.Id );

			this.db.Games.Add( game );
			await this.db.SaveChangesAsync();

			return true;
		}
		
		//EDIT ENTRIES:
		public async Task< bool > EditAsync( int id, Edit_Game_ServiceModel model )
		{
			if ( id <= 0 || model == null )
			{
				return false;
			}

			var developer = this.GetDeveloperByName( this.db, model.DeveloperName );

			if ( developer == null )
			{
				return false;
			}

			var game = this.db.Games.SingleOrDefault( g => g.Id == id );

			if ( game == null )
			{
				return false;
			}

			if ( !string.IsNullOrWhiteSpace( model.Name ) )
			{
				game.Name = model.Name;
			}
			else if ( !string.IsNullOrWhiteSpace( model.Description ) )
			{
				game.Description = model.Description;
			}
			else if ( model.Price > 0 )
			{
				game.Price = model.Price;
			}
			else if ( model.Rating >= 0 )
			{
				game.Rating = model.Rating;
			}

			game.Genre = model.Genre;
			game.Platform = model.Platform;
			game.IsForSale = model.IsForSale;
			game.ReleaseDate = model.ReleaseDate;
			game.Developer = developer;

			this.db.Games.Update( game );
			await this.db.SaveChangesAsync();

			return true;
		}
		
		//DELETE ENTRIES:
		public async Task< bool > DeleteAsync( int gameId )
		{
			if ( gameId <= 0 )
			{
				return false;
			}

			var game = this.db.Games
				.SingleOrDefault( g => g.Id == gameId );

			if ( game == null )
			{
				return false;
			}

			this.db.Games.Remove( game );
			await this.db.SaveChangesAsync();

			return true;
		}


		//HELPER METHODS
		public async Task UpdateDeveloperRatingAsync( int id )
		{
			if ( id <= 0 )
			{
				throw new Exception( "Invalid developer Id!" );
			}

			var developer = this.db.Developers.SingleOrDefault( d => d.Id == id );

			if ( developer == null )
			{
				throw new Exception( "Developer does not exist!" );
			}

			developer.OverallRating = this.db.Games
				.Where( d => d.Id == id )
				.Average( g => g.Rating );

			this.db.Developers.Update( developer );

			await this.db.SaveChangesAsync();
		}

		public Developer GetDeveloperByName( string name )
		{
			if ( string.IsNullOrWhiteSpace( name ) )
			{
				throw new Exception( "Invalid developer name!" );
			}

			var developer = this.db.Developers.SingleOrDefault( d => d.Name.Equals( name ) );

			if ( developer == null )
			{
				throw new Exception( "Developer does not exist!" );
			}

			return developer;
		}
	}
}