using System.Threading.Tasks;
using RB.Services.Store.Models.Music;

namespace RB.Services.Store.Interfaces.Music
{
	public interface ITicketShoppinCartService
	{
		// Create entities:
		Task< bool > Add( Ticket_Order_ServiceModel model );

		// Edit entities:
		Task< bool > Edit( Ticket_Order_ServiceModel model );

		// Delete entities: 
		Task< bool > Remove( Ticket_CancelOrder_ServiceModel model );
	}
}