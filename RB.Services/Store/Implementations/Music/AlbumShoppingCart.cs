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
	public class AlbumShoppingCart : IAlbumShoppingCart
	{
		private readonly RumBlackDbContext db;

		public AlbumShoppingCart( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE
		public async Task< bool > Add( Album_Order_ServiceModel model )
		{
			if ( !Validator< Album_Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = new AlbumInShoppingCart()
			{
				Quantity = model.Quantity,
				AblumId = model.AlbumId,
				CartId = cartId
			};

			this.db.AlbumsInShoppingCarts.Add( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT
		public async Task< bool > ChangeQuantity( Album_Order_ServiceModel model )
		{
			if ( !Validator< Album_Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = this.db.AlbumsInShoppingCarts.SingleOrDefault( aisc =>
				aisc.CartId == cartId && aisc.AblumId == model.AlbumId );

			if ( order == null )
			{
				return false;
			}

			order.Quantity = model.Quantity;

			this.db.AlbumsInShoppingCarts.Update( order );

			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE
		public async Task< bool > Remove( Album_CancelOrder_ServiceModel model )
		{
			if ( !Validator< Album_CancelOrder_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = this.db.AlbumsInShoppingCarts
				.SingleOrDefault( aisc => aisc.AblumId == model.AlbumId && aisc.CartId == cartId );

			if ( order == null )
			{
				return false;
			}

			this.db.AlbumsInShoppingCarts.Remove( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//HELPER METHODS

		private int GetCartId( string id )
		{
			return this.db.Users.SingleOrDefault( u => u.Id == id ).Cart.Id;
		}
	}
}