using System;
using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Movies;
using RB.Services.Movies.Interfaces;
using RB.Services.Movies.Interfaces.Admin;
using RB.Services.Movies.Models;

namespace RB.Services.Movies.Implementations.Admin
{
	public class AdminActorService : IAdminActorService
	{
		private readonly RumBlackDbContext db;

		public AdminActorService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//	CREATE ENTRIES:

		public async Task< bool > CreateAsync( Create_Actor_ServiceModel model )
		{
			DateTime tmp;

			if ( string.IsNullOrWhiteSpace( model.FirstName ) ||
			     string.IsNullOrWhiteSpace( model.LastName ) ||
			     string.IsNullOrWhiteSpace( model.BornInCountry ) ||
			     string.IsNullOrWhiteSpace( model.BornInCity ) ||
			     DateTime.TryParse( model.DateOfBirth.ToString(), out tmp ) )
			{
				return false;
			}

			var actor = new Actor()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				BornInCity = model.BornInCity,
				BornInCountry = model.BornInCountry,
				DateOfBirth = model.DateOfBirth
			};

			if ( this.db.Actors.Any( a => a.FirstName == actor.FirstName && a.LastName == actor.LastName ) )
			{
				return false;
			}

			this.db.Actors.Add( actor );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES:

		public async Task< bool > EditAsync( int id, Create_Actor_ServiceModel model )
		{
			if ( id <= 0 || model == null )
			{
				return false;
			}

			var actor = this.db.Actors.SingleOrDefault( a => a.Id == id );
			DateTime tmp;

			if ( actor == null )
			{
				return false;
			}

			if ( !string.IsNullOrWhiteSpace( model.FirstName ) )
			{
				actor.FirstName = model.FirstName;
			}
			else if ( !string.IsNullOrWhiteSpace( model.LastName ) )
			{
				actor.LastName = model.LastName;
			}
			else if ( !string.IsNullOrWhiteSpace( model.BornInCity ) )
			{
				actor.BornInCity = model.BornInCity;
			}
			else if ( !string.IsNullOrWhiteSpace( model.BornInCountry ) )
			{
				actor.BornInCountry = model.BornInCountry;
			}
			else if ( DateTime.TryParse( model.DateOfBirth.ToString(), out tmp ) )
			{
				actor.DateOfBirth = model.DateOfBirth;
			}

			this.db.Actors.Update( actor );
			await this.db.SaveChangesAsync();

			return true;
		}

		//	DELETE ENTRIES:

		public async Task< bool > DeleteAsync( int id )
		{
			if ( id <= 0 )
			{
				return false;
			}

			var actor = this.db.Actors.SingleOrDefault( a => a.Id == id );

			if ( actor == null )
			{
				return false;
			}

			this.db.Actors.Remove( actor );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}