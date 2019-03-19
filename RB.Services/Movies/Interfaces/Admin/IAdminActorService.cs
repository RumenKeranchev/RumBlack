using System.Threading.Tasks;
using RB.Services.Movies.Models;

namespace RB.Services.Movies.Interfaces.Admin
{
	public interface IAdminActorService
	{
		//Create entries:

		Task< bool > CreateAsync( Create_Actor_ServiceModel model );

		//Edit entries:

		Task< bool > EditAsync( int id, Create_Actor_ServiceModel model );

		//Delete entries:

		Task< bool > DeleteAsync( int id );
	}
}