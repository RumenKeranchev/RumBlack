using System.Threading.Tasks;
using RB.Services.Store.Models.Music;

namespace RB.Services.Store.Interfaces.Music
{
	public interface ISongShoppingCartService
	{
		// Create entities:
		Task< bool > Add( Song_Order_ServiceModel model );

		// Delete entities:
		Task< bool > Remove( Song_Order_ServiceModel model );
	}
}