using System;
using System.Linq;
using System.Threading.Tasks;
using RB.Common;
using RB.Data;
using RB.Data.DbModels.Music;
using RB.Services.Store.Interfaces.Music;
using RB.Services.Store.Models.Music;

namespace RB.Services.Store.Implementations.Music
{
	public class SongShoppingCartService : ISongShoppingCartService
	{
		private readonly RumBlackDbContext db;

		public SongShoppingCartService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE
		public async Task< bool > Add( Song_Order_ServiceModel model )
		{
			if ( !Validator< Song_Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = new SongInShoppingCart()
			{
				CartId = cartId,
				SongId = model.SongId
			};

			this.db.SongsInShoppingCart.Add( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE
		public async Task< bool > Remove( Song_Order_ServiceModel model )
		{
			if ( !Validator< Song_Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = this.db.SongsInShoppingCart.SingleOrDefault(
				sisc => sisc.CartId == cartId && sisc.SongId == model.SongId );

			if ( order == null )
			{
				return false;
			}

			this.db.SongsInShoppingCart.Remove( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//HELPER METHODS
		private int GetCartId( string id )
		{
			return this.db.ShoppingCarts.SingleOrDefault( u => u.UserId == id ).Id;
		}
	}
}