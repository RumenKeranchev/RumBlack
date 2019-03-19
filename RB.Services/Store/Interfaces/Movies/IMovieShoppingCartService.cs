using System.Threading.Tasks;
using RB.Services.Store.Models.Movies;

namespace RB.Services.Store.Interfaces.Movies
{
	public interface IMovieShoppingCartService
	{
		// Create entities:
		Task< bool > Add( Order_ServiceModel model );

		// Edit entities:
		Task< bool > ChangeQuantity( Order_ServiceModel model );

		// Delete entities:
		Task< bool > Remove( CancelOrder_ServiceModel model );
	}
}