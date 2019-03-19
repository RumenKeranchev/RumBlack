using System;
using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Movies;
using RB.Services.Movies.Interfaces.Admin;
using RB.Services.Movies.Models;

namespace RB.Services.Movies.Implementations.Admin
{
	public class AdminMovieService : IAdminMovieService
	{
		private readonly RumBlackDbContext db;

		public AdminMovieService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE ENTRIES:

		public async Task< bool > CreateAsync( Create_Movie_ServiceModel model )
		{
			DateTime tmp;

			if ( string.IsNullOrWhiteSpace( model.Title ) ||
			     string.IsNullOrWhiteSpace( model.Plot ) ||
			     string.IsNullOrWhiteSpace( model.DirectorName ) ||
			     string.IsNullOrWhiteSpace( model.ProductionCompany ) ||
			     string.IsNullOrWhiteSpace( model.WriterName ) ||
			     DateTime.TryParse( model.ReleaseDate.ToString(), out tmp ) ||
			     model.Budget <= 0 ||
			     model.Genre <= 0 ||
			     model.GrossUsa <= 0 ||
			     model.Length <= 0 ||
			     model.OpeningWeekend <= 0 ||
			     model.WorldwideGross <= 0 )
			{
				return false;
			}

			var boxoffice = new BoxOffice()
			{
				Budget = model.Budget,
				GrossUsa = model.GrossUsa,
				OpeningWeekend = model.OpeningWeekend,
				WorldwideGross = model.WorldwideGross
			};

			var movie = new Movie()
			{
				BoxOffice = boxoffice,
				DirectorName = model.DirectorName,
				Genre = model.Genre,
				Length = model.Length,
				Plot = model.Plot,
				ProductionCompany = model.ProductionCompany,
				ReleaseDate = model.ReleaseDate,
				Title = model.Title,
				WriterName = model.WriterName
			};

			if ( this.db.Movies.Any( m =>
				m.Title == movie.Title &&
				m.DirectorName == movie.DirectorName &&
				m.WriterName == movie.WriterName ) )
			{
				return false;
			}

			this.db.Movies.Add( movie );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT ENTRIES:

		public async Task< bool > EditAsync( int id, Edit_Movie_ServiceModel model )
		{
			if ( id <= 0 || model == null )
			{
				return false;
			}

			var movie = this.db.Movies.SingleOrDefault( m => m.Id == id );

			if ( movie == null )
			{
				return false;
			}

			if ( !string.IsNullOrWhiteSpace( model.DirectorName ) )
			{
				movie.DirectorName = movie.DirectorName;
			}
			else if ( !string.IsNullOrWhiteSpace( model.Plot ) )
			{
				movie.Plot = model.Plot;
			}
			else if ( !string.IsNullOrWhiteSpace( model.ProductionCompany ) )
			{
				movie.ProductionCompany = model.ProductionCompany;
			}
			else if ( !string.IsNullOrWhiteSpace( model.Title ) )
			{
				movie.Title = model.Title;
			}
			else if ( !string.IsNullOrWhiteSpace( model.WriterName ) )
			{
				movie.WriterName = model.WriterName;
			}
			else if ( model.Length > 0 )
			{
				movie.Length = model.Length;
			}

			movie.Genre = model.Genre;

			this.db.Movies.Update( movie );
			await this.db.SaveChangesAsync();

			return true;
		}

		/// <summary>
		/// Probably wont work!!!!
		/// </summary>
		/// <param name="movieId"></param>
		/// <param name="actorId"></param>
		/// <returns></returns>
		public async Task< bool > AddActorToMovieAsync( int movieId, int actorId )
		{
			if ( movieId <= 0 || actorId <= 0 )
			{
				return false;
			}

			if ( !this.db.Actors.Any( a => a.Id == actorId ) ||
			     !this.db.Movies.Any( m => m.Id == movieId ) )
			{
				return false;
			}

			var movieActor = new MovieActor()
			{
				ActorId = actorId,
				MovieId = movieId
			};

			this.db.MovieActor.Add( movieActor );
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

			var movie = this.db.Movies.SingleOrDefault( m => m.Id == id );

			if ( movie == null )
			{
				return false;
			}

			this.db.Movies.Remove( movie );
			await this.db.SaveChangesAsync();

			return true;
		}

		public async Task< bool > RemoveActorFromMovieAsync( int movieId, int actorId )
		{
			if ( movieId <= 0 || actorId <= 0 )
			{
				return false;
			}

			if ( !this.db.Actors.Any( a => a.Id == actorId ) ||
			     !this.db.Movies.Any( m => m.Id == movieId ) )
			{
				return false;
			}

			var movieActor = this.db.MovieActor.SingleOrDefault( ma => ma.ActorId == actorId && ma.MovieId == movieId );

			if ( movieActor == null )
			{
				return false;
			}

			this.db.MovieActor.Remove( movieActor );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}