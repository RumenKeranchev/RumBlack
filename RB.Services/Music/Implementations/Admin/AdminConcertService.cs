using System;
using System.Linq;
using System.Threading.Tasks;
using RB.Data;
using RB.Data.DbModels.Music;
using RB.Services.Music.Interfaces.Admin;
using RB.Services.Music.Models;

namespace RB.Services.Music.Implementations.Admin
{
	public class AdminConcertService : IAdminConcertService
	{
		private readonly RumBlackDbContext db;

		public AdminConcertService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE
		public async Task< bool > CreateAsync( Create_Concert_ServiceModel model )
		{
			DateTime tmp;

			if ( string.IsNullOrWhiteSpace( model.City ) ||
			     string.IsNullOrWhiteSpace( model.Country ) ||
			     string.IsNullOrWhiteSpace( model.Location ) ||
			     string.IsNullOrWhiteSpace( model.Name ) ||
			     string.IsNullOrWhiteSpace( model.StreamUrl ) ||
			     string.IsNullOrWhiteSpace( model.PosterUrl ) ||
			     DateTime.TryParse( model.StartDate.ToString(), out tmp ) ||
			     DateTime.TryParse( model.EndDate.ToString(), out tmp ) ||
			     model.Genre <= 0 ||
			     model.MaxNumberOfTickets <= 0 ||
			     model.Poster.Length <= 0 ||
			     model.TicketPrice <= 0 ||
			     model.TicketsSold < 0 ||
			     model.StreamUrl.Length <= 0
			)
			{
				return false;
			}

			var concert = new Concert()
			{
				City = model.City,
				Country = model.Country,
				EndDate = model.EndDate,
				Genre = model.Genre,
				Location = model.Location,
				MaxNumberOfTickets = model.MaxNumberOfTickets,
				Name = model.Name,
				Poster = model.Poster,
				PosterUrl = model.PosterUrl,
				StartDate = model.StartDate,
				Stream = model.Stream,
				StreamUrl = model.StreamUrl,
				TicketPrice = model.TicketPrice,
				TicketsSold = model.TicketsSold
			};

			if ( this.db.Concerts.Contains( concert ) )
			{
				return false;
			}

			this.db.Concerts.Add( concert );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT
		public async Task< bool > EditAsync( Edit_Concert_ServiceModel model )
		{
			DateTime tmp;

			if ( string.IsNullOrWhiteSpace( model.City ) ||
			     string.IsNullOrWhiteSpace( model.Country ) ||
			     string.IsNullOrWhiteSpace( model.Location ) ||
			     string.IsNullOrWhiteSpace( model.Name ) ||
			     string.IsNullOrWhiteSpace( model.PosterUrl ) ||
			     string.IsNullOrWhiteSpace( model.StreamUrl ) ||
			     DateTime.TryParse( model.StartDate.ToString(), out tmp ) ||
			     DateTime.TryParse( model.EndDate.ToString(), out tmp ) ||
			     model.Genre <= 0 ||
			     model.Id <= 0 )
			{
				return false;
			}

			var concert = this.db.Concerts.SingleOrDefault( c => c.Id == model.Id );

			if ( concert == null )
			{
				return false;
			}

			concert.City = model.City;
			concert.Country = model.Country;
			concert.EndDate = model.EndDate;
			concert.StartDate = model.StartDate;
			concert.StreamUrl = model.StreamUrl;
			concert.PosterUrl = model.PosterUrl;
			concert.Genre = model.Genre;
			concert.Location = model.Location;
			concert.Name = model.Name;

			this.db.Concerts.Update( concert );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE
		public async Task< bool > DeleteAsync( int id )
		{
			if ( id <= 0 )
			{
				return false;
			}

			var concert = this.db.Concerts.SingleOrDefault( c => c.Id == id );

			if ( concert == null )
			{
				return false;
			}

			this.db.Concerts.Remove( concert );
			await this.db.SaveChangesAsync();

			return true;
		}
	}
}