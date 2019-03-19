using System;

namespace RB.Services.Movies.Models
{
	public class Create_Actor_ServiceModel
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string BornInCity { get; set; }

		public string BornInCountry { get; set; }
	}
}