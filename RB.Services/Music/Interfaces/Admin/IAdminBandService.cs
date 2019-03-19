using System.Threading.Tasks;
using RB.Services.Music.Models;

namespace RB.Services.Music.Interfaces.Admin
{
	public interface IAdminBandService
	{
		//Create entities:

		Task< bool > CreateAsync( Create_Band_ServiceModel model );

		//Edit Entities:

		Task< bool > EditAsync( int id, Create_Band_ServiceModel model );

		//Delete Entries:

		Task< bool > DeleteAsync( int id );
	}
}