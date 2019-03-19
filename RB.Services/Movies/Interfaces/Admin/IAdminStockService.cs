using System.Threading.Tasks;
using RB.Services.Movies.Models;

namespace RB.Services.Movies.Interfaces.Admin
{
	public interface IAdminStockService
	{
		//Create entries:

		Task< bool > CreateAsync( Create_Stock_ServiceModel model );

		//Edit entries:

		Task< bool > EditAsync( int movieId, Edit_Stock_ServiceModel model );

		//Delete entries:

		Task< bool > DeleteAsync( int movieId );
	}
}