using System.Threading.Tasks;
using RB.Services.Store.Models.Music;

namespace RB.Services.Store.Interfaces.Music
{
	public interface IAlbumShoppingCart
	{
		// Create entities:
		Task< bool > Add( Album_Order_ServiceModel model );

		// Edit entities
		Task< bool > ChangeQuantity( Album_Order_ServiceModel model );

		// Delete entities
		Task< bool > Remove( Album_CancelOrder_ServiceModel model );
	}
}