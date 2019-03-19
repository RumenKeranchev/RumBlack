using System.Threading.Tasks;
using RB.Services.Games.Models;

namespace RB.Services.Games.Interfaces.Admin
{
	public interface IAdminDeveloperService
	{
		// Create entries:

		Task< bool > CreateAsync( Create_Developer_ServiceModel model );

		// Edit entires:

		Task< bool > EditAsync( int id, Create_Developer_ServiceModel model );

		// Delete entries:

		Task< bool > DeleteAsync( int developerId );
	}
}