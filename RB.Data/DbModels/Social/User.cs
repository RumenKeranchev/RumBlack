using Microsoft.AspNetCore.Identity;
using RB.Data.DbModels.Music;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Data.DbModels.Games;
using RB.Data.DbModels.Movies;
using RB.Data.DbModels.Store;

namespace RB.Data.DbModels.Social
{
	public class User : IdentityUser
	{
		[ Required ]
		[ PersonalData ]
		public string FirstName { get; set; }

		[ Required ]
		[ PersonalData ]
		public string LastName { get; set; }

		[ PersonalData ]
		public IEnumerable< GameComment > GameComments { get; set; } = new List< GameComment >();

		[ PersonalData ]
		public IEnumerable< MovieComment > MovieComments { get; set; } = new List< MovieComment >();

		[ PersonalData ]
		public IEnumerable< AlbumComment > AlbumComments { get; set; } = new List< AlbumComment >();

		public IEnumerable< ConcertComment > ConcertComments { get; set; } = new List< ConcertComment >();

		public IEnumerable< SongComment > SongComments { get; set; } = new List< SongComment >();

		[ PersonalData ]
		public IEnumerable< SocialComment > SocialComments { get; set; } = new List< SocialComment >();

		public byte[] ProfilePicture { get; set; }

		public ShoppingCart Cart { get; set; }
	}
}