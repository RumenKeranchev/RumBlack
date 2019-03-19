using RB.Data.DbModels.Movies;

namespace RB.Services.Store.Models.Movies
{
	public class Order_ServiceModel
	{
		public int MovieId { get; set; }

		public int Quantity { get; set; }

		public string UserId { get; set; }
	}
}