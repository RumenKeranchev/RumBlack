using System.Threading.Tasks;
using RB.Services.Games.Models;

namespace RB.Services.Games.Interfaces.Admin
{
	public interface IAdminSystemRequirementsService
	{
		// Create entries:

		/// <summary>
		/// This is to be used when a game is crated directly from the DB and
		/// has no system requirements added (if needed)
		/// </summary>
		/// <param name="model"></param>
		/// <returns>true if successfully added to database, false if a check fails</returns>
		Task< bool > CreateSystemRequirementsAsync( Create_SystemRequirements_ServiceModel model );

		// Edit entries:

		Task< bool > EditSystemRequirementsAsync( int gameId, Edit_SystemRequirements_ServiceModel model );

		// Delete entries:
		
		Task<bool> DeleteSystemRequirementsAsync( int gameId );
	}
}