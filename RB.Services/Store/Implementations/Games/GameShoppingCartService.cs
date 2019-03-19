using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RB.Common;
using RB.Data;
using RB.Data.DbModels.Games;
using RB.Services.Store.Interfaces.Games;
using RB.Services.Store.Models.Games;

namespace RB.Services.Store.Implementations.Games
{
	public class GameShoppingCartService : IGameShoppingCartService
	{
		private readonly RumBlackDbContext db;

		public GameShoppingCartService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE
		public async Task< bool > Add( Order_ServiceModel model )
		{
			if ( !Validator< Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetShoppingCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var gsc = new GameInShoppingCart()
			{
				GameId = model.GameId,
				CartId = cartId,
				Quantity = model.Quantity
			};

			this.db.GamesInShoppingCart.Add( gsc );

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

			var cartId = this.GetShoppingCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var cart = this.db.GamesInShoppingCart.SingleOrDefault( gisc =>
				gisc.CartId == cartId && gisc.GameId == model.GameId );

			if ( cart == null )
			{
				return false;
			}

			cart.Quantity = model.Quantity;

			this.db.GamesInShoppingCart.Update( cart );

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

			var gsc = this.db
				.ShoppingCarts
				.SingleOrDefault( sc => sc.UserId == model.UserId )
				.Games
				.SingleOrDefault( gc => gc.GameId == model.GameId );

			if ( gsc == null )
			{
				return false;
			}

			this.db.GamesInShoppingCart.Remove( gsc );
			await this.db.SaveChangesAsync();

			return true;
		}

		//HELPER METHODS
		private int GetShoppingCartId( string userId )
		{
			var cart = this.db
				.ShoppingCarts
				.SingleOrDefault( sc => sc.UserId == userId )
				.Id;

			return cart;
		}
	}
}