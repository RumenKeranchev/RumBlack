using System.Threading.Tasks;
using RB.Services.Games.Models;

namespace RB.Services.Games.Interfaces.Admin
{
	public interface IAdminStockService
	{
		// Create Entries:

		Task< bool > CreateAsync( Create_Stock_ServiceModel model );

		// Edit Entries:

		Task< bool > EditAsync( int gameId, Edit_Stock_ServiceModel model );

		// Delete Entries:

		Task< bool > DeleteAsync( int gameId );
	}
}