using System.Collections.Generic;
using System.Threading.Tasks;
using RB.Services.Games.Models;

namespace RB.Services.Games.Interfaces
{
	public interface IGameService
	{
		//Read enties

		Task<Details_ServiceModel> DetailsAsync( int id );

		Task< IEnumerable< List_ServiceModel > > ListAsync();
	}
}