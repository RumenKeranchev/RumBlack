using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RB.Data;
using RB.Data.DbModels.Music;
using RB.Services.Music.Interfaces.Admin;
using RB.Services.Music.Models;

namespace RB.Services.Music.Implementations.Admin
{
	public class AdminSongService : IAdminSongService
	{
		private readonly RumBlackDbContext db;

		public AdminSongService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE:
		public async Task< bool > CreateAsync( Create_Song_ServiceModel model )
		{
			if ( model.AlbumId <= 0 ||
			     model.Data.Length <= 0 ||
			     model.Genres <= 0 ||
			     string.IsNullOrWhiteSpace( model.Name ) )
			{
				return false;
			}

			var song = new Song()
			{
				AlbumId = model.AlbumId,
				Data = model.Data,
				Genre = model.Genres,
				Name = model.Name
			};

			if ( await this.db.Songs.AnyAsync( s => s.Data == song.Data && s.Name == song.Name ) )
			{
				return false;
			}

			this.db.Songs.Add( song );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT:
		public async Task< bool > EditAsync( Edit_Song_ServiceModel model )
		{
			if ( model.AlbumId <= 0 ||
			     model.Genres <= 0 ||
			     model.Id <= 0 ||
			     string.IsNullOrWhiteSpace( model.Name ) )
			{
				return false;
			}

			//TODO: in case something fucks up with editing the song, remove the async!
			var song = await this.db.Songs.SingleOrDefaultAsync( s => s.Id == model.Id );

			if ( song == null )
			{
				return false;
			}

			song.Name = model.Name;
			song.AlbumId = model.AlbumId;
			song.Genre = model.Genres;

			this.db.Songs.Update( song );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE:
		public async Task< bool > DeleteAsync( int id )
		{
			if ( id <= 0 )
			{
				return false;
			}

			var song = this.db.Songs.SingleOrDefault( s => s.Id == id );

			if ( song == null )
			{
				return false;
			}

			this.db.Songs.Remove( song );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}