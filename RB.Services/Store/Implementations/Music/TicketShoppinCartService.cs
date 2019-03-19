using System.Linq;
using System.Threading.Tasks;
using RB.Common;
using RB.Data;
using RB.Data.DbModels.Music;
using RB.Services.Store.Interfaces.Music;
using RB.Services.Store.Models.Music;

namespace RB.Services.Store.Implementations.Music
{
	public class TicketShoppinCartService : ITicketShoppinCartService
	{
		private readonly RumBlackDbContext db;

		public TicketShoppinCartService( RumBlackDbContext db )
		{
			this.db = db;
		}

		//CREATE
		public async Task< bool > Add( Ticket_Order_ServiceModel model )
		{
			if ( !Validator< Ticket_Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = new TicketInShoppingCart()
			{
				Quantity = model.Quantity,
				CartId = cartId,
				TicketId = model.TicketId
			};

			this.db.TicketsInShoppingCart.Add( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//EDIT
		public async Task< bool > Edit( Ticket_Order_ServiceModel model )
		{
			if ( !Validator< Ticket_Order_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = this.db.TicketsInShoppingCart.SingleOrDefault( tisc =>
				tisc.CartId == cartId && tisc.TicketId == model.TicketId );

			if ( order == null )
			{
				return false;
			}

			order.Quantity = model.Quantity;

			this.db.TicketsInShoppingCart.Update( order );
			await this.db.SaveChangesAsync();

			return true;
		}

		//DELETE
		public async Task< bool > Remove( Ticket_CancelOrder_ServiceModel model )
		{
			if ( !Validator< Ticket_CancelOrder_ServiceModel >.Validate( model ) )
			{
				return false;
			}

			var cartId = this.GetCartId( model.UserId );

			if ( cartId <= 0 )
			{
				return false;
			}

			var order = this.db.TicketsInShoppingCart.SingleOrDefault( tisc =>
				tisc.CartId == cartId && tisc.TicketId == model.TicketId );

			if ( order == null )
			{
				return false;
			}

			this.db.TicketsInShoppingCart.Remove( order );
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