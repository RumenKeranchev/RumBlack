using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RB.Common;
using RB.Data;
using RB.Data.DbModels.Movies;
using RB.Services.Store.Interfaces.Movies;
using RB.Services.Store.Models.Movies;

namespace RB.Services.Store.Implementations.Movies
{
	public class MovieShoppingCartService : IMovieShoppingCartService
	{
		private readonly RumBlackDbContext db;

		public MovieShoppingCartService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE
		public async Task< bool > Add( Order_ServiceModel model )
		{
			if ( Validator< Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = new MovieInShoppingCart()
			{
				MovieId = model.MovieId,
				CartId = cartId,
				Quantity = model.Quantity
			};

			this.db.MoviesInShoppingCart.Add( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT
		public async Task< bool > ChangeQuantity( Order_ServiceModel model )
		{
			if ( !Validator< Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = this.db.MoviesInShoppingCart
				.SingleOrDefault( misc =>
					misc.CartId == cartId && misc.MovieId == model.MovieId );

			order.Quantity = model.Quantity;

			this.db.MoviesInShoppingCart.Update( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE
		public async Task< bool > Remove( CancelOrder_ServiceModel model )
		{
			if ( !Validator< CancelOrder_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = this.db.MoviesInShoppingCart.SingleOrDefault( misc =>
				misc.CartId == cartId && misc.MovieId == model.MovieId );

			if ( order == null )
			{
				return false;
			}

			this.db.MoviesInShoppingCart.Remove( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//HELPER METHODS
		private int GetCartId( string id )
		{
			return this.db.ShoppingCarts.SingleOrDefault( sc => sc.UserId == id ).Id;
		}
	}
}