using System.Threading.Tasks;
using RB.Services.Music.Models;

namespace RB.Services.Music.Interfaces.Admin
{
	public interface IAdminConcertService
	{
		// Create entities:
		Task< bool > CreateAsync( Create_Concert_ServiceModel model );

		// Edit entities:
		Task< bool > EditAsync( Edit_Concert_ServiceModel model );

		// Delete entities:
		Task< bool > DeleteAsync( int id );
	}
}