using System.Threading.Tasks;
using RB.Services.Games.Models;

namespace RB.Services.Games.Interfaces.Admin
{
	public interface IAdminGameService
	{
		// Create entries:

		Task< bool > CreateAsync( Create_Game_ServiceModel model );
		
		// Edit entries:

		Task< bool > EditAsync( int id, Edit_Game_ServiceModel model );
		
		// Delete entries:

		Task< bool > DeleteAsync( int gameId );
	}
}