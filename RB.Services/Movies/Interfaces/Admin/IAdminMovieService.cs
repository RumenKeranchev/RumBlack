using System.Threading.Tasks;
using RB.Services.Movies.Models;

namespace RB.Services.Movies.Interfaces.Admin
{
	public interface IAdminMovieService
	{
		//Create entries:

		Task< bool > CreateAsync( Create_Movie_ServiceModel model );

		//Edit entries:

		Task< bool > EditAsync( int id, Edit_Movie_ServiceModel model );

		Task< bool > AddActorToMovieAsync( int movieId, int actorId );

		//Delete entries:

		Task< bool > DeleteAsync( int id );

		Task< bool > RemoveActorFromMovieAsync( int movieId, int actorId );
	}
}