using System.Linq;
using System.Threading.Tasks;
using RB.Common.DbCategoriesFlags;
using RB.Data;
using RB.Data.DbModels.Store;
using RB.Services.Games.Interfaces;
using RB.Services.Games.Interfaces.Admin;
using RB.Services.Games.Models;

namespace RB.Services.Games.Implementations.Admin
{
	public class AdminStockService : IAdminStockService
	{
		private readonly RumBlackDbContext db;

		public AdminStockService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE ENTRIES

		public async Task< bool > CreateAsync( Create_Stock_ServiceModel model )
		{
			if ( model.GameId <= 0 ||
			     model.AndroidDigitalCopies < 0 ||
			     model.LinuxDigitalCopies < 0 ||
			     model.LinuxPhysicalCopies < 0 ||
			     model.MacDigitalCopies < 0 ||
			     model.MacPhysicalCopies < 0 ||
			     model.NintentoSwitchDigitalCopies < 0 ||
			     model.NintentoSwitchPhysicalCopies < 0 ||
			     model.PcDigitalCopies < 0 ||
			     model.PcPhysicalCopies < 0 ||
			     model.PlaystationDigitalCopies < 0 ||
			     model.PlaystationPhysicalCopies < 0 ||
			     model.XboxDigitalCopies < 0 ||
			     model.XboxPhysicalCopies < 0 )
			{
				return false;
			}

			var game = this.db.Games.SingleOrDefault( g => g.Id == model.GameId );

			if ( game == null )
			{
				return false;
			}

			var stock = new GameStock();

			if ( game.Genre.HasFlag( GamePlatforms.Linux ) )
			{
				stock.LinuxDigitalCopies = model.LinuxDigitalCopies;
				stock.LinuxPhysicalCopies = model.LinuxDigitalCopies;
			}
			else if ( game.Genre.HasFlag( GamePlatforms.MacOs ) )
			{
				stock.MacDigitalCopies = model.MacDigitalCopies;
				stock.MacPhysicalCopies = model.MacPhysicalCopies;
			}
			else if ( game.Genre.HasFlag( GamePlatforms.Android ) )
			{
				stock.AndroidDigitalCopies = model.AndroidDigitalCopies;
			}
			else if ( game.Genre.HasFlag( GamePlatforms.MicrosoftWindows ) )
			{
				stock.PcDigitalCopies = model.PcDigitalCopies;
				stock.PcPhysicalCopies = model.PcPhysicalCopies;
			}
			else if ( game.Genre.HasFlag( GamePlatforms.NintendoSwitch ) )
			{
				stock.NintentoSwitchDigitalCopies = model.NintentoSwitchDigitalCopies;
				stock.NintentoSwitchPhysicalCopies = model.NintentoSwitchPhysicalCopies;
			}
			else if ( game.Genre.HasFlag( GamePlatforms.PlayStation ) )
			{
				stock.PlaystationDigitalCopies = model.PlaystationDigitalCopies;
				stock.PlaystationPhysicalCopies = model.PlaystationPhysicalCopies;
			}
			else if ( game.Genre.HasFlag( GamePlatforms.XboxOne ) )
			{
				stock.XboxDigitalCopies = model.XboxDigitalCopies;
				stock.XboxPhysicalCopies = model.XboxPhysicalCopies;
			}

			this.db.GameStocks.Add( stock );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES

		public async Task< bool > EditAsync( int gameId, Edit_Stock_ServiceModel model )
		{
			if ( gameId <= 0 || model == null )
			{
				return false;
			}

			var game = this.db.Games
				.Select( g => new
				{
					g.Id,
					g.Platform,
					g.Stock
				} )
				.SingleOrDefault( g => g.Id == gameId );

			if ( game == null )
			{
				return false;
			}

			var stock = game.Stock;

			if ( game.Platform.HasFlag( GamePlatforms.Linux ) )
			{
				if ( model.LinuxDigitalCopies > 0 )
				{
					stock.LinuxDigitalCopies = model.LinuxDigitalCopies;
				}

				if ( model.LinuxPhysicalCopies > 0 )
				{
					stock.LinuxPhysicalCopies = model.LinuxPhysicalCopies;
				}
			}
			else
			{
				stock.LinuxDigitalCopies = 0;
				stock.LinuxPhysicalCopies = 0;
			}

			if ( game.Platform.HasFlag( GamePlatforms.Android ) )
			{
				if ( model.AndroidDigitalCopies > 0 )
				{
					stock.AndroidDigitalCopies = model.AndroidDigitalCopies;
				}
			}
			else
			{
				stock.AndroidDigitalCopies = 0;
			}

			if ( game.Platform.HasFlag( GamePlatforms.MacOs ) )
			{
				if ( model.MacDigitalCopies > 0 )
				{
					stock.MacDigitalCopies = model.MacDigitalCopies;
				}

				if ( model.MacPhysicalCopies > 0 )
				{
					stock.MacPhysicalCopies = model.MacPhysicalCopies;
				}
			}
			else
			{
				stock.MacPhysicalCopies = 0;
				stock.MacDigitalCopies = 0;
			}

			if ( game.Platform.HasFlag( GamePlatforms.MicrosoftWindows ) )
			{
				if ( model.PcPhysicalCopies > 0 )
				{
					stock.PcDigitalCopies = model.PcDigitalCopies;
				}

				if ( model.PcPhysicalCopies > 0 )
				{
					stock.PcPhysicalCopies = model.PcPhysicalCopies;
				}
			}
			else
			{
				stock.PcDigitalCopies = 0;
				stock.PcPhysicalCopies = 0;
			}

			if ( game.Platform.HasFlag( GamePlatforms.NintendoSwitch ) )
			{
				if ( model.NintentoSwitchDigitalCopies > 0 )
				{
					stock.NintentoSwitchDigitalCopies = model.NintentoSwitchDigitalCopies;
				}

				if ( model.NintentoSwitchPhysicalCopies > 0 )
				{
					stock.NintentoSwitchPhysicalCopies = model.NintentoSwitchDigitalCopies;
				}
			}
			else
			{
				stock.NintentoSwitchDigitalCopies = 0;
				stock.NintentoSwitchPhysicalCopies = 0;
			}

			if ( game.Platform.HasFlag( GamePlatforms.PlayStation ) )
			{
				if ( model.PlaystationDigitalCopies > 0 )
				{
					stock.PlaystationDigitalCopies = model.PlaystationDigitalCopies;
				}

				if ( model.PlaystationPhysicalCopies > 0 )
				{
					stock.PlaystationPhysicalCopies = model.PlaystationPhysicalCopies;
				}
			}
			else
			{
				stock.PlaystationDigitalCopies = 0;
				stock.PlaystationPhysicalCopies = 0;
			}

			if ( game.Platform.HasFlag( GamePlatforms.XboxOne ) )
			{
				if ( model.XboxDigitalCopies > 0 )
				{
					stock.XboxDigitalCopies = model.XboxDigitalCopies;
				}

				if ( model.XboxPhysicalCopies > 0 )
				{
					stock.XboxPhysicalCopies = model.XboxPhysicalCopies;
				}
			}
			else
			{
				stock.XboxDigitalCopies = 0;
				stock.XboxPhysicalCopies = 0;
			}

			this.db.GameStocks.Update( stock );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE ENTRIES

		/// <summary>
		/// Use this in case after game deletetion the stock for said game remains
		/// </summary>
		/// <param name="gameId"></param>
		/// <returns>Returns true if stock was removed, false if stock does not exist or
		/// game ID is invalid </returns>
		public async Task< bool > DeleteAsync( int gameId )
		{
			if ( gameId <= 0 )
			{
				return false;
			}

			var stock = this.db.GameStocks.SingleOrDefault( s => s.GameId == gameId );

			if ( stock == null )
			{
				return false;
			}

			this.db.GameStocks.Remove( stock );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}