using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Store;
using RB.Services.Movies.Interfaces.Admin;
using RB.Services.Movies.Models;

namespace RB.Services.Movies.Implementations.Admin
{
	public class AdminStockService : IAdminStockService
	{
		private readonly RumBlackDbContext db;

		public AdminStockService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE ENTRIES:

		public async Task< bool > CreateAsync( Create_Stock_ServiceModel model )
		{
			if ( model == null ||
			     model.DigitalCopies < 0 ||
			     model.PhysicalCopies < 0 ||
			     model.MovieId <= 0 ||
			     !this.db.Movies.Any( m => m.Id == model.MovieId ) )
			{
				return false;
			}

			var stock = new MovieStock()
			{
				DigitalCopies = model.DigitalCopies,
				PhysicalCopies = model.PhysicalCopies,
				MovieId = model.MovieId
			};

			this.db.MovieStocks.Add( stock );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES:

		public async Task< bool > EditAsync( int movieId, Edit_Stock_ServiceModel model )
		{
			if ( movieId <= 0 ||
			     model == null ||
			     model.DigitalCopies < 0 ||
			     model.PhysicalCopies < 0 )
			{
				return false;
			}

			var movieStock = this.db.MovieStocks.SingleOrDefault( s => s.MovieId == movieId );

			if ( movieStock == null )
			{
				return false;
			}

			movieStock.DigitalCopies = model.DigitalCopies;
			movieStock.PhysicalCopies = model.PhysicalCopies;

			this.db.MovieStocks.Update( movieStock );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE ENTRIES:

		public async Task< bool > DeleteAsync( int movieId )
		{
			if ( movieId <= 0 )
			{
				return false;
			}

			var movieStock = this.db.MovieStocks.SingleOrDefault( s => s.MovieId == movieId );

			if ( movieStock == null )
			{
				return false;
			}

			this.db.MovieStocks.Remove( movieStock );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}