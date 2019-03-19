using System.Threading.Tasks;
using RB.Services.Store.Models.Games;

namespace RB.Services.Store.Interfaces.Games
{
	public interface IGameShoppingCartService
	{
		//Create entities:
		Task< bool > Add( Order_ServiceModel model );

		//Edit entities:
		Task< bool > ChangeQuantity( Order_ServiceModel model );

		//Delete entities:
		Task< bool > Remove( CancelOrder_ServiceModel model );
	}
}