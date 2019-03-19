using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Games;
using RB.Services.Games.Interfaces;
using RB.Services.Games.Interfaces.Admin;
using RB.Services.Games.Models;

namespace RB.Services.Games.Implementations.Admin
{
	public class AdminDeveloperService : IAdminDeveloperService
	{
		private readonly RumBlackDbContext db;

		public AdminDeveloperService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//	CREATE ENTRIES:

		public async Task<bool> CreateAsync( Create_Developer_ServiceModel model )
		{
			if ( string.IsNullOrWhiteSpace( model.Name ) ||
			     string.IsNullOrWhiteSpace( model.OriginCity ) ||
			     string.IsNullOrWhiteSpace( model.OriginCountry ) )
			{
				return false;
			}

			var developer = new Developer()
			{
				Name = model.Name,
				OriginCity = model.OriginCity,
				OriginCountry = model.OriginCountry
			};

			if ( this.db.Developers.Any( d => d.Name == developer.Name && d.OriginCountry == developer.OriginCountry ) )
			{
				return false;
			}

			this.db.Developers.Add( developer );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES:

		public async Task<bool> EditAsync( int id, Create_Developer_ServiceModel model )
		{
			if ( id <= 0 || model == null )
			{
				return false;
			}

			var developer = this.db.Developers.SingleOrDefault( d => d.Id == id );

			if ( developer == null )
			{
				return false;
			}

			if ( !string.IsNullOrWhiteSpace( model.Name ) )
			{
				developer.Name = model.Name;
			}
			else if ( !string.IsNullOrWhiteSpace( model.OriginCity ) )
			{
				developer.OriginCity = model.OriginCity;
			}
			else if ( !string.IsNullOrWhiteSpace( model.OriginCountry ) )
			{
				developer.OriginCountry = model.OriginCountry;
			}

			this.db.Developers.Update( developer );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE ENTRIES:

		/// <summary>
		/// Delete developer only if all their games are removed first
		/// </summary>
		/// <param name="developerId"></param>
		/// <returns>Returns true if successfully removed, false if any games from that developer
		/// exist or the ID is invalid</returns>
		public async Task<bool> DeleteAsync( int developerId )
		{
			if ( developerId <= 0 )
			{
				return false;
			}

			var developer = this.db.Developers.SingleOrDefault( d => d.Id == developerId );

			if ( developer == null ||
			     this.db.Games.Any( g => g.DeveloperId == developerId ) )
			{
				return false;
			}

			this.db.Developers.Remove( developer );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}