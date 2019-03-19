using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Games;
using RB.Services.Games.Interfaces;
using RB.Services.Games.Interfaces.Admin;
using RB.Services.Games.Models;

namespace RB.Services.Games.Implementations.Admin
{
	public class AdminSystemRequirementsService : IAdminSystemRequirementsService
	{
		private readonly RumBlackDbContext db;

		public AdminSystemRequirementsService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//	CREATE ENTRIES:

		/// <summary>
		/// This is to be used when a game is crated directly from the DB and
		/// has no system requirements added (if needed)
		/// </summary>
		/// <param name="model"></param>
		/// <returns>true if successfully added to database, false if a check fails</returns>
		public async Task< bool > CreateSystemRequirementsAsync( Create_SystemRequirements_ServiceModel model )
		{
			if ( string.IsNullOrEmpty( model.Os ) ||
			     string.IsNullOrWhiteSpace( model.Processor ) ||
			     string.IsNullOrWhiteSpace( model.VideoCard ) ||
			     model.FreeHddSpace <= 0 ||
			     model.GameId <= 0 ||
			     model.Ram <= 0 )
			{
				return false;
			}

			var sysRequirements = new GameSystemRequirements()
			{
				FreeHddSpace = model.FreeHddSpace,
				GameId = model.GameId,
				Os = model.Os,
				Processor = model.Processor,
				Ram = model.Ram,
				VideoCard = model.VideoCard
			};

			this.db.GameSystemRequirements.Add( sysRequirements );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES:

		public async Task< bool > EditSystemRequirementsAsync( int gameId, Edit_SystemRequirements_ServiceModel model )
		{
			if ( gameId <= 0 || model == null )
			{
				return false;
			}

			var game = this.db.Games
				.Select( g => new
				{
					g.Id,
					g.SystemRequirements
				} )
				.SingleOrDefault( g => g.Id == gameId );

			if ( game == null )
			{
				return false;
			}

			var sysRequirements = game.SystemRequirements;

			if ( !string.IsNullOrWhiteSpace( model.Os ) )
			{
				sysRequirements.Os = model.Os;
			}
			else if ( !string.IsNullOrWhiteSpace( model.Processor ) )
			{
				sysRequirements.Processor = model.Processor;
			}
			else if ( !string.IsNullOrWhiteSpace( model.VideoCard ) )
			{
				sysRequirements.VideoCard = model.VideoCard;
			}
			else if ( model.FreeHddSpace > 0 )
			{
				sysRequirements.FreeHddSpace = model.FreeHddSpace;
			}
			else if ( model.Ram > 0 )
			{
				sysRequirements.Ram = model.Ram;
			}

			this.db.GameSystemRequirements.Update( sysRequirements );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE ENTRIES:

		public async Task< bool > DeleteSystemRequirementsAsync( int gameId )
		{
			if ( gameId <= 0 )
			{
				return false;
			}

			var game = this.db.Games
				.Select( g => new
				{
					g.Id,
					g.SystemRequirements
				} )
				.SingleOrDefault( g => g.Id == gameId );

			if ( game == null )
			{
				return false;
			}

			this.db.GameSystemRequirements.Remove( game.SystemRequirements );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}