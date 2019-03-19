using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Music;
using RB.Services.Music.Interfaces.Admin;
using RB.Services.Music.Models;

namespace RB.Services.Music.Implementations.Admin
{
	public class AdminAlbumService : IAdminAlbumService
	{
		private readonly RumBlackDbContext db;

		public AdminAlbumService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//	CREATE ENTRIES:

		public async Task< bool > CreateAsync( Create_Album_ServiceModel model )
		{
			if ( model == null ||
			     model.BandId <= 0 ||
			     model.Genre <= 0 ||
			     model.Image == null ||
			     string.IsNullOrWhiteSpace( model.Name ) )
			{
				return false;
			}

			var album = new Album()
			{
				BandId = model.BandId,
				Genre = model.Genre,
				Image = HelperMethods.FileToBytes( model.Image ),
				Name = model.Name
			};

			if ( this.db.Albums.Any( a => a.Name == album.Name && a.BandId == album.BandId && a.Genre == album.Genre ) )
			{
				return false;
			}

			this.db.Albums.Add( album );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES:

		public async Task< bool > EditAsync( int id, Create_Album_ServiceModel model )
		{
			if ( model == null ||
			     id <= 0 )
			{
				return false;
			}

			var album = this.db.Albums.SingleOrDefault( a => a.Id == id );
			var image = HelperMethods.FileToBytes( model.Image );

			if ( album == null )
			{
				return false;
			}

			if ( model.BandId > 0 && model.BandId != album.BandId )
			{
				album.BandId = model.BandId;
			}
			else if ( model.Genre > 0 && model.Genre != album.Genre )
			{
				album.Genre = model.Genre;
			}
			else if ( model.Image != null && image != album.Image )
			{
				album.Image = image;
			}
			else if ( !string.IsNullOrWhiteSpace( model.Name ) && !string.Equals( model.Name, album.Name ) )
			{
				album.Name = model.Name;
			}

			this.db.Albums.Update( album );
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

			var album = this.db.Albums.SingleOrDefault( a => a.Id == id );

			if ( album == null )
			{
				return false;
			}

			this.db.Albums.Remove( album );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}