using System.Threading.Tasks;
using RB.Services.Music.Models;

namespace RB.Services.Music.Interfaces.Admin
{
	public interface IAdminAlbumService
	{
		//Create entities:

		Task< bool > CreateAsync( Create_Album_ServiceModel model );

		//Edit entries:

		Task< bool > EditAsync( int id, Create_Album_ServiceModel model );

		//Delete entries:

		Task< bool > DeleteAsync( int id );
	}
}