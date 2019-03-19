using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Music;
using RB.Services.Music.Interfaces.Admin;
using RB.Services.Music.Models;

namespace RB.Services.Music.Implementations.Admin
{
	public class AdminBandService : IAdminBandService
	{
		private readonly RumBlackDbContext db;

		public AdminBandService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE ENTRIES:

		public async Task< bool > CreateAsync( Create_Band_ServiceModel model )
		{
			if ( model == null ||
			     string.IsNullOrWhiteSpace( model.Name ) ||
			     model.Genre <= 0 )
			{
				return true;
			}

			var band = new Band()
			{
				Name = model.Name,
				Genre = model.Genre
			};

			this.db.Bands.Add( band );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES:

		public async Task< bool > EditAsync( int id, Create_Band_ServiceModel model )
		{
			if ( id <= 0 ||
			     model == null ||
			     string.IsNullOrWhiteSpace( model.Name ) ||
			     model.Genre <= 0 )
			{
				return false;
			}

			var band = this.db.Bands.SingleOrDefault( b => b.Id == id );

			if ( band == null )
			{
				return false;
			}

			band.Name = model.Name;
			band.Genre = model.Genre;

			this.db.Bands.Update( band );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE ENTRIES:

		public async Task< bool > DeleteAsync( int id )
		{
			if ( id <= 0 )
			{
				return false;
			}

			var band = this.db.Bands.SingleOrDefault( b => b.Id == id );

			if ( band == null )
			{
				return false;
			}

			this.db.Bands.Remove( band );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}