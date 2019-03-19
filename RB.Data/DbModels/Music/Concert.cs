using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Common.Constants;
using RB.Common.DbCategoriesFlags;
using RB.Data.DbModels.Social;

namespace RB.Data.DbModels.Music
{
	public class Concert
	{
		public int Id { get; set; }

		[ Required ]
		[ MinLength( MusicConstants.ConcertNameMinLength ) ]
		[ MaxLength( MusicConstants.ConcertNameMaxLength ) ]
		public string Name { get; set; }

		[ Required ]
		public DateTime StartDate { get; set; }

		[ Required ]
		public DateTime EndDate { get; set; }

		[ Required ]
		[ MinLength( MusicConstants.ConcertLocationMinLength ) ]
		[ MaxLength( MusicConstants.ConcertLocationMaxLength ) ]
		public string Location { get; set; }

		[ Required ]
		public MusicGenres Genre { get; set; }

		[ Required ]
		[ MinLength( MusicConstants.ConcertCountryMinLength ) ]
		[ MaxLength( MusicConstants.ConcertCountryMaxLength ) ]
		public string Country { get; set; }

		[ Required ]
		[ MinLength( MusicConstants.ConcertCityMinLength ) ]
		[ MaxLength( MusicConstants.ConcertCityMaxLength ) ]
		public string City { get; set; }

		[ Required ]
		[ Range( 0, int.MaxValue ) ]
		public int MaxNumberOfTickets { get; set; }

		// Use when image is not in DB
		public string PosterUrl { get; set; }

		public byte[] Poster { get; set; }

		[ Required ]
		public decimal TicketPrice { get; set; }

		public int TicketsSold { get; set; }

		// Use when stream is not in DB
		public string StreamUrl { get; set; }

		public byte[] Stream { get; set; }

		public List< Ticket > Tickets { get; set; } = new List< Ticket >();

		public List< BandConcert > Bands { get; set; } = new List< BandConcert >();

		public IEnumerable< ConcertComment > Comments { get; set; } = new List< ConcertComment >();
	}
}