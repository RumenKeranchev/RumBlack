using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RB.Data.Configurations;
using RB.Data.Configurations.Game_Configurations;
using RB.Data.Configurations.Movie_Configurations;
using RB.Data.Configurations.Music_Configurations;
using RB.Data.DbModels.Games;
using RB.Data.DbModels.Movies;
using RB.Data.DbModels.Music;
using RB.Data.DbModels.Social;
using RB.Data.DbModels.Store;

namespace RB.Data
{
	public class RumBlackDbContext : IdentityDbContext< User >
	{
		public DbSet< Game > Games { get; set; }

		public DbSet< GameSystemRequirements > GameSystemRequirements { get; set; }

		public DbSet< Developer > Developers { get; set; }

		public DbSet< Album > Albums { get; set; }

		public DbSet< Band > Bands { get; set; }

		public DbSet< Song > Songs { get; set; }

		public DbSet< Concert > Concerts { get; set; }

		public DbSet< Ticket > Tickets { get; set; }

		public DbSet< GameComment > GameComments { get; set; }

		public DbSet< MovieComment > MovieComments { get; set; }

		public DbSet< AlbumComment > AlbumComments { get; set; }

		public DbSet< ConcertComment > ConcertComments { get; set; }

		public DbSet< SongComment > SongComments { get; set; }

		public DbSet< SocialComment > SocialComments { get; set; }

		public DbSet< Movie > Movies { get; set; }

		public DbSet< BoxOffice > BoxOffices { get; set; }

		public DbSet< Actor > Actors { get; set; }

		public DbSet< AlbumStock > AlbumStocks { get; set; }

		public DbSet< GameStock > GameStocks { get; set; }

		public DbSet< MovieStock > MovieStocks { get; set; }

		public DbSet< MovieActor > MovieActor { get; set; }

		public DbSet< SongStock > SongStocks { get; set; }

		public DbSet< ShoppingCart > ShoppingCarts { get; set; }

		public DbSet< GameInShoppingCart > GamesInShoppingCart { get; set; }

		public DbSet< AlbumInShoppingCart > AlbumsInShoppingCarts { get; set; }

		public DbSet< SongInShoppingCart > SongsInShoppingCart { get; set; }

		public DbSet< MovieInShoppingCart > MoviesInShoppingCart { get; set; }

		public DbSet< TicketInShoppingCart > TicketsInShoppingCart { get; set; }

		public RumBlackDbContext( DbContextOptions< RumBlackDbContext > options )
			: base( options )
		{
		}

		//TODO <IMPORTANT> If the db creates an emty migration, make sure all migrations are deleted </IMPORTANT>
		protected override void OnModelCreating( ModelBuilder builder )
		{
			base.OnModelCreating( builder );

			// GAMES
			builder.ApplyConfiguration( new GameConfiguration() );
			//------------------------------------------------------------------------------------------------------------------

			// MOVIES
			builder.ApplyConfiguration( new MovieConfiguration() );
			builder.ApplyConfiguration( new MovieActorConfiguration() );
			//------------------------------------------------------------------------------------------------------------------

			// MUSIC
			builder.ApplyConfiguration( new SongConfiguration() );
			builder.ApplyConfiguration( new AlbumConfiguration() );
			builder.ApplyConfiguration( new BandConcertConfiguration() );
			builder.ApplyConfiguration( new TicketsInShoppingCartConfiguration() );
			//------------------------------------------------------------------------------------------------------------------

			//COMMENTS 
			builder.ApplyConfiguration( new SocialCommentConfiguration() );
			builder.ApplyConfiguration( new AlbumCommentConfiguration() );
			builder.ApplyConfiguration( new ConcertCommentConfiguration() );
			builder.ApplyConfiguration( new SongCommentConfiguration() );
			builder.ApplyConfiguration( new MovieCommentsConfiguration() );
			builder.ApplyConfiguration( new GameCommentConfiguration() );
			//------------------------------------------------------------------------------------------------------------------

			// SHOPPING CART
			builder.ApplyConfiguration( new SongsInShoppingCartConfiguration() );
			builder.ApplyConfiguration( new AlbumsInShoppingCartConfiguration() );
			builder.ApplyConfiguration( new MoviesInShoppingCartConfiguration() );
			builder.ApplyConfiguration( new GamesInShoppingCartConfiguration() );
			builder.ApplyConfiguration( new UserConfiguration() );
			//------------------------------------------------------------------------------------------------------------------

			builder.Entity< Concert >().Property( c => c.TicketPrice ).HasColumnType( "decimal(5,2)" );

			/*TODO: REVISE THE DB CONFIGURATION!
			 	TODO: Add finalizing order (checkout) with the selected items from the cart and/or all items
			    TODO: Finish shopping functionallity
			 	TODO: Create facebook esq social functionality(chat (MQTT), posts, likes, dislikes...)
				TODO: Create Unit Testing Project
				TODO: Create services for every aspect of the App
				TODO: Create RestAPI functionality for admins (for now)
				TODO: Rework the shitty front-end: Each section should have different nav borders >> games-green, 
				TODO: movies-blue, music-magenta_reddish, social-yellow
				TODO: Emails! (sendgrid)
				TODO: Authorization, roles (5 roles, one for each model type, 1 for everything), claims etc..
				TODO: Privacy notice!
				TODO: Add try-catch blocks since SingleOrDefault might throw exceptions!
			*/
		}
	}
}