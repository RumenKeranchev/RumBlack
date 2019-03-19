using System.Threading.Tasks;
using RB.Services.Music.Models;

namespace RB.Services.Music.Interfaces.Admin
{
	public interface IAdminSongService
	{
		// Create entities:
		Task< bool > CreateAsync( Create_Song_ServiceModel model );

		// Edit entities:
		Task< bool > EditAsync( Edit_Song_ServiceModel model );

		//Delete entities:
		Task< bool > DeleteAsync( int id );
	}
}