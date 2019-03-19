using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Common.Constants;

namespace RB.Data.DbModels.Movies
{
	public class Actor
	{
		public int Id { get; set; }

		[ Required ]
		[ MinLength( MovieConstants.MinActorFirstName ) ]
		[ MaxLength( MovieConstants.MaxActorFirstName ) ]
		public string FirstName { get; set; }

		[ Required ]
		[ MinLength( MovieConstants.MinActorLastName ) ]
		[ MaxLength( MovieConstants.MaxActorLastName ) ]
		public string LastName { get; set; }

		[ Required ]
		public DateTime DateOfBirth { get; set; }

		[ Required ]
		[ MinLength( MovieConstants.MinActorBornInCity ) ]
		[ MaxLength( MovieConstants.MaxActorBornInCity ) ]
		public string BornInCity { get; set; }

		[ Required ]
		[ MinLength( MovieConstants.MinActorBornInCountry ) ]
		[ MaxLength( MovieConstants.MaxActoBornInCountry ) ]
		public string BornInCountry { get; set; }

		public IEnumerable< MovieActor > Movies { get; set; } = new List< MovieActor >();

		public byte[] ProfilePicture { get; set; }
	}
}