using System;
using RB.Common.DbCategoriesFlags;

namespace RB.Services.Music.Models
{
	public class Create_Concert_ServiceModel
	{
		public string Name { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Location { get; set; }

		public MusicGenres Genre { get; set; }

		public string Country { get; set; }

		public string City { get; set; }

		public int MaxNumberOfTickets { get; set; }

		public string PosterUrl { get; set; }

		public byte[] Poster { get; set; }

		public decimal TicketPrice { get; set; }

		public int TicketsSold { get; set; }

		public string StreamUrl { get; set; }

		public byte[] Stream { get; set; }
	}
}